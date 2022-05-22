using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Penerima_Sertifikat_cstm : Tb_Penerima_Sertifikat_cstm
    {
        public m_Tb_Penerima_Sertifikat_cstm() { }
        public m_Tb_Penerima_Sertifikat_cstm(Tb_Penerima_Sertifikat_cstm item)
        {
            this.Kode_Penerima_Sertifikat = item.Kode_Penerima_Sertifikat;
            this.Nomer_Lisensi = item.Nomer_Lisensi;
            this.Kode_KK = item.Kode_KK;
            this.IDTahun_pelajaran = item.IDTahun_pelajaran;
            this.Jumlah_penerima_sertifikat = item.Jumlah_penerima_sertifikat;
            this.isDeleted = item.isDeleted;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
            this.Tahun_pelajaran = item.Tahun_pelajaran;

            this.NPSN = item.NPSN;
            this.Nama_KK = item.Nama_KK;
            this.Nama_Sekolah = item.Nama_Sekolah;
            this.NamaKabupaten = item.NamaKabupaten;
            this.Kode_Skema = item.Kode_Skema;
            this.Skema = item.Skema;

        }
        [Display(Name = "Kode Penerima Sertifikat")]
        public new int Kode_Penerima_Sertifikat { get; set; }

        [Required(ErrorMessage = "Harap masukan data Nomer Lisensi")]
        [Display(Name = "Nomor Lisensi")]
        public new string Nomer_Lisensi { get; set; }

        [Required(ErrorMessage = "Harap masukan data Kode Kompetensi Keahlian")]
        [Display(Name = "Kode Kompetensi Keahlian")]
        public new int Kode_KK { get; set; }

        [Display(Name = "Tahun Pelajaran")]
        public new string Tahun_pelajaran { get; set; }

        [Required(ErrorMessage = "Harap masukan data Tahun Pelajaran")]
        [Display(Name = "Tahun Pelajaran")]
        public new Int32? IDTahun_pelajaran { get; set; }

        [Required(ErrorMessage = "Harap masukan data Jumlah Penerima Sertifikat")]
        [Display(Name = "Jumlah Penerima Sertifikat")]
        [Range(1, 1000)]
        public new Int32? Jumlah_penerima_sertifikat { get; set; }

        [Required(ErrorMessage = "Harap masukan data NPSN")]
        [Display(Name = "NPSN")]
        public new Int32? NPSN { get; set; }

        [Display(Name = "Kompetensi Keahlian")]
        public new string Nama_KK { get; set; }

        [Display(Name = "Nama Sekolah (LSP P1)")]
        public new string Nama_Sekolah { get; set; }

        [Display(Name = "Kabupaten")]
        public new string NamaKabupaten { get; set; }

        [Required(ErrorMessage = "Harap masukan data Skema")]
        [Display(Name = "Kode Skema")]
        public new Int32? Kode_Skema { get; set; }

        [Required(ErrorMessage = "Harap masukan data Skema")]
        [Display(Name = "Skema")]
        public new string Skema { get; set; }
    }
}