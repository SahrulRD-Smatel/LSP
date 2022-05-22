
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_Tahun_Pelajaran]
    /// </summary>    
    public partial class Tb_Tahun_PelajaranItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_Tahun_Pelajaran]
        /// </summary>        
        public static Tb_Tahun_Pelajaran Insert(Tb_Tahun_Pelajaran obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Tahun_Pelajaran]([Tahun_pelajaran], [isDeleted], [created], [creator], [edited], [editor]) 
VALUES      (@Tahun_pelajaran, @isDeleted, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @_ID Int
SELECT @_ID = SCOPE_IDENTITY()

SELECT  ID, Tahun_pelajaran, isDeleted, created, creator, edited, editor
FROM    [Tb_Tahun_Pelajaran]
WHERE   [ID]  = @_ID";
            context.AddParameter("@Tahun_pelajaran", string.Format("{0}", obj.Tahun_pelajaran));
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Tahun_Pelajaran>(context, new Tb_Tahun_Pelajaran()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_Tahun_Pelajaran]
        /// </summary>        
        public static Tb_Tahun_Pelajaran Update(Tb_Tahun_Pelajaran obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Tahun_Pelajaran]
SET         [Tahun_pelajaran] = @Tahun_pelajaran,
            [isDeleted] = @isDeleted,
           
            [edited] = @edited,
            [editor] = @editor
WHERE       [ID]  = @ID

SET @Err = @@Error

SELECT  ID, Tahun_pelajaran, isDeleted, created, creator, edited, editor 
FROM    [Tb_Tahun_Pelajaran]
WHERE   [ID]  = @ID";
            context.AddParameter("@Tahun_pelajaran", string.Format("{0}", obj.Tahun_pelajaran));
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@ID", obj.ID);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Tahun_Pelajaran>(context, new Tb_Tahun_Pelajaran()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_Tahun_Pelajaran]
        /// </summary>        
        public static int Delete(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_Tahun_Pelajaran 
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
        /// Get Total records from [Tb_Tahun_Pelajaran]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Tahun_Pelajaran";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Tahun_Pelajaran]
        /// </summary>        
        public static List<Tb_Tahun_Pelajaran> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT ID, Tahun_pelajaran, isDeleted, created, creator, edited, editor FROM Tb_Tahun_Pelajaran";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Tahun_Pelajaran>(context, new Tb_Tahun_Pelajaran());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Tahun_Pelajaran]
        /// </summary>        
        public static List<Tb_Tahun_Pelajaran> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Tahun_Pelajaran] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Tahun_Pelajaran].[ID] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Tahun_Pelajaran].*
                FROM    [Tb_Tahun_Pelajaran]
            )

            SELECT      [Paging_Tb_Tahun_Pelajaran].*
            FROM        [Paging_Tb_Tahun_Pelajaran]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Tahun_Pelajaran>(context, new Tb_Tahun_Pelajaran());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_Tahun_Pelajaran] by Primary Key
        /// </summary>        
        public static Tb_Tahun_Pelajaran GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT ID, Tahun_pelajaran, isDeleted, created, creator, edited, editor FROM Tb_Tahun_Pelajaran
            WHERE [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Tahun_Pelajaran>(context, new Tb_Tahun_Pelajaran()).FirstOrDefault();
        }

        #endregion

    }
}