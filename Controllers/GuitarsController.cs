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
    public class GuitarsController : Controller
    {
        // GET: Guitar
        public ActionResult Index()
        {
            return View(DB.Guitars.ToList());
        }

        // GET: Guitar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guitar guitar=DB.Guitars.Get(id.Value);
            if (guitar != null)
            {
                return View(guitar);
            }
            return HttpNotFound();

        }

        // GET: Guitar/Create
        public ActionResult Create()
        {
            return View(new Guitar());
        }

        // POST: Guitar/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Guitar guitar)
        {
                if (ModelState.IsValid)
                {
                    DB.Guitars.Add(guitar);
                    return RedirectToAction("Index");
                }else return View(guitar);
        }

        // GET: Guitar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Guitar guitar = DB.Guitars.Get(id.Value);
            


            if (guitar == null) { return HttpNotFound(); }
            return View(guitar);
        }

        // POST: Guitar/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost]

        public ActionResult Edit(Guitar guitar)
        {
            if(ModelState.IsValid)
            {
                DB.Guitars.Update(guitar);

                return RedirectToAction("Index");
            }

            return View(guitar);
          
        }

        // GET: Guitar/Delete/5
        public ActionResult Delete(int id)
        {
            DB.Guitars.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
