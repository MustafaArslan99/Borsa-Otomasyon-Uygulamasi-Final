using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Proje
{
    class UrunOnay:Client
    {
        private int urunno;
        public int UrunNo { get { return urunno; } set { this.urunno = value; } }
        OleDbConnection baglanti;
        OleDbCommand komut;
        public void Onayver()
        {
            //Kullanıcının satmak istediği ürünlere onay ver.

            DateTime zaman = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            string zamanim = zaman.ToString(format); 
            //veritabanında tarihin gözükmesini istediğim şekilde ayarladım

            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "update Urunler set AdminOnay='Evet', SatisTarih='" + zamanim + "' where UrunNo=" + urunno + "";
            komut.ExecuteNonQuery();

            baglanti.Close();
        }

        public void Sil()
        {
            //Kullanıcının satmak istediği ürünleri sil
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "delete from Urunler where UrunNo=" + urunno + " AND AdminOnay='Hayır'";
            komut.ExecuteNonQuery();

            baglanti.Close();
        }
    }
}
