using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace phoneliblary
{
    class Rehber
    {
        private List <Contactlist> contactlists;

        public Rehber()
        {
            contactlists = new List<Contactlist>
            {
                new Contactlist("emre","ay","543-4545"),
                new Contactlist("ali","güneş","536-6497"),
                new Contactlist("ayse","yılmaz","535-35647"),
                new Contactlist("elif", "batmaz","543-9734"),
                new Contactlist("mehmet", "aksu","543-9874")
            };
        }
        public void AddContact()
        {
            Console.WriteLine("Lütfen isim giriniz         :");
            string isim=Console.ReadLine();
            Console.WriteLine("Lütfen soyismini giriniz    :");
            string soyisim=Console.ReadLine();
            Console.WriteLine("lütfen numarayı giriniz     :");
            string numara=Console.ReadLine();
            contactlists.Add(new Contactlist(isim,soyisim,numara));
            Console.WriteLine("başarıyla eklendi");
        }
        public void RemoveContact()
        {
            Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string searchQuery = Console.ReadLine();
            var contactlist = contactlists.FirstOrDefault(a => a.İsim.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                                                               a.Soyisim.Equals(searchQuery, StringComparison.OrdinalIgnoreCase));
            if (contactlist != null)
            {
                Console.WriteLine($"{contactlist.İsim} isimli kişiyi silmek üzeresiniz onaylıyor musunuz (E/H)");
                string onay = Console.ReadLine();
                if (onay == "E")
                {
                    contactlists.Remove(contactlist);
                    Console.WriteLine("kişi başarıyla silindi");
                }else{
                    Console.WriteLine("silme işlemi ptal edildi");
                }
            }else {
                Console.WriteLine("aradığınız kritere uygun birisi bulunamadı");
                Console.WriteLine("silme işlemini sonlamdırmak için: (1),yeniden denemek için: (2)");
                string secım =Console.ReadLine();
                if (secım == "2"){
                    RemoveContact();
                }
            }
        }
        public void UpgradeNumber()
        {
            Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string searchQuery = Console.ReadLine();
            var contactlist = contactlists.FirstOrDefault(a => a.İsim.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                                                               a.Soyisim.Equals(searchQuery, StringComparison.OrdinalIgnoreCase));
            if (contactlist != null)
            {
                Console.WriteLine($"Güncellenen Kişi: {contactlist}");
                Console.Write("Yeni telefon numarasını giriniz: ");
                string newNumara = Console.ReadLine();
                contactlist.Numara = newNumara;
                Console.WriteLine("Kişi başarıyla güncellendi.");

                // Console.WriteLine($"Güncellenen Kişi: {contactlist}");
                // Console.Write("Yeni isim giriniz: ");
                // string newİsim = Console.ReadLine();
                // contactlist.İsim = newİsim;
                // Console.WriteLine("Kişi başarıyla güncellendi.");

                // Console.WriteLine($"Güncellenen Kişi: {contactlist}");
                // Console.Write("Yeni soyisim giriniz: ");
                // string newSoyisim = Console.ReadLine();
                // contactlist.Soyisim = newSoyisim;
                // Console.WriteLine("Kişi başarıyla güncellendi.");
            }else{
                Console.WriteLine("aradığınız kritere uygun birisi bulunamadı");
                Console.WriteLine("Güncelleme işlemini sonlamdırmak için: (1),yeniden denemek için: (2)");
                string secım =Console.ReadLine();
                if (secım == "2"){
                    UpgradeNumber();
                }
            }
        }
        public void ListContacts(bool ascending =true)
        {
            var sortedcontactlists = ascending
                ? contactlists.OrderBy(b => b.İsim).ThenBy(b => b.İsim)
                : contactlists.OrderByDescending(b => b.Soyisim).ThenByDescending(b => b.Soyisim);

            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("**********************************************");
            foreach (var contactlist in sortedcontactlists)
            {
                Console.WriteLine(contactlist);
            }
        }
        public void SearchPerson()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz:");
            Console.WriteLine("1. İsim veya soyisime göre arama yapmak");
            Console.WriteLine("2. Telefon numarasına göre arama yapmak");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Lütfen kişinin adını ya da soyadını giriniz: ");
                string searchQuery = Console.ReadLine();
                var contactlist = contactlists.FirstOrDefault(a => a.İsim.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                                                               a.Soyisim.Equals(searchQuery, StringComparison.OrdinalIgnoreCase));
                if (contactlist != null)
                {
                    Console.WriteLine($"aradığınız Kişi: {contactlist}");
                }
                else{
                    Console.WriteLine("eksik yada hatalı tuşladınız. tekrar denekem için: (1), iptal etmek için: (2)");
                    string secim = Console.ReadLine();
                    if ( secim == "1")
                    {
                        SearchPerson();
                    }
                }
            }else{
                Console.Write("Lütfen kişinin anumarasını giriniz: ");
                string searchQuery = Console.ReadLine();
                var contactlist = contactlists.FirstOrDefault(a => a.Numara.Equals(searchQuery, StringComparison.OrdinalIgnoreCase));
                if (contactlist != null)
                {
                    Console.WriteLine($"aradığınız Kişi: {contactlist}");
                }
                else{
                    Console.WriteLine("eksik yada hatalı tuşladınız. tekrar denekem için: (1), iptal etmek için: (2)");
                    string secim = Console.ReadLine();
                    if ( secim == "1")
                    {
                        SearchPerson();
                    }
                }
            }
        }
    }
}