using Bing_Search_API.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Bing_Search_API.ViewModel
{
    public class NewsVM : DictionaryParameter, INotifyPropertyChanged
    {
        ObservableCollection<News.Value> NewsCollection = new ObservableCollection<News.Value>();
        MakeRequestAPI.NewsResponse makeRequestAPI = new MakeRequestAPI.NewsResponse();

        public event PropertyChangedEventHandler PropertyChanged;

        public NewsVM(string _q, string _count, string _offset, string _mkt, string _safesearch)
        {
            this._q = _q;
            this._count = _count;
            this._offset = _offset;
            this._mkt = _mkt;
            this._safesearch = _safesearch;

            BingCollections();
        }
       
        public ObservableCollection<News.Value> newsList
        {
            get { return NewsCollection; }
        }

        public async void BingCollections()
        {
            var getRequest = await makeRequestAPI.GetResponseAsync(_q, _count, _offset, _mkt, _safesearch);
            if (getRequest != null)
            {
                var getJson = JsonConvert.DeserializeObject<News.NewsRootObject>(getRequest);
                if (getJson.value.Count != 0)
                {
                    foreach (var item in getJson.value)
                    {
                        NewsCollection.Add(item);
                    }


                }
            }

        }

        private News.Value newsSelectedItem;
        public News.Value NewsSelectedItem
        {
            get { return newsSelectedItem; }
            set
            {
                if(value!=newsSelectedItem)
                {
                    newsSelectedItem = value;
                    
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewsSelectedItem"));
                }
            }
        }
    }
}
