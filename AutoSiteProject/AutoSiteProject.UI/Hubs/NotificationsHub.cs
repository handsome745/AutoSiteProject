using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace AutoSiteProject.UI.Hubs
{
    [HubName("notificationsHub")]
    public class NotificationsHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        public static void SendInfoMessage(string message)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>();
            // Call the addNewMessageToPage method to update clients.
            hubContext.Clients.All.addNewInfoMessageToPage(message);
        }
    }
}