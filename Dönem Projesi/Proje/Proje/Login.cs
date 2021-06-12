using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        { }
        private void btn_GirisYap_Click(object sender, EventArgs e)
        {
            //kullanıcının giriş yapması
            try
            {
                Giris g = new Giris();
                g.Kulad = txt_KuladGiris.Text;
                g.Sifre = Convert.ToInt32(txt_SifreGiris.Text);
                g.GirisYap();
                GirisEkraniTemizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Lütfen Alanları Boş Bırakmayın.\nBilgileri Doğru Girdiğinizden Emin Olun."+ hata.Message);
            }                
        }

        private void btn_KayitOl_Click(object sender, EventArgs e)
        {
            //kullanıcının kayıt olması
                Kayit k = new Kayit();

                k.Ad = txt_AdKayitOl.Text;
                k.Soyad = txt_SoyadKayitOl.Text;
                k.Kulad = txt_KuladKayitOl.Text;
                k.Sifre = Convert.ToInt32(txt_SifreKayitOl.Text);
                k.TCKimlikNo = Convert.ToInt32(txt_TCKimlikNoKayitOl.Text);
                k.TelNo = Convert.ToInt32(txt_TelefonNoKayitOl.Text);
                k.Email = txt_EmailKayitOl.Text;
                k.Adres = rtxt_AdresKayitOl.Text;
                k.Para = 0;

                k.KayitOl();
                KayitEkraniTemizle();         
        }

        private void GirisEkraniTemizle()
        {
            //ekranın güzel gözükmesi için textbox'ları temizle
            txt_KuladGiris.Text = "";
            txt_SifreGiris.Text = "";
        }
        private void KayitEkraniTemizle()
        {
            //ekranın güzel gözükmesi için textbox'ları temizle
            txt_AdKayitOl.Text = "";
            txt_SoyadKayitOl.Text = "";
            txt_KuladKayitOl.Text = "";
            txt_SifreKayitOl.Text = "";
            txt_EmailKayitOl.Text = "";
            txt_TCKimlikNoKayitOl.Text = "";
            txt_TelefonNoKayitOl.Text = "";
            rtxt_AdresKayitOl.Text = "";
        }
    }
}
