using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using NEW.LSP.Dto;

namespace NEW.LSP.Dta
{
    public partial class Tb_PengumumanItem
    {
        #region Data Access

        public static Tb_Pengumuman Insert(Tb_Pengumuman obj)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [Tb_Pengumuman]([no], [tanggal], [tanggal_hingga], [judul] , [picture], [pictureData],[isi], [created], [creator], [editor], [edited]) 
VALUES      (@no, @tanggal, @tanggal_hingga, @judul, @picture, @pictureData, @isi, @created, @creator, @editor, @edited)

SET @Err = @@Error

DECLARE @_id_pengumuman Int
SELECT @_id_pengumuman = SCOPE_IDENTITY()

SELECT  id_pengumuman, no, tanggal, tanggal_hingga, judul, picture,[pictureData], isi, created, creator, editor, edited
FROM    [Tb_Pengumuman]
WHERE   [id_pengumuman]  = @_id_pengumuman";
            context.AddParameter("@no", string.Format("{0}", obj.no));
            context.AddParameter("@tanggal", obj.tanggal);
            context.AddParameter("@tanggal_hingga", obj.tanggal_hingga);
            context.AddParameter("@judul", string.Format("{0}", obj.judul));
            context.AddParameter("@picture", string.Format("{0}", obj.picture));
            context.AddParameter("@pictureData", obj.pictureData);
            context.AddParameter("@isi", string.Format("{0}", obj.isi));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@edited", obj.edited);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Pengumuman>(context, new Tb_Pengumuman()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [Tb_Pengumuman]
        /// </summary>        
        public static Tb_Pengumuman Update(Tb_Pengumuman obj)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Pengumuman]
SET         [no] = @no,
            [tanggal] = @tanggal,
            [tanggal_hingga] = @tanggal_hingga,
            [judul] = @judul,";

            sqlQuery += obj.pictureData.Length == 0 ? "" : " [picture] = @picture,   [pictureData]= @pictureData,";

            sqlQuery += @"
           [isi] = @isi,
           
            [editor] = @editor,
            [edited] = @edited
WHERE       [id_pengumuman]  = @id_pengumuman

SET @Err = @@Error

SELECT  id_pengumuman, no, tanggal, tanggal_hingga, judul, picture,[pictureData], isi, created, creator, editor, edited 
FROM    [Tb_Pengumuman]
WHERE   [id_pengumuman]  = @id_pengumuman";
            context.AddParameter("@no", string.Format("{0}", obj.no));
            context.AddParameter("@tanggal", obj.tanggal);
            context.AddParameter("@tanggal_hingga", obj.tanggal_hingga);
            context.AddParameter("@judul", string.Format("{0}", obj.judul));
            context.AddParameter("@picture", string.Format("{0}", obj.picture));
            context.AddParameter("@pictureData", obj.pictureData);
            context.AddParameter("@isi", string.Format("{0}", obj.isi));
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@id_pengumuman", obj.id_pengumuman);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Pengumuman>(context, new Tb_Pengumuman()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Delete to TABLE [Tb_Pengumuman]
        /// </summary>        
        public static int Delete(Int32 id_pengumuman)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"DELETE FROM Tb_Pengumuman 
WHERE   [id_pengumuman]  = @id_pengumuman";
            context.AddParameter("@id_pengumuman", id_pengumuman);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [Tb_Pengumuman]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM Tb_Pengumuman";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }

        /// <summary>
        /// Get All records from TABLE [Tb_Pengumuman]
        /// </summary>        
        public static List<Tb_Pengumuman> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id_pengumuman, no, tanggal, tanggal_hingga, judul, picture, [pictureData],isi, created, creator, editor, edited FROM Tb_Pengumuman";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Pengumuman>(context, new Tb_Pengumuman());
        }

        /// <summary>
        /// Get All records from TABLE [Tb_Pengumuman]
        /// </summary>        
        public static List<Tb_Pengumuman> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_Tb_Pengumuman] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [Tb_Pengumuman].[id_pengumuman] DESC ) AS PAGING_ROW_NUMBER,
                        [Tb_Pengumuman].*
                FROM    [Tb_Pengumuman]
            )

            SELECT      [Paging_Tb_Pengumuman].*
            FROM        [Paging_Tb_Pengumuman]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Tb_Pengumuman>(context, new Tb_Pengumuman());
        }

        /// <summary>
        /// Get a single record of TABLE [Tb_Pengumuman] by Primary Key
        /// </summary>        
        public static Tb_Pengumuman GetByPK(Int32 id_pengumuman)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_pengumuman, no, tanggal, tanggal_hingga, judul, picture, [pictureData],isi, created, creator, editor, edited FROM Tb_Pengumuman
            WHERE [id_pengumuman]  = @id_pengumuman";
            context.AddParameter("@id_pengumuman", id_pengumuman);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Pengumuman>(context, new Tb_Pengumuman()).FirstOrDefault();
        }

        #endregion

    }
}

