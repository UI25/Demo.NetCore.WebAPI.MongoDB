using WebAPI.MongoDB.Models;

namespace WebAPI.MongoDB.Services
{
    public interface IBooksService
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(string id);
        Task CreateBookAsync(Book newbook);
        Task UpdatedBookAsync(string id, Book updatedBook);
        Task RemoveBookAsync(string id);
    }
}
