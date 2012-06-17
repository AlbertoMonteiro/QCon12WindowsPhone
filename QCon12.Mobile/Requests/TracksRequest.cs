using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using QCon12.Mobile.Cache;
using QCon12.Mobile.Models;

namespace QCon12.Mobile.Requests
{
    public class TracksRequest : ServiceRequest<Track>
    {
        public TracksRequest() : base("Tracks") { }

        public async Task<IEnumerable<Track>> List(int skip = 0)
        {
            var tracks = cacheContext.Tracks;
            if (!tracks.Any())
            {
                var tempTracks = await BaseList(skip);
                if (tempTracks != null)
                {
                    var trackCaches = tempTracks.Select(track => new TrackCache(track.Id, track.Nome, track.Bio, track.Logo));
                    cacheContext.Tracks.InsertAllOnSubmit(trackCaches);
                    cacheContext.SubmitChanges();
                }
            }
            return tracks.Select(cache => (Track)cache);
        }

        public async Task<Track> Get(int id)
        {
            Track track = cacheContext.Tracks.FirstOrDefault(cache => cache.Id == id);

            if (track == null)
            {
                var tempTrack = await BaseGet(id);
                var trackCache = new TrackCache(tempTrack.Id, tempTrack.Nome, tempTrack.Nome, tempTrack.Logo);
                cacheContext.Tracks.InsertOnSubmit(trackCache);
                cacheContext.SubmitChanges();
            }

            return track;
        }
    }
}