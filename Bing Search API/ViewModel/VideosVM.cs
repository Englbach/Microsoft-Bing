using Bing_Search_API.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bing_Search_API.ViewModel
{
    public class VideosVM : DictionaryParameter, INotifyPropertyChanged
       
    {
        MakeRequestAPI.VideosResponse makeRequestAPI = new MakeRequestAPI.VideosResponse();

        ObservableCollection<Videos.Value> videoCollection = new ObservableCollection<Videos.Value>();

        public VideosVM(string _q, string _count, string _offset, string _mkt, string _safesearch)
        {
            this._q = _q;
            this._count = _count;
            this._offset = _offset;
            this._mkt = _mkt;
            this._safesearch = _safesearch;
            
            BingCollections();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Videos.Value> VideosList
        {
            get { return videoCollection; }
        }



        public async void BingCollections()
        {
            var getRequest = await makeRequestAPI.GetResponseAsync(_q, _count, _offset, _mkt, _safesearch);
            if (getRequest != null)
            {
                var getJson = JsonConvert.DeserializeObject<Videos.VideosRootObject>(getRequest);
                if (getJson.value.Count != 0)
                {
                    foreach (var item in getJson.value)
                    {
                        videoCollection.Add(item);
                    }


                }
            }



        }
    }
}
