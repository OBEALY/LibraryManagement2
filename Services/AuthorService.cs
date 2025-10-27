using LibraryManagement.Models;
using LibraryManagement.Repositories;
using System;
using System.Collections.Generic;

namespace LibraryManagement.Services;

public class AuthorService
{
    private readonly IAuthorRepository _repo;

    public AuthorService(IAuthorRepository repo) => _repo = repo;

    public IEnumerable<Author> GetAll() => _repo.GetAll();
    public Author? GetById(int id) => _repo.GetById(id);

    public Author Add(Author author)
    {
        if (string.IsNullOrWhiteSpace(author.Name))
            throw new ArgumentException("Имя автора не может быть пустым.");
        return _repo.Add(author);
    }

    public bool Update(Author author)
    {
        if (string.IsNullOrWhiteSpace(author.Name))
            throw new ArgumentException("Имя автора не может быть пустым.");
        return _repo.Update(author);
    }

    public bool Delete(int id) => _repo.Delete(id);
}