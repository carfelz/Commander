
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        public ICommanderRepo _data { get; }
        public IMapper _mapper { get; }

        public CreateController(ICommanderRepo commanderRepo, IMapper mapper)
        {
            _data = commanderRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult <ReadDtos> CreateCommand(CreateDto dto)
        {
            var item = _mapper.Map<Command>(dto);
            _data.CreateCommand(item);
            _data.SaveChanges();

            var readDTO = _mapper.Map<ReadDtos>(item);
            var read = new CommandController(_data, _mapper);

            return CreatedAtRoute(nameof(read.GetById), new {readDTO.Id }, readDTO );
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, UpdateDto dto)
        {
            var validate = _data.GetCommandById(id);
            if(validate == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, validate);
            _data.UpdateCommand(validate);
            _data.SaveChanges();

            return NoContent();


        }
        
    }
}
