using BookLibAPI.Models;
using BookLibAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibAPI.Controllers
{
    //An API controller is a class that is responsible for handling request for an endpoint.
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase // provides method/properties used for handling http request.
    {
        //It needs an instance of the book repo to interact with the database. Then we inject the bookrepo in the contructor
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //ActionMethods
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }
        //return action of a book object because. Task is because the caller will be to awiat this method.
        //The action result provides thee flexibility to return all the types like NotFound or BadRequest for instance.
        [HttpGet("{id}")]//it puts the endpoint subpart in the id parameter.
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepository.Get(id);
        }
        //Thanks to Model Binding asp.net will convert JSON in the request to a book object.
        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newbook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newbook.Id }, newbook);
        }
        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest(); //BadRequest is 400 status code
            }
            await _bookRepository.Update(book);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            var bookToDelete = await _bookRepository.Get(id);
            if (bookToDelete == null)
            {
                return NotFound();

            }
            await _bookRepository.Delete(bookToDelete.Id);
            return NoContent();
        }


    }
}
