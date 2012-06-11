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
    public class PalestrantesController : ApiController
    {
        private readonly QCon12Context db = QCon12Context.Instance;

        [Queryable(ResultLimit = 10)]
        public IQueryable<Palestrante> GetPalestrantes()
        {
            var palestrantes = db.Palestrantes.AsQueryable().ToList();
            return palestrantes.AsQueryable();
        }

        public Palestrante GetPalestrante(int id)
        {
            var palestrante = db.Palestrantes.Find(id);
            if (palestrante == null)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return palestrante;
        }

        public HttpResponseMessage PutPalestrante(int id, Palestrante palestrante)
        {
            if (ModelState.IsValid && id == palestrante.Id)
            {
                db.Entry(palestrante).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                } catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, palestrante);
            } else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage PostPalestrante(Palestrante palestrante)
        {
            if (ModelState.IsValid)
            {
                db.Palestrantes.Add(palestrante);
                db.SaveChanges();

                var response = Request.CreateResponse(HttpStatusCode.Created, palestrante);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = palestrante.Id}));
                return response;
            } else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage DeletePalestrante(int id)
        {
            var palestrante = db.Palestrantes.Find(id);
            if (palestrante == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            db.Palestrantes.Remove(palestrante);

            try
            {
                db.SaveChanges();
            } catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, palestrante);
        }
    }
}