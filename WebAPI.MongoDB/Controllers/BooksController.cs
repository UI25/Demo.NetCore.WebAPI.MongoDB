using Microsoft.AspNetCore.Mvc;
using WebAPI.MongoDB.Models;
using WebAPI.MongoDB.Services;

namespace WebAPI.MongoDB.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        [Route("GetBooks")]
        public async Task<List<Book>> GetBooks()=>
                await _booksService.GetBooksAsync();
        
        [HttpGet]
        [Route("GetBook/{id:length(24)}")]
        public async Task<Book> GetBook(string id)
        {
            var book = await _booksService.GetBookAsync(id);   
            return book;
        }
        [HttpPost]
        [Route("CreateBook")]
        public async Task<Book> CreateBook(Book newBook)
        {
            await _booksService.CreateBookAsync(newBook);

            return newBook;
        }
        
        [HttpPut]
        [Route("UpdateBook")]
        public async Task<Book> UpdateBook(string id, Book updatedBook)
        {           
            await _booksService.UpdateBookAsync(id, updatedBook);
            return updatedBook;                                            
        }

        [HttpDelete]
        [Route("DeleteBook/{id:length(24)}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            
            await _booksService.RemoveBookAsync(id);

            return Ok();
        }

    }
}
