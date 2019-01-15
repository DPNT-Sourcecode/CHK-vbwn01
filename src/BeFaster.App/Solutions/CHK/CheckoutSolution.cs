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
                new Item(){Sku = 'A', Price = 50, specialOffer = new SpecialOffer(){Amount = 3, Price = 130}},
                new Item(){Sku = 'B', Price = 30, specialOffer = new SpecialOffer(){Amount = 2, Price = 45}},
                new Item(){Sku = 'C', Price = 20, specialOffer = null},
                new Item(){Sku = 'D', Price = 15, specialOffer = null}
            };
        }

        public static int Checkout(string skus)
        {
            if (!IsInputValid(skus))
            {
                return -1;
            }
            return -1;
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
    }
}
