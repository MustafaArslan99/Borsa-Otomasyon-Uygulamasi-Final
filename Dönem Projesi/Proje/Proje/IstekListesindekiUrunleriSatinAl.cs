using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Proje
{
    class IstekListesindekiUrunleriSatinAl
    {
        OleDbConnection baglanti;
        OleDbCommand komut;

        public void IstegiSil(int istekno)
        {
            komut = new OleDbCommand();

            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut.Connection = baglanti; 

            komut.CommandText = "delete from IstekListesi where IstekNo=" + istekno +"";
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
