using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wipiief
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {}
      public void basildi(object sender ,RoutedEventArgs e ){
        for(int i=0;i<txt1.Text.Length;i++){
          if(txt1.Text[i]!=',')switch(txt1.Text[i]){
            case '0':if(checkbox0.IsChecked==false)checkbox0.IsChecked=true; else{checkbox0.IsChecked=false;}break;
            case '1':if(checkbox1.IsChecked==false)checkbox1.IsChecked=true; else{checkbox1.IsChecked=false;}break;
            case '2':if(checkbox2.IsChecked==false)checkbox2.IsChecked=true; else{checkbox2.IsChecked=false;}break;
            case '3':if(checkbox3.IsChecked==false)checkbox3.IsChecked=true; else{checkbox3.IsChecked=false;}break;
            case '4':if(checkbox4.IsChecked==false)checkbox4.IsChecked=true; else{checkbox4.IsChecked=false;}break;
            case '5':if(checkbox5.IsChecked==false)checkbox5.IsChecked=true; else{checkbox5.IsChecked=false;}break;
            case '6':if(checkbox6.IsChecked==false)checkbox6.IsChecked=true; else{checkbox6.IsChecked=false;}break;
            case '7':if(checkbox7.IsChecked==false)checkbox7.IsChecked=true; else{checkbox7.IsChecked=false;}break;
            case '8':if(checkbox8.IsChecked==false)checkbox8.IsChecked=true; else{checkbox8.IsChecked=false;}break;
            case '9':if(checkbox9.IsChecked==false)checkbox9.IsChecked=true; else{checkbox9.IsChecked=false;}break;
          }
        }
        }
    }
}
