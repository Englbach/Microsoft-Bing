using Bing_Search_API.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Bing_Search_API
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HistoryPage : Page
    {
        Frame frm = Window.Current.Content as Frame;
        public HistoryPage()
        {
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

            titleBar.BackgroundColor = Color.FromArgb(255, 204, 204, 204);
            titleBar.ButtonBackgroundColor = Color.FromArgb(255, 204, 204, 204);

            ApplicationView.GetForCurrentView().Title = "History";
            this.InitializeComponent();

            HistoryVM historyVM = new HistoryVM();
            lsthistory.DataContext = historyVM;

        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            frm.Navigate(typeof(MainPage));
        }
    }
}
