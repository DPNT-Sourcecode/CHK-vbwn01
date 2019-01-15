using BeFaster.Runner.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static List<Item> ItemsList = InitItemsList();

        public static List<Item> InitItemsList()
        {
            return new List<Item>()
            {
                new Item(){Sku = 'A', Price = 50, SpecialOffer = new SpecialOffer(){Amount = 3, Price = 130}},
                new Item(){Sku = 'B', Price = 30, SpecialOffer = new SpecialOffer(){Amount = 2, Price = 45}},
                new Item(){Sku = 'C', Price = 20, SpecialOffer = null},
                new Item(){Sku = 'D', Price = 15, SpecialOffer = null}
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
            foreach(var product in orderedProductAmounts)
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
            if(String.IsNullOrWhiteSpace(skus))
            {
                return false;
            }

            foreach(var sku in skus.Distinct())
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
            foreach(var item in ItemsList)
            {
                int amount = skus.Where(c => c == item.Sku).ToArray().Length;
                if(amount > 0)
                {
                    orderedProductAmounts.Add(new ProductAmountOrdered() { Sku = item.Sku, Amount = amount, Price = item.Price });
                }
            }
            return orderedProductAmounts;
        }

        public static List<SpecialOffer> GetSpecialOffersInOrder (List<ProductAmountOrdered> productAmounts)
        {
            List<SpecialOffer> specialOffers = new List<SpecialOffer>();
            foreach(var productAmount in productAmounts)
            {
                SpecialOffer specialOffer = ItemsList.Where(x => x.Sku == productAmount.Sku && x.SpecialOffer != null).FirstOrDefault()?.SpecialOffer;
                if(specialOffer != null)
                {
                    int numberOfOffers = productAmount.Amount / specialOffer.Amount;
                    for(int i=0; i< numberOfOffers; i++)
                    {
                        specialOffers.Add(specialOffer);
                        productAmount.Amount -= specialOffer.Amount;
                    }
                }
            }
            return specialOffers;
        }
    }
}


