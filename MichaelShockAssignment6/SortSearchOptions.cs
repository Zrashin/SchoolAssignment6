using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelShockAssignment6
{
    class SortSearchOptions
    {

        public static void linearSearchLoan(decimal loanAmt, List<Customer> customers)
        {
            int[] subscriptsFound = new int[customers.Count];  // somewhere to save the subscripts of the elements with the same loan amount.

            bool exitSearch = false;
            int i = 0;
            int j = 0;
            while (!exitSearch)
            {
                if (customers[i].loanAmount == loanAmt)
                {
                    subscriptsFound[j] = i; //Adds to the list of subscripts with the loan amount input.
                    j++;
                }
                i++;
                if (i > customers.Count - 1)
                {
                    exitSearch = true;
                }
            }
            if (j == 0) // if J never got incremented then no one ever was put in, meaning nobody was found with that loan 
            {
                Console.WriteLine("No customer has that loan amount");
            }
            else  // prints all the customers with the loan amount.
            {
                Console.WriteLine("\nThere are " + j + " customers with that loan amount \n");

                for (int counter = 0; counter < j; counter++)
                {
                    Console.WriteLine(customers[subscriptsFound[counter]].ToString()); // prints toString method in each object found.
                }
            }



        }

        public static int BinarySearch(string custName,List<Customer> customers) // Method to search arrays by name using Binary search.
        {
            int subscriptOfCustomer = -1;           // If -1 is returned at the end that means the customer is not found.

            int max = customers.Count - 1;
            int min = 0;
            int mid = 0;
            int compare;
            bool exit = false;

            while (!exit)
            {
                mid = (max + min) / 2;    // Get the middle of the area that target name is inside.

                if (max < min) // ends loop if max is less than min which would mean the name is not listed.
                {
                    exit = true;
                }

                compare = customers[mid].name.CompareTo(custName);   // To test whether the search is higher or lower or on the mark.
                // Console.WriteLine(names[mid] + "  " + custName + "  " + compare + "   " + mid + "" + max + "" + min);  THIS IS USED FOR DEBUGGING

                if (compare == 0)       //found customer
                {
                    subscriptOfCustomer = mid;
                    exit = true;
                }
                else if (compare > 0)  //customer is in the lower half of the array.
                {
                    max = mid - 1;
                    //Console.WriteLine("name is more"); //THIS IS USED FOR DEBUGGING
                }
                else if (compare < 0)   //customer is in the upper half of the array.
                {
                    min = mid + 1;
                    // Console.WriteLine("name is less"); //THIS IS USED FOR DEBUGGING
                }


            }
            return subscriptOfCustomer; //returns result of search.
        }

        public static void SortArrayByName(List<Customer> customers)   //Uses selection Sort to sort the List<> array.
        {
            for (int i = 0; i < customers.Count; i++)
            {
                int smallestElementSubscript = i;
                for (int j = i + 1; j < customers.Count; j++)
                {
                    int compare = customers[j].name.CompareTo(customers[smallestElementSubscript].name); // compare the names to see which is smaller.
                    if (compare == -1)
                    {
                        smallestElementSubscript = j;
                    }
                }

                Swap(customers ,i, smallestElementSubscript);
            }
        } 

        private static void Swap(List<Customer> customers, int pointA, int pointB) // simple swap two points in all three arrays.
        {
            Customer temp;
            temp = customers[pointA];
            customers[pointA] = customers[pointB];
            customers[pointB] = temp;
        }
    }
}
