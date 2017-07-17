using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EDBGS;

namespace EDBGS.Areas.Public.Controllers
{
    public class edsystemsController : Controller
    {
        private edbgsEntities db = new edbgsEntities();

        // GET: Public/edsystems
        public async Task<ActionResult> Index()
        {
            var edsystems = db.edsystems.Include(e => e.reserve);
            return View(await edsystems.ToListAsync());
        }

        // GET: Public/edsystems/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edsystem edsystem = await db.edsystems.FindAsync(id);
            if (edsystem == null)
            {
                return HttpNotFound();
            }
            return View(edsystem);
        }

        // GET: Public/edsystems/Create
        public ActionResult Create()
        {
            ViewBag.Reserves = new SelectList(db.reserves, "reserveid", "name");
            return View();
        }

        // POST: Public/edsystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EDSystemId,EDDNId,Name,X,Y,Z,Premit,Populated,Reserves")] edsystem edsystem)
        {
            if (ModelState.IsValid)
            {
                db.edsystems.Add(edsystem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Reserves = new SelectList(db.reserves, "reserveid", "name", edsystem.Reserves);
            return View(edsystem);
        }

        // GET: Public/edsystems/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edsystem edsystem = await db.edsystems.FindAsync(id);
            if (edsystem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Reserves = new SelectList(db.reserves, "reserveid", "name", edsystem.Reserves);
            return View(edsystem);
        }

        // POST: Public/edsystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EDSystemId,EDDNId,Name,X,Y,Z,Premit,Populated,Reserves")] edsystem edsystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edsystem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Reserves = new SelectList(db.reserves, "reserveid", "name", edsystem.Reserves);
            return View(edsystem);
        }

        // GET: Public/edsystems/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edsystem edsystem = await db.edsystems.FindAsync(id);
            if (edsystem == null)
            {
                return HttpNotFound();
            }
            return View(edsystem);
        }

        // POST: Public/edsystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            edsystem edsystem = await db.edsystems.FindAsync(id);
            db.edsystems.Remove(edsystem);
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
