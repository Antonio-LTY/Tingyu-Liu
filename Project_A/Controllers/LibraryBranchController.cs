using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers
{
    public class LibraryBranchController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LibraryBranchController(ApplicationDbContext context)
        {
            _context = context;
        }
        // 控制器用于处理图书馆分馆相关的操作
        // 包括显示分馆列表、分馆详情、创建新分馆、编辑分馆和删除分馆
        public IActionResult Index()
        {
            var branches = _context.LibraryBranches.ToList();
            return View(branches);
        }
        // 显示分馆详情 
        public IActionResult Details(int id)
        {
            var branch = _context.LibraryBranches
                .FirstOrDefault(b => b.LibraryBranchId == id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        // 显示创建新分馆的表单
        // 该方法返回一个视图，显示一个表单供用户输入新分馆的信息
        // 该表单提交后会调用 Create 方法处理表单数据
        public IActionResult Create()
        {
            return View();
        }

        // 处理创建新分馆的表单提交
        // 该方法接收一个 LibraryBranch 对象作为参数    
        [HttpPost]
        public IActionResult Create(LibraryBranch branch)
        {
            if (ModelState.IsValid)
            {
                _context.LibraryBranches.Add(branch);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branch);
        }
   
        // 显示编辑分馆的表单
        // 该方法接收一个分馆 ID，查找对应的分馆记录
        public IActionResult Edit(int id)
        {
            var branch = _context.LibraryBranches.Find(id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        // 处理编辑分馆的表单提交
        // 该方法接收一个 LibraryBranch 对象作为参数
        [HttpPost]
        public IActionResult Edit(LibraryBranch branch)
        {
            if (ModelState.IsValid)
            {
                _context.LibraryBranches.Update(branch);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        // 显示删除分馆的确认页面   
        public IActionResult Delete(int id)
        {
            var branch = _context.LibraryBranches.Find(id);
            if (branch == null) return NotFound();
            return View(branch);
        }
        
        // 处理删除分馆的确认提交
        // 该方法接收一个分馆 ID，查找对应的分馆记录
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var branch = _context.LibraryBranches.Find(id);
            if (branch != null)
            {
                _context.LibraryBranches.Remove(branch);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}