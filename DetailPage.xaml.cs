using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WeiBoAnalyser.WeiBoAPI;

namespace WeiBoAnalyser
{
    public partial class DetailPage : PhoneApplicationPage
    {
        public DetailPage()
        {
            InitializeComponent();
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
    }
}