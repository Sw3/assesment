using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using assesment.DataAccessLayer;
using assesment.Models;

namespace assesment.Controllers
{
    public class ProductsController : Controller
    {
        private WebShopContext db = new WebShopContext();

        // GET: Products
        public ActionResult Index()
        {
            if ((System.Web.HttpContext.Current.Session["DataAccess"]) == null)
            {
                System.Web.HttpContext.Current.Session["DataAccess"] = "DB";
                Session["products"] = "";
                Session["products"] = "";

            }
            if ((System.Web.HttpContext.Current.Session["DataAccess"]) == "DB")
                    return View(db.Products.ToList());
            else
            {
                string[] ProductParams = Session["products"].ToString().Split(',');
           
                List<Product> products = new List<Product>();
                if (ProductParams.Count() > 1)
                {
                    for (int i = 0; i <= ProductParams.Count(); i++)
                    {
                        try
                        {
                            Product product = new Product();
                            product.productNumber = int.Parse(ProductParams[i]);
                            i++;
                            product.title = ProductParams[i];
                            i++;
                            product.price = Double.Parse(ProductParams[i]);
                            i++;
                            products.Add(product);
                        }
                        catch (Exception e)
                        {
                            break;
                        }
                    }

                }
                return View(products);
            }
                

        }
        // GET: Products
        public ActionResult changeDataSource()
        {
            if ((System.Web.HttpContext.Current.Session["DataAccess"]) == "DB")
            {
                (System.Web.HttpContext.Current.Session["DataAccess"]) = "Local";
            }else
            {
                (System.Web.HttpContext.Current.Session["DataAccess"]) = "DB";
            }

            return RedirectToAction("Index");
        }

        // GET: Products/Details/5
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

        // GET: Products/Create
        public ActionResult Create()
        {
            List <ProductCategory>list = db.ProductCategories.ToList();         
                IEnumerable<SelectListItem> lista = db.ProductCategories.Select(b => new SelectListItem { Value = b.ID.ToString(), Text= b.CategoryName});

            ViewData["Categories"] = lista;
            return View();
        }

        // POST: Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string ID, string productNumber, string title, double price, int Categories)
        {
            Product product = new Product { productNumber = int.Parse(productNumber), title=title, price= price, category= db.ProductCategories.Where( f => f.ID == Categories).ToList()[0] };
            if (ModelState.IsValid)
            {
                if ((System.Web.HttpContext.Current.Session["DataAccess"]) == "Local")
                {
                    System.Web.HttpContext.Current.Session["products"] += product.productNumber + ",";
                    System.Web.HttpContext.Current.Session["products"] += product.title+",";
                    System.Web.HttpContext.Current.Session["products"] += product.price + ",";
                    System.Web.HttpContext.Current.Session["products"] += product.categories + ",";
                }
                else
                {
                var r = ViewBag.Categories;
                db.Products.Add(product);
                db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Edit/5
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
            return View(product);
        }

        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,productNumber,title,price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
