
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of VIEW [v_Login]
    /// </summary>    
    public partial class v_LoginItem
    {

        #region Data Access

        public static v_Login GetByPK(string userid)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @" SELECT [ID]
                  ,[Username]
                  ,[Password]
                  ,[Nama]
                  ,[typeUser]
                FROM [v_Login]
            WHERE [Username]  = @ID";
            context.AddParameter("@ID", userid);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<v_Login>(context, new v_Login()).FirstOrDefault();
        }



       

        #endregion

    }
}