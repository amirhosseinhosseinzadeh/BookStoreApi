using MongoDB.Driver;
using Bookstore.Models;
using Bookstore.Settings.Db;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Bookstore.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IBookStoreDatabaseSettings databaseSettings)
        {
            MongoClient client = new(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _books = database.GetCollection<Book>(databaseSettings.BooksCollectionName);
        }

        public async Task<IList<Book>> GetAsync()
            => await _books.Find(book => true).ToListAsync();

        public async Task<Book> GetByIdAsync(string id)
            => await _books.Find(book => book.Id == id).FirstOrDefaultAsync();

        public async Task<Book> CreateAsync(Book book)
        {
            await _books.InsertOneAsync(book);
            return book;
        }

        public async Task UpdateAsync(string id, Book bookIn)
            => await _books.ReplaceOneAsync<Book>(book => book.Id == id, bookIn);

        public async Task Remove(Book bookIn)
            => await RemoveAsync(bookIn.Id);

        public async Task RemoveAsync(string id)
            => await _books.DeleteOneAsync(book => book.Id == id);
    }
}
