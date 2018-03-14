using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab11
{
    class DATA
    {
        public static int baslangic_sehri_plaka_kodu { get; set; }
        public static int varis_sehri_plaka_kodu { get; set; }
        public static string verilenDosyalarinKlasoru { get; set; }

        public static DugumYapisi[] dugumYapilari_sabit_ucret_max_kar { get; set; }
        public static DugumYapisi[] dugumYapilari_degisken_ucret_50_kar { get; set; }

    }
}
