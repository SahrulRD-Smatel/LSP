
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_Kabupaten]
    /// </summary>    
    public partial class Tb_KabupatenItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_Kabupaten]
        /// </summary>        
        public static Tb_Kabupaten Insert(Tb_Kabupaten obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Kabupaten]([Kode_Kabupaten], [NamaKabupaten], [IbuKotaKabupaten]) 
VALUES      (@Kode_Kabupaten, @NamaKabupaten, @IbuKotaKabupaten)

SET @Err = @@Error

SELECT  Kode_Kabupaten, NamaKabupaten, IbuKotaKabupaten
FROM    [Tb_Kabupaten]
WHERE   [Kode_Kabupaten]  = @Kode_Kabupaten";
            context.AddParameter("@Kode_Kabupaten", obj.Kode_Kabupaten);
            context.AddParameter("@NamaKabupaten", string.Format("{0}", obj.NamaKabupaten));
            context.AddParameter("@IbuKotaKabupaten", string.Format("{0}", obj.IbuKotaKabupaten));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kabupaten>(context, new Tb_Kabupaten()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_Kabupaten]
        /// </summary>        
        public static Tb_Kabupaten Update(Tb_Kabupaten obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Kabupaten]
SET         [NamaKabupaten] = @NamaKabupaten,
            [IbuKotaKabupaten] = @IbuKotaKabupaten
WHERE       [Kode_Kabupaten]  = @Kode_Kabupaten

SET @Err = @@Error

SELECT  Kode_Kabupaten, NamaKabupaten, IbuKotaKabupaten 
FROM    [Tb_Kabupaten]
WHERE   [Kode_Kabupaten]  = @Kode_Kabupaten";
            context.AddParameter("@NamaKabupaten", string.Format("{0}", obj.NamaKabupaten));
            context.AddParameter("@IbuKotaKabupaten", string.Format("{0}", obj.IbuKotaKabupaten));
            context.AddParameter("@Kode_Kabupaten", obj.Kode_Kabupaten);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kabupaten>(context, new Tb_Kabupaten()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_Kabupaten]
        /// </summary>        
        public static int Delete(Int32 Kode_Kabupaten)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_Kabupaten 
WHERE   [Kode_Kabupaten]  = @Kode_Kabupaten";
            context.AddParameter("@Kode_Kabupaten", Kode_Kabupaten);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [Tb_Kabupaten]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Kabupaten";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Kabupaten]
        /// </summary>        
        public static List<Tb_Kabupaten> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Kode_Kabupaten, NamaKabupaten, IbuKotaKabupaten FROM Tb_Kabupaten";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kabupaten>(context, new Tb_Kabupaten());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Kabupaten]
        /// </summary>        
        public static List<Tb_Kabupaten> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Kabupaten] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Kabupaten].[Kode_Kabupaten] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Kabupaten].*
                FROM    [Tb_Kabupaten]
            )

            SELECT      [Paging_Tb_Kabupaten].*
            FROM        [Paging_Tb_Kabupaten]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Kabupaten>(context, new Tb_Kabupaten());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_Kabupaten] by Primary Key
        /// </summary>        
        public static Tb_Kabupaten GetByPK(Int32 Kode_Kabupaten)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT Kode_Kabupaten, NamaKabupaten, IbuKotaKabupaten FROM Tb_Kabupaten
            WHERE [Kode_Kabupaten]  = @Kode_Kabupaten";
            context.AddParameter("@Kode_Kabupaten", Kode_Kabupaten);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kabupaten>(context, new Tb_Kabupaten()).FirstOrDefault();
        }

        #endregion

    }
}