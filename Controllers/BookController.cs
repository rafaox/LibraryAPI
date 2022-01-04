using Microsoft.AspNetCore.Mvc;
using LibraryApi.Services.Base;
using LibraryApi.Services.Contracts;
using LibraryApi.Services.Filter;
using LibraryApi.Services.ViewModels;

namespace LibraryApi.Controllers
{
    [ApiController]
    public class BookController : BaseController
    {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost]
        public async Task<BaseResponse<string>> Create([FromBody] RegisterBookViewModel viewModel)
        {
            await _bookRepository.CreateBook(viewModel);
            return BaseResponse<string>.Created("Registration successful");
        }

        [HttpGet]
        public async Task<BaseResponse<PagedResponseModel<BookViewModel>>> GetAll([FromQuery] BookFilter filter)
        {
            PagedResponseModel<BookViewModel> books = await _bookRepository.GetAllBooks(filter);
            return BaseResponse<PagedResponseModel<BookViewModel>>.Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<BaseResponse<BookViewModel>> GetById(long id)
        {
            BookViewModel book = await _bookRepository.GetBookById(id);
            return BaseResponse<BookViewModel>.Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse<string>> Update(long id, [FromBody] UpdateBookViewModel viewModel)
        {
            await _bookRepository.UpdateBook(id, viewModel);
            return BaseResponse<string>.Ok("Book updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> Delete(long id)
        {
            await _bookRepository.DeleteBook(id);
            return BaseResponse<string>.Ok("Book deleted successfully");
        }
    }
}