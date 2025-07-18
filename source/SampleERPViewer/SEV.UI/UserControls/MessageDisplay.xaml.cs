using SEV.Domain.Models.Messaging;
using System.Windows;
using System.Windows.Controls;

namespace SEV.UI.UserControls
{
  /// <summary>
  /// Interaction logic for MessageDisplay.xaml
  /// </summary>
  public partial class MessageDisplay : UserControl
  {
    public MessageDisplay()
    {
      InitializeComponent();
    }

    public static readonly DependencyProperty MessageProperty =
        DependencyProperty.Register(
          name: "Message",
          propertyType: typeof(string),
          ownerType: typeof(MessageDisplay),
          typeMetadata: new PropertyMetadata(
            defaultValue: string.Empty,
            propertyChangedCallback: new PropertyChangedCallback(OnMessageChanged)));

    public string Message
    {
      get => (string)GetValue(MessageProperty);
      set => SetValue(MessageProperty, value);
    }

    public static readonly DependencyProperty PriorityProperty =
        DependencyProperty.Register(
          name: "Priority",
          propertyType: typeof(MessagePriority),
          ownerType: typeof(MessageDisplay),
          typeMetadata: new PropertyMetadata(
            defaultValue: MessagePriority.Info,
            propertyChangedCallback: new PropertyChangedCallback(OnPriorityChanged)));

    public MessagePriority Priority
    {
      get => (MessagePriority)GetValue(PriorityProperty);
      set => SetValue(PriorityProperty, value);
    }

    private static void OnPriorityChanged(DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (d is MessageDisplay messageDisplay)
        messageDisplay.SetIconsVisibility(messageDisplay.Priority);
    }

    private void SetIconsVisibility(MessagePriority priority)
    {
      iconInfo.Visibility = Visibility.Hidden;
      iconWarning.Visibility = Visibility.Hidden;
      iconError.Visibility = Visibility.Hidden;
      switch (priority)
      {
        case MessagePriority.Info:
          iconInfo.Visibility = Visibility.Visible;
          break;
        case MessagePriority.Warning:
          iconWarning.Visibility = Visibility.Visible;
          break;
        case MessagePriority.Error:
          iconError.Visibility = Visibility.Visible;
          break;
        default:
          break;
      }
    }

    private static void OnMessageChanged(DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (d is MessageDisplay messageDisplay)
        messageDisplay.messageBlock.Text = messageDisplay.Message;
    }


  }
}