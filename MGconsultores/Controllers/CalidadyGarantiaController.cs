﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGconsultores.Controllers
{
    public class CalidadyGarantiaController : Controller
    {
        // GET: CalidadyGarantía
        public ActionResult Index()
        {
            return View();
        }

        // GET: CalidadyGarantía/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CalidadyGarantía/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalidadyGarantía/Create
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

        // GET: CalidadyGarantía/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CalidadyGarantía/Edit/5
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

        // GET: CalidadyGarantía/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CalidadyGarantía/Delete/5
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
