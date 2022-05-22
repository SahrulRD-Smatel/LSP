using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    public partial class Tb_SkemaItem
    {

        #region Data Access

        public static Tb_Skema Insert(Tb_Skema obj)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Skema] ([Kode_Skema], [Kode_KK], [Skema], [isDeleted], [created], [creator], [edited], [editor])
VALUES (@Kode_Skema, @Kode_KK, @Skema, @isDeleted, @created, @creator, @edited, @editor )

SET @Err = @@Error

SELECT Kode_Skema, Kode_KK, Skema, isDeleted, created, creator, edited, editor  FROM [Tb_Skema]
WHERE [Kode_Skema] = @Kode_Skema";
            context.AddParameter("@Kode_Skema", obj.Kode_Skema);
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.AddParameter("@Skema", string.Format("{0}", obj.Skema));
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Skema>(context, new Tb_Skema()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE []
        /// </summary>  
        /// 
        public static Tb_Skema Update(Tb_Skema obj)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Skema]
SET         [Skema] = @Skema,
            [isDeleted] = @isDeleted, 

            [edited] = @edited,
            [editor] = @editor
WHERE   [Kode_Skema] = @Kode_Skema

SET @Err = @@Error


SELECT Kode_Skema, Kode_KK, Skema,  isDeleted, created, creator, edited, editor 
FROM [Tb_Skema]
WHERE [Kode_Skema] = @Kode_Skema";
            context.AddParameter("@Skema", string.Format("{0}", obj.Skema));
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@Kode_Skema", obj.Kode_Skema);
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Skema>(context, new Tb_Skema()).FirstOrDefault();

        }

        /// <summary>
        /// Execute Delete to TABLE []
        /// </summary>        
        public static int Delete(Int32 Kode_Skema)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"DELETE FROM Tb_Skema 
WHERE   [Kode_Skema]  = @Kode_Skema";
            context.AddParameter("@Kode_Skema", Kode_Skema);
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
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Skema";
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
        public static List<Tb_Skema> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = " SELECT Kode_KK, Kode_Skema, Skema, isDeleted, created, creator, edited, editor FROM Tb_Skema";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Skema>(context, new Tb_Skema());
        }

        /// <summary>
        /// Get All records from TABLE []
        /// </summary>        
        public static List<Tb_Skema> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Skema] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Skema].[Skema] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Skema].*
                FROM    [Tb_Skema]
            )

            SELECT      [Paging_Tb_Skema].*
            FROM        [Paging_Tb_Skema]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Skema>(context, new Tb_Skema());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_LSP] by Primary Key
        /// </summary>        
        public static Tb_Skema GetByPK(Int32 Kode_Skema)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT Kode_Skema, Kode_KK, Skema, isDeleted, created, creator, edited, editor FROM Tb_Skema
            WHERE [Kode_Skema]  = @Kode_Skema";
            context.AddParameter("@Kode_Skema", Kode_Skema);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Skema>(context, new Tb_Skema()).FirstOrDefault();
        }

        #endregion

    }
}