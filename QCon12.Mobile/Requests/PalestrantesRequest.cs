using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QCon12.Mobile.Cache;
using QCon12.Mobile.Models;

namespace QCon12.Mobile.Requests
{
    public class PalestrantesRequest : ServiceRequest<Palestrante>
    {
        public PalestrantesRequest() : base("Palestrantes") {}

        public async Task<IEnumerable<Palestrante>> List(int skip = 0)
        {
            var palestrantes = cacheContext.Palestrantes;
            if (!palestrantes.Any())
                await SaveCache(skip);
            else if (palestrantes.Count() <= skip)
                await SaveCache(skip);

            if (palestrantes != null && palestrantes.Count() > 10)
                return palestrantes.Skip(skip).Take(10).Select(cache => (Palestrante) cache);

            return palestrantes.Select(cache => (Palestrante) cache);
        }

        public async Task<Palestrante> Get(int id)
        {
            Palestrante palestrante = cacheContext.Palestrantes.FirstOrDefault(cache => cache.Id == id);

            if (palestrante == null)
            {
                var tempPalestrante = await BaseGet(id);
                var trackCache = AsPalestranteCache(tempPalestrante);
                cacheContext.Palestrantes.InsertOnSubmit(trackCache);
                cacheContext.SubmitChanges();
            }

            return palestrante;
        }

        private async Task SaveCache(int skip)
        {
            var tempPalestrantes = await BaseList(skip);
            if (tempPalestrantes != null)
            {
                var palestranteCaches = tempPalestrantes.Select(AsPalestranteCache);
                cacheContext.Palestrantes.InsertAllOnSubmit(palestranteCaches);
                cacheContext.SubmitChanges();
            }
        }

        private static PalestranteCache AsPalestranteCache(Palestrante palestrante)
        {
            return new PalestranteCache(palestrante.Id, palestrante.Nome, palestrante.Bio, palestrante.Email, palestrante.Foto, palestrante.Twitter);
        }
    }
}