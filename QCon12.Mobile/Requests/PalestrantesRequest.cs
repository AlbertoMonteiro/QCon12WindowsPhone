using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QCon12.Mobile.Models;

namespace QCon12.Mobile.Requests
{
    public class PalestrantesRequest : ServiceRequest<Palestrante>
    {
        public PalestrantesRequest() : base("Palestrantes") {}

        public async Task<List<Palestrante>> List(int skip = 0)
        {
            var palestrantes = cacheContext.Palestrantes.ToList();
            if (!palestrantes.Any())
            {
                palestrantes = await BaseList(skip);
                cacheContext.Palestrantes.InsertAllOnSubmit(palestrantes);
                cacheContext.SubmitChanges();
            }
            else if (palestrantes.Count <= skip)
            {
                palestrantes = await BaseList(skip);
                cacheContext.Palestrantes.InsertAllOnSubmit(palestrantes);
                cacheContext.SubmitChanges();
            }
            return palestrantes;
        }

        public async Task<Palestrante> Get(int id)
        {
            var palestrante = cacheContext.Palestrantes.FirstOrDefault(p => p.Id == id);
            if (palestrante == null)
            {
                palestrante = await BaseGet(id);
                cacheContext.Palestrantes.InsertOnSubmit(palestrante);
                cacheContext.SubmitChanges();
            }
            
            return palestrante;
        }
    }
}