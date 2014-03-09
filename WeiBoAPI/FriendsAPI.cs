using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeiBoAnalyser.Common;

namespace WeiBoAnalyser.WeiBoAPI
{
    public class FriendsAPI
    {
        public enum Mode { Last = 0, All };

        private AccountDetail m_accountDetail;

        public FriendsAPI(AccountDetail accountDetail)
        {
            m_accountDetail = accountDetail;
        }

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

        public void IdolList(int reqNum, int index, Mode mode, Action<Tuple<Result, List<Person>>> callback)
        {
            if (callback == null) throw new ArgumentNullException("callback");

            string url = String.Format(@"http://open.t.qq.com/api/friends/idollist?" +
                "format=xml&reqnum={0}&startindex={1}&mode={2}" +
                "&oauth_consumer_key={3}&access_token={4}" +
                "&openid={5}&oauth_version=2.a",
                reqNum, index, (int)mode,
                m_accountDetail.APP_KEY, m_accountDetail.ACCESS_TOKEN,
                m_accountDetail.OPEN_ID);

            HttpRequestWorker.Get(url, (content) =>
                {
                    Result result = new Result();
                    List<Person> personList = new List<Person>();

                    XDocument xml = XDocument.Parse(content);
                    XElement eleData = xml.Root.Element("data");
                    if (eleData != null)
                    {
                        int curNum = Convert.ToInt32(eleData.Element("curnum").Value);
                        int hasNext = Convert.ToInt32(eleData.Element("hasnext").Value);
                        foreach (XElement eleInfo in eleData.Elements("info"))
                        {
                            Person person = new Person();

                            person.Name = eleInfo.Element("name").Value;
                            person.NickName = eleInfo.Element("nick").Value;
                            person.FansNum = Convert.ToInt32(eleInfo.Element("fansnum").Value);
                            person.IdolNum = Convert.ToInt32(eleInfo.Element("idolnum").Value);
                            person.IsMyFans = bool.Parse(eleInfo.Element("isfans").Value);
                            person.IsMyIdol = bool.Parse(eleInfo.Element("isidol").Value);
                            person.IsRealName = Convert.ToBoolean(Convert.ToInt32(eleInfo.Element("isrealname").Value));
                            person.IsVip = Convert.ToBoolean(Convert.ToInt32(eleInfo.Element("isvip").Value));
                            person.OpenId = eleInfo.Element("openid").Value;
                            person.Sex = (Sex)Convert.ToInt32(eleInfo.Element("sex").Value);

                            personList.Add(person);
                        }
                    }

                    result.ErrCode = Convert.ToInt32(xml.Root.Element("errcode").Value);
                    result.Msg = xml.Root.Element("msg").Value;
                    result.Ret = Convert.ToInt32(xml.Root.Element("ret").Value);

                    callback(new Tuple<Result, List<Person>>(result, personList));

                });
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
