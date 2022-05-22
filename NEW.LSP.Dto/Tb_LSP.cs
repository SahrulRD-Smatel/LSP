
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class Tb_LSP : IDataMapper<Tb_LSP>
    {
        #region Tb_LSP Properties
        public string Nomer_Lisensi { get; set; }
        public Int32? NPSN { get; set; }
        public string Status_LSP { get; set; }
        public DateTime? Berlaku_Sampai { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public Tb_LSP Map(System.Data.IDataReader reader)
        {
            Tb_LSP obj = new Tb_LSP();   
            obj.Nomer_Lisensi = string.Format("{0}",reader["Nomer_Lisensi"]);
            obj.NPSN = reader["NPSN"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["NPSN"]);
            obj.Status_LSP = reader["Status_LSP"] == DBNull.Value ? null : reader["Status_LSP"].ToString();
            obj.Berlaku_Sampai = reader["Berlaku_Sampai"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["Berlaku_Sampai"]);
            obj.isDeleted = reader["isDeleted"] == DBNull.Value ? (bool?) null  : Convert.ToBoolean(reader["isDeleted"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}