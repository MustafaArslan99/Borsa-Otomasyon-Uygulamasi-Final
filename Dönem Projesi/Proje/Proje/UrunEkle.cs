using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Proje
{
    class UrunEkle:Client
    {
        private string urunad;
        private int miktar;
        private string tur;
        private int fiyat;

        public string UrunAd { get { return urunad; } set { this.urunad = value; } }
        public int Miktar { get { return miktar; } set { this.miktar = value; } }
        public string Tur { get { return tur; } set { this.tur = value; } }
        public int Fiyat { get { return fiyat; } set { this.fiyat = value; } }

        OleDbConnection baglanti;
        OleDbCommand komut;

        public void UrunSatis(string kulad)
        {
            //Veritabanı bağlantısı yaparak ürünleri veritabanına ekle
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "insert into Urunler(KullaniciAd, UrunAd ,UrunMiktar, MiktarTur, Fiyat) values('" + kulad + "', '" + urunad + "','" + miktar + "','" + tur + "','" + fiyat + "')";
            komut.ExecuteNonQuery();

            baglanti.Close();
            System.Windows.Forms.MessageBox.Show("Ürün Satış İsteğiniz Admine Ulaştırıldı Kontrolleriniz Yapıldıktan Sonra Admin Onay Verirse Ürününüz Pazara Çıkacaktır.");
        }
    }
}
