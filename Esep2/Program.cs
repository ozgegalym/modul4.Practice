using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearOfPublication { get; set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        YearOfPublication = year;
    }

    public override string ToString()
    {
        return $"{Title} by {Author}, published in {YearOfPublication}";
    }
}

class Library
{
    private List<Book> collection = new List<Book>();

    public void AddNewBook(Book book)
    {
        collection.Add(book);
    }

    public void RemoveExistingBook(Book book)
    {
        collection.Remove(book);
    }

    public List<Book> FindBooksByAuthor(string authorName)
    {
        return collection.Where(book => book.Author == authorName).ToList();
    }

    public List<Book> FindBooksByYearOfPublication(int year)
    {
        return collection.Where(book => book.YearOfPublication == year).ToList();
    }

    public void SortBooksByTitle()
    {
        collection.Sort((book1, book2) => book1.Title.CompareTo(book2.Title));
    }

    public void SortBooksByAuthor()
    {
        collection.Sort((book1, book2) => book1.Author.CompareTo(book2.Author));
    }

    public void SortBooksByYearOfPublication()
    {
        collection.Sort((book1, book2) => book1.YearOfPublication.CompareTo(book2.YearOfPublication));
    }

    public void DisplayAllBooks()
    {
        foreach (var book in collection)
        {
            Console.WriteLine(book);
        }
    }

    public List<Book> GetBookCollection()
    {
        return collection;
    }
}

class Program
{
    static void Main()
    {
        Library myLibrary = new Library();

        myLibrary.AddNewBook(new Book("The Catcher in the Rye", "J.D. Salinger", 1951));
        myLibrary.AddNewBook(new Book("To Kill a Mockingbird", "Harper Lee", 1960));
        myLibrary.AddNewBook(new Book("1984", "George Orwell", 1949));
        myLibrary.AddNewBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925));

        Console.WriteLine("All Books:");
        myLibrary.DisplayAllBooks();

        Console.WriteLine("\nBooks by J.D. Salinger:");
        var booksBySalinger = myLibrary.FindBooksByAuthor("J.D. Salinger");
        foreach (var book in booksBySalinger)
        {
            Console.WriteLine(book);
        }

        Console.WriteLine("\nBooks from the year 1951:");
        var booksFrom1951 = myLibrary.FindBooksByYearOfPublication(1951);
        foreach (var book in booksFrom1951)
        {
            Console.WriteLine(book);
        }

        Console.WriteLine("\nSorting by Title:");
        myLibrary.SortBooksByTitle();
        myLibrary.DisplayAllBooks();

        // Additional Feature
        Console.WriteLine("\nList of Books in the Library:");
        var allBooks = myLibrary.GetBookCollection();
        foreach (var book in allBooks)
        {
            Console.WriteLine(book);
        }

        Console.ReadLine();
    }
}
