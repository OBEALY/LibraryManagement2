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

    public Task<IEnumerable<Book>> GetAllAsync() => _books.GetAllAsync();
    public Task<Book?> GetByIdAsync(int id) => _books.GetByIdAsync(id);

    public async Task<Book> AddAsync(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Название книги не может быть пустым.");

        var author = await _authors.GetByIdAsync(book.AuthorId);
        if (author == null)
            throw new KeyNotFoundException("Указанный автор не найден.");

        return await _books.AddAsync(book);
    }

    public async Task<bool> UpdateAsync(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Название книги не может быть пустым.");

        return await _books.UpdateAsync(book);
    }

    public Task<bool> DeleteAsync(int id) => _books.DeleteAsync(id);

    // Новые методы для LINQ-запросов
    public Task<IEnumerable<Book>> GetBooksAfterYearAsync(int year) =>
        _books.GetBooksAfterYearAsync(year);

    public Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId) =>
        _books.GetBooksByAuthorIdAsync(authorId);
}