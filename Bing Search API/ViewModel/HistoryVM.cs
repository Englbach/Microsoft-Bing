using Bing_Search_API.Model;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bing_Search_API.ViewModel
{
    public class HistoryVM : DataVM
    {
        public HistoryVM()
        {
            GetHistoryData();
        }
        public ObservableCollection<HistoryBrowser> historyCollection = new ObservableCollection<HistoryBrowser>();

        public ObservableCollection<HistoryBrowser> historyList
        {
            get
            {
                return historyCollection;
            }
        }
        public async void GetHistoryData()
        {
            IMobileServiceTableQuery<HistoryBrowser> query = todoTable.OrderByDescending(historyBrowser => historyBrowser.DateCreation);
            List<HistoryBrowser> historyList = await query.ToListAsync();
            foreach (var item in historyList)
            {
                historyCollection.Add(item);
            }

        }
       

    }
}
