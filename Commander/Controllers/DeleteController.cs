using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        public ICommanderRepo _data { get; }
        public DeleteController(ICommanderRepo commanderRepo)
        {
            _data = commanderRepo;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var item = _data.GetCommandById(id);
            if(item == null)
            {
                return NotFound();
            }

            _data.DeleteCommand(item);
            _data.SaveChanges();
            return NoContent();

        }
        
    }
}
