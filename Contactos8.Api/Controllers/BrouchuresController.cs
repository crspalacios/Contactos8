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
    public class BrouchuresController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Brouchures
        public IQueryable<Brouchure> GetBrouchures()
        {
            return db.Brouchures;
        }

        // GET: api/Brouchures/5
        [ResponseType(typeof(Brouchure))]
        public async Task<IHttpActionResult> GetBrouchure(int id)
        {
            Brouchure brouchure = await db.Brouchures.FindAsync(id);
            if (brouchure == null)
            {
                return NotFound();
            }

            return Ok(brouchure);
        }

        // PUT: api/Brouchures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBrouchure(int id, Brouchure brouchure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brouchure.BrouchureId)
            {
                return BadRequest();
            }

            db.Entry(brouchure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrouchureExists(id))
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

        // POST: api/Brouchures
        [ResponseType(typeof(Brouchure))]
        public async Task<IHttpActionResult> PostBrouchure(Brouchure brouchure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Brouchures.Add(brouchure);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = brouchure.BrouchureId }, brouchure);
        }

        // DELETE: api/Brouchures/5
        [ResponseType(typeof(Brouchure))]
        public async Task<IHttpActionResult> DeleteBrouchure(int id)
        {
            Brouchure brouchure = await db.Brouchures.FindAsync(id);
            if (brouchure == null)
            {
                return NotFound();
            }

            db.Brouchures.Remove(brouchure);
            await db.SaveChangesAsync();

            return Ok(brouchure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrouchureExists(int id)
        {
            return db.Brouchures.Count(e => e.BrouchureId == id) > 0;
        }
    }
}