using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Laboratoire3_Guitare.Models;

namespace Laboratoire3_Guitare.Controllers
{
    public class SellersController : Controller
    {
        // GET: Seller
        public ActionResult Index()
        {
            return View(DB.Sellers.ToList().OrderBy(e => e.Name));
        }

        // GET: Seller/Details/5
        public ActionResult Details(int id)
        {
            Seller seller = DB.Sellers.Get(id);

            if (seller == null) { return HttpNotFound(); }


            return View(seller);
        }

        // GET: Seller/Create
        public ActionResult Create()
        {
            return View(new Seller());
        }

        // POST: Seller/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seller vendeur)
        {
            if (ModelState.IsValid)
            {
                DB.Sellers.Add(vendeur);
                return RedirectToAction("Index");
            }
            else return View(vendeur);
        }


    
        // GET: Seller/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            Seller seller = DB.Sellers.Get(id.Value);

            if (seller == null) { return HttpNotFound(); }

            return View(seller);
        }

        // POST: Seller/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Seller seller)
        {
            if (ModelState.IsValid)
            {
                DB.Sellers.Update(seller);

                return RedirectToAction("Index");
            }
            return View(seller);
          
        }

        // GET: Seller/Delete/5
        public ActionResult Delete(int id)
        {

            Seller seller = DB.Sellers.Get(id);

            var list = DB.Guitars.ToList();
            List<int> ids = new List<int>();

            foreach (var item in list)
            {
                if (item.SellerId == seller.Id)
                {
                    ids.Add(item.Id);
                }
            }

            foreach (var elem in ids)
            {
                DB.Guitars.Delete(elem);
            }

            DB.Sellers.Delete(id);

            return RedirectToAction("Index");

        }
    }
}
