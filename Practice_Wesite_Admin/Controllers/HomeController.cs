using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practice_Wesite_Admin.Models;
using Practice_Wesite_Admin.Data;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
namespace Practice_Wesite_Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            Product_and__subcat p = new Product_and__subcat();
            p.categories = _context.Categories.ToList();
            p.subCategories = _context.subCategories.ToList();
            p.subSubCategories = _context.subSubCategories.ToList();
            p.variants = _context.variants.ToList();
            return View(p);
        }
        [HttpPost]
        public IActionResult Index(Product_and__subcat p)
        {
            var files = HttpContext.Request.Form["Form_Images"];
            p.product.CreationDate = DateTime.Now;
            p.product.SubSubCategoryID = p.subSubCategory.SubSubCategoryID;
            p.product.Status = 1;
            _context.products.Add(p.product);
            _context.Category_subCategory.Add(new Category_subCategory { CategoryID = p.category.CategoryID, SubCategoryID = p.subCategory.SubCategoryID, status = 1 });
            _context.SubCategory_SubSubcategory.Add(new SubCategory_SubSubcategory { SubCategoryID = p.subCategory.SubCategoryID, SubSubCategoryID = p.subSubCategory.SubSubCategoryID, status = 1 });
            _context.SaveChanges();
            int pid = p.product.ProductID;
            foreach(var item in p.product_Variants)
            {
                item.ProductID = pid;
                item.status = 1;
                _context.product_Variants.Add(item);
            }
            foreach(var item_list in p.Product_variant_specifications)
            {
                foreach(var item in item_list)
                {
                    item.ProductID = pid;
                    _context.specifications.Add(item);
                }
            }
            _context.SaveChanges();
            return View(p);
        }
        public IActionResult UpdateSubSubCat(int sub_cat)
        {
            var list_subsubcat = _context.SubCategory_SubSubcategory.ToList().Where(e => e.SubCategoryID == sub_cat).Select(e=>e.SubSubCategoryID).ToList();

            return PartialView("~/Views/Home/SubSubCategory.cshtml", _context.subSubCategories.ToList().Where(e => list_subsubcat.Contains(e.SubSubCategoryID)).ToList());
        }
        public IActionResult UpdateSubCat(int cat)
        {
            var list_sub_cat = _context.Category_subCategory.ToList().Where(e => e.CategoryID == cat).Select(e => e.SubCategoryID).ToList();
            return PartialView("~/Views/Home/SubCategory.cshtml", _context.subCategories.Where(e => list_sub_cat.Contains(e.SubCategoryID)).ToList());
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
