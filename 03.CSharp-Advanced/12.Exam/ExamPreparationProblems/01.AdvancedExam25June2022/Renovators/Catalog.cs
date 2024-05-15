using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private string name;
        private int neededRenovators;
        private string project;
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.Renovators = new List<Renovator>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NeededRenovators
        {
            get { return neededRenovators; }
            set { neededRenovators = value; }
        }

        public string Project
        {
            get { return project; }
            set { project = value; }
        }

        public List<Renovator> Renovators
        {
            get { return renovators; }
            set { renovators = value; }
        }

        public int Count
        {
            get { return this.Renovators.Count; }
        }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return $"Invalid renovator's information.";
            }

            if (this.Count >= this.NeededRenovators)
            {
                return $"Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return $"Invalid renovator's rate.";
            }

            this.Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if (this.Renovators.Any(r => r.Name == name))
            {
                Renovator renovator = this.Renovators.Find(r => r.Name == name);
                Renovators.Remove(renovator);
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int counter = 0;
            
            if (this.Renovators.Any(r => r.Type == type))
            {
                for (int i = 0; i < Count; i++)
                {
                    Renovator currentRenovator = Renovators[i];
            
                    if (currentRenovator.Type == type)
                    {
                        Renovators.Remove(currentRenovator);
                        counter++;
                    }
                }
            }
            
            return counter;
        }

        public Renovator HireRenovator(string name)
        {
            if (this.Renovators.Any(r => r.Name == name))
            {
                Renovator renovatorToHire = this.Renovators.Find(r => r.Name == name);

                if (renovatorToHire != null)
                {
                    renovatorToHire.Hired = true;
                }

                return renovatorToHire;
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> tempList = new List<Renovator>();

            tempList = Renovators.FindAll(r => r.Days >= days);

            return tempList;
        }

        public string Report()
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine($"Renovators available for Project {this.Project}:");

            foreach (var renovatorNotHired in Renovators.FindAll(r => r.Hired == false))
            {
                text.AppendLine(renovatorNotHired.ToString());
            }

            return text.ToString().Trim();
        }
    }
}