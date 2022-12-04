using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;
using CommandPattern.Core.Commands;

namespace CommandPattern.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string input)
        {
            string[] inputCommands = input.Split(" ");
            string command = inputCommands[0] + "Command";
            string[] values = inputCommands.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().First(x => x.Name == command);
            ICommand currentInstance = Activator.CreateInstance(type) as ICommand;

            return currentInstance.Execute(values);
        }
    }
}