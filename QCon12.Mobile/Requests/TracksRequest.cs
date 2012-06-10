using QCon12.Mobile.Models;

namespace QCon12.Mobile.Requests
{
    public class TracksRequest : ServiceRequest<Track>
    {
        public TracksRequest() : base("Tracks") {}
    }
}