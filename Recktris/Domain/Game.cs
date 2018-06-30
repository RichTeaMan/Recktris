using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recktris.Domain
{
    public class Game
    {
        public string Id { get; }
        public IReadOnlyList<Player> PlayerList { get; }

        public Game(IEnumerable<Player> players)
        {
            Id = Guid.NewGuid().ToString();
            PlayerList = players.ToList();
        }
    }
}
