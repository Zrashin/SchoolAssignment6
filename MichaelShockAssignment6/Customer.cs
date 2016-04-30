using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelShockAssignment6
{
    class Customer
    {
        public string name { get; set; }        // Properties for each object instead of having an array for each.
        public decimal loanAmount { get; set; }
        public decimal term { get; set; }

        public Customer(string nameStr, decimal loanDec, decimal termDec)// The cunstructor to instantiate each property.
        {
            name = nameStr;
            loanAmount = loanDec;
            term = termDec;
        }   

        public override string ToString()// Override the ToString method and replaced it with a nicely formated version.
        {
            return String.Format("Name :{0, -20}     Loan Amount :{1,-10}  Years :{2,-10}", name, loanAmount, term);
        }   
    }
}
