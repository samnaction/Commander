using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
        bool SaveChanges();
        void UpdateCommand(Command command);

        void DeleteCommand(Command command);
    }
}
