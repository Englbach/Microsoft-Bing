using Bing_Search_API.ViewModel;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Bing_Search_API
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private List<string> arraySearch = new List<string>();
        int i;
        public MainPage()
        {
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            
            titleBar.BackgroundColor = Color.FromArgb(255, 204, 204, 204);
            titleBar.ButtonBackgroundColor= Color.FromArgb(255, 204, 204, 204);

            ApplicationView.GetForCurrentView().Title = "Project";

            this.InitializeComponent();

            SplitViewVM vmSplitView = new SplitViewVM(splitView);
            lstCategories.DataContext = vmSplitView;

           
        }

       

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //base.OnNavigatedTo(e);
            btnRefresh_Click(this, null);
        }


        private void SuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            
            if(SuggestBox.Text!="")
            {
                //checking arraySearch
                if(!arraySearch.Contains(SuggestBox.Text))
                {
                    arraySearch.Add(SuggestBox.Text.ToString());
                    i = arraySearch.Count - 1;
                    btnBack.IsEnabled = true;
                }
               
                

                // pivot is selected

                if (privotContent.SelectedIndex==0)
                {
                    lstWeb.DataContext = null;
                    ViewModel.WebsVM vmWebs = new ViewModel.WebsVM(SuggestBox.Text, "10", "0", "en-us", "Moderate");
                    lstWeb.DataContext = vmWebs;
                }
                else if(privotContent.SelectedIndex==1)
                {
                    lstPhotos.DataContext = null;
                    PhotosVM vmPhotos = new PhotosVM(SuggestBox.Text, "30", "0", "en-us", "Moderate", imgImageView);
                    lstPhotos.DataContext = vmPhotos;
                }
                else if(privotContent.SelectedIndex==2)
                {
                    lstVideo.DataContext = null;
                    VideosVM vmVideos = new VideosVM(SuggestBox.Text, "50", "0", "en-us", "Moderate");
                    lstVideo.DataContext = vmVideos;
                }
                else if(privotContent.SelectedIndex==3)
                {
                    lstNews.DataContext = null;
                    NewsVM vmNews = new NewsVM(SuggestBox.Text, "10", "0", "en-us", "Moderate");
                    lstNews.DataContext = vmNews;
                }

                btnRefresh.IsEnabled = true;
                
            }
           
        }

        List<TextBlock> txt = new List<TextBlock>();
        private void privotContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txt.Add(txtWebHeader);
            txt.Add(txtPhotosHeader);
            txt.Add(txtVideoHeader);
            txt.Add(txtNewsHeader);
            MainVM mainVM = new MainVM(privotContent.SelectedIndex, txt);
            mainVM.PivotItemChanged();

            var args = new AutoSuggestBoxQuerySubmittedEventArgs();
            SuggestBox_QuerySubmitted(SuggestBox, args);


        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SuggestBox.Width = gridPanel.ActualWidth;

        }

        private void btnBackPicture_Click(object sender, RoutedEventArgs e)
        {
            if(lstPhotos.SelectedIndex>0)
            {
                lstPhotos.SelectedIndex--;
            }
                
        }

        private void btnNextPicture_Click(object sender, RoutedEventArgs e)
        {
            if(lstPhotos.SelectedIndex>=0 && lstPhotos.SelectedIndex <= lstPhotos.Items.Count-1)
            {
                lstPhotos.SelectedIndex++;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            var args = new AutoSuggestBoxQuerySubmittedEventArgs();
            SuggestBox_QuerySubmitted(SuggestBox, args);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            if (arraySearch!=null)
            {
                
                
                if(i>0)
                {
                    i = i - 1;
                    btnNext.IsEnabled = true;
                    
                }
                else if(i<=0)
                {
                    btnBack.IsEnabled = false;
                }

                SuggestBox.Text = arraySearch[i];
                var args = new AutoSuggestBoxQuerySubmittedEventArgs();
                SuggestBox_QuerySubmitted(SuggestBox, args);

            }
           
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {


            if (arraySearch!=null)
            {
                if(i < arraySearch.Count-1)
                {
                    i = i + 1;
                   
                }
                else if(i>=arraySearch.Count - 1)
                {
                    btnNext.IsEnabled = false;
                    
                }
               
                SuggestBox.Text = arraySearch[i];
                var args = new AutoSuggestBoxQuerySubmittedEventArgs();
                SuggestBox_QuerySubmitted(SuggestBox, args);
            }
            
        }

        private void btnBack_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(btnBack.IsEnabled==true)
                btnBack.Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 33, 33));
            else
                btnBack.Foreground = new SolidColorBrush(Color.FromArgb(255, 204, 204, 204));
        }

        private void btnNext_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(btnNext.IsEnabled==true)
                btnNext.Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 33, 33));
            else
                btnNext.Foreground = new SolidColorBrush(Color.FromArgb(255, 204, 204, 204));

        }

        private void btnRefresh_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(btnRefresh.IsEnabled==true)
                btnRefresh.Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 33, 33));
            else
                btnRefresh.Foreground= new SolidColorBrush(Color.FromArgb(255, 204, 204, 204));
        }
    }
}
