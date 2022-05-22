
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class Tb_Tahun_Pelajaran : IDataMapper<Tb_Tahun_Pelajaran>
    {
        #region Tb_Tahun_Pelajaran Properties
        public Int32 ID { get; set; }
        public string Tahun_pelajaran { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public Tb_Tahun_Pelajaran Map(System.Data.IDataReader reader)
        {
            Tb_Tahun_Pelajaran obj = new Tb_Tahun_Pelajaran();   
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.Tahun_pelajaran = string.Format("{0}",reader["Tahun_pelajaran"]);
            obj.isDeleted = reader["isDeleted"] == DBNull.Value ? (bool?) null  : Convert.ToBoolean(reader["isDeleted"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}