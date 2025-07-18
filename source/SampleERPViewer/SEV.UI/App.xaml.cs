using SEV.ViewModels;
using SEV.UI.Windows;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using SEV.Data.Repositories;
using System;
using SEV.Data.Contexts;
using CustomT.UI;
using Microsoft.EntityFrameworkCore;

namespace SEV.UI
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {

    // Standard SQL-Server Windows Authentication connection string.  This one uses the
    // current user's credentials to connect to the database.
    private static readonly string connectStandard = "<you know what goes here, and it's normally encrypted>";

    private WndMain wndMain;
    private ViewModelMain vmm;

    public App()
    {
      Current.Startup += Current_Startup;
    }

    private void Current_Startup(object sender, StartupEventArgs e)
    {
      Rect positionAndSize = UI.Properties.Settings.Default.StartWindowPosition;
      WindowState state = UI.Properties.Settings.Default.StartWindowState;
      Theme.ThemeType = UI.Properties.Settings.Default.SavedThemeType;

      var serviceCollection = new ServiceCollection();
      ConfigureServices(serviceCollection);

      var serviceProvider = serviceCollection.BuildServiceProvider();

      try
      {
        var tempWindow = serviceProvider.GetRequiredService<WndMain>();
        wndMain = tempWindow;
        vmm = new(new RepositoryInventory(new ContextInventory(connectStandard)));

        wndMain.DataContext = vmm;
        wndMain.Closing += WndMain_Closing;
        if (positionAndSize.IsEmpty
            || (SystemParameters.VirtualScreenWidth < positionAndSize.Left)
            || (SystemParameters.VirtualScreenHeight < positionAndSize.Top))
        {
          positionAndSize = new Rect(50, 50, 450, 600);
        }

        wndMain.Left = positionAndSize.Left;
        wndMain.Top = positionAndSize.Top;
        wndMain.Width = positionAndSize.Width;
        wndMain.Height = positionAndSize.Height;
        wndMain.WindowState = state;
        Theme.LoadThemeType(Theme.ThemeType);

        wndMain.Show();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Could not start application properly.\n{ex.Message}");
      }
    }

    private void WndMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      UI.Properties.Settings.Default.StartWindowPosition
        = new Rect(wndMain.Left, wndMain.Top, wndMain.Width, wndMain.Height);
      UI.Properties.Settings.Default.StartWindowState = wndMain.WindowState;
      UI.Properties.Settings.Default.SavedThemeType = Theme.ThemeType;
      UI.Properties.Settings.Default.Save();
      Current.Shutdown();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
      services.AddScoped<IRepositoryInventory, RepositoryInventory>();
      services.AddDbContext<ContextInventory>(options =>
          options.UseSqlServer(connectStandard));
      services.AddSingleton<WndMain>();
    }

  }
}
