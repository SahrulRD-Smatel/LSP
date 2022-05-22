using NEW.LSP.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_SMK_Kompetensi_Keahlian : Tb_SMK_Kompetensi_Keahlian
    {
        public m_Tb_SMK_Kompetensi_Keahlian() { }
        public m_Tb_SMK_Kompetensi_Keahlian(Tb_SMK_Kompetensi_Keahlian item)
        {
            this.ID = item.ID;
            this.NPSN = item.NPSN;
            this.Kode_KK = item.Kode_KK;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
        }

        [Display(Name = "ID")]
        public new int ID { get; set; }

        [Display(Name = "NPSN")]
        [Required(ErrorMessage = "Harap masukan data NPSN Number")]
        public new Int32? NPSN { get; set; }

        [Display(Name = "Kode Kopetensi Keahlian")]
        [Required(ErrorMessage = "Harap pilih Kompetensi Keahlian")]
        public new int? Kode_KK { get; set; }
    }
}