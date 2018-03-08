using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test
{
    class Program
    {
        static Dugum d1, d2, d3, d4, d5, d6;

        static void Main(string[] args)
        {

            

            d1 = new Dugum() { isim = "A" };
            d2 = new Dugum() { isim = "B" };
            d3 = new Dugum() { isim = "C" };
            d4 = new Dugum() { isim = "D" };
            d5 = new Dugum() { isim = "E" };
            d6 = new Dugum() { isim = "F" };

            Kenar k12, k13, k34, k25, k26, k36, k46, k45;
            k12 = new Kenar() { ucDugum = d2, agirlik = 2 };
            k13 = new Kenar() { ucDugum = d3, agirlik = 1 };
            k34 = new Kenar() { ucDugum = d4, agirlik = 1 };
            k25 = new Kenar() { ucDugum = d5, agirlik = 2 };
            k26 = new Kenar() { ucDugum = d6, agirlik = 5 };
            k36 = new Kenar() { ucDugum = d6, agirlik = 2 };
            k46 = new Kenar() { ucDugum = d6, agirlik = 5 };
            k45 = new Kenar() { ucDugum = d5, agirlik = 7 };


            d1.kenarlar.Add(k12); d1.kenarlar.Add(k13);
            d2.kenarlar.Add(k25); d2.kenarlar.Add(k26);
            d3.kenarlar.Add(k34); d3.kenarlar.Add(k36);
            d4.kenarlar.Add(k45); d4.kenarlar.Add(k46);
            
            Console.Read();
        }

        public static void DijikstraCoz(Dugum baslangicDugum, Dugum bitisDugum)
        {

        }

    }

    class Dugum
    {
        public string isim{ get; set; }
        public List<Kenar>kenarlar { get; set; }

        public Dugum()
        {
            kenarlar = new List<Kenar>();
        }
    }

    class Kenar
    {
        public int agirlik { get; set; }
        public Dugum ucDugum { get; set; }
    }

}
