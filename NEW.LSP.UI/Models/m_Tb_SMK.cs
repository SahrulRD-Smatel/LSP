using NEW.LSP.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_SMK : Tb_SMK
    {
        public m_Tb_SMK() { }
        public m_Tb_SMK(Tb_SMK item)
        {
            this.NPSN = item.NPSN;
            this.Kode_Kabupaten = item.Kode_Kabupaten;
            this.Nama_Sekolah = item.Nama_Sekolah;
            this.Status_Sekolah = item.Status_Sekolah;
            this.Status_LSP = item.Status_LSP;
            this.Kode_KK = item.Kode_KK;
            this.isDeleted = item.isDeleted;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
        }

        [Required(ErrorMessage = "Harap masukan data NPSN Number")]
        [StringLength(8, MinimumLength = 8)]
        public new Int32 NPSN { get; set; }

        [Required(ErrorMessage = "Harap masukan data Nama Sekolah")]
        [Display(Name = "Nama Sekolah")]
        [StringLength(50, MinimumLength = 5)]
        public new string Nama_Sekolah { get; set; }

        [Required(ErrorMessage = "Harap pilih Kabupaten")]
        [Display(Name = "Kabupaten")]
        public new int? Kode_Kabupaten { get; set; }
  
        [Required(ErrorMessage = "Harap pilih Status Sekolah")]
        [Display(Name = "Status Sekolah")]
        public new string Status_Sekolah { get; set; }
        [Display(Name = "Status LSP")]
        public new string Status_LSP { get; set; }
        [Display(Name = "Kode Kompetensi Keahlian")]
        public new int? Kode_KK { get; set; } 
   
    }
}