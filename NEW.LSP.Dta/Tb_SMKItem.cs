
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_SMK]
    /// </summary>    
    public partial class Tb_SMKItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_SMK]
        /// </summary>        
        public static Tb_SMK Insert(Tb_SMK obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_SMK]([NPSN], [Kode_Kabupaten], [Nama_Sekolah], [Status_Sekolah], [Status_LSP], [Kode_KK], [isDeleted], [created], [creator], [edited], [editor]) 
VALUES      (@NPSN, @Kode_Kabupaten, @Nama_Sekolah, @Status_Sekolah, @Status_LSP, @Kode_KK, @isDeleted, @created, @creator, @edited, @editor)

SET @Err = @@Error

SELECT  NPSN, Kode_Kabupaten, Nama_Sekolah, Status_Sekolah, Status_LSP, Kode_KK, isDeleted, created, creator, edited, editor
FROM    [Tb_SMK]
WHERE   [NPSN]  = @NPSN";
            context.AddParameter("@NPSN", obj.NPSN);
            context.AddParameter("@Kode_Kabupaten", obj.Kode_Kabupaten);
            context.AddParameter("@Nama_Sekolah", string.Format("{0}", obj.Nama_Sekolah));
            context.AddParameter("@Status_Sekolah", string.Format("{0}", obj.Status_Sekolah));
            context.AddParameter("@Status_LSP", string.Format("{0}", obj.Status_LSP));
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_SMK>(context, new Tb_SMK()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_SMK]
        /// </summary>        
        public static Tb_SMK Update(Tb_SMK obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_SMK]
SET         [Kode_Kabupaten] = @Kode_Kabupaten,
            [Nama_Sekolah] = @Nama_Sekolah,
            [Status_Sekolah] = @Status_Sekolah,
            [Status_LSP] = @Status_LSP,
            [Kode_KK] = @Kode_KK,
            [isDeleted] = @isDeleted,
            
            [edited] = @edited,
            [editor] = @editor
WHERE       [NPSN]  = @NPSN

SET @Err = @@Error

SELECT  NPSN, Kode_Kabupaten, Nama_Sekolah, Status_Sekolah, Status_LSP, Kode_KK, isDeleted, created, creator, edited, editor 
FROM    [Tb_SMK]
WHERE   [NPSN]  = @NPSN";
            context.AddParameter("@Kode_Kabupaten", obj.Kode_Kabupaten);
            context.AddParameter("@Nama_Sekolah", string.Format("{0}", obj.Nama_Sekolah));
            context.AddParameter("@Status_Sekolah", string.Format("{0}", obj.Status_Sekolah));
            context.AddParameter("@Status_LSP", string.Format("{0}", obj.Status_LSP));
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@NPSN", obj.NPSN);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_SMK>(context, new Tb_SMK()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_SMK]
        /// </summary>        
        public static int Delete(Int32 NPSN)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_SMK 
WHERE   [NPSN]  = @NPSN";
            context.AddParameter("@NPSN", NPSN);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [Tb_SMK]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_SMK";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_SMK]
        /// </summary>        
        public static List<Tb_SMK> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT NPSN, Kode_Kabupaten, Nama_Sekolah, Status_Sekolah, Status_LSP, Kode_KK, isDeleted, created, creator, edited, editor FROM Tb_SMK";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_SMK>(context, new Tb_SMK());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_SMK]
        /// </summary>        
        public static List<Tb_SMK> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_SMK] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_SMK].[NPSN] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_SMK].*
                FROM    [Tb_SMK]
            )

            SELECT      [Paging_Tb_SMK].*
            FROM        [Paging_Tb_SMK]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_SMK>(context, new Tb_SMK());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_SMK] by Primary Key
        /// </summary>        
        public static Tb_SMK GetByPK(Int32 NPSN)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT NPSN, Kode_Kabupaten, Nama_Sekolah, Status_Sekolah, Status_LSP, Kode_KK, isDeleted, created, creator, edited, editor FROM Tb_SMK
            WHERE [NPSN]  = @NPSN";
            context.AddParameter("@NPSN", NPSN);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_SMK>(context, new Tb_SMK()).FirstOrDefault();
        }

        #endregion

    }
}