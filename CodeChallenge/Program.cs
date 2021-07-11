using System;

namespace CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            ShippingFeesDelegate theDel;
            ShippingDestination theDest;

            string theZone;
            do
            {
                Console.WriteLine("What is the destination zone?");
                theZone = Console.ReadLine();

                if (!theZone.Equals("exit"))
                {
                    theDest = ShippingDestination.getDestinationInfo(theZone);

                    if(theDest != null)
                    {
                        Console.WriteLine("What is the item price?");
                        string thePriceStr = Console.ReadLine();
                        decimal itemPrice = decimal.Parse(thePriceStr);

                        theDel = theDest.calcFees;

                        if(theDest.m_isHighRisk)
                        {
                            theDel += delegate (decimal thePrice, ref decimal itemFee)
                            {
                                itemFee += 25.0m;
                            };
                        }

                        decimal theFee = 0.0m;
                        theDel(itemPrice, ref theFee);
                        Console.WriteLine("The shipping fees are: {0}", theFee);
                    }
                    else
                    {
                        Console.WriteLine("Hmm, you seem to have entered an unknow destination. Try again or 'exit'");
                    }
                }
            }
            while (theZone != "exit");
        }
    }
}
