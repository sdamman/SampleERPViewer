using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomT.UI.UserControls
{
  /// <summary>
  /// Interaction logic for MinMaxCloseEnglish.xaml
  /// </summary>
  public partial class MinMaxCloseEnglish : UserControl
  {
    private WindowState state;
    private Window window;

    public MinMaxCloseEnglish()
    {
      InitializeComponent();

    }

    private void Minimize(object sender, RoutedEventArgs e)
    {
      window.WindowState = WindowState.Minimized;
    }

    private void MaxOrRestore(object sender, RoutedEventArgs e)
    {
      state = window.WindowState;
      if (state == WindowState.Maximized)
        window.WindowState = WindowState.Normal;
      else
        window.WindowState = WindowState.Maximized;

      state = window.WindowState;
      DisplayMaxOrRestore();
    }

    private void DisplayMaxOrRestore()
    {
      if (state == WindowState.Maximized)
      {
        button_Max.Visibility = Visibility.Collapsed;
        button_Restore.Visibility = Visibility.Visible;
      }
      else
      {
        button_Max.Visibility = Visibility.Visible;
        button_Restore.Visibility = Visibility.Collapsed;
      }
    }

    private void CloseWindow(object sender, RoutedEventArgs e)
    {
      SystemCommands.CloseWindow(Window.GetWindow((Button)sender));
    }

    private void OnSystemCommandCloseWindow(object sender, ExecutedRoutedEventArgs e)
    {
      SystemCommands.CloseWindow((Window)e.Parameter);
    }



    private void OnUserControlLoaded(object sender, RoutedEventArgs e)
    {
      if (Window.GetWindow(this) != null)
      {
        window = Window.GetWindow(this);
        state = window.WindowState;
        DisplayMaxOrRestore();
        SetThemeButtons();
      }
    }

    private void OnThemeSwitch(object sender, RoutedEventArgs e)
    {
      Theme.ThemeType = Theme.ThemeType == ThemeType.Light ? ThemeType.Dark : ThemeType.Light;
      SetThemeButtons();
    }

    private void SetThemeButtons()
    {
      if (Theme.ThemeType == ThemeType.Light)
      {
        button_Sun.Visibility = Visibility.Collapsed;
        button_Moon.Visibility = Visibility.Visible;
      }
      else
      {
        button_Sun.Visibility = Visibility.Visible;
        button_Moon.Visibility = Visibility.Collapsed;
      }
      Theme.LoadThemeType(Theme.ThemeType);
    }
  }
}
