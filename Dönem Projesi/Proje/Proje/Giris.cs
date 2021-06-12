using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Proje
{
    public class Giris:Client
    {

        private int kontrol = 0;

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
            komut.CommandText = "SELECT KullaniciAd,Sifre FROM Kullanici where KullaniciAd='" + Kulad + "' AND Sifre=" + Sifre + "";
            dr = komut.ExecuteReader();

            if (dr.Read())
                kontrol = 1;
            baglanti.Close();
            dr.Close();
            return kontrol;
        }

        public void GirisYap()
        {
            //Veritabanı bağlantısı kurup giriş işlemlerini yap.
            if (Kulad=="admin" && Sifre==123)
            {
                AdminOnay ao = new AdminOnay();
                ao.Show();
            }
            else 
            {
                if (KullaniciKontrol() == 1)//Kullanıcı kayıtlı ise giriş yap
                {
                    System.Windows.Forms.MessageBox.Show("Girdiğiniz Bilgiler Sistemde Kayıtlı Programa Girişiniz Yapılıyor.");
                    AliciveSaticiBilgiGiris asbg = new AliciveSaticiBilgiGiris();
                    asbg.KullaniciAd = Kulad;
                    asbg.Show();
                }
                else//kullanici kayıtlı değil ise
                {
                    System.Windows.Forms.MessageBox.Show("Bilgileriniz Sistemde Bulunmuyor Lütfen Tekrar Deneyiniz.Hesabınız Yoksa Lütfen Kayıt Olunuz.");
                }
            }            
        }
    }
}
