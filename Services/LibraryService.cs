using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IBookRepository _repo;

        public LibraryService(IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task AddBookAsync(Book book)
        {
            await _repo.AddAsync(book);
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task IssueBookAsync(int id)
        {
            var book = await _repo.GetByIdAsync(id);

            if (book == null)
                throw new Exception("Book not found");

            if (book.IsIssued)
                throw new Exception("Already issued");

            book.IsIssued = true;
            await _repo.UpdateAsync(book);
        }

        public async Task ReturnBookAsync(int id)
        {
            var book = await _repo.GetByIdAsync(id);

            if (book == null)
                throw new Exception("Book not found");

            if (!book.IsIssued)
                throw new Exception("Book not issued");

            book.IsIssued = false;
            await _repo.UpdateAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}