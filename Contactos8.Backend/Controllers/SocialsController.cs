namespace Contactos8.Backend.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web.Mvc;
    using Contactos8.Backend.Models;
    using Contactos8.Domain.Models;


    [Authorize]
    public class SocialsController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Socials
        public async Task<ActionResult> Index()
        {
            var socials = db.Socials.Include(s => s.PerfilGeneral);
            return View(await socials.ToListAsync());
        }

        // GET: Socials/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Social social = await db.Socials.FindAsync(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        // GET: Socials/Create
        public ActionResult Create()
        {
            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Name");
            return View();
        }

        // POST: Socials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SocialiD,PerfilId,SocialDescription,SocialPerfil")] Social social)
        {
            if (ModelState.IsValid)
            {
                db.Socials.Add(social);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Name", social.PerfilId);
            return View(social);
        }

        // GET: Socials/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Social social = await db.Socials.FindAsync(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Name", social.PerfilId);
            return View(social);
        }

        // POST: Socials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SocialiD,PerfilId,SocialDescription,SocialPerfil")] Social social)
        {
            if (ModelState.IsValid)
            {
                db.Entry(social).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Name", social.PerfilId);
            return View(social);
        }

        // GET: Socials/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Social social = await db.Socials.FindAsync(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        // POST: Socials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Social social = await db.Socials.FindAsync(id);
            db.Socials.Remove(social);
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
