using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCFundamentals.Models;
using System.Web.UI.WebControls.Expressions;

namespace MVCFundamentals.Controllers
{ 
    public class HomeController : Controller
    {
        private sampleEntities db = new sampleEntities();

        public string Search { get; private set; }

        // GET: Home
        public async Task<ActionResult> Index(string searchBy, string search)
        {
            if (searchBy == "Gender")

            {
                return View(db.Workers.Where(x => x.Gender == search || search == null).ToList());
            }
            else
            {
                return View(db.Workers.Where(x => x.Name.StartsWith(search) || search == null).ToList());

            }



        }

        // GET: Home/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = await db.Workers.FindAsync(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Gender,Email")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(worker);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(worker);
        }

        // GET: Home/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = await db.Workers.FindAsync(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Gender,Email")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        // GET: Home/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = await db.Workers.FindAsync(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Worker worker = await db.Workers.FindAsync(id);
            db.Workers.Remove(worker);
            await db.SaveChangesAsync();
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
