using BookLibAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibAPI.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly DataContext _db;
        public BookRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<Book> Create(Book book)
        {
            _db.Books.Add(book);
            await _db.SaveChangesAsync();

            return book;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _db.Books.FindAsync(id);
            _db.Books.Remove(bookToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
            return await _db.Books.FindAsync(id);
        }

        public async Task Update(Book book)
        {
            _db.Entry(book).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
