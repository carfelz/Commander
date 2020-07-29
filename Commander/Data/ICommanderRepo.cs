using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        void CreateCommand(Command command);
        void UpdateCommand(Command command);
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void DeleteCommand(Command command);

    }

}