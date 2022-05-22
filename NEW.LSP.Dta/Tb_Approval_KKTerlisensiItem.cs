
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_Approval_KKTerlisensi]
    /// </summary>    
    public partial class Tb_Approval_KKTerlisensiItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_Approval_KKTerlisensi]
        /// </summary>        
        public static Tb_Approval_KKTerlisensi Insert(Tb_Approval_KKTerlisensi obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Approval_KKTerlisensi]([Kode_KK_Terlisensi], [Status], [Name], [Data], [created], [creator], [edited], [editor]) 
VALUES      (@Kode_KK_Terlisensi, @Status, @Name, @Data, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @_id_app Int
SELECT @_id_app = SCOPE_IDENTITY()

SELECT  id_app, Kode_KK_Terlisensi, Status, Name, Data, created, creator, edited, editor
FROM    [Tb_Approval_KKTerlisensi]
WHERE   [id_app]  = @_id_app";
            context.AddParameter("@Kode_KK_Terlisensi", obj.Kode_KK_Terlisensi);
            context.AddParameter("@Status", obj.Status);
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Data", obj.Data, System.Data.DbType.Binary);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Approval_KKTerlisensi>(context, new Tb_Approval_KKTerlisensi()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_Approval_KKTerlisensi]
        /// </summary>        
        public static Tb_Approval_KKTerlisensi Update(Tb_Approval_KKTerlisensi obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Approval_KKTerlisensi]
SET         [Kode_KK_Terlisensi] = @Kode_KK_Terlisensi,
            [Status] = @Status,
            [Name] = @Name,
            [Data] = @Data,
          
            [edited] = @edited,
            [editor] = @editor
WHERE       [id_app]  = @id_app

SET @Err = @@Error

SELECT  id_app, Kode_KK_Terlisensi, Status, Name, Data, created, creator, edited, editor 
FROM    [Tb_Approval_KKTerlisensi]
WHERE   [id_app]  = @id_app";
            context.AddParameter("@Kode_KK_Terlisensi", obj.Kode_KK_Terlisensi);
            context.AddParameter("@Status", obj.Status);
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Data", obj.Data, System.Data.DbType.Binary);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@id_app", obj.id_app);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Approval_KKTerlisensi>(context, new Tb_Approval_KKTerlisensi()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_Approval_KKTerlisensi]
        /// </summary>        
        public static int Delete(Int32 id_app)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_Approval_KKTerlisensi 
WHERE   [id_app]  = @id_app";
            context.AddParameter("@id_app", id_app);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [Tb_Approval_KKTerlisensi]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Approval_KKTerlisensi";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Approval_KKTerlisensi]
        /// </summary>        
        public static List<Tb_Approval_KKTerlisensi> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id_app, Kode_KK_Terlisensi, Status, Name, Data, created, creator, edited, editor FROM Tb_Approval_KKTerlisensi";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Approval_KKTerlisensi>(context, new Tb_Approval_KKTerlisensi());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Approval_KKTerlisensi]
        /// </summary>        
        public static List<Tb_Approval_KKTerlisensi> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Approval_KKTerlisensi] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Approval_KKTerlisensi].[id_app] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Approval_KKTerlisensi].*
                FROM    [Tb_Approval_KKTerlisensi]
            )

            SELECT      [Paging_Tb_Approval_KKTerlisensi].*
            FROM        [Paging_Tb_Approval_KKTerlisensi]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Approval_KKTerlisensi>(context, new Tb_Approval_KKTerlisensi());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_Approval_KKTerlisensi] by Primary Key
        /// </summary>        
        public static Tb_Approval_KKTerlisensi GetByPK(Int32 id_app)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_app, Kode_KK_Terlisensi, Status, Name, Data, created, creator, edited, editor FROM Tb_Approval_KKTerlisensi
            WHERE [id_app]  = @id_app";
            context.AddParameter("@id_app", id_app);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Approval_KKTerlisensi>(context, new Tb_Approval_KKTerlisensi()).FirstOrDefault();
        }

        #endregion

    }
}