using LibraryManagement.Models;

namespace LibraryManagement.Services;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    Task<Book> AddAsync(Book book);
    Task<bool> UpdateAsync(Book book);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Book>> GetBooksAfterYearAsync(int year);
    Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId);
}