using NEW.LSP.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Skema : Tb_Skema
    {

        public m_Tb_Skema() { }
        public m_Tb_Skema(Tb_Skema item)
        {
            this.Kode_KK = item.Kode_KK;
            this.Kode_Skema = item.Kode_Skema;
            this.Skema = item.Skema;
            this.isDeleted = item.isDeleted;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;

        }

        [Required(ErrorMessage = "Harap masukan data Kompetensi Keahlian")]
        [Display(Name = "Kode Kompetensi Keahlian")]
        public new int Kode_KK { get; set; }

        [Required(ErrorMessage = "Harap masukan data Skema")]
        [Display(Name = "Kode Skema")]
        public new int Kode_Skema { get; set; }

        [Required(ErrorMessage = "Harap masukan data Skema")]
        [Display(Name = "Skema")]
        public new string Skema { get; set; }

    }
}