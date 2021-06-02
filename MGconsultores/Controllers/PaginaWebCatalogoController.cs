using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGconsultores.Controllers
{
    public class PaginaWebCatalogoController : Controller
    {
        // GET: PaginaWebCatalogo
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaginaWebCatalogo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaginaWebCatalogo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaginaWebCatalogo/Create
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

        // GET: PaginaWebCatalogo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaginaWebCatalogo/Edit/5
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

        // GET: PaginaWebCatalogo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaginaWebCatalogo/Delete/5
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
