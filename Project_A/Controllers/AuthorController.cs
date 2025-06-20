using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 显示所有作者
        public IActionResult Index()
        {
            var authors = _context.Authors.ToList();
            return View(authors);
        }

        // 显示作者详情
        public IActionResult Details(int id)
        {
            var author = _context.Authors
                .FirstOrDefault(a => a.AuthorId == id);
            if (author == null) return NotFound();
            return View(author);
        }

        // 显示创建新作者的表单
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Add(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // 显示编辑作者的表单
        public IActionResult Edit(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null) return NotFound();
            return View(author);
        }

        // 处理编辑作者的表单提交
        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Update(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // 显示删除作者的确认页面
        public IActionResult Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null) return NotFound();
            return View(author);
        }
        
        // 处理删除作者的确认提交
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}