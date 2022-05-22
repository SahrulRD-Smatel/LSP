
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class Tb_Kompetensi_Keahlian_Terlisensi : IDataMapper<Tb_Kompetensi_Keahlian_Terlisensi>
    {
        #region Tb_Kompetensi_Keahlian_Terlisensi Properties
        public Int32 Kode_KK_Terlisensi { get; set; }
        public string Nomer_Lisensi { get; set; }
        public Int32? Kode_KK { get; set; }
        public string Status_KK_Terlisensi { get; set; }
        public Int32? Jumlah_asesor { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public Tb_Kompetensi_Keahlian_Terlisensi Map(System.Data.IDataReader reader)
        {
            Tb_Kompetensi_Keahlian_Terlisensi obj = new Tb_Kompetensi_Keahlian_Terlisensi();   
            obj.Kode_KK_Terlisensi = Convert.ToInt32(reader["Kode_KK_Terlisensi"]);
            obj.Nomer_Lisensi = reader["Nomer_Lisensi"] == DBNull.Value ? null : reader["Nomer_Lisensi"].ToString();
            obj.Kode_KK = reader["Kode_KK"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Kode_KK"]);
            obj.Status_KK_Terlisensi = reader["Status_KK_Terlisensi"] == DBNull.Value ? null : reader["Status_KK_Terlisensi"].ToString();
            obj.Jumlah_asesor = reader["Jumlah_asesor"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Jumlah_asesor"]);
            obj.isDeleted = reader["isDeleted"] == DBNull.Value ? (bool?) null  : Convert.ToBoolean(reader["isDeleted"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}