using DataAccessLayer;
using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dta.Custom
{
    public class Tb_Home_cstmItem
    {
        public static List<Tb_Home_cstm> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"select isnull((select count(*)  from  [Tb_LSP]),0)as jmlLSP
                ,isnull((select count(*) from  [Tb_SMK]),0) as jmlSMK
                ,isnull((select sum([Jumlah_asesor]) from  [Tb_Kompetensi_Keahlian_Terlisensi]),0) as jmlAsesor
                ,isnull((select count(*) from  [Tb_Kompetensi_Keahlian_Terlisensi]),0) as jmlKKT
                ,isnull((select sum(Jumlah_penerima_sertifikat) from  [Tb_Penerima_Sertifikat]),0) as jmlPS ,'' as descript ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Home_cstm>(context, new Tb_Home_cstm());
        }

        public static List<Tb_Home_cstm> GetAllSKL(string npsn)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"select isnull((select sum([Jumlah_asesor]) from  [Tb_Kompetensi_Keahlian_Terlisensi]  a 
             inner join  [Tb_LSP] b on a.Nomer_Lisensi = b.Nomer_Lisensi where NPSN =@NPSN),0) as jmlAsesor 
             ,isnull((select count(*) from [Tb_Kompetensi_Keahlian_Terlisensi]  a 
            inner join [Tb_LSP] b on a.Nomer_Lisensi = b.Nomer_Lisensi where NPSN = @NPSN),0) as jmlKKT
            ,isnull((select sum(Jumlah_penerima_sertifikat) from [Tb_Penerima_Sertifikat] a 
            inner join [Tb_LSP] b on a.Nomer_Lisensi = b.Nomer_Lisensi where NPSN = @NPSN),0) as jmlPS, 0 as jmlLSP, 0 as jmlSMK
            ,isnull((SELECT case when DATEDIFF(day, GETDATE() , Berlaku_Sampai)<1 then 'Telah Habis' when DATEDIFF(day, GETDATE() , Berlaku_Sampai)<=7 then 'Kurang Dari 1 Minggu' when DATEDIFF(day, GETDATE() , Berlaku_Sampai) <=30 then 'Kurang Dari 1 Bulan'  when DATEDIFF(day, GETDATE() , Berlaku_Sampai) <=366 then 'Kurang Dari 1 Tahun' when DATEDIFF(day, GETDATE() , Berlaku_Sampai) >367 then 'Beberapa Tahun Lagi' else '' end as Descript FROM [Tb_LSP] a	where a.NPSN = @NPSN),'') as descript ";

            context.AddParameter("@NPSN", npsn);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Home_cstm>(context, new Tb_Home_cstm());
        }

   //     public static Tb_LSP_cstm GetByBetween()
   //     {
   //         IDBHelper context = new DBHelper();
   //         string sqlQuery = @"SELECT a.*, b.Nama_Sekolah, c.NamaKabupaten
   //         ,case  when DATEDIFF(day, GETDATE() , Berlaku_Sampai) <=366 then '1 Tahun' when DATEDIFF(day, GETDATE() , Berlaku_Sampai) <=30 then '1 Bulan' when DATEDIFF(day, GETDATE() , Berlaku_Sampai)<7 then '1 Minggu' end
   //         as Descript
   //         FROM Tb_LSP a
			//left outer join  [Tb_SMK] b on a.NPSN = b.NPSN
			//left outer join  [Tb_Kabupaten] c on b.Kode_Kabupaten=c.Kode_Kabupaten

		 //   and	DATEDIFF(day, GETDATE() , Berlaku_Sampai) <=366";
   //         context.CommandText = sqlQuery;
   //         context.CommandType = System.Data.CommandType.Text;
   //         return DBUtil.ExecuteMapper<Tb_LSP_cstm>(context, new Tb_LSP_cstm()).FirstOrDefault();
   //     }

    }
}
