using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiBoAnalyser.WeiBoAPI
{
    public class Friends
    {
        public enum Mode { Last = 0, All };

        public Tuple<Result, List<Person>> FansList(int reqNum, int index, Mode mode = Mode.Last)
        {
            string url = String.Format("https://open.t.qq.com/api/friends/fanslist?" +
                "format=json&reqnum={0}&startindex={1}&mode={2}" +
                "&oauth_consumer_key=xx&access_token=xx&openid=xx" +
                "&clientip=xx&oauth_version=2.a&scope=xx", reqNum, index, (int)mode);


            List<Person> person = new List<Person>();
            return new Tuple<Result,List<Person>>(new Result(0, 0, String.Empty), person);
        }

        public Tuple<Result, List<Person>> FansList_Name(int reqNum, int index, Mode mode = Mode.Last)
        {
            string url = String.Format("https://open.t.qq.com/api/friends/fanslist_name?" +
                "format=json&reqnum={0}&startindex={1}&mode={2}" +
                "&oauth_consumer_key=xx&access_token=xx&openid=xx" +
                "&clientip=xx&oauth_version=2.a&scope=xx", reqNum, index, (int)mode);

            List<Person> person = new List<Person>();
            return new Tuple<Result, List<Person>>(new Result(0, 0, String.Empty), person);
        }

        public Tuple<Result, List<Person>> FansList_S(int reqNum, int index, Mode mode = Mode.Last)
        {
            string url = String.Format("https://open.t.qq.com/api/friends/fanslist_s?" +
                "format=json&reqnum={0}&startindex={1}&mode={2}" +
                "&oauth_consumer_key=xx&access_token=xx&openid=xx" +
                "&clientip=xx&oauth_version=2.a&scope=xx", reqNum, index, (int)mode);

            List<Person> person = new List<Person>();
            return new Tuple<Result, List<Person>>(new Result(0, 0, String.Empty), person);
        }

        public Tuple<Result, List<Person>> User_FansList(int reqNum, int index, Mode mode = Mode.Last)
        {
            string url = String.Format("https://open.t.qq.com/api/friends/user_fanslist?" +
                "format=json&reqnum={0}&startindex={1}&mode={2}" +
                "&oauth_consumer_key=xx&access_token=xx&openid=xx" +
                "&clientip=xx&oauth_version=2.a&scope=xx", reqNum, index, (int)mode);

            List<Person> person = new List<Person>();
            return new Tuple<Result, List<Person>>(new Result(0, 0, String.Empty), person);
        }

        public Result Add(Person person)
        {
            string url = "https://open.t.qq.com/api/friends/add";
            //post
            return new Result(0, 0, String.Empty); 
        }

        public Result Del(Person person)
        {
            string url = "https://open.t.qq.com/api/friends/del";
            //post
            return new Result(0, 0, String.Empty);
        }
    }
}
