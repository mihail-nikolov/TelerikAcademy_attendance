using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PingPongHW.Hubs
{
    [HubName("game")]
    public class PingPong : Hub
    {
        private static bool otherUser = false;

        public override Task OnDisconnected(bool stopCalled)
        {
            otherUser = false;
            return base.OnDisconnected(stopCalled);
        }

        public void DrawOpponent(int y)
        {
            Clients.Others.drawOpponent(y);
        }

        public void GameWon(int player)
        {
            Clients.All.resetGame(player);
        }

        public bool CheckForUser(bool a)
        {
            if (!otherUser)
            {
                otherUser = true;
                return false;
            }

            bool ballLeft = new Random().Next(0, 2) > 0 ? true : false;

            Clients.All.gameStarts(ballLeft);

            otherUser = true;
            return otherUser;
        }
    }
}