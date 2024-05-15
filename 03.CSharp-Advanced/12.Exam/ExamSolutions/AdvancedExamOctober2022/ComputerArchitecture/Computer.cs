using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private string model;
        private int capacity;
        private List<CPU> multiprocessor;

        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.Multiprocessor = new List<CPU>();
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public List<CPU> Multiprocessor
        {
            get { return multiprocessor; }
            set { multiprocessor = value; }
        }

        public int Count
        {
            get { return this.Multiprocessor.Count; }
        }

        public void Add(CPU cpu)
        {
            if (!(Count >= capacity))
            {
                this.Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            if (this.Multiprocessor.Any(p => p.Brand == brand))
            {
                CPU cpuToRemove = this.Multiprocessor.Find(p => p.Brand == brand);
                this.Multiprocessor.Remove(cpuToRemove);
                return true;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            List<CPU> tempList = this.Multiprocessor.OrderByDescending(p => p.Frequency).ToList();

            CPU mostPower = tempList.First();

            return mostPower;
        }

        public CPU GetCPU(string brand)
        {
            if (this.Multiprocessor.Any(p => p.Brand == brand))
            {
                CPU requestedCPU = this.Multiprocessor.Find(p => p.Brand == brand);

                return requestedCPU;
            }

            return null;
        }

        public string Report()
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine($"CPUs in the Computer {this.Model}:");

            foreach (var cpu in Multiprocessor)
            {
                text.AppendLine($"{cpu}");
            }

            return text.ToString().TrimEnd();
        }
    }
}