using CommunityToolkit.Mvvm.ComponentModel;
using SEV.Domain.Models.Messaging;
using System.Threading.Tasks;

namespace SEV.ViewModels
{
  public partial class ViewModelBase : ObservableObject
  {

    [ObservableProperty]
    private string messageContent = null;
    [ObservableProperty]
    private MessagePriority messagePriority = MessagePriority.Info;
    [ObservableProperty]
    private bool isMessageVisible = false;

    public async void DisplayMessage(string content, MessagePriority priority)
    {
      MessagePriority = priority;
      MessageContent = content;

      await Task.Run(async () =>
      {
        IsMessageVisible = true;
        await Task.Delay(8000);
        IsMessageVisible = false;
      });

      MessageContent = null;
    }

  }
}
