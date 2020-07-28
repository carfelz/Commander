using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommanderRepo _data;

        public IMapper _mapper { get; }

        public CommandController(ICommanderRepo commanderRepo, IMapper mapper )
        {
            _data = commanderRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadDtos>> GetAll()
        {
            var getItems = _data.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<ReadDtos>>(getItems));
        }

        [HttpGet("{id}")]

        public ActionResult <ReadDtos> GetById(int id)
        {
            var item = _data.GetCommandById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<ReadDtos>(item));
            }
            return NotFound();
            
        }
    }
}
