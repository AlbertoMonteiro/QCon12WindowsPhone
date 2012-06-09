using QCon12.Mobile.Models;

namespace QCon12.Mobile.Requests
{
    public class PalestrantesAzureRequest : AzureServiceRequest<Palestrante>
    {
        public PalestrantesAzureRequest() : base("Palestrantes") {}
    }
}