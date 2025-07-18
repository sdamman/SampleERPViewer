using SEV.UI.Windows;
using System.Windows;

namespace SEV.UI.Extension
{
  public static class MessageExtension
  {
    public static MessageBoxResult Show(this string message,
                                        string caption = null,
                                        MessageButton buttons = MessageButton.OkOnly,
                                        MessageType messageType = MessageType.None)
    {
      var messageBoxResult = WndMessage.Show(message, caption, buttons, messageType);

      return messageBoxResult;
    }


  }
}

