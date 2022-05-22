
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_Log]
    /// </summary>    
    public partial class Tb_LogItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_Log]
        /// </summary>        
        public static Tb_Log Insert(Tb_Log obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Log]([menu], [descriptionData], [created], [creator], [edited], [editor]) 
VALUES      (@menu, @descriptionData, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @_ID Int
SELECT @_ID = SCOPE_IDENTITY()

SELECT  ID, menu, descriptionData, created, creator, edited, editor
FROM    [Tb_Log]
WHERE   [ID]  = @_ID";
            context.AddParameter("@menu", string.Format("{0}", obj.menu));
            context.AddParameter("@descriptionData", string.Format("{0}", obj.descriptionData));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Log>(context, new Tb_Log()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_Log]
        /// </summary>        
        public static Tb_Log Update(Tb_Log obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Log]
SET         [menu] = @menu,
            [descriptionData] = @descriptionData,
           
            [edited] = @edited,
            [editor] = @editor
WHERE       [ID]  = @ID

SET @Err = @@Error

SELECT  ID, menu, descriptionData, created, creator, edited, editor 
FROM    [Tb_Log]
WHERE   [ID]  = @ID";
            context.AddParameter("@menu", string.Format("{0}", obj.menu));
            context.AddParameter("@descriptionData", string.Format("{0}", obj.descriptionData));
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@ID", obj.ID);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Log>(context, new Tb_Log()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_Log]
        /// </summary>        
        public static int Delete(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_Log 
WHERE   [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [Tb_Log]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Log";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Log]
        /// </summary>        
        public static List<Tb_Log> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT ID, menu, descriptionData, created, creator, edited, editor FROM Tb_Log";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Log>(context, new Tb_Log());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Log]
        /// </summary>        
        public static List<Tb_Log> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Log] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Log].[ID] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Log].*
                FROM    [Tb_Log]
            )

            SELECT      [Paging_Tb_Log].*
            FROM        [Paging_Tb_Log]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Log>(context, new Tb_Log());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_Log] by Primary Key
        /// </summary>        
        public static Tb_Log GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT ID, menu, descriptionData, created, creator, edited, editor FROM Tb_Log
            WHERE [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Log>(context, new Tb_Log()).FirstOrDefault();
        }

        #endregion

    }
}