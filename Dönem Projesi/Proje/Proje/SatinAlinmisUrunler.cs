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
using Excel = Microsoft.Office.Interop.Excel;


namespace Proje
{
    public partial class SatinAlinmisUrunler : Form
    {
        public SatinAlinmisUrunler()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti;
        OleDbDataAdapter adapter;
        DataSet ds;

        public string kullaniciad;
        private void SatinAlinmisUrunler_Load(object sender, EventArgs e)
        {
            SatilmisUrunler();
            //veritabanından satın alınmış ürünleri getir.
            try
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
                adapter = new OleDbDataAdapter("Select UrunNo, KullaniciAd, SatinAlan, UrunAd, UrunMiktar, MiktarTur, Fiyat, SatisTarih, AlisTarih from Urunler where SatinAlan='" + kullaniciad + "' AND Satildimi='Evet' ", baglanti);
                ds = new DataSet();
                baglanti.Open();

                adapter.Fill(ds, "Urunler");
                dataGridView2.DataSource = ds.Tables["Urunler"];
                dataGridView2.Columns[0].HeaderText = "Ürün Numarası";
                dataGridView2.Columns[1].HeaderText = "Satıcı Adı";
                dataGridView2.Columns[2].HeaderText = "Satın Alan Adı";
                dataGridView2.Columns[3].HeaderText = "Ürün İsmi";
                dataGridView2.Columns[4].HeaderText = "Miktar";
                dataGridView2.Columns[5].HeaderText = "Tür";
                dataGridView2.Columns[6].HeaderText = "Fiyat";
                dataGridView2.Columns[7].HeaderText = "Satışa Çıktığı Tarih";
                dataGridView2.Columns[8].HeaderText = "Satın Alındığı Tarih";


                baglanti.Close();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Bir Hata Meydana Geldi Lütfen Tekrar Deneyiniz.");
            }          
        }

        private void SatilmisUrunler()
        {
            try
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
                adapter = new OleDbDataAdapter("Select UrunNo, KullaniciAd, SatinAlan, UrunAd, UrunMiktar, MiktarTur, Fiyat, SatisTarih, AlisTarih from Urunler where KullaniciAd='" + kullaniciad + "' AND Satildimi='Evet' ", baglanti);
                ds = new DataSet();
                baglanti.Open();

                adapter.Fill(ds, "Urunler");
                dataGridView1.DataSource = ds.Tables["Urunler"];
                dataGridView1.Columns[0].HeaderText = "Ürün Numarası";
                dataGridView1.Columns[1].HeaderText = "Satıcı Adı";
                dataGridView1.Columns[2].HeaderText = "Satın Alan Adı";
                dataGridView1.Columns[3].HeaderText = "Ürün İsmi";
                dataGridView1.Columns[4].HeaderText = "Miktar";
                dataGridView1.Columns[5].HeaderText = "Tür";
                dataGridView1.Columns[6].HeaderText = "Fiyat";
                dataGridView1.Columns[7].HeaderText = "Satışa Çıktığı Tarih";
                dataGridView1.Columns[8].HeaderText = "Satın Alındığı Tarih";


                baglanti.Close();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Bir Hata Meydana Geldi Lütfen Tekrar Deneyiniz.");
            }
        }

        private void btn_satinalinmisrapor_Click(object sender, EventArgs e)
        {

            string baslangiczaman = dateTimePicker1.Value.ToString();
            string bitiszaman = dateTimePicker2.Value.ToString();

            Excel.Application xlOrn = new Microsoft.Office.Interop.Excel.Application();

            if (xlOrn == null)
            {
                MessageBox.Show("Excel yüklü değil!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlOrn.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            OleDbCommand komut = new OleDbCommand();
            OleDbDataReader dr;
            komut.Connection = baglanti;
            komut.CommandText = "Select UrunNo, KullaniciAd, SatinAlan, UrunAd, UrunMiktar, MiktarTur, Fiyat, SatisTarih, AlisTarih from Urunler where SatinAlan='" + kullaniciad + "'";
            baglanti.Open();
            dr = komut.ExecuteReader();
            xlWorkSheet.Cells[1, 1] = "Ürün Numarası";
            xlWorkSheet.Cells[1, 2] = "Satıcı Adı";
            xlWorkSheet.Cells[1, 3] = "Satın Alan Adı";
            xlWorkSheet.Cells[1, 4] = "Ürün İsmi";
            xlWorkSheet.Cells[1, 5] = "Miktar";
            xlWorkSheet.Cells[1, 6] = "Tür";
            xlWorkSheet.Cells[1, 7] = "Fiyat";
            xlWorkSheet.Cells[1, 8] = "Satış Tarihi";
            xlWorkSheet.Cells[1, 9] = "Alış Tarihi";
            int i = 2;
            int j = 1;
            while (dr.Read())
            {
                xlWorkSheet.Cells[i, j] = dr[0].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[1].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[2].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[3].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[4].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[5].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[6].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[7].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[8].ToString(); j++; i++;
                j = 1; 
            }
            baglanti.Close();            

            xlWorkBook.SaveAs("C:\\Users\\marsl\\OneDrive\\Masaüstü\\Dönem Projesi\\SatinAlinmisUrunler.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlOrn.Quit();

            MessageBox.Show("Excel dosyası oluşturuldu. Raporunuza bakmak için dosyanın bulunduğu klasöre bakınız.");

            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlOrn);
                xlOrn = null;
            }
            catch (Exception ex)
            {
                xlOrn = null;
                MessageBox.Show("Hata " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btn_satilmisrapor_Click(object sender, EventArgs e)
        {
            string baslangiczaman = dateTimePicker3.Value.ToString();
            string bitiszaman = dateTimePicker4.Value.ToString();

            Excel.Application xlOrn = new Microsoft.Office.Interop.Excel.Application();

            if (xlOrn == null)
            {
                MessageBox.Show("Excel yüklü değil!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlOrn.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:/Users/marsl/OneDrive/Masaüstü/Dönem Projesi/YazılımProje.accdb");
            OleDbCommand komut = new OleDbCommand();
            OleDbDataReader dr;
            komut.Connection = baglanti;
            komut.CommandText = "Select UrunNo, KullaniciAd, SatinAlan, UrunAd, UrunMiktar, MiktarTur, Fiyat, SatisTarih, AlisTarih from Urunler where KullaniciAd='" + kullaniciad + "'";
            baglanti.Open();
            dr = komut.ExecuteReader();
            xlWorkSheet.Cells[1, 1] = "Ürün Numarası";
            xlWorkSheet.Cells[1, 2] = "Satıcı Adı";
            xlWorkSheet.Cells[1, 3] = "Satın Alan Adı";
            xlWorkSheet.Cells[1, 4] = "Ürün İsmi";
            xlWorkSheet.Cells[1, 5] = "Miktar";
            xlWorkSheet.Cells[1, 6] = "Tür";
            xlWorkSheet.Cells[1, 7] = "Fiyat";
            xlWorkSheet.Cells[1, 8] = "Satış Tarihi";
            xlWorkSheet.Cells[1, 9] = "Alış Tarihi";
            int i = 2;
            int j = 1;
            while (dr.Read())
            {
                xlWorkSheet.Cells[i, j] = dr[0].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[1].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[2].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[3].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[4].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[5].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[6].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[7].ToString(); j++;
                xlWorkSheet.Cells[i, j] = dr[8].ToString(); j++; i++;
                j = 1;
            }
            baglanti.Close();

            xlWorkBook.SaveAs("C:\\Users\\marsl\\OneDrive\\Masaüstü\\Dönem Projesi\\SatılmışUrunler.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlOrn.Quit();

            MessageBox.Show("Excel dosyası oluşturuldu. Raporunuza bakmak için dosyanın bulunduğu klasöre bakınız.");

            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlOrn);
                xlOrn = null;
            }
            catch (Exception ex)
            {
                xlOrn = null;
                MessageBox.Show("Hata " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
