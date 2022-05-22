using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Kompetensi_Keahlian_Terlisensi_cstm: Tb_Kompetensi_Keahlian_Terlisensi_cstm
    {
        public m_Tb_Kompetensi_Keahlian_Terlisensi_cstm() { }
        public m_Tb_Kompetensi_Keahlian_Terlisensi_cstm(Tb_Kompetensi_Keahlian_Terlisensi_cstm item)
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

            this.NPSN = item.NPSN;
            this.Nama_KK = item.Nama_KK;
            this.Nama_Sekolah = item.Nama_Sekolah;
            this.NamaKabupaten = item.NamaKabupaten;
            this.Kode_Skema = item.Kode_Skema;
            this.Skema = item.Skema;
        }


        [Required(ErrorMessage = "Harap masukan data Kode Kompetensi Keahlian Terlisensi")]
        [Display(Name = "Kode Kompetensi Keahlian Terlisensi")]
        public new int Kode_KK_Terlisensi { get; set; }

        [Required(ErrorMessage = "Harap masukan data Nomor Lisensi")]
        [Display(Name = "Nomor Lisensi")]
        public new string Nomer_Lisensi { get; set; }
        [Required(ErrorMessage = "Harap masukan data kode Kompetensi Keahlian")]
        [Display(Name = "Kode Kompetensi Keahlian")]
        public new int Kode_KK { get; set; }
        [Required(ErrorMessage = "Harap masukan data Status Kompetensi Keahlian Terlisensi")]
        [Display(Name = "Status")]
        public new string Status_KK_Terlisensi { get; set; }

        [Required(ErrorMessage = "Harap masukan data Jumlah Asesor")]
        [Display(Name = "Jumlah Asesor")]
        [Range(0, 1000)]
        public new int? Jumlah_asesor { get; set; }

        [Display(Name = "NPSN")]
        [Required(ErrorMessage = "Harap masukan data NPSN Number")]       
        public new Int32? NPSN { get; set; }

        [Display(Name = "Kompetensi Keahlian Terlisensi")]
        public new string Nama_KK { get; set; }

        [Display(Name = "Nama Sekolah (LSP P1)")]
        public new string Nama_Sekolah { get; set; }

        [Display(Name = "Kabupaten")]
        public new string NamaKabupaten { get; set; }

        [Required(ErrorMessage = "Harap masukan data Skema")]
        [Display(Name = "Kode Skema")]
        public new int Kode_Skema { get; set; }

        [Required(ErrorMessage = "Harap masukan data Skema")]
        [Display(Name = "Skema")]
        public new string Skema { get; set; }
    }
}