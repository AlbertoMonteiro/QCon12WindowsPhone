using QCon12.Mobile.Models;

namespace QCon12.Mobile.Requests
{
    public class PalestrantesRequest : ServiceRequest<Palestrante>
    {
        public PalestrantesRequest() : base("Palestrantes") {}
    }
}