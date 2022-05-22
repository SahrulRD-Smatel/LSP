
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_Penerima_Sertifikat]
    /// </summary>    
    public partial class Tb_Penerima_SertifikatItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_Penerima_Sertifikat]
        /// </summary>        
        public static Tb_Penerima_Sertifikat Insert(Tb_Penerima_Sertifikat obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Penerima_Sertifikat]([Nomer_Lisensi], [Kode_KK], [IDTahun_pelajaran], [Jumlah_penerima_sertifikat], [isDeleted], [created], [creator], [edited], [editor]) 
VALUES      (@Nomer_Lisensi, @Kode_KK, @IDTahun_pelajaran, @Jumlah_penerima_sertifikat, @isDeleted, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @_Kode_Penerima_Sertifikat Int
SELECT @_Kode_Penerima_Sertifikat = SCOPE_IDENTITY()

SELECT  Kode_Penerima_Sertifikat, Nomer_Lisensi, Kode_KK, IDTahun_pelajaran, Jumlah_penerima_sertifikat, isDeleted, created, creator, edited, editor
FROM    [Tb_Penerima_Sertifikat]
WHERE   [Kode_Penerima_Sertifikat]  = @_Kode_Penerima_Sertifikat";
            context.AddParameter("@Nomer_Lisensi", string.Format("{0}", obj.Nomer_Lisensi));
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.AddParameter("@IDTahun_pelajaran", obj.IDTahun_pelajaran);
            context.AddParameter("@Jumlah_penerima_sertifikat", obj.Jumlah_penerima_sertifikat);
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Penerima_Sertifikat>(context, new Tb_Penerima_Sertifikat()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_Penerima_Sertifikat]
        /// </summary>        
        public static Tb_Penerima_Sertifikat Update(Tb_Penerima_Sertifikat obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Penerima_Sertifikat]
SET         [Nomer_Lisensi] = @Nomer_Lisensi,
            [Kode_KK] = @Kode_KK,
            [IDTahun_pelajaran] = @IDTahun_pelajaran,
            [Jumlah_penerima_sertifikat] = @Jumlah_penerima_sertifikat,
            [isDeleted] = @isDeleted,
          
            [edited] = @edited,
            [editor] = @editor
WHERE       [Kode_Penerima_Sertifikat]  = @Kode_Penerima_Sertifikat

SET @Err = @@Error

SELECT  Kode_Penerima_Sertifikat, Nomer_Lisensi, Kode_KK, IDTahun_pelajaran, Jumlah_penerima_sertifikat, isDeleted, created, creator, edited, editor 
FROM    [Tb_Penerima_Sertifikat]
WHERE   [Kode_Penerima_Sertifikat]  = @Kode_Penerima_Sertifikat";
            context.AddParameter("@Nomer_Lisensi", string.Format("{0}", obj.Nomer_Lisensi));
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.AddParameter("@IDTahun_pelajaran", obj.IDTahun_pelajaran);
            context.AddParameter("@Jumlah_penerima_sertifikat", obj.Jumlah_penerima_sertifikat);
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@Kode_Penerima_Sertifikat", obj.Kode_Penerima_Sertifikat);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Penerima_Sertifikat>(context, new Tb_Penerima_Sertifikat()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_Penerima_Sertifikat]
        /// </summary>        
        public static int Delete(Int32 Kode_Penerima_Sertifikat)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_Penerima_Sertifikat 
WHERE   [Kode_Penerima_Sertifikat]  = @Kode_Penerima_Sertifikat";
            context.AddParameter("@Kode_Penerima_Sertifikat", Kode_Penerima_Sertifikat);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [Tb_Penerima_Sertifikat]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Penerima_Sertifikat";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Penerima_Sertifikat]
        /// </summary>        
        public static List<Tb_Penerima_Sertifikat> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Kode_Penerima_Sertifikat, Nomer_Lisensi, Kode_KK, IDTahun_pelajaran, Jumlah_penerima_sertifikat, isDeleted, created, creator, edited, editor FROM Tb_Penerima_Sertifikat";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Penerima_Sertifikat>(context, new Tb_Penerima_Sertifikat());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Penerima_Sertifikat]
        /// </summary>        
        public static List<Tb_Penerima_Sertifikat> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Penerima_Sertifikat] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Penerima_Sertifikat].[Kode_Penerima_Sertifikat] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Penerima_Sertifikat].*
                FROM    [Tb_Penerima_Sertifikat]
            )

            SELECT      [Paging_Tb_Penerima_Sertifikat].*
            FROM        [Paging_Tb_Penerima_Sertifikat]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Penerima_Sertifikat>(context, new Tb_Penerima_Sertifikat());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_Penerima_Sertifikat] by Primary Key
        /// </summary>        
        public static Tb_Penerima_Sertifikat GetByPK(Int32 Kode_Penerima_Sertifikat)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT Kode_Penerima_Sertifikat, Nomer_Lisensi, Kode_KK, IDTahun_pelajaran, Jumlah_penerima_sertifikat, isDeleted, created, creator, edited, editor FROM Tb_Penerima_Sertifikat
            WHERE [Kode_Penerima_Sertifikat]  = @Kode_Penerima_Sertifikat";
            context.AddParameter("@Kode_Penerima_Sertifikat", Kode_Penerima_Sertifikat);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Penerima_Sertifikat>(context, new Tb_Penerima_Sertifikat()).FirstOrDefault();
        }

        #endregion

    }
}