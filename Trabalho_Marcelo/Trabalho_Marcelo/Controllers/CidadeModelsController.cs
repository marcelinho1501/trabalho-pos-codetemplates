using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trabalho_Marcelo.Hubs;
using Microsoft.AspNet.SignalR;
using Trabalho_Marcelo.Models;

namespace Trabalho_Marcelo.Controllers
{
    public class CidadeModelsController : Controller
    {
        private Contexto db = new Contexto();
		IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

        // GET: CidadeModels
        public ActionResult Index()
        {
            return View(db.Cidades.ToList());
        }

        // GET: CidadeModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CidadeModel cidadeModel = db.Cidades.Find(id);
            if (cidadeModel == null)
            {
                return HttpNotFound();
            }
            return View(cidadeModel);
        }

        // GET: CidadeModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CidadeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Uf")] CidadeModel cidadeModel)
        {
            if (ModelState.IsValid)
            {
                db.Cidades.Add(cidadeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidadeModel);
        }

        // GET: CidadeModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CidadeModel cidadeModel = db.Cidades.Find(id);
            if (cidadeModel == null)
            {
                return HttpNotFound();
            }
            return View(cidadeModel);
        }

        // POST: CidadeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Uf")] CidadeModel cidadeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidadeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cidadeModel);
        }

        // GET: CidadeModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CidadeModel cidadeModel = db.Cidades.Find(id);
            if (cidadeModel == null)
            {
                return HttpNotFound();
            }
            return View(cidadeModel);
        }

        // POST: CidadeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CidadeModel cidadeModel = db.Cidades.Find(id);
            db.Cidades.Remove(cidadeModel);
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
