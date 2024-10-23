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
    public partial class Kitapiade : Window
    {  public int hucrevalue=0;
       public string kuno="asd";
        public Kitapiade(string kno)
        { kuno=kno;

            InitializeComponent();    
                  using (SQLiteConnection con = new SQLiteConnection("Data Source = SqLiteDataBase.db"))
    {
        // DataTable
        var dataTable = new DataTable();
        // 
     SQLiteCommand command = con.CreateCommand();
        command.CommandText = $"SELECT * FROM kitaplar where sahipno='{kno}'";
        command.CommandType = CommandType.Text;
        command.Connection = con;
        //
        var adapter =new SQLiteDataAdapter();
        adapter.SelectCommand = command;
        adapter.Fill(dataTable);
        dataGrid.DataContext = dataTable;
    }
        }


public void basildi(Object sender,EventArgs e){
        foreach (DataGridCellInfo info in dataGrid.SelectedCells)
    {
           DataRowView satir = (DataRowView)info.Item;

             hucrevalue = Convert.ToInt32(satir["kitapno"]);
    }

    }
     public void geri(Object sender,EventArgs e){
        Anasayfa anasayfa= new Anasayfa(kuno);
        anasayfa.Show();
        this.Close();


        }

    public void kitabiade(Object sender,EventArgs e){
          string baglanti=@"Datasource=.\SqLiteDataBase.db";
            SQLiteConnection conn= new SQLiteConnection(baglanti);
         try{
     conn.Open();
            SQLiteCommand komut=new SQLiteCommand(conn);

komut.CommandText="update kitaplar set sahipno=NULL where kitapno=@kitabno";
           komut.Parameters.AddWithValue("@kitabno",hucrevalue);

            komut.ExecuteNonQuery();
           komut.CommandText="update kitaplar set kalangun='0' where kitapno=@kitabno";
           komut.Parameters.AddWithValue("@kitabno",hucrevalue);
            komut.ExecuteNonQuery();
           komut.CommandText="update kullanicilartablo set klimit=(select klimit from kullanicilartablo where kno=@kuno)+1 where kno=@kuno";
           komut.Parameters.AddWithValue("@kuno",kuno);
            komut.ExecuteNonQuery();
                MessageBox.Show("Kitap iadesi başarılı");



         }  
         catch(Exception ex){MessageBox.Show(ex.ToString());}
         finally{
            conn.Close();
         }
         
         
     


    }

    }
   

}