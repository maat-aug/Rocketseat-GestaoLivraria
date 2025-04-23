using Microsoft.AspNetCore.Mvc;
using Rocketseat_Gestao_Livraria.Communication.Request;
using Rocketseat_Gestão_Livraria.Entities;

namespace Rocketseat_Gestao_Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> books = new List<Book>();
        [HttpPost]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]

        public IActionResult Create([FromBody] RequestBookJson request)
        {
            var book = new Book
            {
                Author = request.Author,
                Title = request.Title,
                Genre = request.Genre,
                Price = request.Price,
                Stock = request.Stock
            };
            books.Add(book);

            return Created(string.Empty, book);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]

        public IActionResult GetAll()
        {
            return Ok(books);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(), StatusCodes.Status404NotFound)]


        public IActionResult Edit([FromRoute] long idSearch, [FromBody] RequestBookJson request)
        {
            var book = books.FirstOrDefault(b => b.Id == idSearch);

            if (book == null)
                return NotFound();

            book.Title = request.Title;
            book.Genre = request.Genre;
            book.Price = request.Price;
            book.Stock = request.Stock;

            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(), StatusCodes.Status404NotFound)]
        public IActionResult Remove([FromRoute] long idSearch)
        {
            var bookToDelete = books.FirstOrDefault(b => b.Id == idSearch);
            
            if (bookToDelete == null)
            {
                return NotFound();
            }

            books.Remove(bookToDelete);
            return Ok();
        }

    }
}
