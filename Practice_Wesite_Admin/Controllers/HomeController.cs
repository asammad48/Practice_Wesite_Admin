using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practice_Wesite_Admin.Models;
using Practice_Wesite_Admin.Data;
namespace Practice_Wesite_Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Product_and__subcat p = new Product_and__subcat();
            p.categories = _context.Categories.ToList();
            p.subCategories = _context.subCategories.ToList();
            p.subSubCategories = _context.subSubCategories.ToList();
            return View(p);
        }
        [HttpPost]
        public IActionResult SaveProduct_withCat(Product_and__subcat p)
        {
            p.product.CreationDate = DateTime.Now;
            _context.products.Add(p.product);
            return View(p);
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
