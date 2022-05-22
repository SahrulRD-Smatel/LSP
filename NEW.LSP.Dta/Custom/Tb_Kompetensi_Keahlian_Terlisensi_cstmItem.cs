using DataAccessLayer;
using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dta.Custom
{
    public class Tb_Kompetensi_Keahlian_Terlisensi_cstmItem
    {
        public static List<Tb_Kompetensi_Keahlian_Terlisensi_cstm> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT [Kode_KK_Terlisensi]
                  ,a.[Nomer_Lisensi]
                  ,a.[Kode_KK] 	  
	              ,c.Nama_KK
				  ,f.Skema
                  ,f.Kode_Skema
                  ,b.NPSN
	              ,d.Nama_Sekolah
	              ,e.NamaKabupaten
                  ,[Status_KK_Terlisensi]
                  ,[Jumlah_asesor],a.[created],a.[creator],a.[edited],a.[editor]
              FROM  [Tb_Kompetensi_Keahlian_Terlisensi] a      
              inner join  [Tb_LSP] b on a.Nomer_Lisensi= b.Nomer_Lisensi
              inner join  [Tb_Kompetensi_Keahlian] c on a.Kode_KK = c.Kode_KK
              inner join  [Tb_SMK] d on b.NPSN = d.NPSN
              inner join  [Tb_Kabupaten] e on d.Kode_Kabupaten = e.Kode_Kabupaten
			  inner join  [Tb_Skema] f on c.Kode_KK = f.Kode_KK";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kompetensi_Keahlian_Terlisensi_cstm>(context, new Tb_Kompetensi_Keahlian_Terlisensi_cstm());
        }

        public static Tb_Kompetensi_Keahlian_Terlisensi_cstm GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT [Kode_KK_Terlisensi]
                  ,a.[Nomer_Lisensi]
                  ,a.[Kode_KK] 	 
                  ,b.NPSN
	              ,c.Nama_KK
                  ,f.Skema
                  ,f.Kode_Skema
	              ,d.Nama_Sekolah
	              ,e.NamaKabupaten
                  ,[Status_KK_Terlisensi]
                  ,[Jumlah_asesor],a.[created],a.[creator],a.[edited],a.[editor]
              FROM  [Tb_Kompetensi_Keahlian_Terlisensi] a      
              inner join  [Tb_LSP] b on a.Nomer_Lisensi= b.Nomer_Lisensi
              inner join  [Tb_Kompetensi_Keahlian] c on a.Kode_KK = c.Kode_KK
              inner join  [Tb_SMK] d on b.NPSN = d.NPSN
              inner join  [Tb_Kabupaten] e on d.Kode_Kabupaten = e.Kode_Kabupaten
              inner join  [Tb_Skema] f on c.Kode_KK = f.Kode_KK
              where a.Kode_KK_Terlisensi = @Kode_KK_Terlisensi ";
            context.AddParameter("@Kode_KK_Terlisensi", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kompetensi_Keahlian_Terlisensi_cstm>(context, new Tb_Kompetensi_Keahlian_Terlisensi_cstm()).FirstOrDefault();
        }

        public static List<Tb_Kompetensi_Keahlian_Terlisensi_cstm> GetAllByNPSN(Int32 npsn)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT [Kode_KK_Terlisensi]
                  ,a.[Nomer_Lisensi]
                  ,a.[Kode_KK] 	 
                  ,b.NPSN
	              ,c.Nama_KK
                  ,f.Skema
                  ,f.Kode_Skema
	              ,d.Nama_Sekolah
	              ,e.NamaKabupaten
                  ,[Status_KK_Terlisensi]
                  ,[Jumlah_asesor],a.[created],a.[creator],a.[edited],a.[editor]
              FROM  [Tb_Kompetensi_Keahlian_Terlisensi] a      
              inner join  [Tb_LSP] b on a.Nomer_Lisensi= b.Nomer_Lisensi
              inner join  [Tb_Kompetensi_Keahlian] c on a.Kode_KK = c.Kode_KK
              inner join  [Tb_SMK] d on b.NPSN = d.NPSN
              inner join  [Tb_Kabupaten] e on d.Kode_Kabupaten = e.Kode_Kabupaten
              inner join  [Tb_Skema] f on c.Kode_KK = f.Kode_KK
			  where b.NPSN = @NPSN";

            context.AddParameter("@NPSN", npsn);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Kompetensi_Keahlian_Terlisensi_cstm>(context, new Tb_Kompetensi_Keahlian_Terlisensi_cstm());
        }

    }
}
