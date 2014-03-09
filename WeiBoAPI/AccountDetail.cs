
namespace WeiBoAnalyser.WeiBoAPI
{
    public class AccountDetail
    {
        public string APP_KEY { get; set; }

        public string APP_SECRET { get; set; }

        public string WEB_REDIRECT { get; set; }

        public string CODE { get; set; }

        public string OPEN_ID { get; set; }

        public string OPEN_KEY { get; set; }

        public string ACCESS_TOKEN { get; set; }

        public int EXPIRES_IN { get; set; }

        public string REFRESH_TOKEN { get; set; }

        public Person Person { get; set; }

        public AccountDetail()
        {
            APP_KEY = @"801405887"; // "801403913";
            APP_SECRET = @"f862896b225f984d8ffe6717e8047ed3"; // "6bb642be3719b3e65fec6b2d649813ea";
            WEB_REDIRECT = @"http://www.cnblogs.com/pennant"; // "http://www.beautypeer.com";
            Person = new Person();
        }
    }
}
