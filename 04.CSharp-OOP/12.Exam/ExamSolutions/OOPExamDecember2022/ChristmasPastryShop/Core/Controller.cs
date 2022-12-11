using System;
using System.Linq;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core

{
    public class Controller : IController
    {
        private BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int newBoothNumber = booths.Models.Count + 1;
            IBooth booth = new Booth(newBoothNumber, capacity);

            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, newBoothNumber, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IDelicacy delicacy;

            switch (delicacyTypeName)
            {
                case "Gingerbread":
                    delicacy = new Gingerbread(delicacyName);
                    break;
                case "Stolen":
                    delicacy = new Stolen(delicacyName);
                    break;
                default:
                    delicacy = null;
                    break;
            }

            IBooth currentBooth = booths.Models.First(b => b.BoothId == boothId);

            if (currentBooth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            currentBooth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != "Hibernation" && cocktailTypeName != "MulledWine")
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Large" && size != "Middle" && size != "Small")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            IBooth currentBooth = booths.Models.First(b => b.BoothId == boothId);

            ICocktail cocktail;

            switch (cocktailTypeName)
            {
                case "Hibernation":
                    cocktail = new Hibernation(cocktailName, size);
                    break;
                case "MulledWine":
                    cocktail = new MulledWine(cocktailName, size);
                    break;
                default:
                    cocktail = null;
                    break;
            }

            if (currentBooth.CocktailMenu.Models.Any(c => c.Size == size && c.Name == cocktailName))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            currentBooth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            var orderedBooths = booths.Models.Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId);

            IBooth firstAvailable = orderedBooths.FirstOrDefault();

            if (firstAvailable == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            firstAvailable.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, firstAvailable.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] strings = order.Split('/').ToArray();

            string itemTypeName = strings[0];
            string itemName = strings[1];
            int countOfOrders = int.Parse(strings[2]);
            string size = string.Empty;

            if (strings.Length == 4)
            {
                size = strings[3];
            }

            IBooth currentBooth = booths.Models.First(b => b.BoothId == boothId);

            if (itemTypeName != "Hibernation" && itemTypeName != "MulledWine" && itemTypeName != "Gingerbread" &&
                itemTypeName != "Stolen")
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            ICocktail cocktail;
            IDelicacy delicacy;

            if (!string.IsNullOrEmpty(size))
            {
                if (!currentBooth.CocktailMenu.Models.Any(b => b.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                cocktail = currentBooth.CocktailMenu.Models.FirstOrDefault(c =>
                    c.GetType().Name == itemTypeName && c.Name == itemName && c.Size == size);

                if (cocktail != null)
                {
                    double sum = cocktail.Price * countOfOrders;
                    currentBooth.UpdateCurrentBill(sum);
                    return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrders, itemName);
                }

                return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
            }
            else
            {
                if (!currentBooth.DelicacyMenu.Models.Any(b => b.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                delicacy = currentBooth.DelicacyMenu.Models.FirstOrDefault(d =>
                    d.GetType().Name == itemTypeName && d.Name == itemName);

                if (delicacy != null)
                {
                    double sum = delicacy.Price * countOfOrders;
                    currentBooth.UpdateCurrentBill(sum);
                    return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrders, itemName);
                }

                return String.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
            }
        }

        public string LeaveBooth(int boothId)
        {
            IBooth currentBooth = booths.Models.First(b => b.BoothId == boothId);
            
            double boothBill = currentBooth.CurrentBill;
            currentBooth.Charge();
            currentBooth.ChangeStatus();

            StringBuilder text = new StringBuilder();

            text.AppendLine($"Bill {boothBill:f2} lv");
            text.Append(string.Format(OutputMessages.BoothIsAvailable, currentBooth.BoothId));

            return text.ToString().Trim();
        }

        public string BoothReport(int boothId)
        {
            IBooth currentBooth = booths.Models.First(b => b.BoothId == boothId);
            
            return currentBooth.ToString();
        }
    }
}