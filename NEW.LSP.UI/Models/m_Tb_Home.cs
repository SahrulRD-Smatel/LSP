using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Home : Tb_Home_cstm
    {
        public m_Tb_Home() { }
        public m_Tb_Home(Tb_Home_cstm item)
        {
            this.jmlSMK = item.jmlSMK;
            this.jmlAsesor = item.jmlAsesor;
            this.jmlLSP = item.jmlLSP;
            this.jmlKKT = item.jmlKKT;
            this.jmlPS = item.jmlPS;
            this.descript = item.descript;
        }
        [Display(Name = "Jumlah SMK")]
        public new Int32? jmlSMK { get; set; }

        [Display(Name = "Jumlah Asesor")]
        public new Int32? jmlAsesor { get; set; }

        [Display(Name = "Jumlah LSP")]
        public new Int32? jmlLSP { get; set; }
        [Display(Name = "Jumlah Kompetensi Keahlian Terlisensi")]
        public new Int32? jmlKKT { get; set; }
        [Display(Name = "Jumlah Penerima Sertifikat")]
        public new Int32? jmlPS { get; set; }
        public new string descript { get; set; }
    }
}