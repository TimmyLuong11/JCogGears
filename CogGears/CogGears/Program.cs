using System;
using System.Collections.Generic;

namespace CogGears
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<Receipts>> stuff = new Dictionary<int, List<Receipts>>(); int cogs;
            int gears;
            int answer;
            int custID;

            Receipts R = new Receipts();

            Console.WriteLine("What is the customer ID");
            custID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many cogs would you to buy: ");
            cogs = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many gears would you to buy: ");
            gears = Convert.ToInt32(Console.ReadLine());
            stuff.Add(custID, new List<Receipts>());
            R = new Receipts()
            {
                CustomerID = custID,
                CogQuantity = cogs,
                GearQuantity = gears,
            };
            stuff[custID].Add(R);
            do
            {
                Console.WriteLine("How would you like your receipts printed: ");
                Console.WriteLine("1.Print off based on CustomerID");
                Console.WriteLine("2.Print all receipts for the day");
                Console.WriteLine("3.Print the receipts with the highest total");
                Console.WriteLine("4.No receipts");
                Console.WriteLine("Please select 1-4: ");
                answer = Convert.ToInt32(Console.ReadLine());
                //printing receipts based on the customers preference

                if (answer == 1)// based off customerID
                {
                    Console.WriteLine("Please enter the customer ID you would like to display:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    DisplayByCustomerID(stuff, id);
                }
                else if (answer == 2)// prints receipts for the day
                {
                    DisplayDateReceipt(stuff);
                }
                else if (answer == 3)// based off the highest total
                {
                    DisplayHighestTotal(stuff);
                }
            } while (answer == 4);

            static void DisplayByCustomerID(Dictionary<int, List<Receipts>> receipts, int id)
            {
                if (receipts.ContainsKey(id) == true)
                {
                    foreach (var receipt in receipts[id])
                    {
                        receipt.PrintRecepit();
                    }
                }
            }

            static void DisplayDateReceipt(Dictionary<int, List<Receipts>> receipts)
            {
                foreach (var cust in receipts.Keys)
                {
                    foreach (var receipt in receipts[cust])
                    {
                        if (receipt.SaleDate.Date == DateTime.Now.Date)
                        {
                            receipt.PrintRecepit();
                        }
                    }
                }
            }

            static void DisplayHighestTotal(Dictionary<int, List<Receipts>> receipts)
            {
                double max = 0;
                foreach (var cust in receipts.Keys)
                {
                    foreach (var receipt in receipts[cust])
                        if (receipt.CalculatorTotal() > max)
                        {
                            max = receipt.CalculatorTotal();
                        }
                }
                foreach (var cust in receipts.Keys)
                {
                    foreach (var receipt in receipts[cust])
                    {
                        if (receipt.CalculatorTotal() == max)
                        {
                            receipt.PrintRecepit();
                        }

                    }
                }
            }




        }
    }
}
        
    

