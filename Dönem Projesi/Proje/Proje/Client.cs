using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Proje
{
    public class Client
    {
        private string ad;
        private string soyad;
        private string kulad;
        private int sifre;
        private int tckimlikno;
        private int telno;
        private string email;
        private string adres;
        private int para;
        public string Ad { get { return ad; } set { this.ad = value; } }
        public string Soyad { get { return soyad; } set { this.soyad = value; } }
        public string Kulad { get { return kulad; } set { this.kulad = value; } }
        public int Sifre { get { return sifre; } set { this.sifre = value; } }
        public int TCKimlikNo { get { return tckimlikno; } set { this.tckimlikno = value; } }
        public int TelNo { get { return telno; } set { this.telno = value; } }
        public string Email { get { return email; } set { this.email = value; } }
        public string Adres { get { return adres; } set { this.adres = value; } }
        public int Para { get { return para; } set { this.para = value; } }

    }
}
