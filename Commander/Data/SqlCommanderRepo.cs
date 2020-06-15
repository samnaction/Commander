using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _commanderContext;

        public SqlCommanderRepo(CommanderContext commanderContext)
        {
            _commanderContext = commanderContext;
        }

        public void CreateCommand(Command command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _commanderContext.Add(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _commanderContext.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _commanderContext.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return _commanderContext.SaveChanges() >= 0;
        }

        public void UpdateCommand(Command command)
        {
            //default implementation
        }
    }
}
