using NEW.LSP.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Pengumuman : Tb_Pengumuman
    {
        public m_Tb_Pengumuman() { }

        public m_Tb_Pengumuman(Tb_Pengumuman item)
        {
            this.id_pengumuman = item.id_pengumuman;
            this.no = item.no;
            this.tanggal = item.tanggal;
            this.tanggal_hingga = item.tanggal_hingga;
            this.judul = item.judul;
            this.picture = item.picture;
            this.pictureData = item.pictureData;
            this.isi = item.isi;
            this.creator = item.creator;
            this.created = item.created;
            this.edited = item.edited;
            this.editor = item.editor;
        }

        [Required(ErrorMessage = "Harap masukan data No Pengumuman")]
        [Display(Name = "Nomor Pengumuman")]
        //[Remote("IsAlreadyNo", "Pengumuman", ErrorMessage = "No Pengumuman sudah ada di database.")]
        public new string no { get; set; }

        [Required(ErrorMessage = "Harap masukan data Tanggal Pengumuman")]
        [Display(Name = "Tanggal Pengumuman")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public new DateTime? tanggal { get; set; }

        [Required(ErrorMessage = "Harap masukan data Tanggal Pengumuman")]
        [Display(Name = "Tanggal Hingga")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public new DateTime? tanggal_hingga { get; set; }

        [Required(ErrorMessage = "Harap masukan data Judul Pengumuman")]
        [Display(Name = "Judul Pengumuman")]
        public new string judul { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload Image")]     
        //[Required(ErrorMessage = "Please choose file to upload.")]

        public new string picture { get; set; }

        [Display(Name = "Isi Pengumuman")]
        public new string isi { get; set; }
    }
}