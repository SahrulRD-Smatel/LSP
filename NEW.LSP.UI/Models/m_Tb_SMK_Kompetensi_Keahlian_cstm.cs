using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_SMK_Kompetensi_Keahlian_cstm : Tb_SMK_Kompetensi_Keahlian_cstm
    {
        public m_Tb_SMK_Kompetensi_Keahlian_cstm() { }
        public m_Tb_SMK_Kompetensi_Keahlian_cstm(Tb_SMK_Kompetensi_Keahlian_cstm item)
        {
            this.ID = item.ID;
            this.NPSN = item.NPSN;
            this.Kode_KK = item.Kode_KK;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;

            this.Nama_Sekolah = item.Nama_Sekolah;
            this.NamaKabupaten = item.NamaKabupaten;
            this.Nama_KK = item.Nama_KK;
        }
        [Display(Name = "ID")]
        public new int ID { get; set; }

        [Display(Name = "NPSN")]
        [Required(ErrorMessage = "Harap masukan data NPSN Number")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Harap masukan data NPSN Number")]
        public new Int32? NPSN { get; set; }

        [Display(Name = "Nama Sekolah")]
        public new string Nama_Sekolah { get; set; }

        [Display(Name = "Kode Kopetensi Keahlian")]
        [Required(ErrorMessage = "Harap pilih Kompetensi Keahlian")]
        public new int? Kode_KK { get; set; }

        [Display(Name = "Kompetensi Keahlian")]
        public new string Nama_KK { get; set; }

        [Display(Name = "Nama Kabupaten")]
        public new string NamaKabupaten { get; set; }
    }

}