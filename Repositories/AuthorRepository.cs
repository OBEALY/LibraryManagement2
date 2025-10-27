using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryContext _context;

    public AuthorRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _context.Authors
            .Include(a => a.Books)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _context.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Author> AddAsync(Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return author;
    }

    public async Task<bool> UpdateAsync(Author author)
    {
        var existingAuthor = await _context.Authors.FindAsync(author.Id);
        if (existingAuthor == null) return false;

        _context.Entry(existingAuthor).CurrentValues.SetValues(author);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null) return false;

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Author>> GetAuthorsWithBookCountAsync()
    {
        return await _context.Authors
            .Select(a => new Author
            {
                Id = a.Id,
                Name = a.Name,
                DateOfBirth = a.DateOfBirth,
                Books = a.Books
            })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Author>> FindByNameAsync(string name)
    {
        return await _context.Authors
            .Where(a => a.Name.Contains(name) || a.Name.StartsWith(name))
            .Include(a => a.Books)
            .AsNoTracking()
            .ToListAsync();
    }
}