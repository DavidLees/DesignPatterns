using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Techniques
{
    public class BookProcessor
    {
        private BookDb bookDatabase;

        public BookProcessor()
        {
             bookDatabase = new BookDb();            
        }

        public string BuyBook(OutOfStockDelegate outOfStock)
        {        

            PrintBookInventory();

            Console.WriteLine("\nPlease enter the ID of a book to purchase.");
            Console.WriteLine("\nEnter q to quit.");
            Console.WriteLine();
            string bookIdToPurchase = Console.ReadLine();
            Book bookToBuy = bookDatabase.RetrieveBook(bookIdToPurchase);

            if (bookToBuy != null && bookToBuy.Quantity != 0)
            {
                bookToBuy.DecrementQuantity(1);
                Console.WriteLine("{0} with price {1} has been purchased!", bookToBuy.Title, bookToBuy.Price);
                if (bookToBuy.Quantity == 0)
                {
                    outOfStock(bookToBuy);
                }
            }
            else
            {
                Console.WriteLine("That Book ID was not found.");
            }

            return bookIdToPurchase;

        }

        public void PrintBookInventory()
        {
            Console.WriteLine("Current book inventory:");
            
            foreach (var book in bookDatabase.GetCompleteBookList())
            {
                if (book.Quantity > 0)
                {
                    Console.WriteLine(book);
                }
            }
        }

        public Book FindBook(string bookId)
        {
            return bookDatabase.RetrieveBook(bookId);
        }

        public void AddBook(string id, string name, string price, string category, int quantity)
        {
            Book newBook = new Book(id, name, price, category, quantity);

            bookDatabase.StoreBook(newBook);
        }

        public delegate void OutOfStockDelegate(Book book);

        public BookDb GetBookDb()
        {
            return bookDatabase;
        }
    }

    public class Book
    {
        public string ID { get; private set; }
        public string Title { get; private set; }
        public string Price { get; private set; }
        public string Category { get; private set; }
        public int Quantity { get; private set; }

        public Book(string bookID, string bookTitle, string bookPrice,  string bookCategory, int bookQuantity)
        {
            ID = bookID;
            Title = bookTitle;
            Price = bookPrice;
            Category = bookCategory;
            Quantity = bookQuantity;
        }

        public override string ToString()
        {
            return("BookID: " + ID + " Book: " + Title + " Price: " + Price + " Category : " + Category + " Quantity: " + Quantity);
        }

        public void DecrementQuantity(int quantityToDecrement)
        {
            Quantity -= 1;
        }
    }

    public delegate void OnDBChanged(object sender, BookDBEventArgs e);

    public class BookDb
    {
        private List<Book> bookDatabase;
        public event OnDBChanged onDBChange;

        public BookDb()
        {
            bookDatabase = new List<Book>();
        }

        public void StoreBook(Book bookToStore)
        {
            bookDatabase.Add(bookToStore);
            BookDBEventArgs BookArgs = new BookDBEventArgs(bookToStore.ID, "stored in");
            if (onDBChange != null) onDBChange(this, BookArgs);
        }

        public void RemoveBook(Book bookToRemove)
        {
            bookDatabase.Remove(bookToRemove);
            BookDBEventArgs BookArgs = new BookDBEventArgs(bookToRemove.ID, "removed from");
            if (onDBChange != null) onDBChange(this, BookArgs);
        }

        public Book RetrieveBook(string bookId)
        {
            return bookDatabase.Find(item => item.ID == bookId);
        }

        public List<Book> GetCompleteBookList()
        {
            //List<Book> bookListForProcessing = new List<Book>();

            //bookListForProcessing = bookDatabase.Select(book )

            return bookDatabase;
        }
    }

    public class BookDBEventArgs : EventArgs
    {
        public string BookID { get; set; }
        public string DBAction { get; set; }

        public BookDBEventArgs(string bookID, string dbAction)
        {
            BookID = bookID;
            DBAction = dbAction;
        }
    }

    public class DBEventListener
    {
        private BookDb _dbToMonitor;

        public DBEventListener(BookDb dbTolistenTo)
        {
            _dbToMonitor = dbTolistenTo;
            _dbToMonitor.onDBChange += new OnDBChanged(PrintDBChangeSummary);
        }

        public void PrintDBChangeSummary(object sender, BookDBEventArgs e)
        {
            Console.WriteLine("\nBook with ID={0} has been {1} from the Book Database", e.BookID, e.DBAction);
        }
    }
}
