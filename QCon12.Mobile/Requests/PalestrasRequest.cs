using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using QCon12.Mobile.Models;
using System.Linq;

namespace QCon12.Mobile.Requests
{
    public class PalestrasRequest : ServiceRequest<Palestra>
    {
        public PalestrasRequest() : base("Palestras") { }

        public async Task<List<Palestra>> List(int skip = 0)
        {
            var palestras = cacheContext.Palestras.ToList();
            if (!palestras.Any())
            {
                palestras = await BaseList(skip);
                if (palestras != null)
                {
                    SynchronizationContext.Current.Post(state =>
                    {
                        foreach (var palestra in palestras)
                        {
                            var track = cacheContext.Tracks.SingleOrDefault(t => t.Nome == palestra.Track.Nome);
                            track.Palestras.Add(new Palestra { Descricao = palestra.Descricao, Horario = palestra.Horario, Nome = palestra.Nome });
                            cacheContext.SubmitChanges();
                        }
                    }, null);
                }
            }
            return palestras;
        }

        public async Task<Palestra> Get(int id)
        {
            Palestra palestra = cacheContext.Palestras.FirstOrDefault(p => p.Id == id);
            if (palestra == null)
            {
                palestra = await BaseGet(id);
                if (palestra != null)
                {
                    cacheContext.Palestras.InsertOnSubmit(palestra);
                    cacheContext.SubmitChanges();
                }
            }
            return palestra;
        }

        public async Task<IEnumerable<Palestra>> FromTrack(int id)
        {
            var palestras = cacheContext.Palestras.Where(palestra => palestra.Track != null && palestra.Track.Id == id).AsEnumerable();
            if (palestras.Any())
            {
                additional = "/FromTrack/" + id;
                palestras = await DownloadAndDeserialize<IEnumerable<Palestra>>();
                if (palestras != null)
                {
                    cacheContext.Palestras.InsertAllOnSubmit(palestras);
                    cacheContext.SubmitChanges();
                }
            }
            return palestras;
        }
    }
}