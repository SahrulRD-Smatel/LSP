
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class Tb_Jejaring : IDataMapper<Tb_Jejaring>
    {
        #region Tb_Jejaring Properties
        public Int32 Kode_Jejaring { get; set; }
        public string Nomer_Lisensi { get; set; }
        public Int32? Kode_KK_Terlisensi { get; set; }
        public Int32? NPSN { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public Tb_Jejaring Map(System.Data.IDataReader reader)
        {
            Tb_Jejaring obj = new Tb_Jejaring();   
            obj.Kode_Jejaring = Convert.ToInt32(reader["Kode_Jejaring"]);
            obj.Nomer_Lisensi = reader["Nomer_Lisensi"] == DBNull.Value ? null : reader["Nomer_Lisensi"].ToString();
            obj.Kode_KK_Terlisensi = reader["Kode_KK_Terlisensi"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Kode_KK_Terlisensi"]);
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