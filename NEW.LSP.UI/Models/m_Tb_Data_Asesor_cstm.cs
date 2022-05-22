using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Data_Asesor_cstm : Tb_Data_Asesor_cstm
    {
        public m_Tb_Data_Asesor_cstm() { }
        public m_Tb_Data_Asesor_cstm(Tb_Data_Asesor_cstm item)
        {
            this.id_asesor = item.id_asesor;
            this.No_Reg_Met = item.No_Reg_Met;
            this.NPSN = item.NPSN;
            this.Nama_Asesor = item.Nama_Asesor;
            this.Kode_KK = item.Kode_KK;
            this.Tanggal_Sertifikat_Asesor = item.Tanggal_Sertifikat_Asesor;
            this.Nama_KK = item.Nama_KK;


            this.isDeleted = item.isDeleted;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;

            this.Nama_Sekolah = item.Nama_Sekolah;
            this.NamaKabupaten = item.NamaKabupaten;
        }

        public new Int32? id_asesor { get; set; }

        [Required(ErrorMessage = "Harap Masukan No REG MET")]
        [Display(Name = "MET (LISENSI BNSP)")]
        [StringLength(100, MinimumLength = 10)]
        public new string No_Reg_Met { get; set; }

        [Required(ErrorMessage = "Harap masukan data NPSN")]
        [Display(Name = "NPSN")]
        public new Int32? NPSN { get; set; }

        [Display(Name = "Nama Asesor")]
        public new string Nama_Asesor { get; set; }

        [Required(ErrorMessage = "Harap masukan data Kode Kompetensi Keahlian Terlisensi")]
        [Display(Name = "Kode Kompetensi Keahlian Terlisensi")]
        public new Int32? Kode_KK { get; set; }

        [Display(Name = "Kompetensi Keahlian Terlisensi")]
        public new string Nama_KK { get; set; }

        [Required(ErrorMessage = "Harap masukan Tanggal Sertifikat Asesor")]
        [Display(Name = "Tanggal Sertifikat Asesor")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public new DateTime? Tanggal_Sertifikat_Asesor { get; set; }

        [Display(Name = "Nama Sekolah")]
        public new string Nama_Sekolah { get; set; }

        [Display(Name = "Nama Kabupaten")]
        public new string NamaKabupaten { get; set; }
    }
}