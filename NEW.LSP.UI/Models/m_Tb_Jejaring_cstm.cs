using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Jejaring_cstm: Tb_Jejaring_cstm
    {
        public m_Tb_Jejaring_cstm() { }
        public m_Tb_Jejaring_cstm(Tb_Jejaring_cstm item)
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

            this.Nama_KK = item.Nama_KK;
            this.Nama_Sekolah = item.Nama_Sekolah;
            this.NamaKabupaten = item.NamaKabupaten;
            this.NPSNJ = item.NPSNJ;
            this.Nama_SekolahJ = item.Nama_SekolahJ;
            this.NamaKabupatenJ = item.NamaKabupatenJ;
        }

        [Display(Name = "Kode Jejaring")]
        public new int Kode_Jejaring { get; set; }
        [Required(ErrorMessage = "Harap masukan data Nomor Lisensi")]
        [Display(Name = "Nomor Lisensi")]
        public new string Nomer_Lisensi { get; set; }
        [Required(ErrorMessage = "Harap masukan data Kode Kompetensi Keahlian Terlisensi")]
        [Display(Name = "Kode Kompetensi Keahlian Terlisensi")]
        public new int Kode_KK_Terlisensi { get; set; }
        [Required(ErrorMessage = "Harap masukan data NPSN")]
        [Display(Name = "NPSN")]
        public new int NPSN { get; set; }

        [Display(Name = "Kompetensi Keahlian Terlisensi")]
        public new string Nama_KK { get; set; }

        [Required(ErrorMessage = "Harap masukan data Nama Sekolah (LSP P1)")]
        [Display(Name = "Nama Sekolah (LSP P1)")]
        public new string Nama_Sekolah { get; set; }

        [Display(Name = "Kabupaten")]
        public new string NamaKabupaten { get; set; }

        [Required(ErrorMessage = "Harap masukan data NPSN")]
        [Display(Name = "NPSN (Jejaring)")]
        public new string NPSNJ { get; set; }

        [Required(ErrorMessage = "Harap masukan data Nama Sekolah(Jejaring)")]
        [Display(Name = "Nama Sekolah (Jejaring)")]
        public new string Nama_SekolahJ { get; set; }

        [Display(Name = "Kabupaten")]
        public new string NamaKabupatenJ { get; set; }
    }
}