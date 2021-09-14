using System;
using System.Collections.Generic;
using System.Text;
//Tuğcan Topaloğlu -05190000072
namespace ds_project_3
{
    class Musteri
    {
        public int musteriID { get; set; }
        public double kiralamaSaati { get; set; }
        public Musteri(int musteriID, double kiralamaSaati)
        {
            this.musteriID = musteriID;
            this.kiralamaSaati = kiralamaSaati;
        }
    }
}
