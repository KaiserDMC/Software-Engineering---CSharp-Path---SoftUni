using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Commands
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] input)
            => $"Hello, {input[0]}";
    }
}