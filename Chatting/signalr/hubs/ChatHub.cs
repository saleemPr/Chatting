using Microsoft.AspNet.SignalR;
using Chatting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chatting.Views;
using Chatting.Models;

namespace Chatting.signalr.hubs
{
    
    public class ChatHub : Hub
    {
            HomeController Home = new HomeController();
            ChattingUs db = new ChattingUs();
            public void sendmessage(int SId, int RId, string message)
            {
                Home.msgsave(SId, RId, message);
                Clients.All.addNewMessageToPage(SId, message);
            }
        public void updatestatus(int SId, string status)
        {
            Home.UpdateState(SId, status);
            Clients.All.addNewStatusToPage(SId, status);
        }
    }
}