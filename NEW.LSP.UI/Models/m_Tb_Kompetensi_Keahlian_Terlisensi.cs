using NEW.LSP.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Kompetensi_Keahlian_Terlisensi: Tb_Kompetensi_Keahlian_Terlisensi
    {
        public m_Tb_Kompetensi_Keahlian_Terlisensi() { }
        public m_Tb_Kompetensi_Keahlian_Terlisensi(Tb_Kompetensi_Keahlian_Terlisensi item)
        {
            this.Kode_KK_Terlisensi = item.Kode_KK_Terlisensi;
            this.Nomer_Lisensi = item.Nomer_Lisensi;
            this.Kode_KK = item.Kode_KK;
            this.Status_KK_Terlisensi = item.Status_KK_Terlisensi;
            this.Jumlah_asesor = item.Jumlah_asesor;
            this.isDeleted = item.isDeleted;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
        }

        [Required(ErrorMessage = "Harap masukan data Kode Kompetensi Keahlian Terlisensi")]
        [Display(Name = "Kode Kompetensi Keahlian Terlisensi")]
        public new int Kode_KK_Terlisensi { get; set; }

        [Required(ErrorMessage = "Harap masukan data Nomor Lisensi")]
        [Display(Name = "Nomor Lisensi")]
        public new string Nomer_Lisensi { get; set; }
        [Required(ErrorMessage = "Harap masukan data kode Kompetensi Keahlian")]
        [Display(Name = "Kode Kompetensi Keahlian")]
        public new Int32? Kode_KK { get; set; }
        [Required(ErrorMessage = "Harap masukan data Status Kompetensi Keahlian Terlisensi")]
        [Display(Name = "Status")]
        public new string Status_KK_Terlisensi { get; set; }

        [Required(ErrorMessage = "Harap masukan data Jumlah Asesor")]
        [Display(Name = "Jumlah Asesor")]
        [Range(0, 1000)]
        public new int? Jumlah_asesor { get; set; }       

    }
}