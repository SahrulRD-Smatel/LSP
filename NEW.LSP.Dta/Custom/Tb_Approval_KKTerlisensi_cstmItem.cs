using DataAccessLayer;
using NEW.LSP.Dto;
using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dta
{
    public partial class Tb_Approval_KKTerlisensiItem
    {
        public static List<Tb_Approval_KKTerlisensi_cstm> GetAllCustom()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT f.id_app, a.[Kode_KK_Terlisensi]
                  ,a.[Nomer_Lisensi]
                  ,a.[Kode_KK] 	 
                  ,b.NPSN
	              ,c.Nama_KK
	              ,d.Nama_Sekolah
	              ,e.NamaKabupaten
                  ,[Status_KK_Terlisensi]
                  ,isnull([Jumlah_asesor],0) as Jumlah_asesor,f.Name, f.[Status], f.[created],f.[creator],f.[edited],f.[editor]
              FROM  [Tb_Kompetensi_Keahlian_Terlisensi] a      
              inner join  [Tb_LSP] b on a.Nomer_Lisensi= b.Nomer_Lisensi
              inner join  [Tb_Kompetensi_Keahlian] c on a.Kode_KK = c.Kode_KK
              inner join  [Tb_SMK] d on b.NPSN = d.NPSN
              inner join  [Tb_Kabupaten] e on d.Kode_Kabupaten = e.Kode_Kabupaten
			  inner join  [Tb_Approval_KKTerlisensi] f on a.Kode_KK_Terlisensi = f.Kode_KK_Terlisensi
			  where f.[Status]=0";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Approval_KKTerlisensi_cstm>(context, new Tb_Approval_KKTerlisensi_cstm());
        }
    }
}
