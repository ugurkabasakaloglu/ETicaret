using ETicaretWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretWebMvc.Controllers
{
    public class HomeController : Controller
    {
        DataContext _db = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            var srg = _db.Products.Where(i => i.IsApproved == true)
                .Select(i => new ProductView()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image == null ? "1.jpg" : i.Image,
                    CategoryId = i.CategoryId
                }).ToList();
            return View(srg);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var srg = _db.Products.Where(s=>s.Id==id).FirstOrDefault();
            return View(srg);
        }

        // GET: List
        public ActionResult List(int? id)
        {
            var srg = _db.Products.Where(i => i.IsApproved == true)
                .Select(i => new ProductView()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image==null?"1.jpg":i.Image,
                    CategoryId = i.CategoryId
                }).AsQueryable();

            if (id!=null)
            {
                srg = srg.Where(i=>i.CategoryId==id);
            }

            return View(srg.ToList());
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(_db.Categories.ToList());
        }
    }
}