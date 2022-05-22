using DataAccessLayer;
using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dta.Custom
{
    public class Tb_SMK_Kompetensi_Keahlian_cstmItem
    {
        public static List<Tb_SMK_Kompetensi_Keahlian_cstm> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT  [ID]
      , a.[NPSN]
	  ,b.Nama_Sekolah
      ,a.[Kode_KK]
	  ,c.Nama_KK,'' NamaKabupaten
      ,a.[created]
      ,a.[creator]
      ,a.[edited]
      ,a.[editor]
  FROM [Tb_SMK_Kompetensi_Keahlian] a
left outer join Tb_SMK b on a.NPSN = b.NPSN
  left outer join Tb_Kompetensi_Keahlian c on a.Kode_KK = c.Kode_KK order by a.NPSN";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_SMK_Kompetensi_Keahlian_cstm>(context, new Tb_SMK_Kompetensi_Keahlian_cstm());
        }

        public static Tb_SMK_Kompetensi_Keahlian_cstm GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT  a.[ID]
      ,a.[NPSN]
	  ,b.Nama_Sekolah
      ,a.[Kode_KK]
	  ,c.Nama_KK , '' NamaKabupaten
      ,a.[created]
      ,a.[creator]
      ,a.[edited]
      ,a.[editor]
  FROM  [Tb_SMK_Kompetensi_Keahlian] a 
  left outer join Tb_SMK b on a.NPSN = b.NPSN
  left outer join Tb_Kompetensi_Keahlian c on a.Kode_KK=c.Kode_KK        
            WHERE [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_SMK_Kompetensi_Keahlian_cstm>(context, new Tb_SMK_Kompetensi_Keahlian_cstm()).FirstOrDefault();
        }

        public static List<Tb_SMK_Kompetensi_Keahlian_cstm> GetByNPSN(Int32 NPSN)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT  a.[ID]
                  ,a.[NPSN]
	              ,b.Nama_Sekolah
                  ,a.[Kode_KK]
	              ,c.Nama_KK, '' NamaKabupaten
                  ,a.[created]
                  ,a.[creator]
                  ,a.[edited]
                  ,a.[editor]
              FROM  [Tb_SMK_Kompetensi_Keahlian] a 
              left outer join Tb_SMK b on a.NPSN = b.NPSN
              left outer join Tb_Kompetensi_Keahlian c on a.Kode_KK=c.Kode_KK
			  where b.NPSN = @ID";
            context.AddParameter("@ID", NPSN);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_SMK_Kompetensi_Keahlian_cstm>(context, new Tb_SMK_Kompetensi_Keahlian_cstm());
        }


    }
}
