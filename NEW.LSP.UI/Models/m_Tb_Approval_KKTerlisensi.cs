using NEW.LSP.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Models
{
    public class m_Tb_Approval_KKTerlisensi : Tb_Approval_KKTerlisensi
    {
        public m_Tb_Approval_KKTerlisensi() { }

        public m_Tb_Approval_KKTerlisensi(Tb_Approval_KKTerlisensi item)
        {
            this.id_app = item.id_app;
            this.Kode_KK_Terlisensi = item.Kode_KK_Terlisensi;
            this.Status = item.Status;
            this.Name = item.Name;
            this.Data = item.Data;
            this.created = item.created;
            this.creator = item.creator;
            this.edited = item.edited;
            this.editor = item.editor;
        }
    }
}