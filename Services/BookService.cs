using LibraryManagement.Models;
using LibraryManagement.Repositories;
using System;
using System.Collections.Generic;

namespace LibraryManagement.Services;

public class BookService
{
    private readonly IBookRepository _books;
    private readonly IAuthorRepository _authors;

    public BookService(IBookRepository books, IAuthorRepository authors)
    {
        _books = books;
        _authors = authors;
    }

    public IEnumerable<Book> GetAll() => _books.GetAll();
    public Book? GetById(int id) => _books.GetById(id);

    public Book Add(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Название книги не может быть пустым.");
        if (_authors.GetById(book.AuthorId) == null)
            throw new KeyNotFoundException("Указанный автор не найден.");

        return _books.Add(book);
    }

    public bool Update(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Название книги не может быть пустым.");
        return _books.Update(book);
    }

    public bool Delete(int id) => _books.Delete(id);
}