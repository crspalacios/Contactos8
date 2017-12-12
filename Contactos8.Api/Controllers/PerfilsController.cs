namespace Contactos8.Api.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Contactos8.Domain;
    using Contactos8.Domain.Models;


    [Authorize]
    public class PerfilsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Perfils
        public IQueryable<Perfil> GetPerfils()
        {
            return db.Perfils;
        }

        // GET: api/Perfils/5
        [ResponseType(typeof(Perfil))]
        public async Task<IHttpActionResult> GetPerfil(int id)
        {
            Perfil perfil = await db.Perfils.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        // PUT: api/Perfils/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerfil(int id, Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfil.PerfilId)
            {
                return BadRequest();
            }

            db.Entry(perfil).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Perfils
        [ResponseType(typeof(Perfil))]
        public async Task<IHttpActionResult> PostPerfil(Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Perfils.Add(perfil);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = perfil.PerfilId }, perfil);
        }

        // DELETE: api/Perfils/5
        [ResponseType(typeof(Perfil))]
        public async Task<IHttpActionResult> DeletePerfil(int id)
        {
            Perfil perfil = await db.Perfils.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            db.Perfils.Remove(perfil);
            await db.SaveChangesAsync();

            return Ok(perfil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerfilExists(int id)
        {
            return db.Perfils.Count(e => e.PerfilId == id) > 0;
        }
    }
}