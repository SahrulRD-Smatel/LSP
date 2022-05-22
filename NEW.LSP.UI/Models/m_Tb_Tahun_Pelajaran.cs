using NEW.LSP.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Tahun_Pelajaran: Tb_Tahun_Pelajaran
    {
        public m_Tb_Tahun_Pelajaran() { }
        public m_Tb_Tahun_Pelajaran(Tb_Tahun_Pelajaran item) {
            this.ID = item.ID;
            this.Tahun_pelajaran = item.Tahun_pelajaran;
            this.isDeleted = item.isDeleted;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
        }

        [Required(ErrorMessage = "Harap masukan data Tahun Pelajaran")]
        [Display(Name = "Tahun Pelajaran")]
        public new string Tahun_pelajaran { get; set; }
    }
}