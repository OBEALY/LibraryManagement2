using LibraryManagement.Models;
using System.Collections.Generic;

namespace LibraryManagement.Repositories;

public interface IBookRepository
{
    IEnumerable<Book> GetAll();
    Book? GetById(int id);
    Book Add(Book book);
    bool Update(Book book);
    bool Delete(int id);
}