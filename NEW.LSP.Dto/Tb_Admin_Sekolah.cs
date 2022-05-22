
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class Tb_Admin_Sekolah : IDataMapper<Tb_Admin_Sekolah>
    {
        #region Tb_Admin_Sekolah Properties
        public Int32 ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Int32? NPSN { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public Tb_Admin_Sekolah Map(System.Data.IDataReader reader)
        {
            Tb_Admin_Sekolah obj = new Tb_Admin_Sekolah();   
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.Username = string.Format("{0}",reader["Username"]);
            obj.Password = reader["Password"] == DBNull.Value ? null : reader["Password"].ToString();
            obj.NPSN = reader["NPSN"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["NPSN"]);
            obj.isDeleted = reader["isDeleted"] == DBNull.Value ? (bool?) null  : Convert.ToBoolean(reader["isDeleted"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}