using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
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
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo commanderRepo, IMapper mapper)
        {
            _commanderRepo = commanderRepo;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _commanderRepo.GetAllCommands();
            if(commandItems.Any())
            {
                return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
            }
            return NotFound();
        }

        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _commanderRepo.GetCommandById(id);
            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto command)
        {
            var writeCommand = _mapper.Map<Command>(command);
            _commanderRepo.CreateCommand(writeCommand);
            _commanderRepo.SaveChanges();

            var readCommand = _mapper.Map<CommandReadDto>(writeCommand);
            return CreatedAtRoute(nameof(GetCommandById), new { Id = writeCommand.Id }, readCommand);
        }

    }
}
