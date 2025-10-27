using LibraryManagement.Models;
using System.Collections.Generic;

namespace LibraryManagement.Repositories;

public class BookRepository : IBookRepository
{
    private readonly List<Book> _books = new();
    private int _nextId = 1;

    public IEnumerable<Book> GetAll() => _books;

    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public Book Add(Book book)
    {
        book.Id = _nextId++;
        _books.Add(book);
        return book;
    }

    public bool Update(Book book)
    {
        var existing = GetById(book.Id);
        if (existing == null) return false;
        existing.Title = book.Title;
        existing.PublishedYear = book.PublishedYear;
        existing.AuthorId = book.AuthorId;
        return true;
    }

    public bool Delete(int id)
    {
        var book = GetById(id);
        if (book == null) return false;
        _books.Remove(book);
        return true;
    }
}