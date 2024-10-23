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
    public partial class Anasayfa : Window
    {
        string kullanicino="bos";
        public Anasayfa(string kno)
        {   kullanicino=kno;
            InitializeComponent();
             string baglanti=@"Datasource=.\SqLiteDataBase.db";
            SQLiteConnection conn= new SQLiteConnection(baglanti);
            conn.Open();
            SQLiteCommand komut=new SQLiteCommand(conn);
            komut.CommandText="SELECT isim from kullanicilartablo where kno=@kullanicino";
            komut.Parameters.AddWithValue("@kullanicino",kno);
            string sifredogrula=Convert.ToString(komut.ExecuteScalar());
             komut.CommandText="SELECT klimit from kullanicilartablo where kno=@kullanicino";
            komut.Parameters.AddWithValue("@kullanicino",kno);
            string limit=Convert.ToString(komut.ExecuteScalar());
            conn.Close();
            isim.Content=$@"Hoşgeldin {sifredogrula}";
            klimit.Content=$"Kitap limitiniz= {limit} ";
        }
     
    public string sorgula(string tablo,string aranacak,string parametre,string aranan){
            string baglanti=@"Datasource=.\SqLiteDataBase.db";
            SQLiteConnection conn= new SQLiteConnection(baglanti);
            SQLiteCommand komut=new SQLiteCommand(conn);
            string limit="olmadi";
            try{

            conn.Open();
      
            komut.CommandText=$"select {aranacak} from {tablo} where {parametre}=@aranan";
            komut.Parameters.AddWithValue("@aranan",aranan);
            limit=Convert.ToString(komut.ExecuteScalar());
              return limit;
            }
            catch(Exception err){MessageBox.Show(Convert.ToString(err));

            }
            finally{
            conn.Close();
            }

            return limit;
    }
   public void kitapal(Object sender,EventArgs e){
    Kitapal kitappenceresi=new Kitapal(kullanicino);
    kitappenceresi.Show();
    this.Close();
   }
    public void kitapiade(Object sender,EventArgs e){
        Kitapiade kitapiade= new Kitapiade(kullanicino);
        kitapiade.Show();
        this.Close();
        }
        
    }
}