using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    public partial class Tb_Data_AsesorItem
    {

        #region Data Access

        public static Tb_Data_Asesor Insert(Tb_Data_Asesor obj)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Data_Asesor] ([No_Reg_Met], [Kode_KK], [NPSN],[Nama_Asesor],[Tanggal_Sertifikat_Asesor],[isDeleted],[created],[creator],[edited],[editor])
VALUES (@No_Reg_Met, @Kode_KK, @NPSN, @Nama_Asesor, @Tanggal_Sertifikat_Asesor, @isDeleted, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @id_asesor Int
SELECT @id_asesor = SCOPE_IDENTITY()

SELECT id_asesor,No_Reg_Met, Kode_KK, NPSN, Nama_Asesor, Tanggal_Sertifikat_Asesor, isDeleted, created, creator, edited, editor
FROM [Tb_Data_Asesor]
WHERE [id_asesor] = @id_asesor";
            context.AddParameter("@No_Reg_Met", string.Format("{0}", obj.No_Reg_Met));
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.AddParameter("@NPSN", obj.NPSN);
            context.AddParameter("@Nama_Asesor", string.Format("{0}", obj.Nama_Asesor));
            context.AddParameter("@Tanggal_Sertifikat_Asesor", obj.Tanggal_Sertifikat_Asesor);
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Data_Asesor>(context, new Tb_Data_Asesor()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE []
        /// </summary>  
        /// 
        public static Tb_Data_Asesor Update(Tb_Data_Asesor obj)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Data_Asesor]
SET         [No_Reg_Met] = @No_Reg_Met,
            [Kode_KK] = @Kode_KK,
            [NPSN] = @NPSN,
            [Nama_Asesor] = @Nama_Asesor,
            [Tanggal_Sertifikat_Asesor] = @Tanggal_Sertifikat_Asesor,
            [isDeleted] = @isDeleted,

            [edited] = @edited,
            [editor] = @editor
WHERE   [id_asesor] = @id_asesor

SET @Err = @@Error


SELECT id_asesor,No_Reg_Met, Kode_KK, NPSN, Nama_Asesor, Tanggal_Sertifikat_Asesor, isDeleted, created, creator, edited, editor
FROM [Tb_Data_Asesor]
WHERE [id_asesor] = @id_asesor";
            context.AddParameter("@No_Reg_Met", string.Format("{0}", obj.No_Reg_Met));
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.AddParameter("@NPSN", obj.NPSN);
            context.AddParameter("@Nama_Asesor", string.Format("{0}", obj.Nama_Asesor));
            context.AddParameter("@Tanggal_Sertifikat_Asesor", obj.Tanggal_Sertifikat_Asesor);
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@id_asesor", obj.id_asesor);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Data_Asesor>(context, new Tb_Data_Asesor()).FirstOrDefault();

        }

        /// <summary>
        /// Execute Delete to TABLE []
        /// </summary>        
        public static int Delete(Int32 id_asesor)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"DELETE FROM Tb_Data_Asesor 
WHERE   [id_asesor]  = @id_asesor";
            context.AddParameter("@id_asesor", id_asesor);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from []
        /// </summary> 
        /// 
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Data_Asesor";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }

        /// <summary>
        /// Get All records from TABLE []
        /// </summary>        
        public static List<Tb_Data_Asesor> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = " SELECT id_asesor, No_Reg_Met, Kode_KK, NPSN, Nama_Asesor, Tanggal_Sertifikat_Asesor, isDeleted, created, creator, edited, editor FROM Tb_Data_Asesor";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Data_Asesor>(context, new Tb_Data_Asesor());
        }

        /// <summary>
        /// Get All records from TABLE []
        /// </summary>        
        public static List<Tb_Data_Asesor> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Data_Asesor] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Data_Asesor].[No_Reg_Met] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Data_Asesor].*
                FROM    [Tb_Data_Asesor]
            )

            SELECT      [Paging_Tb_Data_Asesor].*
            FROM        [Paging_Tb_Data_Asesor]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Data_Asesor>(context, new Tb_Data_Asesor());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_LSP] by Primary Key
        /// </summary>        
        public static Tb_Data_Asesor GetByPK(Int32 id_asesor)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_asesor, No_Reg_Met, Kode_KK, NPSN, Nama_Asesor, Tanggal_Sertifikat_Asesor, isDeleted, created, creator, edited, editor FROM Tb_Data_Asesor
            WHERE [id_asesor]  = @id_asesor";
            context.AddParameter("@id_asesor", id_asesor);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Data_Asesor>(context, new Tb_Data_Asesor()).FirstOrDefault();
        }

        #endregion

    }
}