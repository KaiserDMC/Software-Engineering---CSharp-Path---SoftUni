﻿using System;
using System.Collections.Generic;
using System.Text;
using VehiclesExtension.IO.Interfaces;

namespace VehiclesExtension.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
           string text = Console.ReadLine();
           return text;
        }
    }
}
