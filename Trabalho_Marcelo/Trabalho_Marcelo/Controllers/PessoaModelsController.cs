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
    public class PessoaModelsController : Controller
    {
        private Contexto db = new Contexto();
		IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

        // GET: PessoaModels
        public ActionResult Index()
        {
            hubContext.Clients.All.chamarTexto("Testando signalR!");
            return View(db.Pessoas.ToList());

        }

        // GET: PessoaModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaModel pessoaModel = db.Pessoas.Find(id);
            if (pessoaModel == null)
            {
                return HttpNotFound();
            }
            return View(pessoaModel);
        }

        // GET: PessoaModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,idCidade")] PessoaModel pessoaModel)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoaModel);
                db.SaveChanges();
                hubContext.Clients.All.chamarTexto("Testando signalR!");
                return RedirectToAction("Index");
            }

            return View(pessoaModel);
        }

        // GET: PessoaModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaModel pessoaModel = db.Pessoas.Find(id);
            if (pessoaModel == null)
            {
                return HttpNotFound();
            }
            return View(pessoaModel);
        }

        // POST: PessoaModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,idCidade")] PessoaModel pessoaModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoaModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoaModel);
        }

        // GET: PessoaModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaModel pessoaModel = db.Pessoas.Find(id);
            if (pessoaModel == null)
            {
                return HttpNotFound();
            }
            return View(pessoaModel);
        }

        // POST: PessoaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PessoaModel pessoaModel = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoaModel);
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
