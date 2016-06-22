using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Bing_Search_API.ViewModel
{
    public class SplitViewVM : INotifyPropertyChanged
    {
        public class SplitMenu
        {
            public string bitmapIcon { get; set; }
            public string title { get; set; }
        }

        private SplitView splitView { get; set; }

        ObservableCollection<SplitMenu> splitMenu = new ObservableCollection<SplitMenu>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<SplitMenu> menuList
        {
            get { return splitMenu; }
        }

        public SplitViewVM(SplitView splView)
        {
            splitView = splView;
            AddMenu();
        }



        public void AddMenu()
        {
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Menu-24.png", title = "" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Brush-24.png", title = "Arts" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/US Dollar-24.png", title = "Business" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Theatre Mask-24.png", title = "Entertaiment" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Cook Male-24.png", title = "Food" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Cards-24.png", title = "Gaming" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Heart Health-24.png", title = "Health" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Date Man Woman-24.png", title = "Lifestyle" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Home-24.png", title = "Living" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Car-24.png", title = "Motoring" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Megaphone-24.png", title = "News" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Test Tube-24.png", title = "Science" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Football 2-24.png", title = "Sport" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Google Drive-24.png", title = "Technology" });
            splitMenu.Add(new SplitMenu { bitmapIcon = "/Assets/Airplane Take Off-24.png", title = "Travel" });
            
        }

        private int selectedIndex =-1;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if(value!=selectedIndex)
                {
                    selectedIndex = value;
                    if(selectedIndex==0)
                    {
                        splitView.IsPaneOpen = !splitView.IsPaneOpen;
                    }

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedIndex"));
                }
            }
        }

        private string selectedItem;
        public string SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (value != selectedItem)
                {
                    selectedItem = value;

                    if(selectedIndex!=0)
                    {
                        
                    }

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedItem"));
                }
            }
        }
    }
}
