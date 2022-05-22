
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class Tb_Menu : IDataMapper<Tb_Menu>
    {
        #region Tb_Menu Properties
        public string UserType { get; set; }
        public string GroupName { get; set; }
        public Int32? NomerUrut { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        #endregion    
        public Tb_Menu Map(System.Data.IDataReader reader)
        {
            Tb_Menu obj = new Tb_Menu();   
            obj.UserType = reader["UserType"] == DBNull.Value ? null : reader["UserType"].ToString();
            obj.GroupName = reader["GroupName"] == DBNull.Value ? null : reader["GroupName"].ToString();
            obj.NomerUrut = reader["NomerUrut"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["NomerUrut"]);
            obj.MenuName = string.Format("{0}",reader["MenuName"]);
            obj.MenuDescription = reader["MenuDescription"] == DBNull.Value ? null : reader["MenuDescription"].ToString();
            return obj;
        }
    }
}