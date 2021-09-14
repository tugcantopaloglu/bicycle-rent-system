using System;
using System.Collections.Generic;
using System.Text;
//Tuğcan Topaloğlu -05190000072
namespace ds_project_3
{
    class Durak
    {
        public string durakAdi { get; set; }
        public int bosPark { get; set; }
        public int tandemBisiklet { get; set; }

        public List<Musteri> musteriListesi { get; set; }

        public int normalBisiklet { get; set; }
        public Durak(string durakAdi, int bosPark, int tandemBisiklet, int normalBisiklet, List<Musteri> musteriListesi)
        {
            this.durakAdi = durakAdi;
            this.bosPark = bosPark;
            this.tandemBisiklet = tandemBisiklet;
            this.normalBisiklet = normalBisiklet;
            this.musteriListesi = musteriListesi;
        }

        public Durak(string durakAdi, int bosPark, int tandemBisiklet, int normalBisiklet)
        {
            this.durakAdi = durakAdi;
            this.bosPark = bosPark;
            this.tandemBisiklet = tandemBisiklet;
            this.normalBisiklet = normalBisiklet;
            
        }

    }
}
