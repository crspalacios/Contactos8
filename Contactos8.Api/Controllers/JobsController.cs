﻿namespace Contactos8.Api.Controllers
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
    public class JobsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Jobs
        public IQueryable<Job> GetJobs()
        {
            return db.Jobs;
        }

        // GET: api/Jobs/5
        [ResponseType(typeof(Job))]
        public async Task<IHttpActionResult> GetJob(int id)
        {
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // PUT: api/Jobs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJob(int id, Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job.JobId)
            {
                return BadRequest();
            }

            db.Entry(job).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
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

        // POST: api/Jobs
        [ResponseType(typeof(Job))]
        public async Task<IHttpActionResult> PostJob(Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jobs.Add(job);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = job.JobId }, job);
        }

        // DELETE: api/Jobs/5
        [ResponseType(typeof(Job))]
        public async Task<IHttpActionResult> DeleteJob(int id)
        {
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            db.Jobs.Remove(job);
            await db.SaveChangesAsync();

            return Ok(job);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobExists(int id)
        {
            return db.Jobs.Count(e => e.JobId == id) > 0;
        }
    }
}