using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QCon12.Models;

namespace QCon12.Controllers.Api
{
    public class TracksController : ApiController
    {
        private readonly QCon12Context db = QCon12Context.Instance;

        // GET api/Tracks
        [Queryable(ResultLimit = 10)]
        public IQueryable<Track> GetTracks()
        {
            var tracks = db.Tracks.AsQueryable().ToList();
            return tracks.AsQueryable();
        }

        // GET api/Tracks/5
        public Track GetTrack(int id)
        {
            var track = db.Tracks.Find(id);
            if (track == null)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return track;
        }

        // PUT api/Tracks/5
        public HttpResponseMessage PutTrack(int id, Track track)
        {
            if (ModelState.IsValid && id == track.Id)
            {
                db.Entry(track).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                } catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, track);
            } else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST api/Tracks
        public HttpResponseMessage PostTrack(Track track)
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(track);
                db.SaveChanges();

                var response = Request.CreateResponse(HttpStatusCode.Created, track);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = track.Id}));
                return response;
            } else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/Tracks/5
        public HttpResponseMessage DeleteTrack(int id)
        {
            var track = db.Tracks.Find(id);
            if (track == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            db.Tracks.Remove(track);

            try
            {
                db.SaveChanges();
            } catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, track);
        }
    }
}