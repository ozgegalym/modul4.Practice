using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }

    public Book(string title, string author, int publicationYear)
    {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
    }

    public override string ToString()
    {
        return $"{Title} by {Author}, {PublicationYear}";
    }
}

class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    public List<Book> SearchBooksByAuthor(string authorName)
    {
        return books.Where(book => book.Author == authorName).ToList();
    }

    public List<Book> SearchBooksByPublicationYear(int year)
    {
        return books.Where(book => book.PublicationYear == year).ToList();
    }

    public void SortBooksByTitle()
    {
        books.Sort((book1, book2) => book1.Title.CompareTo(book2.Title));
    }

    public void SortBooksByAuthor()
    {
        books.Sort((book1, book2) => book1.Author.CompareTo(book2.Author));
    }

    public void SortBooksByPublicationYear()
    {
        books.Sort((book1, book2) => book1.PublicationYear.CompareTo(book2.PublicationYear));
    }

    public void DisplayBooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
}

class Program
{
    static void Main()
    {
        Library myLibrary = new Library();

        myLibrary.AddBook(new Book("Title 1", "Author X", 2000));
        myLibrary.AddBook(new Book("Title 2", "Author Y", 1995));
        myLibrary.AddBook(new Book("Title 3", "Author X", 2010));
        myLibrary.AddBook(new Book("Title 4", "Author Z", 2005));

        Console.WriteLine("All Books:");
        myLibrary.DisplayBooks();

        Console.WriteLine("\nBooks by Author X:");
        var booksByAuthorX = myLibrary.SearchBooksByAuthor("Author X");
        foreach (var book in booksByAuthorX)
        {
            Console.WriteLine(book);
        }

        Console.WriteLine("\nBooks from the year 2000:");
        var booksFromYear2000 = myLibrary.SearchBooksByPublicationYear(2000);
        foreach (var book in booksFromYear2000)
        {
            Console.WriteLine(book);
        }

        Console.WriteLine("\nSorting by Title:");
        myLibrary.SortBooksByTitle();
        myLibrary.DisplayBooks();

        Console.ReadLine();
    }
}
