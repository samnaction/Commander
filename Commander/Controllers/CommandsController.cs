using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _commanderRepo;

        public CommandsController(ICommanderRepo commanderRepo)
        {
            _commanderRepo = commanderRepo;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            return Ok(_commanderRepo.GetAllCommands());
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            return Ok(_commanderRepo.GetCommandById(id));
        }

    }
}
