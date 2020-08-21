using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTrack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTrack.Controllers
{
    public class TarkovController : Controller
    {
        // GET: Tarkov
        public ActionResult Index()
        {
            List<TarkovStats> model =  TarkovRepository.GetTarkovStats();
                return View(model);
        }



        public ActionResult NewStat()
        {
            return View("Button");
        }




























        public ActionResult Increment(int id)
        {
            TarkovRepository.IncrementCounter(id);
                return RedirectToAction(nameof(Index));
        }

        // GET: Tarkov/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tarkov/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarkov/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tarkov/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tarkov/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tarkov/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tarkov/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}