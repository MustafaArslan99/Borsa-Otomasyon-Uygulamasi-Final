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
    public partial class AdminOnay : Form
    {
        public AdminOnay()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti;
        OleDbDataAdapter adapter;
        DataSet ds;

        private void AdminOnay_Load(object sender, EventArgs e)
        {
            UrunlerDoldur();//Admin onayına gönderilmiş ürün varsa getir.
            KullaniciDoldur();//Admin onayına gönderilmiş para ekleme isteği varsa getir.
        }

        private void UrunlerDoldur()
        {
            //Admin onayına gönderilmiş ürün varsa getir.
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            adapter = new OleDbDataAdapter("Select * from OnayBekleyenUrunler", baglanti);
            ds = new DataSet();
            baglanti.Open();

            adapter.Fill(ds, "OnayBekleyenUrunler");
            dataGridView1.DataSource = ds.Tables["OnayBekleyenUrunler"];

            baglanti.Close();
        }

        private void KullaniciDoldur()
        {
            //Admin onayına gönderilmiş para ekleme isteği varsa getir.
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            adapter = new OleDbDataAdapter("Select * from OnayBekleyenParalar", baglanti);
            ds = new DataSet();
            baglanti.Open();

            adapter.Fill(ds, "OnayBekleyenParalar");
            dataGridView2.DataSource = ds.Tables["OnayBekleyenParalar"];

            baglanti.Close();
        }

        private void btn_urunonayla_Click(object sender, EventArgs e)
        {
            //Adminin ürünü onaylayabilmesi için gerekli işlemler
            try
            {
                UrunOnay uo = new UrunOnay();
                uo.UrunNo =Convert.ToInt32(txt_urunno.Text);
                uo.Onayver();
                UrunlerDoldur();
                txt_urunno.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Meydana Geldi Lütfen Tekrar Deneyiniz.");
            }
            
        }

        private void btn_urunsil_Click(object sender, EventArgs e)
        {
            //Adminin ürünü silebilmesi için gerekli işlemler.
            try
            {
                UrunOnay uo = new UrunOnay();
                uo.UrunNo = Convert.ToInt32(txt_urunno.Text);
                uo.Sil();
                UrunlerDoldur();
                txt_urunno.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Meydana Geldi Lütfen Tekrar Deneyiniz.");
            }
            
        }

        private void btn_paraonayla_Click(object sender, EventArgs e)
        {
            //Adminin kullanıcıdan gelen yükleme isteğini onaylaması için gerekli işlemler
            try
            {
                ParaOnay po = new ParaOnay();
                po.KullaniciNo = txt_kullanicino.Text;
                po.Onayver();
                KullaniciDoldur();
                txt_kullanicino.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Meydana Geldi Lütfen Tekrar Deneyiniz.");
            }
            
        }

        private void btn_parasil_Click(object sender, EventArgs e)
        {
            //Adminin kullanıcıdan gelen yükleme isteiğini silmesi için gerekli işlemler.
            try
            {
                ParaOnay po = new ParaOnay();
                po.KullaniciNo = txt_kullanicino.Text;
                po.Sil();
                KullaniciDoldur();
                txt_kullanicino.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Meydana Geldi Lütfen Tekrar Deneyiniz.");
            }
            
        }
    }
}
