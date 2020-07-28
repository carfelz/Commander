using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class SqlCommandRepo : ICommanderRepo
    {
        private readonly CommanderBbContext _dbContext;

        public SqlCommandRepo( CommanderBbContext commanderBbContext )
        {
            _dbContext = commanderBbContext;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            return _dbContext.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _dbContext.Commands.FirstOrDefault(p => p.Id == id);
        }
    }
}
