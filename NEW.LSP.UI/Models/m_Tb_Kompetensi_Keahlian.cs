using NEW.LSP.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Kompetensi_Keahlian : Tb_Kompetensi_Keahlian
    {
        public m_Tb_Kompetensi_Keahlian() { }
        public m_Tb_Kompetensi_Keahlian(Tb_Kompetensi_Keahlian item)
        {
            this.Kode_KK = item.Kode_KK;
            this.Nama_KK = item.Nama_KK;
            this.isDeleted = item.isDeleted;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
        }


        [Required(ErrorMessage = "Harap masukan data Kompetensi Keahlian")]
        [Display(Name = "Kode Kompetensi Keahlian")]
        public new int Kode_KK { get; set; }

        [Required(ErrorMessage = "Harap masukan data Kompetensi Keahlian")]
        [Display(Name = "Kompetensi Keahlian")]
        public new string Nama_KK { get; set; }

    }
}