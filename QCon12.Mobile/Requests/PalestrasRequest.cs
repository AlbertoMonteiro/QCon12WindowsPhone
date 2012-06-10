using QCon12.Mobile.Models;

namespace QCon12.Mobile.Requests
{
    public class PalestrasRequest : ServiceRequest<Palestra>
    {
        public PalestrasRequest() : base("Palestras") { }
    }
}