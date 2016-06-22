using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Bing_Search_API.userControl
{
    public sealed partial class FlyoutFavouriteControl : UserControl
    {
        public FlyoutFavouriteControl()
        {
            this.InitializeComponent();
        }
        Frame fr = Window.Current.Content as Frame;
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if(lstList.SelectedIndex != 0)
            {
               
                fr.Navigate(typeof(HistoryPage));
            }
            lstList.SelectedIndex = -1;
        }
    }
}
