using BooksAndAuthors.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndAuthors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        [HttpGet]
        [ProducesResponseType(statusCode: 400, type: typeof(BadRequestResult))]
        public  IActionResult GetBooks()
        {
            try
            {
                return Ok(_bookRepository.GetBooks());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Authors")]
        [ProducesResponseType(statusCode: 400, type: typeof(BadRequestResult))]
        public IActionResult GetAuthors()
        {
            try
            {
                return Ok(_bookRepository.GetAuthors());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("BooksByStoredProc")]
        [ProducesResponseType(statusCode: 400, type: typeof(BadRequestResult))]
        public IActionResult SPGetBooks()
        {
            try
            {
                return Ok(_bookRepository.GetBooksByStoredProc());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("AuthorsByStoredProc")]
        [ProducesResponseType(statusCode: 400, type: typeof(BadRequestResult))]
        public IActionResult SPGetAuthors()
        {
            try
            {
                return Ok(_bookRepository.GetAuthorsByStoredProc());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Total")]
        [ProducesResponseType(statusCode: 400,type:typeof(BadRequestResult))]
        public IActionResult GetTotalPrice()
        {
            try
            {
                return Ok(_bookRepository.GetTotalPrice());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
