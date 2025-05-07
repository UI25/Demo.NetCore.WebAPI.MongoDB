using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebAPI.MongoDB.Models;

namespace WebAPI.MongoDB.Services
{
    public class BooksService 
    {
        private readonly IMongoCollection<Book> _booksCollection;

        public BooksService(IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {

            var mongoClient = new MongoClient(bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(bookStoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(bookStoreDatabaseSettings.Value.BooksCollectionName);           
        }

        public async Task<List<Book>> GetBooksAsync()=>
            await _booksCollection.Find(_ => true).ToListAsync();
        
        public async Task<Book?> GetBookAsync(string id)=>
            await _booksCollection.Find(x=> x.Id == id).FirstOrDefaultAsync();
        
        public async Task CreateBookAsync(Book newBook)=>
            await _booksCollection.InsertOneAsync(newBook);
        
        public async Task UpdateBookAsync(string id, Book updatedBook)=>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);
        
        public async Task RemoveBookAsync(string id)=>
            await _booksCollection.DeleteOneAsync(x=>x.Id== id);       
    }
}
