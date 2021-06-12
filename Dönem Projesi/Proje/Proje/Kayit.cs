using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace Proje
{
    public class Kayit:Client
    {
        private int kontrol=0;

        OleDbConnection baglanti;
        OleDbCommand komut;
        OleDbDataReader dr;
        private int KullaniciKontrol()
        {
            //Veritabanında girilen kullanıcı adı var mı diye kontrol et varsa 1 yoksa 0 döndür

            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            baglanti.Open();
            komut.CommandText = "SELECT KullaniciAd FROM Kullanici where KullaniciAd='" + Kulad + "'";

            dr = komut.ExecuteReader();
            if (dr.Read())
                kontrol = 1;

            baglanti.Close();
            dr.Close();
            return kontrol;
        }
        public void KayitOl()
        {
            //Veritabanı bağlantısı aç kayıt işlemlerini gerçekleştir.

            if (KullaniciKontrol() == 0)//Kullanıcı kayıtlı değil ise ekle
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
                komut.Connection = baglanti;
                baglanti.Open();
                komut.CommandText = "insert into Kullanici(Ad, Soyad, KullaniciAd, Sifre, TcKimlikNo, Telefon, Email, Adres, ParaIsteniyorMu, ParaIste, YukluPara) values('" + Ad + "','" + Soyad + "','" + Kulad + "','" + Sifre + "','" + TCKimlikNo + "','" + TelNo + "','" + Email + "','" + Adres + "', 'Hayır','" + Para + "','" + Para + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                System.Windows.Forms.MessageBox.Show("Kaydınız Oluşturuldu. Lütfen Giriş Yapınız.");
            }
            else//kullanici kayıtlı ise
            {
                System.Windows.Forms.MessageBox.Show("Kullanıcı Adı Zaten Kayıtlı Lütfen Kullanıcı Adını Değiştiriniz.");
            }
        }
    }
}
