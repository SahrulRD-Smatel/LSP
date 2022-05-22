using DataAccessLayer;
using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dta.Custom
{
    public class Tb_LSP_cstmItem
    {
        public static List<Tb_LSP_cstm> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"select  a.Nomer_Lisensi, a.NPSN, b.Nama_Sekolah, d.Username, c.NamaKabupaten, a.Status_LSP, CONVERT(date,  replace(a.Berlaku_Sampai,'1900-01-01',null)) as Berlaku_Sampai, a.created, a.creator, a.edited, a.editor
from  [Tb_LSP] a 
left outer join  [Tb_SMK] b on a.NPSN = b.NPSN
left outer join  [Tb_Kabupaten] c on b.Kode_Kabupaten=c.Kode_Kabupaten
left outer join [Tb_Admin_Sekolah] d on a.NPSN = d.NPSN
 order by a.Nomer_Lisensi";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_LSP_cstm>(context, new Tb_LSP_cstm());
        }

        public static Tb_LSP_cstm GetByPK(string ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"select  a.Nomer_Lisensi, a.NPSN, b.Nama_Sekolah, d.Username, c.NamaKabupaten, a.Status_LSP, convert(date, a.Berlaku_Sampai) as Berlaku_Sampai, a.created, a.creator, a.edited, a.editor
from  [Tb_LSP] a 
left outer join  [Tb_SMK] b on a.NPSN = b.NPSN
left outer join  [Tb_Kabupaten] c on b.Kode_Kabupaten=c.Kode_Kabupaten 
left outer join [Tb_Admin_Sekolah] d on a.NPSN = d.NPSN
            WHERE a.[Nomer_Lisensi]  = @Nomer_Lisensi";
            context.AddParameter("@Nomer_Lisensi", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_LSP_cstm>(context, new Tb_LSP_cstm()).FirstOrDefault();
        }

        public static Tb_LSP_cstm GetByNPSN(Int32 NPSN)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"select  a.Nomer_Lisensi, a.NPSN, b.Nama_Sekolah, c.NamaKabupaten, a.Status_LSP, convert(date, a.Berlaku_Sampai) as Berlaku_Sampai, a.created, a.creator, a.edited, a.editor
from  [Tb_LSP] a 
left outer join  [Tb_SMK] b on a.NPSN = b.NPSN
left outer join  [Tb_Kabupaten] c on b.Kode_Kabupaten=c.Kode_Kabupaten 
            WHERE b.NPSN = @NPSN";
            context.AddParameter("@NPSN", NPSN);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_LSP_cstm>(context, new Tb_LSP_cstm()).FirstOrDefault();
        }

    }
}
