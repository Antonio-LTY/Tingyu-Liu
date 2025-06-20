using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        // 控制器用于处理书籍相关的操作
        // 包括显示书籍列表、书籍详情、创建新书、编辑书籍和删除书籍
        // 依赖注入 ApplicationDbContext 用于访问数据库 
        private readonly ApplicationDbContext _context;
        // 构造函数注入 ApplicationDbContext
        // 通过依赖注入获取数据库上下文实例         
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 显示所有书籍
        public IActionResult Index()
        {
            var books = _context.Books
                .Include(b => b.Author)
                .Include(b => b.LibraryBranch)
                .ToList();
            return View(books);
        }

        // 显示书籍详情
        public IActionResult Details(int id)
        {
            var book = _context.Books
                .Include(b => b.Author)
                .Include(b => b.LibraryBranch)
                .FirstOrDefault(b => b.BookId == id);
            if (book == null) return NotFound();
            return View(book);
        }

        // 显示创建新书的表单
        public IActionResult Create()
        {
            // 可传递作者和分馆下拉列表到视图
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Branches = _context.LibraryBranches.ToList();
            return View();
        }

        // 处理创建新书的表单提交
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Branches = _context.LibraryBranches.ToList();
            return View(book);
        }

        // 显示编辑书籍的表单
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Branches = _context.LibraryBranches.ToList();
            return View(book);
        }

        // 处理编辑书籍的表单提交
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Branches = _context.LibraryBranches.ToList();
            return View(book);
        }

        // 显示删除确认页
        public IActionResult Delete(int id)
        {
            var book = _context.Books
                .Include(b => b.Author)
                .Include(b => b.LibraryBranch)
                .FirstOrDefault(b => b.BookId == id);
            if (book == null) return NotFound();
            return View(book);
        }

        // 处理删除操作
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}