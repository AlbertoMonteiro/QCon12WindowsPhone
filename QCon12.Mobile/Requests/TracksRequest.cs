using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QCon12.Mobile.Models;

namespace QCon12.Mobile.Requests
{
    public class TracksRequest : ServiceRequest<Track>
    {
        public TracksRequest() : base("Tracks") {}

        public async Task<List<Track>> List(int skip = 0)
        {
            var tracks = cacheContext.Tracks.ToList();
            if (!tracks.Any())
            {
                tracks = await BaseList(skip);
                cacheContext.Tracks.InsertAllOnSubmit(tracks);
                cacheContext.SubmitChanges();
            }
            return tracks;
        }

        public async Task<Track> Get(int id)
        {
            Track track = cacheContext.Tracks.FirstOrDefault(t => t.Id == id);
            if (track == null)
            {
                track = await BaseGet(id);
                cacheContext.Tracks.InsertOnSubmit(track);
                cacheContext.SubmitChanges();
            }
            return track;
        }
    }
}