using System.Collections.Generic;
using System.Threading.Tasks;
using QCon12.Mobile.Models;

namespace QCon12.Mobile.Requests
{
    public class PalestrasRequest : ServiceRequest<Palestra>
    {
        public PalestrasRequest() : base("Palestras") { }

        public async Task<IEnumerable<Palestra>> FromTrack(int id)
        {
            additional = "/FromTrack/" + id;
            return await DownloadAndDeserialize<IEnumerable<Palestra>>();
        }
    }
}