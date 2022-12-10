using System;
using System.Text;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private DelicacyRepository delicacyRepository;
        private CocktailRepository cocktailRepository;

        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
            this.CurrentBill = 0;
            this.Turnover = 0;
            this.IsReserved = false;
            delicacyRepository = new DelicacyRepository();
            cocktailRepository = new CocktailRepository();
        }

        public int BoothId
        {
            get => boothId;
            private set { boothId = value; }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CapacityLessThanOne));
                }

                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => delicacyRepository;
        public IRepository<ICocktail> CocktailMenu => cocktailRepository;

        public double CurrentBill { get; private set; }
        public double Turnover { get; private set; }
        public bool IsReserved { get; private set; }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void ChangeStatus()
        {
            if (IsReserved)
            {
                IsReserved = false;
            }
            else
            {
                IsReserved = true;
            }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine($"Booth: {BoothId}");
            text.AppendLine($"Capacity: {Capacity}");
            text.AppendLine($"Turnover: {Turnover:f2} lv");

            text.AppendLine($"-Cocktail menu:");
            foreach (var cocktail in cocktailRepository.Models)
            {
                text.AppendLine($"--{cocktail.ToString()}");
            }

            text.AppendLine($"-Delicacy menu:");
            foreach (var delicacy in delicacyRepository.Models)
            {
                text.AppendLine($"--{delicacy.ToString()}");
            }


            return text.ToString().Trim();
        }
    }
}