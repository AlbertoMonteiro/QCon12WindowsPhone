using QCon12.Mobile.Models;

namespace QCon12.Mobile.Requests
{
    public class TracksAzureRequest : AzureServiceRequest<Track>
    {
        public TracksAzureRequest() : base("Tracks") {}
    }
}