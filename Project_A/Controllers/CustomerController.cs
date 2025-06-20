using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 显示所有客户
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        // 显示客户详情
        public IActionResult Details(int id)
        {
            var customer = _context.Customers
                .FirstOrDefault(c => c.CustomerId == id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        // 显示创建新客户的表单
        public IActionResult Create()
        {
            return View();
        }

        // 处理创建新客户的表单提交
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // 显示编辑客户的表单
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        // 处理编辑客户的表单提交
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // 显示删除客户的确认页面
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        // 处理删除客户的确认提交
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}