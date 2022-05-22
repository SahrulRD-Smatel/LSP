using NEW.LSP.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Jejaring : Tb_Jejaring
    {
        public m_Tb_Jejaring() { }
        public m_Tb_Jejaring(Tb_Jejaring item)
        {
            this.Kode_Jejaring = item.Kode_Jejaring;
            this.Nomer_Lisensi = item.Nomer_Lisensi;
            this.Kode_KK_Terlisensi = item.Kode_KK_Terlisensi;
            this.NPSN = item.NPSN;
            this.isDeleted = item.isDeleted;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
        }

        [Display(Name = "Kode Jejaring")]
        public new int Kode_Jejaring { get; set; }
        [Required(ErrorMessage = "Harap masukan data Nomor Lisensi")]
        [Display(Name = "Nomor Lisensi")]
        public new string Nomer_Lisensi { get; set; }
        [Required(ErrorMessage = "Harap masukan data Kode Kompetensi Keahlian Terlisensi")]
        [Display(Name = "Kode Kompetensi Keahlian Terlisensi")]
        public new Int32? Kode_KK_Terlisensi { get; set; }
        [Required(ErrorMessage = "Harap masukan data NPSN")]
        [Display(Name = "NPSN")]
        public new Int32? NPSN { get; set; }
    }
}