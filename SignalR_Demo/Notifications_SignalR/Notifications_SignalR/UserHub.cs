using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Notifications_SignalR
{
    public class UserHub : Hub
    {
        public static void Show()
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<UserHub>();
            hubContext.Clients.All.GetDemoUsers();
        }
    }
}