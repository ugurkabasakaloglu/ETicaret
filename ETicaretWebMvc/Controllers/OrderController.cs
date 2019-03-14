using ETicaretWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretWebMvc.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderDate = i.OrderDate,
                OrderNumber = i.OrderNumber,
                OrderState = i.OrderState,
                Count = i.OrderLines.Count,
                Total = i.Total
            }).OrderByDescending(i=>i.OrderDate).ToList();
            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    UserName=i.UserName,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Sehir = i.Sehir,
                    Semt = i.Semt,
                    Mahalle = i.Mahalle,
                    PostaKodu = i.PostaKodu,
                    OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name.Length > 50 ? a.Product.Name.Substring(0, 47) + "..." : a.Product.Name,
                        Image = a.Product.Image,
                        Quantity = a.Quantity,
                        Price = a.Price
                    }).ToList()
                }).FirstOrDefault();
            return View(entity);
        }

        
        public ActionResult UpdateOrderState(int orderid,EnumOrderState orderstate)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == orderid);
            if (order!=null)
            {
                order.OrderState = orderstate;
                db.SaveChanges();
                TempData["message"] = "Bilgileriniz kayıt edildi";
                return RedirectToAction("Details",new { id=orderid});
            }
            return RedirectToAction("Index");
        }
    }
}