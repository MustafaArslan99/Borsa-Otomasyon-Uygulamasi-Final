using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Proje
{
    class ParaOnay:Client
    {
        private string kulno;
        private int istenenpara;
        private int yuklupara;
        public string KullaniciNo { get { return kulno; } set { this.kulno = value; } }

        OleDbConnection baglanti;
        OleDbCommand komut;
        OleDbDataReader dr;

        private int ParayiGetir()
        {
            //Kullanıcının yüklemek istediği para miktarını döndür.İçeride para varsa toplam parayı toplayıp döndür.
            komut = new OleDbCommand();
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "select ParaIste, YukluPara from Kullanici where KullaniciNo=" + kulno + "";
            dr = komut.ExecuteReader();

            while(dr.Read())
            {
                istenenpara = Convert.ToInt32(dr[0]);//veri tabanındaki istenen parayı aktar
                yuklupara = Convert.ToInt32(dr[1]);//veri tabanındaki yüklü parayı aktar
            }            
            istenenpara += yuklupara; //ikisini topla

            baglanti.Close();
            dr.Close();
            return istenenpara;//sonucu döndür
        }
        public void Onayver()
        {
            //Kullanıcının istediği paranın hesaba aktarılması
            int toplampara = ParayiGetir();
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();            
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "update Kullanici set ParaIsteniyorMu='Hayır', ParaIste=0, YukluPara='" + toplampara + "'  where KullaniciNo=" + kulno + " ";
            komut.ExecuteNonQuery();

            baglanti.Close();
        }
        public void Sil()
        {
            //Kullanıcının istediği paranın iptal edilmesi
            komut = new OleDbCommand();
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "update Kullanici set ParaIsteniyorMu='Hayır', ParaIste=0 where KullaniciNo=" + kulno + " ";
            komut.ExecuteNonQuery();

            baglanti.Close();
        }
    }
}
