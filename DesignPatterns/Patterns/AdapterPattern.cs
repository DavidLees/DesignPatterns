using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns
{
    class AdapterPattern
    {
        public void TestAdapterPattern()
        {   
            IEmployeeAdapter eAdapter = new HRAdapter();
            BillingSystem bSystem = new BillingSystem(eAdapter);
            HRSystem hrSystem = new HRSystem();

            bSystem.PrintEmployeeList();
        }
    }

    class BillingSystem
    {
        private IEmployeeAdapter empleeEmployeeAdapter;
        private List<string> _employeeList;

        public BillingSystem(IEmployeeAdapter eAdapter)
        {
            empleeEmployeeAdapter = eAdapter;
        }

        public void PrintEmployeeList()
        {
            _employeeList = empleeEmployeeAdapter.GetEmployeeList();

            foreach (string s in _employeeList)
            {
                Console.WriteLine("Employee {0} works for the compaly!", s);
            }
        }
    }

    interface IEmployeeAdapter
    {
        List<string> GetEmployeeList();
    }

    class HRAdapter:HRSystem, IEmployeeAdapter
    {
        private List<string> employeeArrayasList = new List<string>();
        


        public List<string> GetEmployeeList()
        {
            string[] employeeArray = GetEmployeeArray();

            if (employeeArray != null)
            {
                foreach (string s in employeeArray)
                {
                    employeeArrayasList.Add(s);
                }
            }

            return employeeArrayasList;
        }
    }

    class HRSystem
    {
        private string[] employeeArray = new string[5] {"Bob", "Mary", "John", "Steve", "Cindy"};

        public string[] GetEmployeeArray()
        {
            return employeeArray;
        }
    }
}
