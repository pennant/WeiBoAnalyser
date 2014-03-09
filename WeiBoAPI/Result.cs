using System.Threading;

namespace WeiBoAnalyser.WeiBoAPI
{
    public class Result
    {
        public const int SUCCESS = 0;

        public int Ret { get; set; }

        public int ErrCode { get; set; }

        public string Msg { get; set; }

        public AutoResetEvent AutoResetEvent { get; set; }

        public int Page { get; set; }

        public Result() { }

        public Result(int ret, int errCode, string msg)
        {
            Ret = ret;
            ErrCode = errCode;
            Msg = msg;
        }
    }
}
