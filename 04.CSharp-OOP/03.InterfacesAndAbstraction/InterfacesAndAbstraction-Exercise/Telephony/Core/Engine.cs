using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Telephony.Exceptions;
using Telephony.IO.Interfaces;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly StationaryPhone stationaryPhone;
        private readonly Smartphone smartphone;

        public Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] urlStrings = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    if (ValidPhoneNumber(phoneNumber))
                    {
                        if (phoneNumber.Length == 10)
                        {
                            this.writer.WriteLine(this.smartphone.Call(phoneNumber));
                        }
                        else if (phoneNumber.Length == 7)
                        {
                            this.writer.WriteLine(this.stationaryPhone.Call(phoneNumber));
                        }
                    }
                    else
                    {
                        throw new InvalidPhonesNumberException();
                    }
                }
                catch (InvalidPhonesNumberException invalidPhonesNumber)
                {
                    this.writer.WriteLine(invalidPhonesNumber.Message);
                }
            }

            foreach (var url in urlStrings)
            {
                try
                {
                    if (ValidUrl(url))
                    {
                        this.writer.WriteLine(this.smartphone.Browse(url));
                    }
                    else
                    {
                        throw new InvalidURLException();
                    }
                }
                catch (InvalidURLException invalidUrl)
                {
                    this.writer.WriteLine(invalidUrl.Message);
                }
                
            }
        }

        private bool ValidPhoneNumber(string number) => number.All(c => char.IsDigit(c));

        private bool ValidUrl(string url) => !url.Any(c => char.IsDigit(c));
    }
}
