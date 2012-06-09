using QCon12.Mobile.Models;

namespace QCon12.Mobile.Requests
{
    public class PalestrasAzureRequest : AzureServiceRequest<Palestra>
    {
        public PalestrasAzureRequest() : base("Palestras") { }
    }
}