using DataAccessLayer;
using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dta.Custom
{
    public class Tb_Admin_Sekolah_cstmItem
    {
        public static List<Tb_Admin_Sekolah_cstm> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT ID,[Username]
            ,[Password]
            ,a.[NPSN]
            ,b.Nama_Sekolah
            ,a.[created]
            ,a.[creator]
            ,a.[edited]
            ,a.[editor]
            FROM  [Tb_Admin_Sekolah] a
        left outer join  [Tb_SMK] b on a.NPSN = b.NPSN";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Admin_Sekolah_cstm>(context, new Tb_Admin_Sekolah_cstm());
        }

        public static Tb_Admin_Sekolah_cstm GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT a.ID,[Username]
            ,[Password]
            ,a.[NPSN]
            ,b.Nama_Sekolah
            ,a.[created]
            ,a.[creator]
            ,a.[edited]
            ,a.[editor]
        FROM  [Tb_Admin_Sekolah] a
        left outer join  [Tb_SMK] b on a.NPSN = b.NPSN    
            WHERE a.[ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Admin_Sekolah_cstm>(context, new Tb_Admin_Sekolah_cstm()).FirstOrDefault();
        }

        public static Tb_Admin_Sekolah_cstm GetByPKNPSN(Int32 NPSN, string Username)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT a.ID,[Username]
            ,[Password]
            ,a.[NPSN]
            ,b.Nama_Sekolah
            ,a.[created]
            ,a.[creator]
            ,a.[edited]
            ,a.[editor]
            FROM  [Tb_Admin_Sekolah] a
            left outer join  [Tb_SMK] b on a.NPSN = b.NPSN    
            WHERE a.[NPSN]  = @NPSN and a.Username=@Username";
            context.AddParameter("@NPSN", NPSN);
            context.AddParameter("@Username", Username);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Admin_Sekolah_cstm>(context, new Tb_Admin_Sekolah_cstm()).FirstOrDefault();
        }


    }
}
