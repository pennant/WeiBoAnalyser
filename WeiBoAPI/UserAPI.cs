using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeiBoAnalyser.Common;

namespace WeiBoAnalyser.WeiBoAPI
{
    public class UserAPI
    {
        private AccountDetail m_accountDetail;

        public UserAPI(AccountDetail accountDetail)
        {
            m_accountDetail = accountDetail;
        }

        public void Info(Action<Tuple<Result, Person>> callback)
        {
            if (callback == null) throw new ArgumentNullException("callback");

            string url = String.Format(@"http://open.t.qq.com/api/user/info?" +
                "format=xml&access_token={0}&openid={1}&oauth_version=2.a" +
                "&oauth_consumer_key={2}",
                m_accountDetail.ACCESS_TOKEN, m_accountDetail.OPEN_ID,
                m_accountDetail.APP_KEY);

            HttpRequestWorker.Get(url, (content) =>
                {
                    Result result = new Result();
                    Person person = new Person();

                    XDocument xml = XDocument.Parse(content);
                    XElement eleData = xml.Root.Element("data");
                    if (eleData != null)
                    {
                        person.Name = eleData.Element("name").Value;
                        person.NickName = eleData.Element("nick").Value;
                        person.Birthday = new DateTime(
                            Convert.ToInt32(eleData.Element("birth_year").Value),
                            Convert.ToInt32(eleData.Element("birth_month").Value),
                            Convert.ToInt32(eleData.Element("birth_day").Value));
                        person.Experience = Convert.ToInt32(eleData.Element("exp").Value);
                        person.Country = Convert.ToInt32(eleData.Element("country_code").Value);
                        person.Province = Convert.ToInt32(eleData.Element("province_code").Value);
                        person.City = Convert.ToInt32(eleData.Element("city_code").Value);
                        person.FansNum = Convert.ToInt32(eleData.Element("fansnum").Value);
                        person.FavNum = Convert.ToInt32(eleData.Element("favnum").Value);
                        person.IdolNum = Convert.ToInt32(eleData.Element("idolnum").Value);
                        person.Industry = Convert.ToInt32(eleData.Element("industry_code").Value);
                        person.Introduction = eleData.Element("introduction").Value;
                        person.IsEnt = Convert.ToBoolean(Convert.ToInt32(eleData.Element("isent").Value));
                        person.IsMyBlack = Convert.ToBoolean(Convert.ToInt32(eleData.Element("ismyblack").Value));
                        person.IsMyFans = Convert.ToBoolean(Convert.ToInt32(eleData.Element("ismyfans").Value));
                        person.IsMyIdol = Convert.ToBoolean(Convert.ToInt32(eleData.Element("ismyidol").Value));
                        person.IsRealName = Convert.ToBoolean(Convert.ToInt32(eleData.Element("isrealname").Value));
                        person.IsVip = Convert.ToBoolean(Convert.ToInt32(eleData.Element("isvip").Value));
                        person.Level = Convert.ToInt32(eleData.Element("level").Value);
                        person.MutualFansNum = Convert.ToInt32(eleData.Element("mutual_fans_num").Value);
                        person.OpenId = eleData.Element("openid").Value;
                        person.RegTime = new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt32(eleData.Element("regtime").Value));
                        person.Sex = (Sex)Convert.ToInt32(eleData.Element("sex").Value);
                    }

                    result.ErrCode = Convert.ToInt32(xml.Root.Element("errcode").Value);
                    result.Msg = xml.Root.Element("msg").Value;
                    result.Ret = Convert.ToInt32(xml.Root.Element("ret").Value);

                    callback(new Tuple<Result, Person>(result, person));
                });

        }
    }
}
