using System.Collections.Generic;
using System.Threading.Tasks;
using QCon12.Mobile.Cache;
using QCon12.Mobile.Models;
using System.Linq;

namespace QCon12.Mobile.Requests
{
    public class PalestrasRequest : ServiceRequest<Palestra>
    {
        public PalestrasRequest() : base("Palestras") { }

        public async Task<IEnumerable<Palestra>> List(int skip = 0)
        {
            var palestraCaches = cacheContext.Palestras;
            if (!palestraCaches.Any())
                await SaveCache(skip);
            else if (palestraCaches.Count() <= skip)
                await SaveCache(skip);

            if (palestraCaches != null && palestraCaches.Count() > 10)
                return palestraCaches.Skip(skip).Take(10).Select(cache => (Palestra)cache);

            return palestraCaches.Select(cache => (Palestra)cache);
        }

        public async Task<Palestra> Get(int id)
        {
            Palestra palestra = cacheContext.Palestras.FirstOrDefault(cache => cache.Id == id);

            if (palestra == null)
            {
                var tempPalestra = await BaseGet(id);
                var trackCache = AsPalestraCache(tempPalestra);
                cacheContext.Palestras.InsertOnSubmit(trackCache);
                cacheContext.SubmitChanges();
            }

            return palestra;
        }

        public async Task<IEnumerable<Palestra>> FromTrack(int id)
        {
            var palestraCaches = cacheContext.Palestras.Where(cache => cache.Track.Id == id);

            if (!palestraCaches.Any())
            {
                additional = "/FromTrack/" + id;
                var palestras = await BaseList();
                if (palestras != null)
                {
                    foreach (var palestra in palestras)
                    {
                        var p = cacheContext.Palestras.FirstOrDefault(cache => cache.Id == palestra.Id);
                        if (p == null)
                        {
                            var tPalestraCaches = palestras.Select(AsPalestraCache);
                            cacheContext.Palestras.InsertAllOnSubmit(tPalestraCaches);
                        } else
                        {
                            var trackCache = cacheContext.Tracks.FirstOrDefault(cache => cache.Id == palestra.Track.Id);
                            if (trackCache != null)
                                trackCache.Palestras.Add(p);
                        }

                        cacheContext.SubmitChanges();
                    }
                }
            }
            return palestraCaches.Select(cache => (Palestra)cache);
        }

        private async Task SaveCache(int skip = 0)
        {
            var palestrantes = await BaseList(skip);
            if (palestrantes != null)
            {
                var palestraCaches = palestrantes.Select(AsPalestraCache);
                cacheContext.Palestras.InsertAllOnSubmit(palestraCaches);
                cacheContext.SubmitChanges();
            }
        }

        private PalestraCache AsPalestraCache(Palestra tempPalestra)
        {
            var palestraCache = new PalestraCache(tempPalestra.Id, tempPalestra.Nome, tempPalestra.Descricao, tempPalestra.Horario);
            var trackCache = cacheContext.Tracks.FirstOrDefault(cache => cache.Id == tempPalestra.TrackId);
            if (trackCache != null)
                trackCache.Palestras.Add(palestraCache);
            return palestraCache;
        }
    }
}