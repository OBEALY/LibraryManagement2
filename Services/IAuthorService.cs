using LibraryManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Services;

public interface IAuthorService
{
    Task<IEnumerable<Author>> GetAllAsync();
    Task<Author?> GetByIdAsync(int id);
    Task<Author> AddAsync(Author author);
    Task<bool> UpdateAsync(Author author);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Author>> GetAuthorsWithBookCountAsync();
    Task<IEnumerable<Author>> FindByNameAsync(string name);
}