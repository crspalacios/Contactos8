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
    public class SocialsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Socials
        public IQueryable<Social> GetSocials()
        {
            return db.Socials;
        }

        // GET: api/Socials/5
        [ResponseType(typeof(Social))]
        public async Task<IHttpActionResult> GetSocial(int id)
        {
            Social social = await db.Socials.FindAsync(id);
            if (social == null)
            {
                return NotFound();
            }

            return Ok(social);
        }

        // PUT: api/Socials/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSocial(int id, Social social)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != social.SocialiD)
            {
                return BadRequest();
            }

            db.Entry(social).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialExists(id))
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

        // POST: api/Socials
        [ResponseType(typeof(Social))]
        public async Task<IHttpActionResult> PostSocial(Social social)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Socials.Add(social);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = social.SocialiD }, social);
        }

        // DELETE: api/Socials/5
        [ResponseType(typeof(Social))]
        public async Task<IHttpActionResult> DeleteSocial(int id)
        {
            Social social = await db.Socials.FindAsync(id);
            if (social == null)
            {
                return NotFound();
            }

            db.Socials.Remove(social);
            await db.SaveChangesAsync();

            return Ok(social);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SocialExists(int id)
        {
            return db.Socials.Count(e => e.SocialiD == id) > 0;
        }
    }
}