using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dto.Custom
{
    public class Tb_Admin_Sekolah_cstm : IDataMapper<Tb_Admin_Sekolah_cstm>
    {
        #region Tb_Admin_Sekolah_cstm Properties
        public Int32 ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Int32? NPSN { get; set; }
        public string Nama_Sekolah { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public Tb_Admin_Sekolah_cstm Map(System.Data.IDataReader reader)
        {
            Tb_Admin_Sekolah_cstm obj = new Tb_Admin_Sekolah_cstm();
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.Username = string.Format("{0}", reader["Username"]);
            obj.Password = reader["Password"] == DBNull.Value ? null : reader["Password"].ToString();
            obj.NPSN = reader["NPSN"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["NPSN"]);
            //obj.isDeleted = reader["isDeleted"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["isDeleted"]);
            obj.Nama_Sekolah = reader["Nama_Sekolah"] == DBNull.Value ? null : reader["Nama_Sekolah"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}
