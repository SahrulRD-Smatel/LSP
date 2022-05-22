using NEW.LSP.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Kabupaten : Tb_Kabupaten
    {
        public m_Tb_Kabupaten() { }
        public m_Tb_Kabupaten(Tb_Kabupaten item)
        {
            this.Kode_Kabupaten = item.Kode_Kabupaten;
            this.NamaKabupaten = item.NamaKabupaten;
            this.IbuKotaKabupaten = item.IbuKotaKabupaten;
        }

        [Required(ErrorMessage = "Harap masukan data Kode Kabupaten")]
        [Display(Name = "Kode Kabupaten")]
        public new int Kode_Kabupaten { get; set; }

        [Required(ErrorMessage = "Harap masukan data Nama Kabupaten")]
        [Display(Name = "Nama Kabupaten")]
        public new string NamaKabupaten { get; set; }

        [Required(ErrorMessage = "Harap masukan data Ibu Kota Kabupaten")]
        [Display(Name = "Ibu Kota Kabupaten")]
        public new string IbuKotaKabupaten { get; set; }

    }
}