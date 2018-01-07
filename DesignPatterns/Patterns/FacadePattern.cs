using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns
{
    class FacadePattern
    {
        static void main()
        {
           
        }
    }

    class Customer
    {
        public string Name { get; set; }
        public int Income { get; set; }

        public Customer(string customerName, int customerIncome)
        {
            Name = customerName;
            Income = customerIncome;
        }
    }

    class MortgageApprover
    {
        public bool CheckForApproval(Customer customerToApprove)
        {
            bool customerApproved = true;

            customerApproved = CheckCustomerIncome.IncomeIsSufficient(customerToApprove);

            return customerApproved;
        }
    }

    static class CheckCustomerIncome
    {
        public static bool IncomeIsSufficient(Customer customerToCheck)
        {
            return customerToCheck.Income > 100000 ? true : false;
        }
    }
}
