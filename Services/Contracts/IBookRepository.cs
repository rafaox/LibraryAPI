using LibraryApi.Services.Base;
using LibraryApi.Services.Filter;
using LibraryApi.Services.ViewModels;

namespace LibraryApi.Services.Contracts
{
    public interface IBookRepository
    {
        Task<PagedResponseModel<BookViewModel>> GetAllBooks(BookFilter filter);
        Task<BookViewModel> GetBookById(long id);
        Task CreateBook(RegisterBookViewModel viewModel);
        Task UpdateBook(long id, UpdateBookViewModel viewModel);
        Task DeleteBook(long id);
    }
}