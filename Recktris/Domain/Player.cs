using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recktris.Domain
{
    public class Player
    {
        public string Id { get; set; }
        public string ConnectionId { get; set; }
        public string Name { get; set; }

        public Game Game { get; set; }
    }
}
