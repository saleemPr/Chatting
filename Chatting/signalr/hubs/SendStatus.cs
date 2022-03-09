using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatting.signalr.hubs
{
    public class SendStatus : Hub
    {
        public void Send(string name, string status)
        {
            
            Clients.All.addNewMessageToPage(name, status);
        }
    }
}