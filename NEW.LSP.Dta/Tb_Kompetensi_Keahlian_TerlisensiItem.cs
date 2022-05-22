
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_Kompetensi_Keahlian_Terlisensi]
    /// </summary>    
    public partial class Tb_Kompetensi_Keahlian_TerlisensiItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_Kompetensi_Keahlian_Terlisensi]
        /// </summary>        
        public static Tb_Kompetensi_Keahlian_Terlisensi Insert(Tb_Kompetensi_Keahlian_Terlisensi obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Kompetensi_Keahlian_Terlisensi]([Nomer_Lisensi], [Kode_KK], [Status_KK_Terlisensi], [Jumlah_asesor], [isDeleted], [created], [creator], [edited], [editor]) 
VALUES      (@Nomer_Lisensi, @Kode_KK, @Status_KK_Terlisensi, @Jumlah_asesor, @isDeleted, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @_Kode_KK_Terlisensi Int
SELECT @_Kode_KK_Terlisensi = SCOPE_IDENTITY()

SELECT  Kode_KK_Terlisensi, Nomer_Lisensi, Kode_KK, Status_KK_Terlisensi, Jumlah_asesor, isDeleted, created, creator, edited, editor
FROM    [Tb_Kompetensi_Keahlian_Terlisensi]
WHERE   [Kode_KK_Terlisensi]  = @_Kode_KK_Terlisensi";
            context.AddParameter("@Nomer_Lisensi", string.Format("{0}", obj.Nomer_Lisensi));
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.AddParameter("@Status_KK_Terlisensi", string.Format("{0}", obj.Status_KK_Terlisensi));
            context.AddParameter("@Jumlah_asesor", obj.Jumlah_asesor);
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kompetensi_Keahlian_Terlisensi>(context, new Tb_Kompetensi_Keahlian_Terlisensi()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_Kompetensi_Keahlian_Terlisensi]
        /// </summary>        
        public static Tb_Kompetensi_Keahlian_Terlisensi Update(Tb_Kompetensi_Keahlian_Terlisensi obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Kompetensi_Keahlian_Terlisensi]
SET         [Nomer_Lisensi] = @Nomer_Lisensi,
            [Kode_KK] = @Kode_KK,
            [Status_KK_Terlisensi] = @Status_KK_Terlisensi,
            [Jumlah_asesor] = @Jumlah_asesor,
            [isDeleted] = @isDeleted,
           
            [edited] = @edited,
            [editor] = @editor
WHERE       [Kode_KK_Terlisensi]  = @Kode_KK_Terlisensi

SET @Err = @@Error

SELECT  Kode_KK_Terlisensi, Nomer_Lisensi, Kode_KK, Status_KK_Terlisensi, Jumlah_asesor, isDeleted, created, creator, edited, editor 
FROM    [Tb_Kompetensi_Keahlian_Terlisensi]
WHERE   [Kode_KK_Terlisensi]  = @Kode_KK_Terlisensi";
            context.AddParameter("@Nomer_Lisensi", string.Format("{0}", obj.Nomer_Lisensi));
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.AddParameter("@Status_KK_Terlisensi", string.Format("{0}", obj.Status_KK_Terlisensi));
            context.AddParameter("@Jumlah_asesor", obj.Jumlah_asesor);
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@Kode_KK_Terlisensi", obj.Kode_KK_Terlisensi);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kompetensi_Keahlian_Terlisensi>(context, new Tb_Kompetensi_Keahlian_Terlisensi()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_Kompetensi_Keahlian_Terlisensi]
        /// </summary>        
        public static int Delete(Int32 Kode_KK_Terlisensi)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_Kompetensi_Keahlian_Terlisensi 
WHERE   [Kode_KK_Terlisensi]  = @Kode_KK_Terlisensi";
            context.AddParameter("@Kode_KK_Terlisensi", Kode_KK_Terlisensi);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [Tb_Kompetensi_Keahlian_Terlisensi]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Kompetensi_Keahlian_Terlisensi";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Kompetensi_Keahlian_Terlisensi]
        /// </summary>        
        public static List<Tb_Kompetensi_Keahlian_Terlisensi> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Kode_KK_Terlisensi, Nomer_Lisensi, Kode_KK, Status_KK_Terlisensi, Jumlah_asesor, isDeleted, created, creator, edited, editor FROM Tb_Kompetensi_Keahlian_Terlisensi";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kompetensi_Keahlian_Terlisensi>(context, new Tb_Kompetensi_Keahlian_Terlisensi());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Kompetensi_Keahlian_Terlisensi]
        /// </summary>        
        public static List<Tb_Kompetensi_Keahlian_Terlisensi> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Kompetensi_Keahlian_Terlisensi] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Kompetensi_Keahlian_Terlisensi].[Kode_KK_Terlisensi] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Kompetensi_Keahlian_Terlisensi].*
                FROM    [Tb_Kompetensi_Keahlian_Terlisensi]
            )

            SELECT      [Paging_Tb_Kompetensi_Keahlian_Terlisensi].*
            FROM        [Paging_Tb_Kompetensi_Keahlian_Terlisensi]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Kompetensi_Keahlian_Terlisensi>(context, new Tb_Kompetensi_Keahlian_Terlisensi());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_Kompetensi_Keahlian_Terlisensi] by Primary Key
        /// </summary>        
        public static Tb_Kompetensi_Keahlian_Terlisensi GetByPK(Int32 Kode_KK_Terlisensi)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT Kode_KK_Terlisensi, Nomer_Lisensi, Kode_KK, Status_KK_Terlisensi, Jumlah_asesor, isDeleted, created, creator, edited, editor FROM Tb_Kompetensi_Keahlian_Terlisensi
            WHERE [Kode_KK_Terlisensi]  = @Kode_KK_Terlisensi";
            context.AddParameter("@Kode_KK_Terlisensi", Kode_KK_Terlisensi);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kompetensi_Keahlian_Terlisensi>(context, new Tb_Kompetensi_Keahlian_Terlisensi()).FirstOrDefault();
        }

        #endregion

    }
}