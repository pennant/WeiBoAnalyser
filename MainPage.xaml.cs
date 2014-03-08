using Microsoft.Phone.Controls;
using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Navigation;

namespace WeiBoAnalyser
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = String.Format(@"https://open.t.qq.com/cgi-bin/oauth2/authorize?client_id={0}" +
                "&response_type=code&redirect_uri=http://www.beautypeer.com", App.Account.APP_KEY);
            webBrowser.Navigate(new Uri(url));
        }

        private void AuthCallback(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            if (request != null)
            {
                try
                {
                    WebResponse response = request.EndGetResponse(result);
                    long length = response.ContentLength;
                    using (Stream stream = response.GetResponseStream())
                    {
                        byte[] data = new byte[length];
                        stream.Read(data, 0, data.Length);
                        string content = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);

                        string[] paramStr = content.Split('=', '&');
                        App.Account.ACCESS_TOKEN = paramStr[1];
                        App.Account.EXPIRES_IN = Convert.ToInt32(paramStr[3]);
                        App.Account.REFRESH_TOKEN = paramStr[5];
                        App.Account.Person.Name = paramStr[9];
                        App.Account.Person.NickName = paramStr[11];

                        Dispatcher.BeginInvoke(() =>
                            {
                                NavigationService.Navigate(new Uri("/DetailPage.xaml", UriKind.RelativeOrAbsolute));
                            });
                    }
                }
                catch (WebException ex)
                {
                    Dispatcher.BeginInvoke(() =>
                        {
                            MessageBox.Show(ex.Message);
                        });
                }
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string uri = String.Format(@"https://open.t.qq.com/cgi-bin/oauth2/authorize?client_id={0}" +
                "&response_type=code&redirect_uri={1}&wap=2", 
                App.Account.APP_KEY, App.Account.WEB_REDIRECT);
            webBrowser.Navigate(new Uri(uri));
        }

        private void webBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            if (webBrowser.Source == null) return;

            string host = webBrowser.Source.Host;
            if (host == @"www.cnblogs.com")
            {
                string[] paramStrs = webBrowser.Source.Query.Split('=', '&');
                App.Account.CODE = paramStrs[1];
                App.Account.OPEN_ID = paramStrs[3];
                App.Account.OPEN_KEY = paramStrs[5];

                string url = String.Format(@"https://open.t.qq.com/cgi-bin/oauth2/access_token?" +
                    "client_id={0}&client_secret={1}" +
                    "&redirect_uri={2}" +
                    "&grant_type=authorization_code&code={3}",
                    App.Account.APP_KEY, App.Account.APP_SECRET,
                    App.Account.WEB_REDIRECT,
                    App.Account.CODE);

                HttpWebRequest request = HttpWebRequest.CreateHttp(url);
                request.Method = "GET";
                request.BeginGetResponse(AuthCallback, request);
            }
        }

        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}