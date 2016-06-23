using Bing_Search_API.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Bing_Search_API.ViewModel
{
    public class WebsVM : DictionaryParameter,  INotifyPropertyChanged
    {
        MakeRequestAPI.WebResponse makeRequestAPI = new MakeRequestAPI.WebResponse();
        
        ObservableCollection<Webs.Value> webCollection = new ObservableCollection<Webs.Value>();

        DataVM dataVM = new DataVM();
        

        public WebsVM(string _q, string _count, int _offset, string _mkt, string _safesearch)
        {
            this._q = _q;
            this._count = _count;
            this._offset = _offset;
            this._mkt = _mkt;
            this._safesearch = _safesearch;

            BingCollections();
        }

        public ObservableCollection<Webs.Value> WebsList
        {
            get { return webCollection; }
        }

       

        public async void BingCollections()
        {
            var getRequest = await makeRequestAPI.GetResponseAsync(_q, _count, _offset, _mkt, _safesearch);
            if(getRequest!=null)
            {
                var getJson = JsonConvert.DeserializeObject<Webs.WebsRootObject>(getRequest);
                if(getJson.webPages.value.Count!=0)
                {
                    foreach(var item in getJson.webPages.value)
                    {
                        webCollection.Add(item);
                    }
                   

                }
            }
            
        }
        // launch to browser
        private async void LaunchUri(string url)
        {
            var ishttp = url.Contains("http://");
            var ishttps = url.Contains("https://");
            Uri uri;
            if (ishttp==true || ishttps==true)
            {
                uri = new Uri(url);
            }
            else
            {
                uri = new Uri("https://" + url);
            }
            

            await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        // insert data to history databse on Microsoft Azure

        
        //
        private Webs.Value _websSelectedItem;

        public event PropertyChangedEventHandler PropertyChanged;

        public Webs.Value WebsSelectedItems
        {
            get { return _websSelectedItem; }
            set
            {
                if(value!=_websSelectedItem)
                {
                    _websSelectedItem = value;
                    dataVM.InsertDataFromClient(_websSelectedItem.name, DateTime.Now.ToString(), _websSelectedItem.displayUrl);
                    //open web browser with the link
                    LaunchUri(_websSelectedItem.displayUrl);
                    _websSelectedItem = null;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WebsSelectedItems"));

                }
            }
        }
        



    }
}
