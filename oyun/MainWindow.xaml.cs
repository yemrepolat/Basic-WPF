using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace oyun
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   Rectangle uzaygemisi = new Rectangle();
        Rectangle dusman = new Rectangle();
        Rectangle dusman2 = new Rectangle();
        Rectangle dusman3 = new Rectangle();
        Rectangle dusman4 = new Rectangle();
        Rectangle dusman5 = new Rectangle();
        Ellipse mermi=new Ellipse();
        Ellipse mermi2=new Ellipse();
        int kursun=5;
        Random randomsayi=new Random();
        Random randomsayi2=new Random();

        public void basildi(Object sender,KeyEventArgs e){
            double x,y;
            switch(e.Key){
            case Key.Left: x=Canvas.GetLeft(uzaygemisi)-30; if(x<0)x=0;    Canvas.SetLeft(uzaygemisi,x);         mermi.Fill=Brushes.Black;  mermi.Stroke=Brushes.Black; mermi2.Stroke=Brushes.Black;  mermi2.Fill=Brushes.Black;       dusmanoynat(dusman); dusmanoynat(dusman2);dusmanoynat(dusman3);dusmanoynat(dusman4);dusmanoynat(dusman5); break;
            case Key.Right:x=Canvas.GetLeft(uzaygemisi)+30;  if(x>800-uzaygemisi.Width)x=800-uzaygemisi.Width;     Canvas.SetLeft(uzaygemisi,x); mermi.Stroke=Brushes.Black; mermi2.Stroke=Brushes.Black;    mermi.Fill=Brushes.Black;    mermi2.Fill=Brushes.Black;         dusmanoynat(dusman);dusmanoynat(dusman2);dusmanoynat(dusman3);dusmanoynat(dusman4);dusmanoynat(dusman5);  break;
            case Key.Up:   y=Canvas.GetTop(uzaygemisi)-30;  if(y<600)y=600;Canvas.SetTop(uzaygemisi,y);                                  mermi.Stroke=Brushes.Black; mermi2.Stroke=Brushes.Black;                   mermi.Fill=Brushes.Black;    mermi2.Fill=Brushes.Black;     dusmanoynat(dusman);dusmanoynat(dusman2);dusmanoynat(dusman3);dusmanoynat(dusman4);dusmanoynat(dusman5);                                            break;
            case Key.Down: y=Canvas.GetTop(uzaygemisi)+30;  if(y>1200-(uzaygemisi.Height+200))y=1200-(uzaygemisi.Height+200); Canvas.SetTop(uzaygemisi,y);        mermi.Stroke=Brushes.Black; mermi2.Stroke=Brushes.Black;   mermi.Fill=Brushes.Black;    mermi2.Fill=Brushes.Black;     dusmanoynat(dusman);dusmanoynat(dusman2);dusmanoynat(dusman3);dusmanoynat(dusman4);dusmanoynat(dusman5);                                                                                          break;
            case Key.Space:   ateset();
            if(Canvas.GetLeft(uzaygemisi)>=Canvas.GetLeft(dusman)&&Canvas.GetLeft(uzaygemisi)<=Canvas.GetLeft(dusman)+30){vur(dusman);} 
            if(Canvas.GetLeft(uzaygemisi)+30>=Canvas.GetLeft(dusman)&&Canvas.GetLeft(uzaygemisi)+30<=Canvas.GetLeft(dusman)+30&&dusman.Visibility!=Visibility.Hidden)vur(dusman);
            if(Canvas.GetLeft(uzaygemisi)>=Canvas.GetLeft(dusman2)&&Canvas.GetLeft(uzaygemisi)<=Canvas.GetLeft(dusman2)+30||Canvas.GetLeft(uzaygemisi)+30>=Canvas.GetLeft(dusman2)&&Canvas.GetLeft(uzaygemisi)+30<=Canvas.GetLeft(dusman2)+30&&dusman2.Visibility!=Visibility.Hidden){vur(dusman2); } 
            if(Canvas.GetLeft(uzaygemisi)+30>=Canvas.GetLeft(dusman2)&&Canvas.GetLeft(uzaygemisi)+30<=Canvas.GetLeft(dusman2)+30&&dusman2.Visibility!=Visibility.Hidden)vur(dusman2);
            if(Canvas.GetLeft(uzaygemisi)>=Canvas.GetLeft(dusman3)&&Canvas.GetLeft(uzaygemisi)<=Canvas.GetLeft(dusman3)+30||Canvas.GetLeft(uzaygemisi)+30>=Canvas.GetLeft(dusman3)&&Canvas.GetLeft(uzaygemisi)+30<=Canvas.GetLeft(dusman3)+30&&dusman3.Visibility!=Visibility.Hidden){vur(dusman3); } 
            if(Canvas.GetLeft(uzaygemisi)+30>=Canvas.GetLeft(dusman3)&&Canvas.GetLeft(uzaygemisi)+30<=Canvas.GetLeft(dusman3)+30&&dusman3.Visibility!=Visibility.Hidden)vur(dusman3);
            if(Canvas.GetLeft(uzaygemisi)>=Canvas.GetLeft(dusman4)&&Canvas.GetLeft(uzaygemisi)<=Canvas.GetLeft(dusman4)+30||Canvas.GetLeft(uzaygemisi)+30>=Canvas.GetLeft(dusman4)&&Canvas.GetLeft(uzaygemisi)+30<=Canvas.GetLeft(dusman4)+30&&dusman4.Visibility!=Visibility.Hidden){vur(dusman4); } 
            if(Canvas.GetLeft(uzaygemisi)+30>=Canvas.GetLeft(dusman4)&&Canvas.GetLeft(uzaygemisi)+30<=Canvas.GetLeft(dusman4)+30&&dusman4.Visibility!=Visibility.Hidden)vur(dusman4);
            if(Canvas.GetLeft(uzaygemisi)>=Canvas.GetLeft(dusman5)&&Canvas.GetLeft(uzaygemisi)<=Canvas.GetLeft(dusman5)+30||Canvas.GetLeft(uzaygemisi)+30>=Canvas.GetLeft(dusman5)&&Canvas.GetLeft(uzaygemisi)+30<=Canvas.GetLeft(dusman5)+30&&dusman5.Visibility!=Visibility.Hidden){vur(dusman5);} 
            if(Canvas.GetLeft(uzaygemisi)+30>=Canvas.GetLeft(dusman5)&&Canvas.GetLeft(uzaygemisi)+30<=Canvas.GetLeft(dusman5)+30&&dusman5.Visibility!=Visibility.Hidden)vur(dusman5);

             break;



            }
        }
        public MainWindow()
        {

            InitializeComponent();
            tuval.Children.Add(uzaygemisi);
            uzaygemisiyerlestir();
            dusmanyerlestir(dusman);
            dusmanyerlestir(dusman2);
            dusmanyerlestir(dusman3);
            dusmanyerlestir(dusman4);
            dusmanyerlestir(dusman5);

        }
        public void vur(Rectangle dusman){
              Random randomsayi=new Random();
        Random randomsayi2=new Random();
        int randomyon=randomsayi2.Next(0,2);
         puan.Content=Convert.ToInt32(puan.Content)+1;
         if(randomyon==1) 
         if(Canvas.GetLeft(dusman)+125<1200)Canvas.SetLeft(dusman,Canvas.GetLeft(dusman)+randomsayi.Next(50,125));
         else{dusman.Visibility=Visibility.Hidden;}
         else
         if(Canvas.GetLeft(dusman)-125>0)Canvas.SetLeft(dusman,Canvas.GetLeft(dusman)-randomsayi.Next(50,125));
        }
      public void uzaygemisiyerlestir(){
            uzaygemisi.Width=75;
            uzaygemisi.Height=30;
            uzaygemisi.Stroke=Brushes.Pink;
            uzaygemisi.Fill=Brushes.Pink;
            Canvas.SetLeft(uzaygemisi,400);
            Canvas.SetTop(uzaygemisi,800);
            tuval.Children.Add(mermi);
            tuval.Children.Add(mermi2);

        }
         public void dusmanyerlestir(Rectangle dusman){ 
            tuval.Children.Add(dusman);
            dusman.Width=30;
            dusman.Height=30;
            dusman.Stroke=Brushes.Red;
            dusman.Fill=Brushes.Red;
            Canvas.SetLeft(dusman,randomsayi.Next(0,800));
            Canvas.SetTop(dusman,randomsayi2.Next(0,550));
          }
       

        public void dusmanoynat(Rectangle dusman){
   int rastgelesayi=randomsayi.Next(0,10),rastgelesayi2=randomsayi2.Next(0,4); 
   double dusmaninx=Canvas.GetLeft(dusman),dusmaniny=Canvas.GetTop(dusman);
   if(rastgelesayi<7){switch(rastgelesayi2){ 
    case 1:if(dusmaninx>0){Canvas.SetLeft(dusman,dusmaninx-20);   Canvas.SetTop(dusman,dusmaniny);}break; 
    case 2: if(dusmaninx<800-dusman.Width){ Canvas.SetLeft(dusman,dusmaninx+20); Canvas.SetTop(dusman,dusmaniny);} break;
     case 3: if(dusmaniny>20){ Canvas.SetLeft(dusman,dusmaninx); Canvas.SetTop(dusman,dusmaniny-20);} break; 
     case 4:  if(dusmaniny<570){Canvas.SetLeft(dusman,dusmaninx); Canvas.SetTop(dusman,dusmaniny+20);} break;  };                                                                      

        }
           

        }
        public void ateset(){ double mermix=Canvas.GetLeft(uzaygemisi),mermiy=Canvas.GetTop(uzaygemisi); double mermix2=(Canvas.GetLeft(uzaygemisi)+60),mermiy2=Canvas.GetTop(uzaygemisi);
            mermi.Width=20;
            mermi.Height=mermiy;
            mermi.Stroke=Brushes.Blue;
            mermi.Fill=Brushes.Blue;
            mermi2.Width=20;
            mermi2.Height=mermiy;
            mermi2.Stroke=Brushes.Blue;
            mermi2.Fill=Brushes.Blue;
            Canvas.SetTop(mermi,0); Canvas.SetLeft(mermi,mermix); 
             Canvas.SetTop(mermi2,0); Canvas.SetLeft(mermi2,mermix2);  } 
        }

    }

