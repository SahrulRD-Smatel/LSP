
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class v_Login : IDataMapper<v_Login>
    {
        #region v_Login Properties
        public Int32 ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nama { get; set; }
        public string typeUser { get; set; }
        #endregion    
        public v_Login Map(System.Data.IDataReader reader)
        {
            v_Login obj = new v_Login();   
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.Username = string.Format("{0}",reader["Username"]);
            obj.Password = reader["Password"] == DBNull.Value ? null : reader["Password"].ToString();
            obj.Nama = reader["Nama"] == DBNull.Value ? null : reader["Nama"].ToString();
            obj.typeUser = string.Format("{0}",reader["typeUser"]);
            return obj;
        }
    }
}