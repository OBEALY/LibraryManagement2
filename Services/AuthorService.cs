using LibraryManagement.Models;
using LibraryManagement.Repositories;

namespace LibraryManagement.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repo;

    public AuthorService(IAuthorRepository repo) => _repo = repo;

    public Task<IEnumerable<Author>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Author?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public async Task<Author> AddAsync(Author author)
    {
        if (string.IsNullOrWhiteSpace(author.Name))
            throw new ArgumentException("Имя автора не может быть пустым.");

        return await _repo.AddAsync(author);
    }

    public async Task<bool> UpdateAsync(Author author)
    {
        if (string.IsNullOrWhiteSpace(author.Name))
            throw new ArgumentException("Имя автора не может быть пустым.");

        return await _repo.UpdateAsync(author);
    }

    public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);

    public Task<IEnumerable<Author>> GetAuthorsWithBookCountAsync() =>
        _repo.GetAuthorsWithBookCountAsync();

    public Task<IEnumerable<Author>> FindByNameAsync(string name) =>
        _repo.FindByNameAsync(name);
}
