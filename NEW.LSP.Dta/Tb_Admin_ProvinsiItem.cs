
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Tb_Admin_Provinsi]
    /// </summary>    
    public partial class Tb_Admin_ProvinsiItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Tb_Admin_Provinsi]
        /// </summary>        
        public static Tb_Admin_Provinsi Insert(Tb_Admin_Provinsi obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Admin_Provinsi]([Username], [Password], [NamaLengkap], [isDeleted], [created], [creator], [edited], [editor]) 
VALUES      (@Username, @Password, @NamaLengkap, @isDeleted, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @_ID Int
SELECT @_ID = SCOPE_IDENTITY()

SELECT  ID, Username, Password, NamaLengkap, isDeleted, created, creator, edited, editor
FROM    [Tb_Admin_Provinsi]
WHERE   [ID]  = @_ID";
            context.AddParameter("@Username", string.Format("{0}", obj.Username));
            context.AddParameter("@Password", string.Format("{0}", obj.Password));
            context.AddParameter("@NamaLengkap", string.Format("{0}", obj.NamaLengkap));
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Admin_Provinsi>(context, new Tb_Admin_Provinsi()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_Admin_Provinsi]
        /// </summary>        
        public static Tb_Admin_Provinsi Update(Tb_Admin_Provinsi obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Admin_Provinsi]
SET         [Username] = @Username,
            [Password] = @Password,
            [NamaLengkap] = @NamaLengkap,
            [isDeleted] = @isDeleted,
           
            [edited] = @edited,
            [editor] = @editor
WHERE       [ID]  = @ID

SET @Err = @@Error

SELECT  ID, Username, Password, NamaLengkap, isDeleted, created, creator, edited, editor 
FROM    [Tb_Admin_Provinsi]
WHERE   [ID]  = @ID";
            context.AddParameter("@Username", string.Format("{0}", obj.Username));
            context.AddParameter("@Password", string.Format("{0}", obj.Password));
            context.AddParameter("@NamaLengkap", string.Format("{0}", obj.NamaLengkap));
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@ID", obj.ID);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Admin_Provinsi>(context, new Tb_Admin_Provinsi()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_Admin_Provinsi]
        /// </summary>        
        public static int Delete(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM Tb_Admin_Provinsi 
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
        /// Get Total records from [Tb_Admin_Provinsi]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Admin_Provinsi";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Admin_Provinsi]
        /// </summary>        
        public static List<Tb_Admin_Provinsi> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT ID, Username, Password, NamaLengkap, isDeleted, created, creator, edited, editor FROM Tb_Admin_Provinsi";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Admin_Provinsi>(context, new Tb_Admin_Provinsi());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Admin_Provinsi]
        /// </summary>        
        public static List<Tb_Admin_Provinsi> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Admin_Provinsi] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Admin_Provinsi].[ID] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Admin_Provinsi].*
                FROM    [Tb_Admin_Provinsi]
            )

            SELECT      [Paging_Tb_Admin_Provinsi].*
            FROM        [Paging_Tb_Admin_Provinsi]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Admin_Provinsi>(context, new Tb_Admin_Provinsi());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_Admin_Provinsi] by Primary Key
        /// </summary>        
        public static Tb_Admin_Provinsi GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT ID, Username, Password, NamaLengkap, isDeleted, created, creator, edited, editor FROM Tb_Admin_Provinsi
            WHERE [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Admin_Provinsi>(context, new Tb_Admin_Provinsi()).FirstOrDefault();
        }

        #endregion

    }
}