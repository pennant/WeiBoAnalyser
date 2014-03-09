using Microsoft.Phone.Storage;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Storage;

namespace WeiBoAnalyser.Common
{
    public class DbHelper
    {
        private static string m_dbPath;

        private static SQLiteConnection m_gConn;

        static DbHelper()
        {
            m_dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "weibodb.sqlite");
        }

        public static void Init()
        {   
            m_gConn = new SQLite.SQLiteConnection(m_dbPath);
        }

        public static async void DeleteDb()
        {
            try
            {
                StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("weibodb.sqlite");
                await file.DeleteAsync();
            }
            catch
            {

            }
        }

        public static async void ExportDb()
        {
            try
            {
                StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("weibodb.sqlite");
                ExternalStorageDevice device = (await ExternalStorage.GetExternalStorageDevicesAsync()).FirstOrDefault();
                ExternalStorageFolder folder = await device.GetFolderAsync("WeiBo");
                //await file.CopyAsync(folder);
            }
            catch
            {

            }
        }

        public static bool Insert<T>(T t)
        {
            return m_gConn.Insert(t, typeof(T)) > 0 ? true : false;
        }

        public static bool CreateTable<T>()
        {
            return m_gConn.CreateTable<T>() > 0 ? true : false;
        }

    }
}
