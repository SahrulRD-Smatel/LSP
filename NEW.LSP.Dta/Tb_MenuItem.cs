
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_Menu]
    /// </summary>    
    public partial class Tb_MenuItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_Menu]
        /// </summary>        
        public static Tb_Menu Insert(Tb_Menu obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Menu]([UserType], [GroupName], [NomerUrut], [MenuName], [MenuDescription]) 
VALUES      (@UserType, @GroupName, @NomerUrut, @MenuName, @MenuDescription)

SET @Err = @@Error

SELECT  UserType, GroupName, NomerUrut, MenuName, MenuDescription
FROM    [Tb_Menu]
WHERE   [MenuName]  = @MenuName";
            context.AddParameter("@UserType", string.Format("{0}", obj.UserType));
            context.AddParameter("@GroupName", string.Format("{0}", obj.GroupName));
            context.AddParameter("@NomerUrut", obj.NomerUrut);
            context.AddParameter("@MenuName", string.Format("{0}", obj.MenuName));
            context.AddParameter("@MenuDescription", string.Format("{0}", obj.MenuDescription));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Menu>(context, new Tb_Menu()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_Menu]
        /// </summary>        
        public static Tb_Menu Update(Tb_Menu obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Menu]
SET         [UserType] = @UserType,
            [GroupName] = @GroupName,
            [NomerUrut] = @NomerUrut,
            [MenuDescription] = @MenuDescription
WHERE       [MenuName]  = @MenuName

SET @Err = @@Error

SELECT  UserType, GroupName, NomerUrut, MenuName, MenuDescription 
FROM    [Tb_Menu]
WHERE   [MenuName]  = @MenuName";
            context.AddParameter("@UserType", string.Format("{0}", obj.UserType));
            context.AddParameter("@GroupName", string.Format("{0}", obj.GroupName));
            context.AddParameter("@NomerUrut", obj.NomerUrut);
            context.AddParameter("@MenuDescription", string.Format("{0}", obj.MenuDescription));
            context.AddParameter("@MenuName", string.Format("{0}", obj.MenuName));            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Menu>(context, new Tb_Menu()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_Menu]
        /// </summary>        
        public static int Delete(string MenuName)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_Menu 
WHERE   [MenuName]  = @MenuName";
            context.AddParameter("@MenuName",  string.Format("{0}", MenuName));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [Tb_Menu]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Menu";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Menu]
        /// </summary>        
        public static List<Tb_Menu> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT UserType, GroupName, NomerUrut, MenuName, MenuDescription FROM Tb_Menu";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Menu>(context, new Tb_Menu());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Menu]
        /// </summary>        
        public static List<Tb_Menu> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Menu] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Menu].[MenuName] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Menu].*
                FROM    [Tb_Menu]
            )

            SELECT      [Paging_Tb_Menu].*
            FROM        [Paging_Tb_Menu]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Menu>(context, new Tb_Menu());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_Menu] by Primary Key
        /// </summary>        
        public static Tb_Menu GetByPK(string MenuName)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT UserType, GroupName, NomerUrut, MenuName, MenuDescription FROM Tb_Menu
            WHERE [MenuName]  = @MenuName";
            context.AddParameter("@MenuName", MenuName);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Menu>(context, new Tb_Menu()).FirstOrDefault();
        }

        #endregion

    }
}