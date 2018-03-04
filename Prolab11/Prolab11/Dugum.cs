﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab11
{
    public class Dugum
    {
        public int plakaKodu { get; set; }
        public string isim { get; set; }
        public int rakim { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public int harita_X { get; set; }
        public int harita_Y { get; set; }
        
        public List<Komsu> komsular { get; set; }
    }

    public class Komsu
    {
        public Dugum komsuDugum { get; set; }
        public int mesafe { get; set; }
    }
}
