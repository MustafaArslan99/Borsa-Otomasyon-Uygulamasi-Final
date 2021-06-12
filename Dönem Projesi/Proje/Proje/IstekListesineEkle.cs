using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Proje
{
    class IstekListesineEkle:Client
    {
        private string almakisteyen;
        private string urunad;
        private int miktar;
        private string tur;
        private int fiyat;
        public string AlmakIsteyen { get { return almakisteyen; } set { this.almakisteyen = value; } }
        public string UrunAd { get { return urunad; } set { this.urunad = value; } }
        public int Miktar { get { return miktar; } set { this.miktar = value; } }
        public string Tur { get { return tur; } set { this.tur = value; } }
        public int Fiyat { get { return fiyat; } set { this.fiyat = value; } }

        OleDbConnection baglanti;
        OleDbCommand komut;
        public void ListeyeEkle()
        {
            DateTime dt = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            string zaman = dt.ToString(format);
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "insert into IstekListesi(IsteyenAd,UrunAd,Miktar,Tur,Fiyat,IstekTarih) values('" + almakisteyen + "','" + urunad + "'," + miktar + ",'" + tur + "'," + fiyat + ",'" + zaman + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            System.Windows.Forms.MessageBox.Show("\nSatın alma isteğiniz listeye eklendi istediğiniz fiyattan ürün satılırsa otomatik olarak satış işlemi gerçekleşecek.\n");

        }
    }
}
