
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class Tb_SMK : IDataMapper<Tb_SMK>
    {
        #region Tb_SMK Properties
        public Int32 NPSN { get; set; }
        public Int32? Kode_Kabupaten { get; set; }
        public string Nama_Sekolah { get; set; }
        public string Status_Sekolah { get; set; }
        public string Status_LSP { get; set; }
        public Int32? Kode_KK { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public Tb_SMK Map(System.Data.IDataReader reader)
        {
            Tb_SMK obj = new Tb_SMK();   
            obj.NPSN = Convert.ToInt32(reader["NPSN"]);
            obj.Kode_Kabupaten = reader["Kode_Kabupaten"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Kode_Kabupaten"]);
            obj.Nama_Sekolah = reader["Nama_Sekolah"] == DBNull.Value ? null : reader["Nama_Sekolah"].ToString();
            obj.Status_Sekolah = reader["Status_Sekolah"] == DBNull.Value ? null : reader["Status_Sekolah"].ToString();
            obj.Status_LSP = reader["Status_LSP"] == DBNull.Value ? null : reader["Status_LSP"].ToString();
            obj.Kode_KK = reader["Kode_KK"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Kode_KK"]);
            obj.isDeleted = reader["isDeleted"] == DBNull.Value ? (bool?) null  : Convert.ToBoolean(reader["isDeleted"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}