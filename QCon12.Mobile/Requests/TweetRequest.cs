using QCon12.Mobile.Models;

namespace QCon12.Mobile.Requests
{
    public class TweetRequest : ServiceRequest<Tweet>
    {
        public TweetRequest(string twitterName)
        {
            URL = string.Format("https://twitter.com/statuses/user_timeline/{0}.json", twitterName);
        }
    }
}