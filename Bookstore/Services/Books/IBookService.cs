using Bookstore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Services.Books
{
    public interface IBookService
    {
        Task<IList<Book>> GetAsync();

        Task<Book> GetByIdAsync(string id);

        Task<Book> CreateAsync(Book book);

        Task UpdateAsync(string id, Book bookIn);

        Task Remove(Book bookIn);

        Task RemoveAsync(string id);
    }
}
