
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_Jejaring]
    /// </summary>    
    public partial class Tb_JejaringItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_Jejaring]
        /// </summary>        
        public static Tb_Jejaring Insert(Tb_Jejaring obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Jejaring]([Nomer_Lisensi], [Kode_KK_Terlisensi], [NPSN], [isDeleted], [created], [creator], [edited], [editor]) 
VALUES      (@Nomer_Lisensi, @Kode_KK_Terlisensi, @NPSN, @isDeleted, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @_Kode_Jejaring Int
SELECT @_Kode_Jejaring = SCOPE_IDENTITY()

SELECT  Kode_Jejaring, Nomer_Lisensi, Kode_KK_Terlisensi, NPSN, isDeleted, created, creator, edited, editor
FROM    [Tb_Jejaring]
WHERE   [Kode_Jejaring]  = @_Kode_Jejaring";
            context.AddParameter("@Nomer_Lisensi", string.Format("{0}", obj.Nomer_Lisensi));
            context.AddParameter("@Kode_KK_Terlisensi", obj.Kode_KK_Terlisensi);
            context.AddParameter("@NPSN", obj.NPSN);
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Jejaring>(context, new Tb_Jejaring()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_Jejaring]
        /// </summary>        
        public static Tb_Jejaring Update(Tb_Jejaring obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Jejaring]
SET         [Nomer_Lisensi] = @Nomer_Lisensi,
            [Kode_KK_Terlisensi] = @Kode_KK_Terlisensi,
            [NPSN] = @NPSN,
            [isDeleted] = @isDeleted,
            
            [edited] = @edited,
            [editor] = @editor
WHERE       [Kode_Jejaring]  = @Kode_Jejaring

SET @Err = @@Error

SELECT  Kode_Jejaring, Nomer_Lisensi, Kode_KK_Terlisensi, NPSN, isDeleted, created, creator, edited, editor 
FROM    [Tb_Jejaring]
WHERE   [Kode_Jejaring]  = @Kode_Jejaring";
            context.AddParameter("@Nomer_Lisensi", string.Format("{0}", obj.Nomer_Lisensi));
            context.AddParameter("@Kode_KK_Terlisensi", obj.Kode_KK_Terlisensi);
            context.AddParameter("@NPSN", obj.NPSN);
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@Kode_Jejaring", obj.Kode_Jejaring);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Jejaring>(context, new Tb_Jejaring()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_Jejaring]
        /// </summary>        
        public static int Delete(Int32 Kode_Jejaring)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_Jejaring 
WHERE   [Kode_Jejaring]  = @Kode_Jejaring";
            context.AddParameter("@Kode_Jejaring", Kode_Jejaring);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [Tb_Jejaring]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Jejaring";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Jejaring]
        /// </summary>        
        public static List<Tb_Jejaring> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Kode_Jejaring, Nomer_Lisensi, Kode_KK_Terlisensi, NPSN, isDeleted, created, creator, edited, editor FROM Tb_Jejaring";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Jejaring>(context, new Tb_Jejaring());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Jejaring]
        /// </summary>        
        public static List<Tb_Jejaring> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Jejaring] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Jejaring].[Kode_Jejaring] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Jejaring].*
                FROM    [Tb_Jejaring]
            )

            SELECT      [Paging_Tb_Jejaring].*
            FROM        [Paging_Tb_Jejaring]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Jejaring>(context, new Tb_Jejaring());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_Jejaring] by Primary Key
        /// </summary>        
        public static Tb_Jejaring GetByPK(Int32 Kode_Jejaring)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT Kode_Jejaring, Nomer_Lisensi, Kode_KK_Terlisensi, NPSN, isDeleted, created, creator, edited, editor FROM Tb_Jejaring
            WHERE [Kode_Jejaring]  = @Kode_Jejaring";
            context.AddParameter("@Kode_Jejaring", Kode_Jejaring);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Jejaring>(context, new Tb_Jejaring()).FirstOrDefault();
        }

        #endregion

    }
}