namespace Contactos8.Backend.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web.Mvc;
    using Contactos8.Backend.Models;
    using Contactos8.Domain.Models;
    using Contactos8.Backend.Helpers;
    using System;

    [Authorize]
    public class PerfilsController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Perfils
        public async Task<ActionResult> Index()
        {
            return View(await db.Perfils.ToListAsync());
        }

        // GET: Perfils/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var  perfil = await db.Perfils.FindAsync(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // GET: Perfils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PerfilView view)
        {
            if (ModelState.IsValid)
            {

                var pic = string.Empty;
                var folder = "~/Content/ImagePerfil";

                if (view.ImagePerfilFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImagePerfilFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var perfil = ToPerfil(view);
                perfil.ImagePerfil = pic;

                db.Perfils.Add(perfil);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        private Perfil ToPerfil(PerfilView view)
        {
            return new Perfil
            {
                Name = view.Name,
                LastName = view.LastName,
                ImagePerfil = view.ImagePerfil,
                PerfilId = view.PerfilId,
                Addresses = view.Addresses,
                Brouchures = view.Brouchures,
                Emails = view.Emails,
                Jobs = view.Jobs,
                Phones = view.Phones,
                Socials = view.Socials, 
                Urls = view.Urls,

            };
        }

        // GET: Perfils/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = await db.Perfils.FindAsync(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            var view = ToView(perfil);
            return View(view);
        }

        private PerfilView ToView(Perfil perfil)
        {
            return new PerfilView
            {
                Name = perfil.Name,
                LastName = perfil.LastName,
                ImagePerfil = perfil.ImagePerfil,
                PerfilId = perfil.PerfilId,
                Addresses = perfil.Addresses,
                Brouchures = perfil.Brouchures,
                Emails = perfil.Emails,
                Jobs = perfil.Jobs,
                Phones = perfil.Phones,
                Socials = perfil.Socials,
                Urls = perfil.Urls,

            };
        }

        // POST: Perfils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PerfilView view)
        {
            if (ModelState.IsValid)
            {
                var pic = view.ImagePerfil;
                var folder = "~/Content/ImagePerfil";

                if (view.ImagePerfilFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImagePerfilFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var perfil = ToPerfil(view);
                perfil.ImagePerfil = pic;

                db.Entry(perfil).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(view);
        }

        // GET: Perfils/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = await db.Perfils.FindAsync(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: Perfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Perfil perfil = await db.Perfils.FindAsync(id);
            db.Perfils.Remove(perfil);
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
