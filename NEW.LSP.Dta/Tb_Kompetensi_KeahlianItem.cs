
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_Kompetensi_Keahlian]
    /// </summary>    
    public partial class Tb_Kompetensi_KeahlianItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_Kompetensi_Keahlian]
        /// </summary>        
        public static Tb_Kompetensi_Keahlian Insert(Tb_Kompetensi_Keahlian obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Kompetensi_Keahlian]([Kode_KK], [Nama_KK], [isDeleted], [created], [creator], [edited], [editor]) 
VALUES      (@Kode_KK, @Nama_KK, @isDeleted, @created, @creator, @edited, @editor)

SET @Err = @@Error

SELECT  Kode_KK, Nama_KK, isDeleted, created, creator, edited, editor
FROM    [Tb_Kompetensi_Keahlian]
WHERE   [Kode_KK]  = @Kode_KK";
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.AddParameter("@Nama_KK", string.Format("{0}", obj.Nama_KK));
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kompetensi_Keahlian>(context, new Tb_Kompetensi_Keahlian()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_Kompetensi_Keahlian]
        /// </summary>        
        public static Tb_Kompetensi_Keahlian Update(Tb_Kompetensi_Keahlian obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Kompetensi_Keahlian]
SET         [Nama_KK] = @Nama_KK,
            [isDeleted] = @isDeleted,
       
            [edited] = @edited,
            [editor] = @editor
WHERE       [Kode_KK]  = @Kode_KK

SET @Err = @@Error

SELECT  Kode_KK, Nama_KK, isDeleted, created, creator, edited, editor 
FROM    [Tb_Kompetensi_Keahlian]
WHERE   [Kode_KK]  = @Kode_KK";
            context.AddParameter("@Nama_KK", string.Format("{0}", obj.Nama_KK));
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@Kode_KK", obj.Kode_KK);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kompetensi_Keahlian>(context, new Tb_Kompetensi_Keahlian()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_Kompetensi_Keahlian]
        /// </summary>        
        public static int Delete(Int32 Kode_KK)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_Kompetensi_Keahlian 
WHERE   [Kode_KK]  = @Kode_KK";
            context.AddParameter("@Kode_KK", Kode_KK);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [Tb_Kompetensi_Keahlian]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Kompetensi_Keahlian";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Kompetensi_Keahlian]
        /// </summary>        
        public static List<Tb_Kompetensi_Keahlian> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Kode_KK, Nama_KK, isDeleted, created, creator, edited, editor FROM Tb_Kompetensi_Keahlian";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kompetensi_Keahlian>(context, new Tb_Kompetensi_Keahlian());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Kompetensi_Keahlian]
        /// </summary>        
        public static List<Tb_Kompetensi_Keahlian> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Kompetensi_Keahlian] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Kompetensi_Keahlian].[Kode_KK] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Kompetensi_Keahlian].*
                FROM    [Tb_Kompetensi_Keahlian]
            )

            SELECT      [Paging_Tb_Kompetensi_Keahlian].*
            FROM        [Paging_Tb_Kompetensi_Keahlian]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Kompetensi_Keahlian>(context, new Tb_Kompetensi_Keahlian());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_Kompetensi_Keahlian] by Primary Key
        /// </summary>        
        public static Tb_Kompetensi_Keahlian GetByPK(Int32 Kode_KK)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT Kode_KK, Nama_KK, isDeleted, created, creator, edited, editor FROM Tb_Kompetensi_Keahlian
            WHERE [Kode_KK]  = @Kode_KK";
            context.AddParameter("@Kode_KK", Kode_KK);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kompetensi_Keahlian>(context, new Tb_Kompetensi_Keahlian()).FirstOrDefault();
        }

        #endregion

    }
}