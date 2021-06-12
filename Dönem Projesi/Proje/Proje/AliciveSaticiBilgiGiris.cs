using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Proje
{
    public partial class AliciveSaticiBilgiGiris : Form
    {
        public AliciveSaticiBilgiGiris()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti;
        OleDbCommand komut;
        OleDbDataReader dr;
        OleDbDataAdapter adapter;
        DataSet ds;

        public string KullaniciAd;
        public int para;
        private void AliciveSaticiBilgiGiris_Load(object sender, EventArgs e)
        {            
            lbl_Kulad.Text = KullaniciAd;
            ParayiGetir(); //Kullanıcının Parasını label'a yazdırır
            UrunleriGetir(); //Satış listesindeki ürünleri getirir.  
            IstekListesiDoldur();//İstek listesindeki ürünleri getirir.    
            
            OtomatikSatinAl();

            UrunleriGetir();
            IstekListesiDoldur();
            ParayiGetir();
        }

        private void ParayiGetir()
        {
            //veritabanından parayı çek. Paranın tutulduğu labela yaz.            
            try
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
                komut = new OleDbCommand();
                komut.Connection = baglanti;
                baglanti.Open();
                komut.CommandText = "SELECT YukluPara FROM Kullanici where KullaniciAd='" + lbl_Kulad.Text + "'";
                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    para = Convert.ToInt32(dr[0]);
                }

                baglanti.Close();
                dr.Close();
                lbl_Para.Text = para.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Meydana Geldi.\nLütfen Tekrar Deneyiniz.");
            }
            
        }

        private void UrunleriGetir()
        {
            //veritabanından satış listesindeki ürünleri getir.
            try
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
                adapter = new OleDbDataAdapter("Select * from SatistakiUrunler", baglanti);
                ds = new DataSet();
                baglanti.Open();

                adapter.Fill(ds, "SatistakiUrunler");
                dataGridView1.DataSource = ds.Tables["SatistakiUrunler"];
                dataGridView1.Columns[0].HeaderText = "Ürün Numarası";
                dataGridView1.Columns[1].HeaderText = "Satıcı Adı";
                dataGridView1.Columns[2].HeaderText = "Ürün İsmi";
                dataGridView1.Columns[3].HeaderText = "Miktar";
                dataGridView1.Columns[4].HeaderText = "Tür";
                dataGridView1.Columns[5].HeaderText = "Fiyat";
                dataGridView1.Columns[6].HeaderText = "Satışa Çıktığı Tarih";

                baglanti.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Meydana Geldi.\nLütfen Tekrar Deneyiniz.");
            }
            
        }

        private void IstekListesiDoldur()
        {
            try
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
                adapter = new OleDbDataAdapter("Select * from IstekListesi ", baglanti);
                ds = new DataSet();
                baglanti.Open();

                adapter.Fill(ds, "IstekListesi");
                dataGridView2.DataSource = ds.Tables["IstekListesi"];
                dataGridView2.Columns[1].HeaderText = "İsteyen Alıcı";
                dataGridView2.Columns[2].HeaderText = "Ürün İsmi";
                dataGridView2.Columns[3].HeaderText = "Miktar";
                dataGridView2.Columns[4].HeaderText = "Tür";
                dataGridView2.Columns[5].HeaderText = "Fiyat";
                dataGridView2.Columns[6].HeaderText = "İsteğin Atıldığı Zaman";

                baglanti.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Meydana Geldi.\nLütfen Tekrar Deneyiniz.");
            }
        }

        private void OtomatikSatinAl()
        {
            int urunno, urunmiktar, fiyat; 
            string urunad, miktartur;

            int istekno, istekmiktar, istekfiyat;
            string isteyenad, istekurunad, istektur;

            OleDbDataReader dr2;
            OleDbCommand komut2 = new OleDbCommand();

            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            komut = new OleDbCommand();
            komut.Connection = baglanti;
            baglanti.Open();

            komut.CommandText = "select UrunNo,UrunAd,UrunMiktar,MiktarTur,Fiyat from Urunler where AdminOnay='Evet'";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                urunno = Convert.ToInt32(dr[0]);
                urunad = dr[1].ToString();
                urunmiktar = Convert.ToInt32(dr[2]);
                miktartur = dr[3].ToString();
                fiyat = Convert.ToInt32(dr[4]);
                
                komut2.Connection = baglanti;
                komut2.CommandText = "select IstekNo,IsteyenAd,Urunad,Miktar,Tur,Fiyat from IstekListesi";
                dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    istekno = Convert.ToInt32(dr2[0]);
                    isteyenad = dr2[1].ToString();
                    istekurunad = dr2[2].ToString();
                    istekmiktar = Convert.ToInt32(dr2[3]);
                    istektur = dr2[4].ToString();
                    istekfiyat = Convert.ToInt32(dr2[5]);

                    if ((urunad == istekurunad) && (urunmiktar == istekmiktar) && (miktartur == istektur) && (fiyat == istekfiyat))
                    {
                        // istek listesindeki ürün satışa çıkmış demektir.
                        // istek numarasını ve ürün numarasını fonksiyona gönder.
                        UrunSatinAl usa = new UrunSatinAl();
                        usa.SatinAlan = isteyenad;
                        usa.Bakiye = para;
                        usa.UrunNo = urunno;
                        usa.UrunSatinAlma();
                        IstekListesindekiUrunleriSatinAl ilusa = new IstekListesindekiUrunleriSatinAl();
                        ilusa.IstegiSil(istekno);
                    }
                }
                dr2.Close();
            }
            dr.Close();
            baglanti.Close();
        }
        private void btn_Parayükle_Click(object sender, EventArgs e)
        {
            //Kullanıcının para yükleme işlemleri
            try
            {
                string paracinsi = cmbbox_ParaCins.Text;
                ParaEkleme pe = new ParaEkleme();
                pe.IstenenPara = Convert.ToInt32(txt_parayükle.Text);
                pe.ParaEKle(KullaniciAd,paracinsi);
                txt_parayükle.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Meydana Geldi.\nLütfen Tekrar Deneyiniz.");
            }            
        }
            
        private void btn_urunekle_Click(object sender, EventArgs e)
        {
            //Kullanıcının ürün satışa çıkarmka için gerekli işlemleri
            try
            {
                UrunEkle ue = new UrunEkle();
                ue.UrunAd = txt_urunad.Text;
                ue.Miktar = Convert.ToInt32(txt_urunmiktar.Text);
                ue.Tur = txt_uruntur.Text;
                ue.Fiyat = Convert.ToInt32(txt_urunfiyat.Text);

                ue.UrunSatis(KullaniciAd);
                txt_urunad.Text = "";
                txt_urunfiyat.Text = "";
                txt_urunmiktar.Text = "";
                txt_uruntur.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Meydana Geldi.\nLütfen Tekrar Deneyiniz.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kullanıcının satış listesindeki ürünü almak için gerekli işlemleri
            try
            {
                UrunSatinAl usa = new UrunSatinAl();
                usa.UrunNo = Convert.ToInt32(txt_urunno.Text);
                usa.SatinAlan = lbl_Kulad.Text;
                usa.Bakiye = para;
                usa.UrunSatinAlma();
                UrunleriGetir();
                ParayiGetir();
                txt_urunno.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Meydana Geldi.\nLütfen Tekrar Deneyiniz.");
            }            
        }

        private void btn_satinalinmisurunler_Click(object sender, EventArgs e)
        {
            //Satın alınmış ürünlere bakmak isterse forma gönder.
            SatinAlinmisUrunler sau = new SatinAlinmisUrunler();
            sau.kullaniciad = lbl_Kulad.Text;
            sau.Show();
        }

        private void btn_isteklistesineekle_Click(object sender, EventArgs e)
        {
            try
            {
                IstekListesineEkle ıle = new IstekListesineEkle();
                //bilgileri gir
                ıle.AlmakIsteyen = lbl_Kulad.Text;
                ıle.UrunAd = txt_istekurunad.Text;
                ıle.Miktar = Convert.ToInt32(txt_istekurunmiktar.Text);
                ıle.Tur = txt_istekuruntur.Text;
                ıle.Fiyat = Convert.ToInt32(txt_istekurunfiyat.Text);
                ıle.ListeyeEkle();

                IstekListesiDoldur();//veritabanına ekle
                //ekranı güzelleştir.
                txt_istekurunad.Text = "";
                txt_istekurunfiyat.Text = "";
                txt_istekurunmiktar.Text = "";
                txt_istekuruntur.Text = "";

                OtomatikSatinAl();
                UrunleriGetir();
                IstekListesiDoldur();
                ParayiGetir();
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Meydana Geldi.\nLütfen Tekrar Deneyiniz.");
            }
            
        }
    }
}
