using CRUD_Post.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Post.Services;

public class Book_service
{
    private List<Book> ListedBooks;

    public Book_service()
    {
        ListedBooks = new List<Book>();
        DataSeed();
    }


    public Book AddBook(Book book)
    {
        book.Id = Guid.NewGuid();
        ListedBooks.Add(book);

        return book;
    }




    public Book GetById(Guid bookID)
    {
        foreach(var book in ListedBooks)
        {
            if(book.Id == bookID)
            {
                return book;
            }
        }
        return null;
    }



    public bool DeleteBook(Guid bookID)
    {
        var bookId = GetById(bookID);

        if(bookId is null)
        {
            return false;
        }
        ListedBooks.Remove(bookId);
        return true;
    }


    public bool UpdatedBook(Guid bookId, Book book)
    {
        var foundBook = GetById(bookId);

        if(foundBook is null)
        {
            return false;
        }

        var index = ListedBooks.IndexOf(foundBook);
        ListedBooks[index] = book;
        return true;
    }



    public List<Book> GetAllBooks()
    {
        return ListedBooks;
    }





    public Book GetExpensiveBook()
    {
        var bookResponce = new Book();

        foreach(var book in ListedBooks)
        {
            if(book.Price > bookResponce.Price)
            {
                bookResponce = book;
            }
        }
        return bookResponce;
    }



    public Book GetMostPagedBook()
    {
        var bookPage = new Book();

        foreach(var book in ListedBooks)
        {
            if(book.PageNumber > bookPage.PageNumber)
            {
                bookPage = book;
            }
        }
        return bookPage;
    }



    public Book GetMostReadBook()  
    {
        var mostReadBook = new Book();

        foreach(var book in ListedBooks)
        {
            if(book.ReaderName.Count > mostReadBook.ReaderName.Count)
            {
                mostReadBook = book;
            }
        }
        return mostReadBook;
    }



    public List<Book> GetBooksByReaderName(string readerName)
    {
        var reader = new List<Book>();

        foreach(var book in ListedBooks)
        {
            if (book.ReaderName.Contains(readerName))
            {
                reader.Add(book);
            }
        }
        return reader;
    }

    


    public List<Book> GetBooksByAuthorName(string authorName)
    {
        var author = new List<Book>();

        foreach(var book in ListedBooks)
        {
            if (book.AuthorsName.Contains(authorName))
            {
                author.Add(book);
            }
        }
        return author;
    }

    

    public bool AddReaderToBook(Guid bookId, string readerName)
    {
        var foundBook = GetById(bookId);

        if(foundBook is null)
        {
            return false;
        }

        var index = ListedBooks.IndexOf(foundBook);
        ListedBooks[index].ReaderName.Add(readerName);
        return true;
    }



    public bool AddAuthorToBook(Guid bookId, string authorName)
    {
        var foundBook = GetById(bookId);

        if(foundBook is null)
        {
            return false;
        }

        var index = ListedBooks.IndexOf(foundBook);
        ListedBooks[index].AuthorsName.Add(authorName);
        return true;
    }





    public void DataSeed()
    {
        var firstSeed = new Book()
        {
            Id = Guid.NewGuid(),
            Title = "The Great Adventure",
            PublicationDate = new DateTime(2020, 6, 15),
            Description = "A thrilling adventure of a group of explorers discovering hidden treasures.",
            PageNumber = 350,
            Price = 19.99,
            AuthorsName = new List<string> { "John Doe", "Jane Smith" },
            ReaderName = new List<string> { "Alice", "Bob", "Charlie" }
        };


        var secondSeed = new Book()
        {
            Id = Guid.NewGuid(),
            Title = "The Future of AI",
            PublicationDate = new DateTime(2022, 9, 10),
            Description = "An in-depth analysis of artificial intelligence and its future impact on society.",
            PageNumber = 450,
            Price = 29.99,
            AuthorsName = new List<string> { "Sarah Lee" },
            ReaderName = new List<string> { "David", "Eve" }
        };



        var thirdSeed = new Book()
        {
            Id = Guid.NewGuid(),
            Title = "A Journey Through Time",
            PublicationDate = new DateTime(2021, 3, 20),
            Description = "A historical fiction novel that transports readers to different time periods.",
            PageNumber = 400,
            Price = 25.99,
            AuthorsName = new List<string> { "James Brown" },
            ReaderName = new List<string> { "George", "Hannah" }
        };



        var fourthSeed = new Book()
        {
            Id = Guid.NewGuid(),
            Title = "The Art of Cooking",
            PublicationDate = new DateTime(2019, 11, 5),
            Description = "A comprehensive guide to cooking with recipes from around the world.",
            PageNumber = 300,
            Price = 15.99,
            AuthorsName = new List<string> { "Anna White" },
            ReaderName = new List<string> { "Isabella", "Jack", "Liam" }
        };


        ListedBooks.Add(firstSeed);
        ListedBooks.Add(secondSeed);
        ListedBooks.Add(thirdSeed);
        ListedBooks.Add(fourthSeed);
    }
}
