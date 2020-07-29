using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Commander.Data
{
    public class SqlCommandRepo : ICommanderRepo
    {
        private readonly CommanderBbContext _dbContext;

        public SqlCommandRepo( CommanderBbContext commanderBbContext )
        {
            _dbContext = commanderBbContext;
        }

        public void CreateCommand(Command command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _dbContext.Commands.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _dbContext.Commands.Remove(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _dbContext.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _dbContext.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command command)
        {
           
        }
    }
}
