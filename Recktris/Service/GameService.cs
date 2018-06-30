using Recktris.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recktris.Service
{
    public class GameService
    {
        private ConcurrentQueue<Player> _playerQueue = new ConcurrentQueue<Player>();

        private ConcurrentBag<Player> _playerList = new ConcurrentBag<Player>();

        public void EnqueuePlayer(Player player)
        {
            _playerQueue.Enqueue(player);
            _playerList.Add(player);
        }

        public Player FindPlayerFromId(string id)
        {
            return _playerList.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Find the opponent of a player from their ID, or null if that player does not exist or does not yet have an opponent.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Player FindOpponentFromId(string id)
        {
            return FindPlayerFromId(id)?.Game?.PlayerList.Single(p => p.Id != id);
        }

        /// <summary>
        /// Will create a game from 2 queued players. Returns null if a game couldn't be created.
        /// </summary>
        /// <returns></returns>
        public Game AttemptGameCreation()
        {
            Player player1 = null;
            Player player2 = null;
            Game game = null;

            if (_playerQueue.TryDequeue(out player1) && _playerQueue.TryDequeue(out player2))
            {
                game = new Game(new[] { player1, player2 });
                player1.Game = game;
                player2.Game = game;
            }
            else
            {
                if (player1 != null)
                {
                    _playerQueue.Enqueue(player1);
                }
                if (player2 != null)
                {
                    _playerQueue.Enqueue(player2);
                }
            }

            return game;
        }
    }
}
