using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETicaretWebMvc.Models;

namespace ETicaretWebMvc.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file,Product product)
        {
            var productImagePath = string.Empty;
            if (file != null && file.ContentLength > 0)
            {
                var extensition = Path.GetExtension(file.FileName);
                
                if (extensition == ".jpg" || extensition == ".png")
                {
                    var folder = Server.MapPath("~/Upload");
                    var randomfilename = Path.GetRandomFileName();
                    var filename = Path.ChangeExtension(randomfilename, ".jpg");

                    var path = Path.Combine(folder, filename);

                    //var filename = Path.GetFileName(file.FileName);
                    //var path = Path.Combine(Server.MapPath("~/upload"), filename);

                    file.SaveAs(path);
                    productImagePath = filename;
                }
                else
                {
                    ViewData["message"] = "Resim dosyası seçiniz.";
                }
            }
            else
            {
                ViewData["message"] = "Bir dosya seçiniz";
            }

            //veritabanı kayıt işlemini
            //Product => productid , image = filename
            //product nesnesini veritanına kayıt et.
            //<img src="/upload/@image">
            var dbProduct = new Product();
            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
            dbProduct.Stock = product.Stock;
            dbProduct.IsHome = product.IsHome;
            dbProduct.IsApproved = product.IsApproved;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.Image = productImagePath;
            db.Products.Add(dbProduct);
            db.SaveChanges();
                return RedirectToAction("Index");
         
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, Product product)
        {
            var productImagePath = string.Empty;
            if (file != null && file.ContentLength > 0)
            {
                var extensition = Path.GetExtension(file.FileName);
                if (extensition == ".jpg" || extensition == ".png")
                {
                    var folder = Server.MapPath("~/Upload");
                    var randomfilename = Path.GetRandomFileName();
                    var filename = Path.ChangeExtension(randomfilename, ".jpg");
                    var path = Path.Combine(folder, filename);
                    file.SaveAs(path);
                    productImagePath = filename;
                }
                else
                {
                    ViewData["message"] = "Resim dosyası seçiniz.";
                }
            }
            else
            {
                ViewData["message"] = "Bir dosya seçiniz";
            }
            var dbProduct = db.Products.FirstOrDefault(i => i.Id == product.Id);
            var dosyaAd = dbProduct.Image;
            System.IO.File.Exists(Server.MapPath("~/Upload/" + dosyaAd));
            System.IO.File.Delete(Server.MapPath("~/Upload/" + dosyaAd));
            dbProduct.Id = product.Id;
            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
            dbProduct.Stock = product.Stock;
            dbProduct.IsHome = product.IsHome;
            dbProduct.IsApproved = product.IsApproved;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.Image = productImagePath;
            db.SaveChanges();
            return RedirectToAction("Index");         }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            var dosyaAd = product.Image;
            System.IO.File.Exists(Server.MapPath("~/Upload/" +dosyaAd));
            System.IO.File.Delete(Server.MapPath("~/Upload/" + dosyaAd));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
