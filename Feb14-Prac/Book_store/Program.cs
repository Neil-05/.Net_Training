using System;

public class InvalidBookDataException : Exception
{
public InvalidBookDataException(string msg) : base(msg) { }
}

// 🔹 Book Class
public class Book
{
private int price;
private int stock;

public string Id { get; set; }
public string Title { get; set; }
public string Author { get; set; }

public int Price
{
get { return price; }
set
{
if(value < 0) throw new InvalidBookDataException("Invalid Price");
price = value;
}
}

public int Stock
{
get { return stock; }
set
{
if(value < 0) throw new InvalidBookDataException("Invalid Stock");
stock = value;
}
}
}

// 🔹 BookUtility Class
public class BookUtility
{
private Book book;

public BookUtility(Book b)
{
book = b;
}

public void GetBookDetails()
{
Console.WriteLine("Details: " + book.Id + " " + book.Title + " " + book.Price + " " + book.Stock);
}

public void UpdateBookPrice(int newPrice)
{
book.Price = newPrice;
Console.WriteLine("Updated Price: " + newPrice);
}

public void UpdateBookStock(int newStock)
{
book.Stock = newStock;
Console.WriteLine("Updated Stock: " + newStock);
}
}

// 🔹 Program Class
public class Program
{
public static void Main()
{
string firstLine = Console.ReadLine();
string[] data = firstLine.Split(' ');

Book book = new Book();
book.Id = data[0];
book.Title = data[1];
book.Price = int.Parse(data[2]);
book.Stock = int.Parse(data[3]);

BookUtility util = new BookUtility(book);

while(true)
{
int choice = int.Parse(Console.ReadLine());

if(choice == 1)
{
util.GetBookDetails();
}
else if(choice == 2)
{
int newPrice = int.Parse(Console.ReadLine());
util.UpdateBookPrice(newPrice);
}
else if(choice == 3)
{
int newStock = int.Parse(Console.ReadLine());
util.UpdateBookStock(newStock);
}
else if(choice == 4)
{
Console.WriteLine("Thank You");
break;
}
}
}
}