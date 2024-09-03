using System;
using System.Collections;

namespace phoneliblary
{
    class Program
    {
        static void Main(string[] args)
        {
            Rehber rehber = new Rehber();
            bool exit =false;
            
            while (!exit)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
                Console.WriteLine("(6) Çıkış");

                string secım =Console.ReadLine();

                switch (secım)
                {
                    case "1":
                        rehber.AddContact();
                        break;
                    case "2":
                        rehber.RemoveContact();
                        break;
                    case "3":
                        rehber.UpgradeNumber();
                        break;
                    case "4":
                        rehber.ListContacts();
                        break;
                    case "5":
                        rehber.SearchPerson();
                        break;
                    case "6":
                        exit =true;
                        break;
                    default:
                        Console.WriteLine("geçersiz secenek lütfen tekrar deneyin");
                        break;
                }   

            }
        }
    }
}