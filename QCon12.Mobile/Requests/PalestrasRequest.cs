using System.Collections.Generic;
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
                cacheContext.Palestras.InsertAllOnSubmit(palestras);
                cacheContext.SubmitChanges();
            }
            return palestras;
        }

        public async Task<Palestra> Get(int id)
        {
            Palestra palestra = cacheContext.Palestras.FirstOrDefault(p => p.Id == id);
            if (palestra == null) 
            {
                palestra = await BaseGet(id);
                cacheContext.Palestras.InsertOnSubmit(palestra);
                cacheContext.SubmitChanges();
            }
            return palestra;
        }

        public async Task<IEnumerable<Palestra>> FromTrack(int id)
        {
            var palestras = cacheContext.Palestras.Where(palestra => palestra.Track != null && palestra.Track.Id == id).AsEnumerable().ToList();
            if (palestras.Any())
            {
                additional = "/FromTrack/" + id;
                palestras = (await DownloadAndDeserialize<IEnumerable<Palestra>>()).ToList();
                cacheContext.Palestras.InsertAllOnSubmit(palestras);
                cacheContext.SubmitChanges();
            }
            return palestras;
        }
    }
}