using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;
using System.Data.Entity;
namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        // GET: EF
        public ActionResult Index(bool? IsActive, String keyword)
        {

            var product = new Product()
            {
                ProductName = "BM",
                Price = 3,
                Stock = 1,
                Active = true
            };

            //db.Product.Add(product);

            //var data = db.Product.ToList();
            var pkey = product.ProductId;
           // var data = db.Product.OrderByDescending(p => p.ProductId).AsQueryable();


            var data = db.Product.OrderByDescending(p => p.ProductId).AsQueryable();

            if (IsActive.HasValue)
            {
                data = data.Where(p => p.Active.HasValue ? p.Active.Value == IsActive.Value : false);
            }
            if (!String.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.ProductName.Contains(keyword));
            }
            foreach (var item in data)
            {
               item.Price =  item.Price+1;
            }
            SaveChanges();
            return View(data);
        }

        private void SaveChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    string entityName = item.Entry.Entity.GetType().Name;
                    foreach (DbValidationError err in item.ValidationErrors)
                    {
                        throw new Exception(entityName + " 類型驗證失敗: " + err.ErrorMessage);
                    }
                }

                throw;
            }
        }

        public ActionResult Detial(int id)
        {
            var data = db.Product.FirstOrDefault(p => p.ProductId == id);
            return View(data);
        }

        public ActionResult Delete(int id)
        {
           // var item = db.Product.Find(id);
            var product = db.Product.Find(id);
            // db.Product.Remove(item);
            db.OrderLine.RemoveRange(product.OrderLine);

            db.Product.Remove(product);

            SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult QueryPlan()
        {
            var data = db.Product.Include("OrderLine");
             
            return View(data);
        }
    }
}