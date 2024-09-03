using System;

namespace phoneliblary
{
    class Contactlist
    {
        public string İsim {get; set;}
        public string Soyisim { get; set; }
        public string Numara {get; set;}


        public Contactlist (string isim, string soyisim, string numara)
        {
            İsim= isim;
            Soyisim = soyisim;
            Numara = numara;
        }
        public override string ToString()
        {
            return $"İsim: {İsim} , Soyisim: {Soyisim} , Telefon numarası: {Numara}";
        }
    }
}