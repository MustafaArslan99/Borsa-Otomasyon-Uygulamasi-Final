using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Xml;

namespace Proje
{
    class ParaEkleme:Client
    {
        private double istenenpara;
        public double IstenenPara { get { return istenenpara; } set { this.istenenpara = value; } }

        OleDbConnection baglanti;
        OleDbCommand komut;

        public void ParaEKle(string kulad,string paracins)
        {
            //Veritabanındaki parayı istenen para ile degistir.

            XmlTextReader rdr = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");

            XmlDocument myxml = new XmlDocument();

            myxml.Load(rdr);

            XmlNode tarih = myxml.SelectSingleNode("/Tarih_Date/@Tarih");
            XmlNodeList mylist = myxml.SelectNodes("/Tarih_Date/Currency");
            XmlNodeList adi = myxml.SelectNodes("/Tarih_Date/Currency/Isim");
            XmlNodeList kod = myxml.SelectNodes("/Tarih_Date/Currency/@Kod");
            XmlNodeList doviz_alis = myxml.SelectNodes("/Tarih_Date/Currency/ForexBuying");
            XmlNodeList doviz_satis = myxml.SelectNodes("/Tarih_Date/Currency/ForexSelling");
            XmlNodeList efektif_alis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteBuying");
            XmlNodeList efektif_satis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteSelling");

            if (paracins=="TL")
            {
                istenenpara *= 1;
            }
            else if(paracins=="USD")
            {
                double degisecekpara = Convert.ToDouble(doviz_satis.Item(0).InnerText.ToString());
                istenenpara *= (degisecekpara/10000);
            }
            else if (paracins=="EURO")
            {
                double degisecekpara = Convert.ToDouble(doviz_satis.Item(3).InnerText.ToString());
                istenenpara *= (degisecekpara / 10000);
            }
            else
            {
                double degisecekpara = Convert.ToDouble(doviz_satis.Item(4).InnerText.ToString());
                istenenpara *= (degisecekpara / 10000);
            }

            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "update Kullanici set ParaIsteniyorMu='Evet', ParaIste='" + istenenpara + "' where KullaniciAd='" + kulad + "'";
            komut.ExecuteNonQuery();

            baglanti.Close();

            System.Windows.Forms.MessageBox.Show("Para Yükleme İsteğiniz Gönderildi Admin Onay Verdiğinde Hesabınıza Para Yüklenecektir.");
        }
    }
}
