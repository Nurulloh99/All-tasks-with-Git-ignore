using CRUD_Post.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Post.Services;

public class Book_service
{

    private static List<Book> ListedBook;

    public Book_service()
    {
        ListedBook = new List<Book>();
    }


    public Book AddBook(Book book)
    {
        book.Id = Guid.NewGuid();
        ListedBook.Add(book);

        return book;
    }


    public Book GetById(Guid bookId)
    {
        foreach(var book in ListedBook)
        {
            if(book.Id == bookId)
            {
                return book;
            }
        }
        return null;
    }


    public List<Book> GetAllBooks()
    {
        return ListedBook;
    }


    public bool DeleteBook(Guid bookId)
    {
        var foundBook = GetById(bookId);

        if(foundBook is null)
        {
            return false;
        }

        ListedBook.Remove(foundBook);
        return true;
    }


    public bool UpdateBook(Book book)
    {
        var foundBook = GetById(book.Id);

        if(foundBook is null)
        {
            return false;
        }

        var index = ListedBook.IndexOf(foundBook);
        ListedBook[index] = book;
        return true;
    }


    // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 


    public Book GetExpensiveBook()
    {
        var resultOfBook = new Book();

        foreach(var book in ListedBook)
        {
            if(book.Price > resultOfBook.Price)
            {
                resultOfBook = book;
            }
        }
        return resultOfBook;
    }



    public Book GetMostPagedBook()
    {
        var resultOfBook = new Book();

        foreach(var book in ListedBook)
        {
            if(book.PageNumber > resultOfBook.PageNumber)
            {
                resultOfBook = book;
            }
        }
        return resultOfBook;
    }



    public Book GetMostReadBook()
    {
        var resultOfBook = new Book();

        foreach(var book in ListedBook)
        {
            if(book.ReadersName.Count > resultOfBook.ReadersName.Count)
            {
                resultOfBook = book;
            }
        }
        return resultOfBook;
    }




    public List<Book> GetBooksByReaderName(string readerName)
    {
        var Books = new List<Book>();

        foreach(var book in ListedBook)
        {
            if (book.ReadersName.Contains(readerName))
            {
                Books.Add(book);
            }
        }
        return Books;
    }





    public List<Book> GetBooksByAuthorName(string authorName)
    {
        var resultOfBooks = new List<Book>();

        foreach(var book in ListedBook)
        {
            if (book.AuthorsName.Contains(authorName))
            {
                resultOfBooks.Add(book);
            }
        }
        return resultOfBooks;
    }





    public bool AddReaderToBook(Guid bookId, string readerName)
    {
        var resultOfBook = new Book();

        if(resultOfBook is null)
        {
            return false;
        }

        var index = ListedBook.IndexOf(resultOfBook);
        ListedBook[index].ReadersName.Add(readerName);
        return true;
    }




    public bool AddAuthorToBook(Guid bookId, string authorName)
    {
        var resultOfBook = new Book();

        if(resultOfBook is null)
        {
            return false;
        }

        var index = ListedBook.IndexOf(resultOfBook);
        ListedBook[index].AuthorsName.Add(authorName);
        return true;
    }

}
