namespace Contactos8.Backend.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web.Mvc;
    using Contactos8.Backend.Models;
    using Contactos8.Domain.Models;

    [Authorize]
    public class BrouchuresController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Brouchures
        public async Task<ActionResult> Index()
        {
            var brouchures = db.Brouchures.Include(b => b.Perfil);
            return View(await brouchures.ToListAsync());
        }

        // GET: Brouchures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brouchure brouchure = await db.Brouchures.FindAsync(id);
            if (brouchure == null)
            {
                return HttpNotFound();
            }
            return View(brouchure);
        }

        // GET: Brouchures/Create
        public ActionResult Create()
        {
            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Name");
            return View();
        }

        // POST: Brouchures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BrouchureId,PerfilId,BrochureDescription,LastUpdate")] Brouchure brouchure)
        {
            if (ModelState.IsValid)
            {
                db.Brouchures.Add(brouchure);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Name", brouchure.PerfilId);
            return View(brouchure);
        }

        // GET: Brouchures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brouchure brouchure = await db.Brouchures.FindAsync(id);
            if (brouchure == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Name", brouchure.PerfilId);
            return View(brouchure);
        }

        // POST: Brouchures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BrouchureId,PerfilId,BrochureDescription,LastUpdate")] Brouchure brouchure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brouchure).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Name", brouchure.PerfilId);
            return View(brouchure);
        }

        // GET: Brouchures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brouchure brouchure = await db.Brouchures.FindAsync(id);
            if (brouchure == null)
            {
                return HttpNotFound();
            }
            return View(brouchure);
        }

        // POST: Brouchures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Brouchure brouchure = await db.Brouchures.FindAsync(id);
            db.Brouchures.Remove(brouchure);
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
