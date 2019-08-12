using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using LOC_WebApi.Models;

namespace LOC_WebApi.Hubs
{
    public class ChatHub : Hub
    {
        static List<ApplicationUser> Users = new List<ApplicationUser>();

        // Отправка сообщений
        public void Send(string chatUserName, string message)
        {
            Clients.All.addMessage(chatUserName, message);
        }

        // Подключение нового пользователя
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            if (Users.Any(x => x.Id == id))
            {
                Users.Add(new ApplicationUser { Id = id, UserName = userName });

                // Посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, userName, Users);

                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }

        // Отключение пользователя
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.Id == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}