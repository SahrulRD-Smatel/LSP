
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_SMK_Kompetensi_Keahlian]
    /// </summary>    
    public partial class Tb_SMK_Kompetensi_KeahlianItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_SMK_Kompetensi_Keahlian]
        /// </summary>        
        public static Tb_SMK_Kompetensi_Keahlian Insert(Tb_SMK_Kompetensi_Keahlian obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_SMK_Kompetensi_Keahlian]([NPSN], [Kode_KK], [created], [creator], [edited], [editor]) 
VALUES      (@NPSN, @Kode_KK, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @_ID Int
SELECT @_ID = SCOPE_IDENTITY()

SELECT  ID, NPSN, Kode_KK, created, creator, edited, editor
FROM    [Tb_SMK_Kompetensi_Keahlian]
WHERE   [ID]  = @_ID";
            context.AddParameter("@NPSN", obj.NPSN);
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_SMK_Kompetensi_Keahlian>(context, new Tb_SMK_Kompetensi_Keahlian()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_SMK_Kompetensi_Keahlian]
        /// </summary>        
        public static Tb_SMK_Kompetensi_Keahlian Update(Tb_SMK_Kompetensi_Keahlian obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_SMK_Kompetensi_Keahlian]
SET         [NPSN] = @NPSN,
            [Kode_KK] = @Kode_KK,
          
            [edited] = @edited,
            [editor] = @editor
WHERE       [ID]  = @ID

SET @Err = @@Error

SELECT  ID, NPSN, Kode_KK, created, creator, edited, editor 
FROM    [Tb_SMK_Kompetensi_Keahlian]
WHERE   [ID]  = @ID";
            context.AddParameter("@NPSN", obj.NPSN);
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@ID", obj.ID);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_SMK_Kompetensi_Keahlian>(context, new Tb_SMK_Kompetensi_Keahlian()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_SMK_Kompetensi_Keahlian]
        /// </summary>        
        public static int Delete(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_SMK_Kompetensi_Keahlian 
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
        /// Get Total records from [Tb_SMK_Kompetensi_Keahlian]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_SMK_Kompetensi_Keahlian";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_SMK_Kompetensi_Keahlian]
        /// </summary>        
        public static List<Tb_SMK_Kompetensi_Keahlian> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT ID, NPSN, Kode_KK, created, creator, edited, editor FROM Tb_SMK_Kompetensi_Keahlian";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_SMK_Kompetensi_Keahlian>(context, new Tb_SMK_Kompetensi_Keahlian());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_SMK_Kompetensi_Keahlian]
        /// </summary>        
        public static List<Tb_SMK_Kompetensi_Keahlian> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_SMK_Kompetensi_Keahlian] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_SMK_Kompetensi_Keahlian].[ID] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_SMK_Kompetensi_Keahlian].*
                FROM    [Tb_SMK_Kompetensi_Keahlian]
            )

            SELECT      [Paging_Tb_SMK_Kompetensi_Keahlian].*
            FROM        [Paging_Tb_SMK_Kompetensi_Keahlian]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_SMK_Kompetensi_Keahlian>(context, new Tb_SMK_Kompetensi_Keahlian());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_SMK_Kompetensi_Keahlian] by Primary Key
        /// </summary>        
        public static Tb_SMK_Kompetensi_Keahlian GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT ID, NPSN, Kode_KK, created, creator, edited, editor FROM Tb_SMK_Kompetensi_Keahlian
            WHERE [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_SMK_Kompetensi_Keahlian>(context, new Tb_SMK_Kompetensi_Keahlian()).FirstOrDefault();
        }

        #endregion

    }
}