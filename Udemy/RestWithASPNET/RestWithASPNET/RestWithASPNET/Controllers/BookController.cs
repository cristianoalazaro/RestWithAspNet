using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Hypermedia.Filters;
using RestWithASPNET.Services;
using RestWithASPNET.Utils;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:ApiVersion}")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {

            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get([FromQuery] ParamsPagination paramsPagination)
        {
            return Ok(_bookService.FindAll(paramsPagination));
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id) 
        { 
            var book = _bookService.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookService.Create(book));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookService.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
    }
}
