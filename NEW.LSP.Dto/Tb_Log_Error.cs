
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class Tb_Log_Error : IDataMapper<Tb_Log_Error>
    {
        #region Tb_Log_Error Properties
        public Int32 id { get; set; }
        public string Menu { get; set; }
        public string FunctionName { get; set; }
        public string ErrorLog { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public Tb_Log_Error Map(System.Data.IDataReader reader)
        {
            Tb_Log_Error obj = new Tb_Log_Error();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.Menu = reader["Menu"] == DBNull.Value ? null : reader["Menu"].ToString();
            obj.FunctionName = reader["FunctionName"] == DBNull.Value ? null : reader["FunctionName"].ToString();
            obj.ErrorLog = reader["ErrorLog"] == DBNull.Value ? null : reader["ErrorLog"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}