using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Interfaces
{
    public interface ILibraryService
    {
        Task AddBookAsync(Book book);

        Task<List<Book>> GetBooksAsync();

        Task<Book?> GetBookByIdAsync(int id);

        Task IssueBookAsync(int id);

        Task ReturnBookAsync(int id);

        Task DeleteBookAsync(int id);
    }
}