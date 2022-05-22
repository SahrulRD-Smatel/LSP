using DataAccessLayer;
using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dta.Custom
{
    public class Tb_Jejaring_cstmItem
    {
        public static List<Tb_Jejaring_cstm> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT 
a.Kode_Jejaring
,a.Nomer_Lisensi
,a.Kode_KK_Terlisensi	  
,c.Nama_KK
,b.NPSN 
,d.Nama_Sekolah
,e.NamaKabupaten
, a.NPSN as NPSNJ
, ja.Nama_Sekolah as Nama_SekolahJ
, jb.NamaKabupaten as NamaKabupatenJ
,a.[created],a.[creator],a.[edited],a.[editor]
FROM  [Tb_Jejaring] a      
left outer join  [Tb_LSP] b on a.Nomer_Lisensi= b.Nomer_Lisensi
left outer join  [Tb_Kompetensi_Keahlian] c on a.Kode_KK_Terlisensi = c.Kode_KK
left outer join  [Tb_SMK] d on b.NPSN = d.NPSN
left outer join  [Tb_Kabupaten] e on d.Kode_Kabupaten = e.Kode_Kabupaten
left outer join  [Tb_SMK] Ja on Ja.NPSN = a.NPSN
left outer join  [Tb_Kabupaten] Jb on Ja.Kode_Kabupaten = Jb.Kode_Kabupaten";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Jejaring_cstm>(context, new Tb_Jejaring_cstm());
        }

        public static Tb_Jejaring_cstm GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT 
a.Kode_Jejaring
,a.Nomer_Lisensi
,a.Kode_KK_Terlisensi	  
,c.Nama_KK
,b.NPSN 
,d.Nama_Sekolah
,e.NamaKabupaten
, a.NPSN as NPSNJ
, ja.Nama_Sekolah as Nama_SekolahJ
, jb.NamaKabupaten as NamaKabupatenJ
,a.[created],a.[creator],a.[edited],a.[editor]
FROM  [Tb_Jejaring] a      
left outer join  [Tb_LSP] b on a.Nomer_Lisensi= b.Nomer_Lisensi
left outer join  [Tb_Kompetensi_Keahlian] c on a.Kode_KK_Terlisensi = c.Kode_KK
left outer join  [Tb_SMK] d on b.NPSN = d.NPSN
left outer join  [Tb_Kabupaten] e on d.Kode_Kabupaten = e.Kode_Kabupaten
left outer join  [Tb_SMK] Ja on Ja.NPSN = a.NPSN
left outer join  [Tb_Kabupaten] Jb on Ja.Kode_Kabupaten = Jb.Kode_Kabupaten
 WHERE a.Kode_Jejaring = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Jejaring_cstm>(context, new Tb_Jejaring_cstm()).FirstOrDefault();
        }

        public static List<Tb_Jejaring_cstm> GetAllByNPSN(Int32 npsn)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"select a.Kode_Jejaring
                ,a.Nomer_Lisensi
                ,a.Kode_KK_Terlisensi	  
                ,c.Nama_KK
                ,b.NPSN 
                ,d.Nama_Sekolah
                ,e.NamaKabupaten
                , a.NPSN as NPSNJ
                , ja.Nama_Sekolah as Nama_SekolahJ
                , jb.NamaKabupaten as NamaKabupatenJ
                ,a.[created],a.[creator],a.[edited],a.[editor]
                FROM  [Tb_Jejaring] a      
                left outer join  [Tb_LSP] b on a.Nomer_Lisensi= b.Nomer_Lisensi
                left outer join  [Tb_Kompetensi_Keahlian] c on a.Kode_KK_Terlisensi = c.Kode_KK
                left outer join  [Tb_SMK] d on b.NPSN = d.NPSN
                left outer join  [Tb_Kabupaten] e on d.Kode_Kabupaten = e.Kode_Kabupaten
                left outer join  [Tb_SMK] Ja on Ja.NPSN = a.NPSN
                left outer join  [Tb_Kabupaten] Jb on Ja.Kode_Kabupaten = Jb.Kode_Kabupaten where b.NPSN = @NPSN";

            context.AddParameter("@NPSN", npsn);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Jejaring_cstm>(context, new Tb_Jejaring_cstm());
        }

    }
}
