using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recktris.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendCommand(string user, string message)
        {
            var opponent = Program.GameService.FindOpponentFromId(user);
            if (opponent != null)
            {
                await Clients.Client(opponent.ConnectionId).SendAsync("ReceiveCommand", user, message);
            }
        }

        public async Task SendPreviewPiece(string user, string message)
        {
            var opponent = Program.GameService.FindOpponentFromId(user);
            if (opponent != null)
            {
                await Clients.Client(opponent.ConnectionId).SendAsync("ReceivePreviewPiece", user, message);
            }
        }

        public async Task Waiting(string user, string message)
        {
            var player = Program.GameService.FindPlayerFromId(user);
            if (player != null)
            {
                player.ConnectionId = Context.ConnectionId;
            }

            var game = Program.GameService.AttemptGameCreation();
            if (game != null)
            {
                foreach (var gamePlayer in game.PlayerList)
                {
                    await Clients.Client(gamePlayer.ConnectionId).SendAsync("GameReady");
                }
            }
        }

    }
}
