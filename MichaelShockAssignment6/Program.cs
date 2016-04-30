// By Michael Shock
// An improved version of Assignment 6 in my opinion. Not as intensive on the amount of code. Simple use of List<> Arrays to store many names and make it easier to read.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MichaelShockAssignment6
{
    class Program
    {
        private static bool exit = false;
        private static int numberChoiceInt = 0;

        private static List<Customer> customers = new List<Customer>(); // Creates a array that doesn't have a size but can have elements added in that are an object of the Customer Class.

        static void Main(string[] args)
        {
            ReadFile();

            while (!exit) // keep running menu until exit is comfirmed.
            {
                Menu();
            }

        }

        public static void ReadFile()   // quick method to grab all customers names, loan amounts and terms from the LOANFILE.txt and make objects.
        {
            StreamReader fileReader = new StreamReader("LOANFILE.txt");

            while (!fileReader.EndOfStream) // Reads the information into the corresponding arrays.
            {
                string tempStr = fileReader.ReadLine(); //hold full data string
                string[] tempSplit;                     //hold seperate data split by delimiter later (comma)

                tempStr.Replace(" ", "");      
                tempSplit = tempStr.Split(','); //splits up array into a parts using the comma delimiter.
                customers.Add(new Customer(tempSplit[0], decimal.Parse(tempSplit[1]), decimal.Parse(tempSplit[2]))); // creates a new object and adds it in the List.
                
            }

            fileReader.Close(); // dont forget to close
        }

//*****************************************************************************************************************************

        public static void Menu() // Shows the menu and gives you the options.
        {
            Console.Clear();
            Console.WriteLine("HELLO NEWCOMER! This is the menu! \n\n"
                + "1: Show all Customer Data \n"
                + "2: Input loan amount Search \n"
                + "3: Sort array by name \n"
                + "4: Process and Report Customer Monthly Payments\n"
                + "5: Exit");

            ChooseNumber(); // get users input for which option.


            switch (numberChoiceInt) // selection of options
            {
                case 1:
                    Console.Clear();
                    for (int i=0; i < customers.Count; i++)
                    {
                        Console.WriteLine(customers[i].ToString());
                    }
                    Console.WriteLine("\nEnter to go back to the Menu!");
                    Console.ReadLine();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Please Enter in the Loan Amount to Search:");
                    SortSearchOptions.linearSearchLoan(decimal.Parse(Console.ReadLine()), customers);   //calls the method to search for the name using linear Search
                    Console.WriteLine("\nEnter to go back to the Menu!");
                    Console.ReadLine();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Sorting by name.....");
                    SortSearchOptions.SortArrayByName(customers);
                    Console.WriteLine("COMPLETED\n");
                    for (int i = 0; i < customers.Count; i++)
                    {
                        Console.WriteLine(customers[i].ToString());
                    }
                    Console.WriteLine("\nEnter to go back to the Menu!");
                    Console.ReadLine();
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Please enter the name of the customer: ");

                    string customerName = Console.ReadLine();
                    int custSubscript = SortSearchOptions.BinarySearch(customerName,customers); //calls a method to binary search for the name. Array must be sorted for this to work accurately.

                    if (custSubscript == -1) // if returns with -1 then it found nothing.
                    {
                        Console.WriteLine("Customer DOES NOT exist");
                    }
                    else
                    {
                        CalculateOutput(custSubscript);
                    }

                    Console.WriteLine("\nEnter to go back to the Menu!");
                    Console.ReadLine();
                    break;

                case 5:
                    exit = true;
                    break;
            }


            numberChoiceInt = 0;



        }

        public static void ChooseNumber() // validation for choosing item menu.
        {
            while (numberChoiceInt < 1 || numberChoiceInt >5)
            {
                Console.WriteLine("Please enter a number between 1 and 5");

                try
                {
                    numberChoiceInt = int.Parse(Console.ReadLine());
                }catch(Exception e)
                {
                    Console.WriteLine("I am sorry, error: " + e.Message);
                }
            }
        }

        public static void CalculateOutput(int custSubscript) //This outputs the customers monthly payment and total due after the loan.
        {
            decimal simpInterest = customers[custSubscript].loanAmount * .05m * customers[custSubscript].term; // How much interest adds to the loan
            decimal totalDue = simpInterest + customers[custSubscript].loanAmount;                    // how much the total due is.
            decimal monthPayment = totalDue / (customers[custSubscript].term * 12);                  // how much monthly payment is.

            decimal extraMoney = (monthPayment % Math.Round(monthPayment, 2)) * customers[custSubscript].term * 12;   // all the money extra that is less than a penny.


            string output = customers[custSubscript].ToString() + Environment.NewLine;
            output += "********************************************************************************\n";

            int j = 0;

            for (int i = 1; i < (customers[custSubscript].term * 12); i++) // a for loop to express each monthly payment.
            {
                output += string.Format("Month {0,-5} : {1,-5} \n", i, Math.Round(monthPayment, 2).ToString("c"));
                j = i;
            }
            j++;
            output += string.Format("Month {0,-5} : {1,-5} \n", j, (monthPayment + extraMoney).ToString("c"));
            output += "********************************************************************************\n";

            output += "\nTotal Due : " + totalDue.ToString("c") + Environment.NewLine   // end report with a smiley face to garner that customer trust.
                + "Thank you for choosing us! :)";

            Console.WriteLine(output);


        }

    }
}
