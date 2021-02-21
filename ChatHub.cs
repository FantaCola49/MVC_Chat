using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MVC_Chat
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Вызывается для обновления списка подключённых клиентов
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}