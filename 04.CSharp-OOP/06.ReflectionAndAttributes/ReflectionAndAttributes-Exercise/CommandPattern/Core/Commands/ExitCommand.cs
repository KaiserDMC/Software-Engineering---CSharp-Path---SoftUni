using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] input)
        {
            Environment.Exit(0);
            return null;
        }
    }
}