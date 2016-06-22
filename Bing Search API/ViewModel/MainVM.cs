using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Bing_Search_API.ViewModel
{
    public class MainVM 
    {
       
       private int index { get; set; }
       private List<TextBlock> txt { get; set; }
       public MainVM(int index, List<TextBlock> txt)
        {
            this.index = index;
            this.txt = txt;
            
        }
       
        public void PivotItemChanged()
        {
            try
            {
                switch(index)
                {
                    case 0:
                        txt[0].Foreground = new SolidColorBrush(Color.FromArgb(255, 13, 71, 161));
                        txt[1].Foreground = new SolidColorBrush(Color.FromArgb(255,102,102,102));
                        txt[2].Foreground = new SolidColorBrush(Color.FromArgb(255, 102, 102, 102));
                        txt[3].Foreground = new SolidColorBrush(Color.FromArgb(255, 102, 102, 102));
                        
                        break;
                    case 1:
                        txt[0].Foreground = new SolidColorBrush(Color.FromArgb(255, 102, 102, 102));
                        txt[1].Foreground = new SolidColorBrush(Color.FromArgb(255, 13, 71, 161));
                        txt[2].Foreground = new SolidColorBrush(Color.FromArgb(255, 102, 102, 102));
                        txt[3].Foreground = new SolidColorBrush(Color.FromArgb(255, 102, 102, 102));
                        break;
                    case 2:
                        txt[0].Foreground = new SolidColorBrush(Color.FromArgb(255, 102, 102, 102));
                        txt[1].Foreground = new SolidColorBrush(Color.FromArgb(255, 102, 102, 102));
                        txt[2].Foreground = new SolidColorBrush(Color.FromArgb(255, 13, 71, 161));
                        txt[3].Foreground = new SolidColorBrush(Color.FromArgb(255, 102, 102, 102));
                        break;
                    case 3:
                        txt[0].Foreground = new SolidColorBrush(Color.FromArgb(255, 102, 102, 102));
                        txt[1].Foreground = new SolidColorBrush(Color.FromArgb(255, 102, 102, 102));
                        txt[2].Foreground = new SolidColorBrush(Color.FromArgb(255, 102, 102, 102));
                        txt[3].Foreground = new SolidColorBrush(Color.FromArgb(255, 13, 71, 161));
                        break;
                }
            }
            catch
            {

            }
        }
    }


}
