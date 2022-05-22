
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class Tb_Approval_KKTerlisensi : IDataMapper<Tb_Approval_KKTerlisensi>
    {
        #region Tb_Approval_KKTerlisensi Properties
        public Int32 id_app { get; set; }
        public Int32? Kode_KK_Terlisensi { get; set; }
        public bool? Status { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public Tb_Approval_KKTerlisensi Map(System.Data.IDataReader reader)
        {
            Tb_Approval_KKTerlisensi obj = new Tb_Approval_KKTerlisensi();   
            obj.id_app = Convert.ToInt32(reader["id_app"]);
            obj.Kode_KK_Terlisensi = reader["Kode_KK_Terlisensi"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Kode_KK_Terlisensi"]);
            obj.Status = reader["Status"] == DBNull.Value ? (bool?) null  : Convert.ToBoolean(reader["Status"]);
            obj.Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString();
            obj.Data = reader["Data"] == DBNull.Value ? (byte[]) null : (byte[]) reader["Data"];
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}