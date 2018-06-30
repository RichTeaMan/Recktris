using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recktris.Domain;

namespace Recktris.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpPost]
        [HttpGet]
        [Route("api/Join")]
        public string Join(string name)
        {
            var id = Guid.NewGuid().ToString();
            var player = new Player
            {
                Id = id,
                Name = name
            };


            Program.GameService.EnqueuePlayer(player);

            return id;
        }
    }
}