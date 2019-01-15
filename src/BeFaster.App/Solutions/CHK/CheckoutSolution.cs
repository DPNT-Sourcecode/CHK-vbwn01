using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int Checkout(string skus)
        {
            if (!IsInputValid(skus))
            {
                return -1;
            }
        }

        public static bool IsInputValid(string skus)
        {
            return true;
        }
    }
}

