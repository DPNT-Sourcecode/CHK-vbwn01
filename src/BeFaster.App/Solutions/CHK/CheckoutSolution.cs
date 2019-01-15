using BeFaster.Runner.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static List<char> GroupOfItems = new List<char>() { 'S', 'T', 'X', 'Y', 'Z' };
        public static int NumberOfGroupItemsToBuy = 3;
        public static int PriceForGroupItems = 45;

        public static List<Item> ItemsList = InitItemsList();

        public static List<Item> InitItemsList()
        {
            return new List<Item>()
            {
                new Item(){Sku = 'A', Price = 50, SpecialOffers = new List<SpecialOffer>(){
                    new SpecialOffer(){Amount = 3, Price = 130, Type = SpecialOfferType.Discount},
                    new SpecialOffer(){Amount = 5, Price = 200, Type = SpecialOfferType.Discount} } },
                new Item(){Sku = 'B', Price = 30, SpecialOffers = new List<SpecialOffer>(){
                    new SpecialOffer(){Amount = 2, Price = 45, Type = SpecialOfferType.Discount} } },
                new Item(){Sku = 'C', Price = 20, SpecialOffers = null},
                new Item(){Sku = 'D', Price = 15, SpecialOffers = null},
                new Item(){Sku = 'E', Price = 40, SpecialOffers = new List<SpecialOffer>(){
                    new SpecialOffer(){Amount = 2, FreeItemName = 'B', Type = SpecialOfferType.FreeItem} } },
                new Item(){Sku = 'F', Price = 10, SpecialOffers = new List<SpecialOffer>(){
                    new SpecialOffer(){Amount = 3, FreeItemName = 'F', Type = SpecialOfferType.FreeItem} } },
                new Item(){Sku = 'G', Price = 20, SpecialOffers = null},
                new Item(){Sku = 'H', Price = 10, SpecialOffers = new List<SpecialOffer>(){
                    new SpecialOffer(){Amount = 5, Price = 45, Type = SpecialOfferType.Discount},
                    new SpecialOffer(){Amount = 10, Price = 80, Type = SpecialOfferType.Discount} } },
                new Item(){Sku = 'I', Price = 35, SpecialOffers = null},
                new Item(){Sku = 'J', Price = 60, SpecialOffers = null},
                new Item(){Sku = 'K', Price = 70, SpecialOffers = new List<SpecialOffer>(){
                    new SpecialOffer(){Amount = 2, Price = 120, Type = SpecialOfferType.Discount} } },
                new Item(){Sku = 'L', Price = 90, SpecialOffers = null},
                new Item(){Sku = 'M', Price = 15, SpecialOffers = null},
                new Item(){Sku = 'N', Price = 40, SpecialOffers = new List<SpecialOffer>(){
                    new SpecialOffer(){Amount = 3, FreeItemName = 'M', Type = SpecialOfferType.FreeItem} } },
                new Item(){Sku = 'O', Price = 10, SpecialOffers = null},
                new Item(){Sku = 'P', Price = 50, SpecialOffers = new List<SpecialOffer>(){
                    new SpecialOffer(){Amount = 5, Price = 200, Type = SpecialOfferType.Discount} } },
                new Item(){Sku = 'Q', Price = 30, SpecialOffers = new List<SpecialOffer>(){
                    new SpecialOffer(){Amount = 3, Price = 80, Type = SpecialOfferType.Discount} } },
                new Item(){Sku = 'R', Price = 50, SpecialOffers = new List<SpecialOffer>(){
                    new SpecialOffer(){Amount = 3, FreeItemName = 'Q', Type = SpecialOfferType.FreeItem} } },
                new Item(){Sku = 'S', Price = 20, SpecialOffers = null},
                new Item(){Sku = 'T', Price = 20, SpecialOffers = null},
                new Item(){Sku = 'U', Price = 40, SpecialOffers = new List<SpecialOffer>(){
                    new SpecialOffer(){Amount = 4, FreeItemName = 'U', Type = SpecialOfferType.FreeItem} } },
                new Item(){Sku = 'V', Price = 50, SpecialOffers = new List<SpecialOffer>(){
                    new SpecialOffer(){Amount = 2, Price = 90, Type = SpecialOfferType.Discount},
                    new SpecialOffer(){Amount = 3, Price = 130, Type = SpecialOfferType.Discount} } },
                new Item(){Sku = 'W', Price = 20, SpecialOffers = null},
                new Item(){Sku = 'X', Price = 17, SpecialOffers = null},
                new Item(){Sku = 'Y', Price = 20, SpecialOffers = null},
                new Item(){Sku = 'Z', Price = 21, SpecialOffers = null}
            };
        }

        public static int Checkout(string skus)
        {
            if (!IsInputValid(skus))
            {
                return -1;
            }

            List<ProductAmountOrdered> orderedProductAmounts = GetOrderedProductAmounts(skus);
            List<SpecialOffer> specialOffersInOrder = GetSpecialOffersInOrder(orderedProductAmounts);

            int fullPrice = GetFullPrice(orderedProductAmounts, specialOffersInOrder);

            return fullPrice;
        }

        public static int GetFullPrice(List<ProductAmountOrdered> orderedProductAmounts, List<SpecialOffer> specialOffersInOrder)
        {
            int fullPrice = 0;
            foreach (var product in orderedProductAmounts)
            {
                fullPrice += product.Amount * product.Price;
            }
            foreach (var specialOffer in specialOffersInOrder)
            {
                fullPrice += specialOffer.Price;
            }
            return fullPrice;
        }

        public static bool IsInputValid(string skus)
        {
            foreach (var sku in skus.Distinct())
            {
                bool isCharValid = ItemsList.Where(x => x.Sku == sku).FirstOrDefault() != null;
                if (!isCharValid)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<ProductAmountOrdered> GetOrderedProductAmounts(string skus)
        {
            List<ProductAmountOrdered> orderedProductAmounts = new List<ProductAmountOrdered>();
            foreach (var item in ItemsList)
            {
                int amount = skus.Where(c => c == item.Sku).ToArray().Length;
                if (amount > 0)
                {
                    orderedProductAmounts.Add(new ProductAmountOrdered() { Sku = item.Sku, Amount = amount, Price = item.Price });
                }
            }
            return orderedProductAmounts;
        }

        public static List<SpecialOffer> GetSpecialOffersInOrder(List<ProductAmountOrdered> productAmounts)
        {
            List<SpecialOffer> specialOffersInOrder = new List<SpecialOffer>();
            //FreeItem
            foreach (var productAmount in productAmounts)
            {
                List<SpecialOffer> specialOffers = ItemsList.Where(x => x.Sku == productAmount.Sku && x.SpecialOffers != null && x.SpecialOffers.Any()).FirstOrDefault()?.SpecialOffers.Where(s => s.Type == SpecialOfferType.FreeItem).ToList();
                if (specialOffers != null)
                {
                    foreach (var specialOffer in specialOffers)
                    {
                        int numberOfOffers = productAmount.Amount / specialOffer.Amount;
                        for (int i = 0; i < numberOfOffers; i++)
                        {
                            var freeProductAmount = productAmounts.Where(p => p.Sku == specialOffer.FreeItemName).FirstOrDefault();
                            if (freeProductAmount != null && freeProductAmount.Amount > 0)
                            {
                                freeProductAmount.Amount--;
                            }
                        }
                    }
                }
            }
            //Discount
            foreach (var productAmount in productAmounts)
            {
                List<SpecialOffer> specialOffers = ItemsList.Where(x => x.Sku == productAmount.Sku && x.SpecialOffers != null && x.SpecialOffers.Any()).FirstOrDefault()?.SpecialOffers.Where(s => s.Type == SpecialOfferType.Discount).ToList();
                if (specialOffers != null)
                {
                    foreach (var specialOffer in specialOffers.OrderByDescending(x => x.Amount))
                    {
                        int numberOfOffers = productAmount.Amount / specialOffer.Amount;
                        for (int i = 0; i < numberOfOffers; i++)
                        {
                            specialOffersInOrder.Add(specialOffer);
                            productAmount.Amount -= specialOffer.Amount;
                        }
                    }
                }
            }
            //GroupOfItems
            int sum = productAmounts.Where(x => GroupOfItems.Contains(x.Sku)).Sum(s => s.Amount);
            int numberOfDiscounts = sum / NumberOfGroupItemsToBuy;
            for (int i = 0; i < numberOfDiscounts; i++)
            {
                specialOffersInOrder.Add(new SpecialOffer() { Price = PriceForGroupItems });
                for (int t = 0; t < NumberOfGroupItemsToBuy; t++)
                {
                    var groupItems = productAmounts.Where(x => GroupOfItems.Contains(x.Sku)).OrderByDescending(p => p.Price).ToList();
                    var mostExpensive = groupItems.First();
                    if (mostExpensive.Amount > 1)
                    {
                        productAmounts.Where(x => x.Sku == mostExpensive.Sku).First().Amount--;
                    }
                    else
                    {
                        productAmounts.Remove(mostExpensive);
                    }
                }
            }

            return specialOffersInOrder;
        }
    }
}



