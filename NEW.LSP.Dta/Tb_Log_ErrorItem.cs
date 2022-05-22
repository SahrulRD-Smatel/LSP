
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_Log_Error]
    /// </summary>    
    public partial class Tb_Log_ErrorItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_Log_Error]
        /// </summary>        
        public static Tb_Log_Error Insert(Tb_Log_Error obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Log_Error]([Menu], [FunctionName], [ErrorLog], [created], [creator], [edited], [editor]) 
VALUES      (@Menu, @FunctionName, @ErrorLog, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, Menu, FunctionName, ErrorLog, created, creator, edited, editor
FROM    [Tb_Log_Error]
WHERE   [id]  = @_id";
            context.AddParameter("@Menu", string.Format("{0}", obj.Menu));
            context.AddParameter("@FunctionName", string.Format("{0}", obj.FunctionName));
            context.AddParameter("@ErrorLog", string.Format("{0}", obj.ErrorLog));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Log_Error>(context, new Tb_Log_Error()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_Log_Error]
        /// </summary>        
        public static Tb_Log_Error Update(Tb_Log_Error obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Log_Error]
SET         [Menu] = @Menu,
            [FunctionName] = @FunctionName,
            [ErrorLog] = @ErrorLog,
            [creator] = @creator,
            [edited] = @edited,
            [editor] = @editor
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, Menu, FunctionName, ErrorLog, created, creator, edited, editor 
FROM    [Tb_Log_Error]
WHERE   [id]  = @id";
            context.AddParameter("@Menu", string.Format("{0}", obj.Menu));
            context.AddParameter("@FunctionName", string.Format("{0}", obj.FunctionName));
            context.AddParameter("@ErrorLog", string.Format("{0}", obj.ErrorLog));
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Log_Error>(context, new Tb_Log_Error()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_Log_Error]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_Log_Error 
WHERE   [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [Tb_Log_Error]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Log_Error";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Log_Error]
        /// </summary>        
        public static List<Tb_Log_Error> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, Menu, FunctionName, ErrorLog, created, creator, edited, editor FROM Tb_Log_Error";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Log_Error>(context, new Tb_Log_Error());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Log_Error]
        /// </summary>        
        public static List<Tb_Log_Error> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Log_Error] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Log_Error].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Log_Error].*
                FROM    [Tb_Log_Error]
            )

            SELECT      [Paging_Tb_Log_Error].*
            FROM        [Paging_Tb_Log_Error]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Log_Error>(context, new Tb_Log_Error());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_Log_Error] by Primary Key
        /// </summary>        
        public static Tb_Log_Error GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, Menu, FunctionName, ErrorLog, created, creator, edited, editor FROM Tb_Log_Error
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Log_Error>(context, new Tb_Log_Error()).FirstOrDefault();
        }

        #endregion

    }
}