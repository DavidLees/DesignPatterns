using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Model;
using DesignPatterns.Patterns;
using DesignPatterns.Techniques;

namespace DesignPatterns
{
    public class Program
    {
        static void Main(string[] args)
        {

            #region Patterns
            //factory patterns           
            RunSimpleFactory();
            RunAbstrctMethodFactory();

            //Singleton pattern
            RunSingleton();
            #endregion

            #region StructVSClass
            //Struct vs Class

            TestStruct testStruct = new TestStruct();
            TestClass testClass = new TestClass();

            testStruct.x = 1;
            testClass.x = 1;

            StructTest.TakeClass(testClass);
            StructTest.TakeStruct(testStruct);

            Console.WriteLine();
            Console.WriteLine("TestClass = {0} TestStruct = {1}", testClass.x, testStruct.x);
            #endregion

            #region index test
            //indexer test
            MyArray myTestArray = new MyArray();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(myTestArray[i]);
            }

            for (int i = 0; i < 10 / 2; i++)
            {
                string s = myTestArray[i];
                myTestArray[i] = myTestArray[myTestArray.Length() - i - 1];
                myTestArray[myTestArray.Length() - i - 1] = s;
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(myTestArray[i]);
            }

            #endregion

            #region BookTest
            var bookProcesser = new BookProcessor();
            DBEventListener dbBookListener = new DBEventListener(bookProcesser.GetBookDb());

            PopulateBookProcessor(bookProcesser);

            string choice = string.Empty;

            do
            {
                choice = bookProcesser.BuyBook(new BookProcessor.OutOfStockDelegate(ProcessOutofStock));
            } while (choice != "q");


            #endregion BookTest

            #region FacadeTest
            Customer customerOne = new Customer("Bob Jones", 150000);
            Customer customerTwo = new Customer("Sally Smith", 90000);

            MortgageApprover mortgageApprove = new MortgageApprover();

            Console.WriteLine(
                mortgageApprove.CheckForApproval(customerOne)
                    ? "Customer {0} is approved!"
                    : "Custerom {0} is declined :(", customerOne.Name);

            Console.WriteLine(
                mortgageApprove.CheckForApproval(customerTwo)
                    ? "Customer {0} is approved!"
                    : "Custerom {0} is declined :(", customerTwo.Name);
            #endregion

            #region AdapterTest
            AdapterPattern adapterTest = new AdapterPattern();

            adapterTest.TestAdapterPattern();
            #endregion



        }

        public static void ChooseTest()
        {
            Console.WriteLine("Please choose a test to run: \n");
            //Console.WriteLine();
            Console.WriteLine("1. Work with Arrays[]");
            Console.WriteLine("2. Run Simple Factory");
            Console.WriteLine("3. Run Abstract Method Factory");
            Console.WriteLine("4. Run Singleton");

            switch (Console.ReadLine())
            {
                case "1":
                    TestArrays();
                    break;
                case "2":
                    RunSimpleFactory();
                    break;
                case "3":
                    RunAbstrctMethodFactory();
                    break;
                case "4":
                    RunSingleton();
                    break;
                default:
                    Console.WriteLine("You entered in invalid choice, try again.");
                    break;

            }

        }

        public static void TestArrays()
        {
            string[] stringArray = new string[10];
            int[] intArray = new int[5] { 1, 2, 3, 4, 5 };

            for (int i = 0; i < stringArray.Length; i++)
            {
                stringArray[i] = "Number " + i.ToString();
            }

            foreach (string s in stringArray)
            {
                Console.WriteLine("Array value = {0}", s);
            }

            foreach (int j in intArray)
            {
                Console.WriteLine("Int array value: {0}", j);
            }
        }

        public static void ProcessOutofStock(Book book)
        {
            Console.WriteLine("Book {0} is now out of stock!", book.Title);
            Console.WriteLine();
        }

        public static void PopulateBookProcessor(BookProcessor processor)
        {
            processor.AddBook("100", "It", "10.00", "Horror", 5);
            processor.AddBook("200", "Game of Thrones", "15.00", "Fantasy", 1);
            processor.AddBook("300", "A is for Alibi", "20.00", "Mystery", 3);
        }



        public static void RunSingleton()
        {
            Singleton testSingleton = Singleton.Instance;

            Console.WriteLine("Found a new Singleton with name " + testSingleton.Name);
            Console.WriteLine("Running Singleton:");
            testSingleton.Execute();
            
        }

        public static void RunSimpleFactory()
        {
            //Simple factory

            SimpleToyFactory simpleFactory = new SimpleToyFactory();
            ToyFactory toyFactory = new ToyFactory(simpleFactory);

            TypesofToys toyToMake = GetToyChoice();

            Toy newToy = toyFactory.ProduceToy(toyToMake, "20000", "Black", "Ford", "Flex");

            PrintToyInfo(newToy);   
        }

        public static void RunAbstrctMethodFactory()
        {
            //Abstract Factory

            TypesofToys toyToMake = GetToyChoice();

            IpswichToyFactory ipswichFactory = new IpswichToyFactory();

            Toy ipswichToy = ipswichFactory.ProduceToy(toyToMake, "50000", "Red", "AbstractMake", "AbstractModel");

            PrintToyInfo(ipswichToy);
        }

        public static void PrintToyInfo(Toy toy)
        {
            //Console.WriteLine("New toy created with price " + toy.Price + " and color " + toy.Color);
            //Console.WriteLine("This is a {0}, {1}, {2}!", toy.ToyType, toy.Make, toy.Model);

            Console.WriteLine(toy);
            Console.WriteLine();
        }

        public static TypesofToys GetToyChoice()
        {
            Console.WriteLine("Please pick a toy to assemble.");
            Console.WriteLine("1: Toy Train");
            Console.WriteLine("2. Toy Car");
            Console.WriteLine("Choice:");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                {
                    return TypesofToys.ToyTrain;
                }
                case "2":
                {
                    return TypesofToys.ToyCar;
                }
                default:
                {
                    return TypesofToys.ToyTrain;
                }
            }
        }
    }
}
