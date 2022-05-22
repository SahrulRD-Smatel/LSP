
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_LSP]
    /// </summary>    
    public partial class Tb_LSPItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_LSP]
        /// </summary>        
        public static Tb_LSP Insert(Tb_LSP obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_LSP]([Nomer_Lisensi], [NPSN], [Status_LSP], [Berlaku_Sampai], [isDeleted], [created], [creator], [edited], [editor]) 
VALUES      (@Nomer_Lisensi, @NPSN, @Status_LSP, @Berlaku_Sampai, @isDeleted, @created, @creator, @edited, @editor)

SET @Err = @@Error

SELECT  Nomer_Lisensi, NPSN, Status_LSP, Berlaku_Sampai, isDeleted, created, creator, edited, editor
FROM    [Tb_LSP]
WHERE   [Nomer_Lisensi]  = @Nomer_Lisensi";
            context.AddParameter("@Nomer_Lisensi", string.Format("{0}", obj.Nomer_Lisensi));
            context.AddParameter("@NPSN", obj.NPSN);
            context.AddParameter("@Status_LSP", string.Format("{0}", obj.Status_LSP));
            context.AddParameter("@Berlaku_Sampai", obj.Berlaku_Sampai);
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_LSP>(context, new Tb_LSP()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_LSP]
        /// </summary>        
        public static Tb_LSP Update(Tb_LSP obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_LSP]
SET         [NPSN] = @NPSN,
            [Status_LSP] = @Status_LSP,
            [Berlaku_Sampai] = @Berlaku_Sampai,
            [isDeleted] = @isDeleted,
          
            [edited] = @edited,
            [editor] = @editor
WHERE       [Nomer_Lisensi]  = @Nomer_Lisensi

SET @Err = @@Error

SELECT  Nomer_Lisensi, NPSN, Status_LSP, Berlaku_Sampai, isDeleted, created, creator, edited, editor 
FROM    [Tb_LSP]
WHERE   [Nomer_Lisensi]  = @Nomer_Lisensi";
            context.AddParameter("@NPSN", obj.NPSN);
            context.AddParameter("@Status_LSP", string.Format("{0}", obj.Status_LSP));
            context.AddParameter("@Berlaku_Sampai", obj.Berlaku_Sampai);
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@Nomer_Lisensi", string.Format("{0}", obj.Nomer_Lisensi));            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_LSP>(context, new Tb_LSP()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_LSP]
        /// </summary>        
        public static int Delete(string Nomer_Lisensi)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_LSP 
WHERE   [Nomer_Lisensi]  = @Nomer_Lisensi";
            context.AddParameter("@Nomer_Lisensi",  string.Format("{0}", Nomer_Lisensi));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [Tb_LSP]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_LSP";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_LSP]
        /// </summary>        
        public static List<Tb_LSP> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Nomer_Lisensi, NPSN, Status_LSP, Berlaku_Sampai, isDeleted, created, creator, edited, editor FROM Tb_LSP";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_LSP>(context, new Tb_LSP());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_LSP]
        /// </summary>        
        public static List<Tb_LSP> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_LSP] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_LSP].[Nomer_Lisensi] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_LSP].*
                FROM    [Tb_LSP]
            )

            SELECT      [Paging_Tb_LSP].*
            FROM        [Paging_Tb_LSP]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_LSP>(context, new Tb_LSP());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_LSP] by Primary Key
        /// </summary>        
        public static Tb_LSP GetByPK(string Nomer_Lisensi)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT Nomer_Lisensi, NPSN, Status_LSP, Berlaku_Sampai, isDeleted, created, creator, edited, editor FROM Tb_LSP
            WHERE [Nomer_Lisensi]  = @Nomer_Lisensi";
            context.AddParameter("@Nomer_Lisensi", Nomer_Lisensi);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_LSP>(context, new Tb_LSP()).FirstOrDefault();
        }

        #endregion

    }
}