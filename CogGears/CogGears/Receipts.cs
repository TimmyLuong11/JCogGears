using System;
using System.Collections.Generic;
using System.Text;

namespace CogGears
{
    class Receipts
    {
        public int CustomerID { get; set; }
        public int CogQuantity { get; set; }
        public int GearQuantity { get; set; }
        public DateTime SaleDate { get; set; }

        private double SalesTaxPercent;
        private double CogPrice;
        private double GearPrice;

        public Receipts()
        {
            CustomerID = 0;
            CogQuantity = 0;
            GearQuantity = 0;
            SaleDate = DateTime.Now;
            SalesTaxPercent = 0.089;
            CogPrice = 79.99;
            GearPrice = 250.00;



        }
        public Receipts(int ID, int cog, int gear)
        {
            CustomerID = 0;
            CogQuantity = 0;
            GearQuantity = 0;
            SaleDate = DateTime.Now;
            SalesTaxPercent = 0.089;
            CogPrice = 79.99;
            GearPrice = 250.00;


        }

        public double CalculatorTotal()
        {
            double tax = CalculateTaxAmount();
            double net = CalculateNetAmount();
            return net + tax;
        }

        public void PrintRecepit()
        {
            Console.WriteLine($"CustomerID: {CustomerID}");
            Console.WriteLine($"Date: {SaleDate}");
            Console.WriteLine($"Number of Cogs: {CogQuantity}");
            Console.WriteLine($"Number of Gears: {GearQuantity}");
            Console.WriteLine($"Subtotal:{CalculateNetAmount().ToString("C")}");
            Console.WriteLine($"Sales Tax: {CalculateTaxAmount().ToString("C")}");
            Console.WriteLine($"Total:{CalculatorTotal().ToString("C")}");
        }

        public double CalculateTaxAmount()
        {
            double amount = CalculateNetAmount() * SalesTaxPercent;
            return amount;
        }

        public double CalculateNetAmount()
        {
            double netAmount, CMarkup, GMarkup;
            if (CogQuantity > 10 || (CogQuantity + GearQuantity) > 16 || GearQuantity > 10)
            {
                CMarkup = CogPrice + CogPrice * .125;
                GMarkup = GearPrice + GearPrice * .125;
            }
            else
            {
                CMarkup = CogPrice + CogPrice * .15;
                GMarkup = GearPrice + GearPrice * .15;
            }
            netAmount = CogQuantity * CMarkup + GearQuantity * GMarkup;
            return netAmount;
        }
    }
}

