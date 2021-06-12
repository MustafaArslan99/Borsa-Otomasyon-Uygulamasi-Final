using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Proje
{
    class UrunSatinAl:Client
    {
        private string satinalan;
        private string satan;
        private int bakiye;
        private int urunfiyat;
        private int urunno;

        public string SatinAlan { get { return satinalan; } set { this.satinalan = value; } }
        public int Bakiye { get { return bakiye; } set { this.bakiye = value; } }
        public int UrunNo { get { return urunno; } set { this.urunno = value; } }
        
        OleDbConnection baglanti;
        OleDbCommand komut;
        OleDbDataReader dr;
        public void UrunSatinAlma()
        {
            DateTime dt = DateTime.Now;
            string format= "yyyy-MM-dd HH:mm:ss";
            string zaman = dt.ToString(format);
            //veritabanındaki ürün satıldımı sütununu evete değiştir.tarih ekle
            //satın alan kullanıcının parasını düşür,satanın parasını arttır.
            UrunFiyatGetir();
            Satici();
            if (urunfiyat<=bakiye)//Kullanıcının parası ürünü almak için yeterliyse işlemleri gerçekleştir
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
                komut = new OleDbCommand();
                komut.Connection = baglanti;
                baglanti.Open();

                komut.CommandText = "update Urunler set SatinAlan='" + satinalan + "',Satildimi='Evet', AlisTarih='" + zaman + "' where UrunNo=" + urunno + " AND AdminOnay='Evet'";
                komut.ExecuteNonQuery();

                baglanti.Close();
                SaticiyaParaEkle();
                AlicininParasiniAzalt();
                AlicidanKomisyonKes();
                MuhasebeyeParaEkle();
                System.Windows.Forms.MessageBox.Show("Ürün Satın Alındı.");
            }
            else//değilse
            {
                System.Windows.Forms.MessageBox.Show("Paranız Yetersiz.Lütfen Para Yükleyiniz..");
            }                      
        }
        private void UrunFiyatGetir()
        {
            //Kullanıcının satın almak istediği ürünün fiyatını döndür
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "select Fiyat from Urunler where UrunNo=" + urunno + "";
            dr = komut.ExecuteReader();
            while(dr.Read())
            {
                urunfiyat = Convert.ToInt32(dr[0]);
            }
            dr.Close();            
            baglanti.Close();
        }
        private void Satici()
        {
            //Satıcının kim olduğunu döndür.
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "select KullaniciAd from Urunler where UrunNo=" + urunno + "";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                this.satan = dr[0].ToString();
            }
            dr.Close();
            baglanti.Close();
        }
        private void SaticiyaParaEkle()
        {
            //Satan kişiye ürünün fiyatını ekle
            int saticininparasi=0;
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "select YukluPara from Kullanici where KullaniciAd='" + satan + "'";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                saticininparasi = Convert.ToInt32(dr[0]);
            }
            dr.Close();

            saticininparasi += urunfiyat;//içerideki para ile topla.
            komut.CommandText = "update Kullanici set YukluPara='" + saticininparasi  + "' where KullaniciAd='" + satan  + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void AlicininParasiniAzalt()
        {
            //Satın alan kişinin parasını azalt
            int alicininparasi = 0;
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "select YukluPara from Kullanici where KullaniciAd='" + satinalan + "'";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                alicininparasi = Convert.ToInt32(dr[0]);
            }
            dr.Close();

            alicininparasi -= urunfiyat;//İçerideki paradan ürünün fiyatını çıkar.
            komut.CommandText = "update Kullanici set YukluPara='" + alicininparasi + "' where KullaniciAd='" + satinalan + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void AlicidanKomisyonKes()
        {
            //Satın Alanadan %1 komisyon kes
            //Muhasebeye ekle
            int komisyon = 0;
            int alicininparasi = 0;
            double urunfiyatbolu100 = urunfiyat / 100;
            if (urunfiyatbolu100<1)
            {
                komisyon = 1;   
            }
            else
            {
                komisyon=Convert.ToInt32(Math.Round(urunfiyatbolu100));
            }
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "select YukluPara from Kullanici where KullaniciAd='" + satinalan + "'";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                alicininparasi = Convert.ToInt32(dr[0]);
            }
            dr.Close();

            alicininparasi -= komisyon;//İçerideki paradan ürünün fiyatını çıkar.
            komut.CommandText = "update Kullanici set YukluPara='" + alicininparasi + "' where KullaniciAd='" + satinalan + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void MuhasebeyeParaEkle()
        {
            int komisyon = 0;
            int muhasebepara = 0;
            double urunfiyatbolu100 = urunfiyat / 100;
            if (urunfiyatbolu100 < 1)
            {
                komisyon = 1;
            }
            else
            {
                komisyon = Convert.ToInt32(Math.Round(urunfiyatbolu100));
            }
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "select ParaMiktari from Muhasebe where MuhasebeNo=1";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                muhasebepara = Convert.ToInt32(dr[0]);
            }
            dr.Close();
            muhasebepara += komisyon;
            komut.CommandText = "update Muhasebe set ParaMiktari='" + muhasebepara + "' where MuhasebeNo=1";
            komut.ExecuteNonQuery();

            baglanti.Close();

            System.Windows.Forms.MessageBox.Show("Satıştan Komisyon Olarak " + komisyon + " TL Sizin Hesabınızdan Kesildi");
        }
    }
}
