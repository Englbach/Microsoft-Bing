using Bing_Search_API.Model;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace Bing_Search_API.ViewModel
{
    public class DataVM
    {

        private MobileServiceCollection<HistoryBrowser, HistoryBrowser> Items;
        public IMobileServiceTable<HistoryBrowser> todoTable = App.MobileService.GetTable<HistoryBrowser>();


        private async Task InsertData(HistoryBrowser Item)
        {
            // This code inserts a new TodoItem into the database. When the operation completes
            // and Mobile Apps has assigned an Id, the item is added to the CollectionView
            
            await todoTable.InsertAsync(Item);
            //Items.Add(Item);

            //await App.MobileService.SyncContext.PushAsync(); // offline sync
        }


       

        public async void GetBookmarkData()
        {
            List<HistoryBrowser> historyList = await todoTable.ToListAsync();
            foreach (var item in historyList)
            {
                
            }

        }


        public async void InsertDataFromClient(string _title, string _datetime, string _contenturl)
        {
            var item = new HistoryBrowser {  Title = _title, DateCreation = _datetime, ContentDisplay= _contenturl };
            await InsertData(item);
        }
    }
}
