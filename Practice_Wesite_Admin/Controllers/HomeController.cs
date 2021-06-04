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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Practice_Wesite_Admin.Controllers
{
   
    public class HomeController : Controller
    {
        private IHostingEnvironment _environment;
        private readonly ApplicationContext _context;
        //const string SessionAge = "";
        public HomeController(ApplicationContext context,IHostingEnvironment environment)
        {
            _context = context;
            _environment=environment;
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
            foreach (var item_list in p.Product_variant_specifications)
            {
                foreach (var item in item_list)
                {
                    item.ProductID = pid;
                    _context.specifications.Add(item);
                }
            }
            
            HttpContext.Session.SetInt32("SessionAge", pid);
            _context.SaveChanges();
            return View(p);
        }
        public IActionResult UpdateSubSubCat(int sub_cat)
        {
            var list_subcat_subsubcat = _context.SubCategory_SubSubcategory.Select(e => e.SubSubCategoryID).ToList();
            var list_subsubcat = _context.SubCategory_SubSubcategory.ToList().Where(e => e.SubCategoryID == sub_cat).Select(e=>e.SubSubCategoryID).ToList();
            var sub_table = _context.subSubCategories.Where(e => !(list_subcat_subsubcat.Contains(e.SubSubCategoryID))).Select(e => e.SubSubCategoryID).ToList();
            list_subsubcat.AddRange(sub_table);
            return PartialView("~/Views/Home/SubSubCategory.cshtml", _context.subSubCategories.ToList().Where(e => list_subsubcat.Contains(e.SubSubCategoryID)).ToList());
        }
        public IActionResult UpdateSubCat(int cat)
        {
            var list_cat_sub = _context.Category_subCategory.Select(e => e.SubCategoryID).ToList();
            var list_sub_cat = _context.Category_subCategory.ToList().Where(e => e.CategoryID == cat).Select(e => e.SubCategoryID).ToList();
            var sub_table = _context.subCategories.Where(e => !(list_cat_sub.Contains(e.SubCategoryID))).Select(e=>e.SubCategoryID).ToList();
            foreach(var item in sub_table)
            {
                list_sub_cat.Add(item);
            }
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
        [HttpGet]
        public IActionResult SaveFile()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult SaveFile(ICollection<IFormFile> files)
        {
            int? pid= HttpContext.Session.GetInt32("SessionAge");
            HttpContext.Session.SetInt32("SessionAge", 0);
            if(pid!=0)
                {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string Filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, Filename), FileMode.Create))
                        {
                            file.CopyToAsync(fileStream);
                            _context.images.Add(new Product_Images { ProductID = Convert.ToInt32(pid), Images = Filename.ToString() });
                            _context.SaveChanges();
                        }
                    }
                }
            }
            
            return View();
        }
    }
}
