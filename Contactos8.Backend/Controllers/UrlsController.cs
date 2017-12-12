namespace Contactos8.Backend.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web.Mvc;
    using Contactos8.Backend.Models;
    using Contactos8.Domain.Models;
        
    [Authorize]
    public class UrlsController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Urls
        public async Task<ActionResult> Index()
        {
            var urls = db.Urls.Include(u => u.Perfil);
            return View(await urls.ToListAsync());
        }

        // GET: Urls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url url = await db.Urls.FindAsync(id);
            if (url == null)
            {
                return HttpNotFound();
            }
            return View(url);
        }

        // GET: Urls/Create
        public ActionResult Create()
        {
            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Name");
            return View();
        }

        // POST: Urls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UrlId,PerfilId,DescriptionUrl,NameUrl")] Url url)
        {
            if (ModelState.IsValid)
            {
                db.Urls.Add(url);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Name", url.PerfilId);
            return View(url);
        }

        // GET: Urls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url url = await db.Urls.FindAsync(id);
            if (url == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Name", url.PerfilId);
            return View(url);
        }

        // POST: Urls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UrlId,PerfilId,DescriptionUrl,NameUrl")] Url url)
        {
            if (ModelState.IsValid)
            {
                db.Entry(url).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Name", url.PerfilId);
            return View(url);
        }

        // GET: Urls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url url = await db.Urls.FindAsync(id);
            if (url == null)
            {
                return HttpNotFound();
            }
            return View(url);
        }

        // POST: Urls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Url url = await db.Urls.FindAsync(id);
            db.Urls.Remove(url);
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
