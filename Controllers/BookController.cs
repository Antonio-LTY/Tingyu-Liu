// BookController.cs
 using Microsoft.AspNetCore.Mvc;
 using LibraryManagement.Models;
 using LibraryManagement.ViewModels;
   
 namespace LibraryManagement.Controllers
{
public class BookController : Controller
{
    public IActionResult Details(int id)
    {
    // Simulated data access
     Book book = new Book
    {
    BookId = id,
    Title = "Sample Book",
    AuthorId = 1,
    LibraryBranchId = 1
    };
    Author author = new Author
    {
    AuthorId = 1,
    Name = "John Doe"
    };

    LibraryBranch branch = new LibraryBranch
    {
    LibraryBranchId = 1,
    BranchName = "Main Branch"
    };

    BookViewModel viewModel = new BookViewModel
    {
    BookId = book.BookId,
    Title = book.Title,
    AuthorName = author.Name,
    BranchName = branch.BranchName
    };

    return View(viewModel);
    }
}
}