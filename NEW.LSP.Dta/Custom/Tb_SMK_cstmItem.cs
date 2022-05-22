using DataAccessLayer;
using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dta.Custom
{
    public partial class Tb_SMK_cstmItem
    {
        public static List<Tb_SMK_cstm> getAllCustom()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT  a.[NPSN]
      ,a.[Kode_Kabupaten]
	  ,c.NamaKabupaten
      ,[Nama_Sekolah]
      ,[Status_Sekolah]
      ,a.[Status_LSP]      
      ,a.[Kode_KK]
	  ,b.Nama_KK
,a.isDeleted, a.created, a.creator, a.edited,a.editor
  FROM  [Tb_SMK] a
left outer join  [Tb_Kompetensi_Keahlian] b on a.Kode_KK= b.Kode_KK
left outer join  [Tb_Kabupaten] c on a.[Kode_Kabupaten] =c.[Kode_Kabupaten]
order by a.[NPSN]";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_SMK_cstm>(context, new Tb_SMK_cstm());
        }

        public static Tb_SMK_cstm GetByPKCustom(Int32 NPSN)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @" SELECT  a.[NPSN]
      ,a.[Kode_Kabupaten]
	  ,c.NamaKabupaten
      ,[Nama_Sekolah]
      ,[Status_Sekolah]
      ,a.[Status_LSP]      
      ,a.[Kode_KK]
	  ,b.Nama_KK, a.created, a.creator, a.edited, a.editor
       FROM  [Tb_SMK] a
        left outer join  [Tb_Kompetensi_Keahlian] b on a.Kode_KK= b.Kode_KK
left outer join  [Tb_Kabupaten] c on a.[Kode_Kabupaten] =c.[Kode_Kabupaten]
        where a.[NPSN] = @NPSN";
            context.AddParameter("@NPSN", NPSN);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_SMK_cstm>(context, new Tb_SMK_cstm()).FirstOrDefault();
        }

    }
}
