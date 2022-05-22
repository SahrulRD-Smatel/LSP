using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_LSP_cstm: Tb_LSP_cstm
    {
        public m_Tb_LSP_cstm() { }
        public m_Tb_LSP_cstm(Tb_LSP_cstm item)
        {
            this.Nomer_Lisensi = item.Nomer_Lisensi;
            this.NPSN = item.NPSN;
            this.Status_LSP = item.Status_LSP;
            this.Berlaku_Sampai = item.Berlaku_Sampai;
            this.isDeleted = item.isDeleted;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
            this.Nama_Sekolah = item.Nama_Sekolah;
            this.NamaKabupaten = item.NamaKabupaten;
            this.Username = item.Username;
        }
        [Required(ErrorMessage = "Harap masukan data Nomor Lisensi")]
        [Display(Name = "Nomor Lisensi")]
        [StringLength(100, MinimumLength = 7)]
        public new string Nomer_Lisensi { get; set; }

        [Required(ErrorMessage = "Harap masukan data NPSN")]
        [Display(Name = "NPSN")]
        public new Int32? NPSN { get; set; }
        
        [Display(Name = "Nama Sekolah")]
        public new string Nama_Sekolah { get; set; }

        [Display(Name = "Status LSP")]
        public new string Status_LSP { get; set; }

        [Required(ErrorMessage = "Harap masukan data Berlaku Sampai")]
        [Display(Name = "Berlaku Hingga")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public new DateTime? Berlaku_Sampai { get; set; }

        [Display(Name = "Kabupaten")]
        public new string NamaKabupaten { get; set; }

        [Display(Name = "Email")]
        public new string Username { get; set; }

    }
}