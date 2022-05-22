using NEW.LSP.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Admin_Provinsi : Tb_Admin_Provinsi
    {

        public m_Tb_Admin_Provinsi() { }

        public m_Tb_Admin_Provinsi(Tb_Admin_Provinsi item)
        {
            this.ID = item.ID;
            this.Username = item.Username;
            this.Password = item.Password;
            this.NamaLengkap = item.NamaLengkap;
            this.isDeleted = item.isDeleted;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
        }


        [Required(ErrorMessage = "Harap masukan data Email Address")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(50, MinimumLength = 7)]
        public new string Username { get; set; }

        [Required(ErrorMessage = "Harap masukan data Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 7)]
        public new string Password { get; set; }

        [Required(ErrorMessage = "Harap masukan data Confirm Password")]
        [Display(Name = "Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }

        [Display(Name = "Nama Lengkap")]
        public new string NamaLengkap { get; set; }

    }
}