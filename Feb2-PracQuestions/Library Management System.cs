using System;
using System.Collections.Generic;

public class Book
{
    public int Id;
    public string Title;
    public string Author;
    public string Genre;
    public int PublicationYear;
}

public class LibraryUtility
{
    private List<Book> books = new List<Book>();
    private int idCounter = 1;

   
    public void AddBook(string title, string author, string genre, int year)
    {
        Book b = new Book();

        b.Id = idCounter++;
        b.Title = title;
        b.Author = author;
        b.Genre = genre;
        b.PublicationYear = year;

        books.Add(b);
    }

   
    public SortedDictionary<string, List<Book>> GroupBooksByGenre()
    {
        SortedDictionary<string, List<Book>> result =
            new SortedDictionary<string, List<Book>>();

        foreach (Book b in books)
        {
            if (!result.ContainsKey(b.Genre))
            {
                result[b.Genre] = new List<Book>();
            }

            result[b.Genre].Add(b);
        }

        return result;
    }


    public List<Book> GetBooksByAuthor(string author)
    {
        List<Book> result = new List<Book>();

        foreach (Book b in books)
        {
            if (b.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(b);
            }
        }

        return result;
    }

    public int GetTotalBooksCount()
    {
        return books.Count;
    }

   
    public Dictionary<string, int> GetBooksPerGenre()
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (Book b in books)
        {
            if (!result.ContainsKey(b.Genre))
            {
                result[b.Genre] = 0;
            }

            result[b.Genre]++;
        }

        return result;
    }
}


public class Program
{
    static void Main()
    {
        LibraryUtility library = new LibraryUtility();

       
        library.AddBook("The Hobbit", "J.R.R. Tolkien", "Fiction", 1937);
        library.AddBook("Clean Code", "Robert Martin", "Non-Fiction", 2008);
        library.AddBook("Sherlock Holmes", "Arthur Conan Doyle", "Mystery", 1892);
        library.AddBook("The Lord of the Rings", "J.R.R. Tolkien", "Fiction", 1954);


        Console.WriteLine("Books Grouped By Genre:\n");

        var grouped = library.GroupBooksByGenre();

        foreach (var genre in grouped)
        {
            Console.WriteLine("Genre: " + genre.Key);

            foreach (Book b in genre.Value)
            {
                Console.WriteLine($"  {b.Id}. {b.Title} - {b.Author}");
            }

            Console.WriteLine();
        }

        // 2. Search By Author
        Console.WriteLine("Books by J.R.R. Tolkien:\n");

        var authorBooks = library.GetBooksByAuthor("J.R.R. Tolkien");

        foreach (Book b in authorBooks)
        {
            Console.WriteLine($"{b.Title} ({b.PublicationYear})");
        }

        Console.WriteLine();

        // 3. Statistics
        Console.WriteLine("Library Statistics:\n");

        Console.WriteLine("Total Books: " + library.GetTotalBooksCount());

        var perGenre = library.GetBooksPerGenre();

        Console.WriteLine("\nBooks Per Genre:");

        foreach (var item in perGenre)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }

        Console.ReadLine();
    }
}
