using QCon12.Phone.Models;

namespace QCon12.Phone.Requests
{
    public class TracksAzureRequest : AzureServiceRequest<Track>
    {
        public TracksAzureRequest() : base("Tracks") {}
    }
}