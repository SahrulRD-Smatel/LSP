
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class Tb_SMK_Kompetensi_Keahlian : IDataMapper<Tb_SMK_Kompetensi_Keahlian>
    {
        #region Tb_SMK_Kompetensi_Keahlian Properties
        public Int32 ID { get; set; }
        public Int32? NPSN { get; set; }
        public Int32? Kode_KK { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public Tb_SMK_Kompetensi_Keahlian Map(System.Data.IDataReader reader)
        {
            Tb_SMK_Kompetensi_Keahlian obj = new Tb_SMK_Kompetensi_Keahlian();   
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.NPSN = reader["NPSN"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["NPSN"]);
            obj.Kode_KK = reader["Kode_KK"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Kode_KK"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}