using Bing_Search_API.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Bing_Search_API.ViewModel
{
    public class PhotosVM : DictionaryParameter, INotifyPropertyChanged
    {
        MakeRequestAPI.PhotosResponse makeRequestAPI = new MakeRequestAPI.PhotosResponse();

        ObservableCollection<Photos.Value> photoCollection = new ObservableCollection<Photos.Value>();


        private Image imageView { get; set; }
        public PhotosVM(string _q, string _count, string _offset, string _mkt, string _safesearch, Image imageView)
        {
            this._q = _q;
            this._count = _count;
            this._offset = _offset;
            this._mkt = _mkt;
            this._safesearch = _safesearch;
            this.imageView = imageView;
            BingCollections();
        }

        public ObservableCollection<Photos.Value> PhotosList
        {
            get { return photoCollection; }
        }



        public async void BingCollections()
        {
            var getRequest = await makeRequestAPI.GetResponseAsync(_q, _count, _offset, _mkt, _safesearch);
            if (getRequest != null)
            {
                var getJson = JsonConvert.DeserializeObject<Photos.PhotoRootObject>(getRequest);
                if (getJson.value.Count != 0)
                {
                    foreach (var item in getJson.value)
                    {
                        photoCollection.Add(item);
                    }


                }
            }



        }


        public void ImageLoading()
        {
            this.imageView.Source = new BitmapImage(new Uri(displayImage));
            this.imageView.Width = width;
            this.imageView.Height = height;
        }

        private string displayImage;

        public event PropertyChangedEventHandler PropertyChanged;

        public string DisplayImage
        {
            get { return displayImage; }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DisplayImage"));
                }
            }
        }

        private int width;
        public int Width
        {
            get { return width; }
            set
            {
               
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Width"));
            }
        }

        private int height;
        public int Height
        {
            get { return height; }
            set
            {
                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Height"));
            }
        }

        private Photos.Value photoSelectedItem;
        public Photos.Value PhotoSelectedItem
        {
            get { return photoSelectedItem; }
            set
            {
                if(value!=photoSelectedItem)
                {
                    photoSelectedItem = value;

                    // get source of item here
                    height = photoSelectedItem.height;
                    width = photoSelectedItem.width;
                    displayImage = photoSelectedItem.contentUrl;

                    // called imageLoading here
                    ImageLoading();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PhotoSelectedItem"));
                }
            }
        }
    }
}
