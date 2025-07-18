using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;

namespace SEV.UI.Windows
{
  /// <summary>
  /// Interaction logic for WndMessage.xaml
  /// </summary>
  public partial class WndMessage : Window
  {


    private WndMessage()
    {
      InitializeComponent();
    }

    private static WndMessage wndMessage;
    private static MessageBoxResult result = MessageBoxResult.No;

    public static new MessageBoxResult Show()
    {
      return Show(null, null, MessageButton.OkOnly, MessageType.None);
    }

    public static MessageBoxResult Show(string message)
    {
      return Show(message, null, MessageButton.OkOnly, MessageType.None);
    }

    public static MessageBoxResult Show(string message, MessageButton buttons)
    {
      return Show(message, null, buttons, MessageType.None);
    }

    public static MessageBoxResult Show(string message, MessageType messageType)
    {
      return Show(message, null, MessageButton.OkOnly, messageType);
    }

    public static MessageBoxResult Show(string message, string caption)
    {
      return Show(message, caption, MessageButton.OkOnly, MessageType.None);
    }

    public static MessageBoxResult Show(string message, string caption,
      MessageButton buttons)
    {
      return Show(message, caption, buttons, MessageType.None);
    }


    public static MessageBoxResult Show(string message, string caption,
      MessageButton buttons, MessageType messageType)
    {
      wndMessage = new()
      {
        Title = caption,
        Owner = Application.Current.MainWindow,
        WindowStartupLocation = WindowStartupLocation.CenterOwner
      };
      wndMessage.MessageBody.Text = message;
      SetMessageType(messageType);
      SetButtonType(buttons);
      wndMessage.ShowDialog();
      return result;
    }

    private static void SetMessageType(MessageType messageType)
    {
      switch (messageType)
      {
        case MessageType.Error:
          wndMessage.MessageTypeIcon.Template =
            (ControlTemplate)App.Current.TryFindResource("Icon_Error");
          wndMessage.MessageTypeIcon.Visibility = Visibility.Visible;
          break;
        case MessageType.Warning:
          wndMessage.MessageTypeIcon.Template =
            (ControlTemplate)App.Current.TryFindResource("Icon_Warning");
          wndMessage.MessageTypeIcon.Visibility = Visibility.Visible;
          break;
        case MessageType.Information:
          wndMessage.MessageTypeIcon.Template =
            (ControlTemplate)App.Current.TryFindResource("Icon_Information");
          wndMessage.MessageTypeIcon.Visibility = Visibility.Visible;
          break;
        case MessageType.None:
        default:
          wndMessage.MessageTypeIcon.Visibility = Visibility.Collapsed;
          break;
      }
    }

    private static void SetButtonType(MessageButton buttons)
    {
      wndMessage.ButtonYes.Visibility = Visibility.Collapsed;
      wndMessage.ButtonNo.Visibility = Visibility.Collapsed;
      wndMessage.ButtonOk.Visibility = Visibility.Collapsed;
      wndMessage.ButtonCancel.Visibility = Visibility.Collapsed;
      switch (buttons)
      {
        case MessageButton.OkOnly:
          wndMessage.ButtonOk.Visibility = Visibility.Visible;
          break;
        case MessageButton.OkCancel:
          wndMessage.ButtonOk.Visibility = Visibility.Visible;
          wndMessage.ButtonCancel.Visibility = Visibility.Visible;
          break;
        case MessageButton.YesNo:
          wndMessage.ButtonYes.Visibility = Visibility.Visible;
          wndMessage.ButtonNo.Visibility = Visibility.Visible;
          break;
        default:
          break;
      }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if (sender == ButtonYes)
        result = MessageBoxResult.Yes;
      else if (sender == ButtonNo)
        result = MessageBoxResult.No;
      else if (sender == ButtonOk)
        result = MessageBoxResult.OK;
      else if (sender == ButtonCancel)
        result = MessageBoxResult.Cancel;
      else
        result = MessageBoxResult.None;

      wndMessage.Close();
      wndMessage = null;
    }
  }

  public enum MessageType
  {
    None,
    Information,
    Warning,
    Error
  }

  public enum MessageButton
  {
    OkOnly,
    OkCancel,
    YesNo
  }

}
