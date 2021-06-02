using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGconsultores.Controllers
{
    public class TiendasVirtualesController : Controller
    {
        // GET: TiendasVirtuales
        public ActionResult Index()
        {
            return View();
        }

        // GET: TiendasVirtuales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TiendasVirtuales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiendasVirtuales/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TiendasVirtuales/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TiendasVirtuales/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TiendasVirtuales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TiendasVirtuales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
