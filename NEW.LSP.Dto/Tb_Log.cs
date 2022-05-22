
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class Tb_Log : IDataMapper<Tb_Log>
    {
        #region Tb_Log Properties
        public Int32 ID { get; set; }
        public string menu { get; set; }
        public string descriptionData { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public Tb_Log Map(System.Data.IDataReader reader)
        {
            Tb_Log obj = new Tb_Log();   
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.menu = reader["menu"] == DBNull.Value ? null : reader["menu"].ToString();
            obj.descriptionData = reader["descriptionData"] == DBNull.Value ? null : reader["descriptionData"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}