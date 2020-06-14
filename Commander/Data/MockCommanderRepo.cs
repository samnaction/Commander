﻿using Commander.Models;
using System;
using System.Collections.Generic;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo="HowTo1", Line="Line1", Platform = "Platform1" },
                new Command { Id = 0, HowTo="HowTo2", Line="Line2", Platform = "Platform2" },
                new Command { Id = 0, HowTo="HowTo3", Line="Line3", Platform = "Platform3" }
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "HowTo1", Line = "Line1", Platform = "Platform1" };
        }
    }
}