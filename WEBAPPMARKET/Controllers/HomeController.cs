using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WEBAPPMARKET.Models;

namespace WEBAPPMARKET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MYDBCONTEXT _context;

        public HomeController(ILogger<HomeController> logger, MYDBCONTEXT context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(PRODUCTS product1) 
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product1);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product1);
        }
        public IActionResult Delete(int id)
        {
            var productid = _context.Products.FirstOrDefault(s=>s.ID == id);

            if (productid!=null)
            {
                _context.Products.Remove(productid);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var productid = _context.Products.FirstOrDefault(s => s.ID == id);
            if (productid == null)
            {
                return RedirectToAction("Index");
            }
            return View(productid);
        }
        [HttpPost]
        public IActionResult Update(PRODUCTS updatedProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(updatedProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updatedProduct);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}