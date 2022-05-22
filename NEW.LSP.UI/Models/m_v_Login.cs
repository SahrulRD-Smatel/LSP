using NEW.LSP.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_v_Login : v_Login
    {
        public m_v_Login() { }
        public m_v_Login(v_Login item)
        {
            this.ID = item.ID;
            this.Username = item.Username;
            this.Password = item.Password;
            this.Nama = item.Nama;
            this.typeUser = item.typeUser;
        }

        [Required(ErrorMessage = "Harap masukan Username")]
        [Display(Name = "Username")]
        public new string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Harap masukan Password")]
        [Display(Name = "Password")]
        public new string Password { get; set; }
    }
}