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
    public partial class Kitapal : Window
    {   public string kuno;
        public int hucrevalue=0;
        public Kitapal(string kno)
        {   kuno=kno;
            InitializeComponent();
    
        using (SQLiteConnection con = new SQLiteConnection("Data Source = SqLiteDataBase.db"))
    {
        // DataTable
        var dataTable = new DataTable();
        // 
     SQLiteCommand command = con.CreateCommand();
        command.CommandText = "SELECT * FROM kitaplar where sahipno is null or sahipno='0' or sahipno='NULL'";
        command.CommandType = CommandType.Text;
        command.Connection = con;
        //
        var adapter =new SQLiteDataAdapter();
        adapter.SelectCommand = command;
        adapter.Fill(dataTable);
        dataGrid.DataContext = dataTable;
    }
        }
        public void basildi(Object sender,SelectedCellsChangedEventArgs e){
             foreach (DataGridCellInfo info in dataGrid.SelectedCells)
    {
           DataRowView satir = (DataRowView)info.Item;

             hucrevalue = Convert.ToInt32(satir["kitapno"]);
    }

        }
        public void kitabial(Object sender, EventArgs e){
            string baglanti=@"Datasource=.\SqLiteDataBase.db";
            SQLiteConnection conn= new SQLiteConnection(baglanti);
            try{conn.Open();
            SQLiteCommand komut=new SQLiteCommand(conn);
           komut.CommandText="select sahipno from kitaplar where kitapno=@kitabno";
           komut.Parameters.AddWithValue("@kitabno",hucrevalue);
           string sahiplimi=komut.ExecuteScalar().ToString();


            if(String.IsNullOrEmpty(sahiplimi)||sahiplimi=="0"){

komut.CommandText="update kitaplar set sahipno=@kuno where kitapno=@kitabno";
           komut.Parameters.AddWithValue("@kuno",kuno);
           komut.Parameters.AddWithValue("@kitabno",hucrevalue);

            komut.ExecuteNonQuery();
           komut.CommandText="update kitaplar set kalangun='30' where kitapno=@kitabno";
           komut.Parameters.AddWithValue("@kitabno",hucrevalue);
            komut.ExecuteNonQuery();
           komut.CommandText="update kullanicilartablo set klimit=(select klimit from kullanicilartablo where kno=@kuno)-1 where kno=@kuno";
           komut.Parameters.AddWithValue("@kuno",kuno);
            komut.ExecuteNonQuery();
                MessageBox.Show("Kitap alımı başarılı");







            }
           else{
            MessageBox.Show("Kitap alımı başarısız");
           }
            }
            catch(Exception er){MessageBox.Show(Convert.ToString(er));}
            finally{
                 conn.Close();
            }
        }
        public void geri(Object sender,EventArgs e){
        Anasayfa anasayfa= new Anasayfa(kuno);
        anasayfa.Show();
        this.Close();


        }
       

    }





}