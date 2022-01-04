using Microsoft.EntityFrameworkCore;
using LibraryApi.DataAccessLayer.Models;
using LibraryApi.Services.Base;
using LibraryApi.Services.Contracts;
using LibraryApi.Services.Errors;
using LibraryApi.Services.Extensions;
using LibraryApi.Services.Filter;
using LibraryApi.Services.ViewModels;

namespace LibraryApi.Services.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IAsyncRepository _repository;

        public BookRepository(IAsyncRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateBook(RegisterBookViewModel viewModel)
        {
            if (await _repository.GetQueryable<Book>().AnyAsync(b => b.Isbn == viewModel.Isbn))
                throw new AppException($@"ISBN ${viewModel.Isbn} is already taken");

            var book = new Book(
                default(long),
                viewModel.Title,
                viewModel.Summary,
                viewModel.Author,
                viewModel.Isbn,
                DateTime.Now
            );

            await _repository.AddAsync(book);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteBook(long id)
        {
            var book = await _repository.GetByIdAsync<Book>(id);

            if (book == null)
                throw new AppException("Book not found");

            _repository.Remove(book);
            await _repository.SaveChangesAsync();
        }

        public async Task<PagedResponseModel<BookViewModel>> GetAllBooks(BookFilter filter)
        {
            var query = _repository.GetQueryable<Book>();
            var booksPaging = await IQueryableExtensions.ReadPage<Book>(filter, func =>
            {
                if (!string.IsNullOrWhiteSpace(filter.Title))
                    query = query.Where(b => b.Title.Contains(filter.Title));

                if (!string.IsNullOrWhiteSpace(filter.Summary))
                    query = query.Where(b => b.Summary.Contains(filter.Summary));

                if (!string.IsNullOrWhiteSpace(filter.Author))
                    query = query.Where(b => b.Author.Contains(filter.Author));

                if (!string.IsNullOrWhiteSpace(filter.Isbn))
                    query = query.Where(b => b.Isbn.Contains(filter.Isbn));

                return filter.OrderByDescending.Value ? query.OrderByDescending(q => q.Id) : query;
            });

            var paging = new PageData {
                Page = booksPaging.Paging.Page,
                PageSize = booksPaging.Paging.PageSize,
                Total = booksPaging.Paging.Total
            };

            var books = booksPaging.Data is null
                ? Enumerable.Empty<BookViewModel>()
                : (from b in booksPaging.Data
                   select new BookViewModel
                   {
                       Id = b.Id,
                       Title = b.Title,
                       Summary = b.Summary,
                       Author = b.Author,
                       Isbn = b.Isbn,
                       CreatedAt = b.CreatedAt
                   }).AsEnumerable();

            return new PagedResponseModel<BookViewModel>(paging, books);
        }

        public async Task<BookViewModel> GetBookById(long id)
        {
            var book = await _repository.GetByIdAsync<Book>(id);

            if (book is null)
                throw new AppException("Book not found");

            return new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Summary = book.Summary,
                Author = book.Author,
                Isbn = book.Isbn,
                CreatedAt = book.CreatedAt
            };
        }

        public async Task UpdateBook(long id, UpdateBookViewModel viewModel)
        {
            var book = await _repository.GetByIdAsync<Book>(id);

            if (book is null)
                throw new AppException("Book not found");

            if (viewModel.Isbn != book.Isbn && await _repository.GetQueryable<Book>().AnyAsync(b => b.Isbn == viewModel.Isbn))
                throw new AppException($@"ISBN ${viewModel.Isbn} is already taken");

            if (!string.IsNullOrWhiteSpace(viewModel.Title))
                book.SetTitle(viewModel.Title);

            if (!string.IsNullOrWhiteSpace(viewModel.Summary))
                book.SetSummary(viewModel.Summary);

            if (!string.IsNullOrWhiteSpace(viewModel.Author))
                book.SetAuthor(viewModel.Author);

            if (!string.IsNullOrWhiteSpace(viewModel.Isbn))
                book.SetIsbn(viewModel.Isbn);

            _repository.Update(book);
            await _repository.SaveChangesAsync();
        }
    }
}