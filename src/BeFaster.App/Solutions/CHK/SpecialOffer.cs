using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    public class SpecialOffer
    {
        public int Amount;
        public int Price;
        public SpecialOfferType Type;
        public char FreeItemName;
    }

    public enum SpecialOfferType
    {
        Discount,
        FreeItem
    }
}


