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
    public partial class Kaydolpencere : Window
    {   public string kuno="asd";
        public Kaydolpencere()
        {
            InitializeComponent();
            
        }


        public void kaydet(Object sender,EventArgs e){
    if(!String.IsNullOrEmpty(kadi.Text)&&!String.IsNullOrEmpty(sifre.Password)&&!String.IsNullOrEmpty(isim.Text)&&!String.IsNullOrEmpty(soyisim.Text)){
        if(kontrolet()){
             string baglanti=@"Datasource=.\SqLiteDataBase.db";
            SQLiteConnection conn= new SQLiteConnection(baglanti);
            conn.Open();
           
           if(sifretekrar.Password==sifre.Password){
            kayit(); SQLiteCommand komut2=new SQLiteCommand(conn);
         komut2.CommandText="SELECT kno from ids where kadi=@kullaniciadi and sifre=@sifremiz";
            komut2.Parameters.AddWithValue("@kullaniciadi",kadi.Text);
            komut2.Parameters.AddWithValue("@sifremiz",sifre.Password);
             kuno=Convert.ToString(komut2.ExecuteScalar());
        
            conn.Close();
        MessageBox.Show("Kayıt olundu"+kuno);
        Anasayfa anasayfa =new Anasayfa(kuno);
        this.Close();
        anasayfa.Show();
        }
        else{MessageBox.Show("Şifre şifre tekrarı ile uyuşmuyor");
        } }
        else{
            MessageBox.Show("Bu kullanıcı adı ile daha önce kayıt olunmuş");
        }
    }
        else MessageBox.Show("Hiçbir bilgi boş bırakılamaz");
        }
        
        public void kayit(){
            
 string baglanti=@"Datasource=.\SqLiteDataBase.db";SQLiteConnection conn= new SQLiteConnection(baglanti);
            conn.Open(); SQLiteCommand komud=new SQLiteCommand(conn);  SQLiteCommand   komud2=new SQLiteCommand(conn);
          SQLiteCommand  komud3=new SQLiteCommand(conn);
           try{
                 
        
            komud.CommandText="INSERT INTO ids (kadi,sifre) VALUES (@kullaniciadi, @sifre);"; 
            komud.Parameters.AddWithValue("@kullaniciadi",kadi.Text);
            komud.Parameters.AddWithValue("@sifre",sifre.Password);
            komud.ExecuteNonQuery(); 
            komud2.CommandText="insert into kullanicilartablo(kno,isim,soyad,klimit) values(@kno,@isim,@soyad,@klimit)";
            komud3.CommandText="select kno from ids where kadi=@kullaniciadi";komud3.Parameters.AddWithValue("@kullaniciadi",kadi.Text);
            int kullanicino=Convert.ToInt32(komud3.ExecuteScalar());
            komud2.Parameters.AddWithValue("@isim",isim.Text);
            komud2.Parameters.AddWithValue("@soyad",soyisim.Text);
            komud2.Parameters.AddWithValue("@kno",kullanicino);
            komud2.Parameters.AddWithValue("@klimit","5");
           komud2.ExecuteNonQuery();
            
           
                     conn.Close();
        
           }
            catch(Exception err){
                MessageBox.Show(Convert.ToString(err));
            }
            finally
            {
            }
        }

        public bool kontrolet(){ 
               string baglanti=@"Datasource=.\SqLiteDataBase.db";
            SQLiteConnection conn=new SQLiteConnection(baglanti);  conn.Open();
            SQLiteCommand kontrol= new SQLiteCommand(conn);
          
            try{
                                  kontrol.CommandText="select count(*) from ids where kadi=@kullaniciadi";
            kontrol.Parameters.AddWithValue("@kullaniciadi",kadi.Text);
            if(Convert.ToInt32(kontrol.ExecuteScalar())==0)return true;
            else return false;
            }
            catch(Exception err){MessageBox.Show(Convert.ToString(err)); return false;}
           finally{conn.Close();}
        }
    }
}