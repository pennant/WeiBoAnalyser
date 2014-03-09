using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Windows;
using WeiBoAnalyser.Resources;
using WeiBoAnalyser.WeiBoAPI;

namespace WeiBoAnalyser
{
    public partial class DetailPage : PhoneApplicationPage
    {
        public DetailPage()
        {
            InitializeComponent();

            BuildLocalizedApplicationBar();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            UserAPI userAPI = new UserAPI(App.Account);
            userAPI.Info((returnResult) =>
                {
                    Result result = returnResult.Item1;
                    Person person = returnResult.Item2;

                    if (result.ErrCode == Result.SUCCESS)
                    {
                        App.Account.Person = person;

                        this.Dispatcher.BeginInvoke(() =>
                            {
                                txtName.Text = person.Name;
                                txtNickName.Text = person.NickName;
                                txtFansCount.Text = person.FansNum.ToString();
                                txtFavoursCount.Text = person.FavNum.ToString();
                                txtIdolsCount.Text = person.IdolNum.ToString();
                                txtLevel.Text = person.Level.ToString();
                                txtOpenId.Text = person.OpenId;
                            });
                    }
                });
        }

        // 用于生成本地化 ApplicationBar 的示例代码
        private void BuildLocalizedApplicationBar()
        {
            // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
            ApplicationBar = new ApplicationBar();

            // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);

            // 使用 AppResources 中的本地化字符串创建新菜单项。
            ApplicationBarMenuItem getIdolListAppBarMenuItem = new ApplicationBarMenuItem(AppResources.GetIdolListMenuItemText);
            getIdolListAppBarMenuItem.Click += getIdolListAppBarMenuItem_Click;
            ApplicationBar.MenuItems.Add(getIdolListAppBarMenuItem);
        }

        private void getIdolListAppBarMenuItem_Click(object sender, EventArgs e)
        {
            FriendsAPI friendsAPI = new FriendsAPI(App.Account);
            int reqNum = 30;
            int page = 1;
            int index = reqNum * (page - 1);
            friendsAPI.IdolList(reqNum, index, FriendsAPI.Mode.All, (returnResult) =>
                {
                    Result result = returnResult.Item1;
                    List<Person> personList = returnResult.Item2;
                    if (result.ErrCode == Result.SUCCESS)
                    {
                        foreach(Person person in personList)
                        {
                            WeiBoAnalyser.Common.DbHelper.Insert<Person>(person);
                        }
                    }
                });
        }
    }
}