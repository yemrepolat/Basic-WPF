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
using System.Data;
using System.Data.SQLite;
namespace nesneproje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void girisdenemesi(Object sender,RoutedEventArgs e){
       
            string baglanti=@"Datasource=.\SqLiteDataBase.db";
            SQLiteConnection conn= new SQLiteConnection(baglanti);
            try{conn.Open();
            SQLiteCommand komut=new SQLiteCommand(conn);
            SQLiteCommand komut2=new SQLiteCommand(conn);
           
            komut2.CommandText="SELECT kno from ids where kadi=@kullaniciadi and sifre=@sifremiz";
            komut2.Parameters.AddWithValue("@kullaniciadi",kadi.Text);
            komut2.Parameters.AddWithValue("@sifremiz",sifre.Password);
            string kuno=Convert.ToString(komut2.ExecuteScalar());
           
          
            if(!string.IsNullOrEmpty(kuno)){



        Anasayfa anasayfa =new Anasayfa(kuno);
        this.Close();
        anasayfa.Show();
            }
            else MessageBox.Show("Kullanıcı adı veya şifre yanlış");
            }
            catch(Exception er){MessageBox.Show(Convert.ToString(er));}
            finally{
                conn.Close();
            }
        }
        public void kaydolagec(Object sender,EventArgs e){
           Kaydolpencere pencere=new Kaydolpencere();

            this.Close();
            pencere.Show();
        }
    }
}
