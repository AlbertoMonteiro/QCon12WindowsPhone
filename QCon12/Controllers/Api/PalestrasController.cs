using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QCon12.Models;

namespace QCon12.Controllers.Api
{
    public class PalestrasController : ApiController
    {
        private readonly QCon12Context db = QCon12Context.Instance;

        // GET api/Palestras
        [Queryable(ResultLimit = 10)]
        public IQueryable<Palestra> GetPalestras()
        {
            return db.Palestras.AsQueryable();
        }

        // GET api/Palestras/5
        public Palestra GetPalestra(int id)
        {
            var palestra = db.Palestras.Find(id);
            if (palestra == null)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return palestra;
        }

        // GET api/Palestras/FromTrack/5
        [HttpGet]
        public IEnumerable<Palestra> FromTrack(int id)
        {
            var palestras = db.Palestras.Include("Track").Include("Palestrante").Where(x => x.Track.Id == id).ToList();
            if (palestras == null)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return palestras;
        }

        // PUT api/Palestras/5
        public HttpResponseMessage PutPalestra(int id, Palestra palestra)
        {
            if (ModelState.IsValid && id == palestra.Id)
            {
                db.Entry(palestra).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                } catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, palestra);
            } else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST api/Palestras
        public HttpResponseMessage PostPalestra(Palestra palestra)
        {
            if (ModelState.IsValid)
            {
                db.Palestras.Add(palestra);
                db.SaveChanges();

                var response = Request.CreateResponse(HttpStatusCode.Created, palestra);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = palestra.Id}));
                return response;
            } else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/Palestras/5
        public HttpResponseMessage DeletePalestra(int id)
        {
            var palestra = db.Palestras.Find(id);
            if (palestra == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            db.Palestras.Remove(palestra);

            try
            {
                db.SaveChanges();
            } catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, palestra);
        }
    }
}