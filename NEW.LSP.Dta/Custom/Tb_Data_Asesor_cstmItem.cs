using DataAccessLayer;
using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dta.Custom
{
    public class Tb_Data_Asesor_cstmItem
    {
        public static List<Tb_Data_Asesor_cstm> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_asesor, No_Reg_Met, a.Kode_KK, Nama_Asesor, b.NPSN, b.Nama_Sekolah, c.NamaKabupaten , Nama_KK, Tanggal_Sertifikat_Asesor, a.isDeleted, a.created, a.creator, a.edited, a.editor
FROM [Tb_Data_Asesor] a
left outer join  [Tb_SMK] b on a.NPSN = b.NPSN
left outer join  [Tb_Kabupaten] c on b.Kode_Kabupaten=c.Kode_Kabupaten
left outer join  [Tb_Jejaring] d on a.NPSN = d.NPSN
left outer join  [Tb_Kompetensi_Keahlian] e on a.Kode_KK = e.Kode_KK
 order by a.id_asesor";

            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Data_Asesor_cstm>(context, new Tb_Data_Asesor_cstm());
        }

        public static Tb_Data_Asesor_cstm GetByPK(Int32 id_asesor)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_asesor, No_Reg_Met, Nama_Asesor, b.NPSN, b.Nama_Sekolah, c.NamaKabupaten , a.Kode_KK, Nama_KK, Tanggal_Sertifikat_Asesor, a.isDeleted, a.created, a.creator, a.edited, a.editor
FROM [Tb_Data_Asesor] a
left outer join  [Tb_SMK] b on a.NPSN = b.NPSN
left outer join  [Tb_Kabupaten] c on b.Kode_Kabupaten=c.Kode_Kabupaten
left outer join  [Tb_Jejaring] d on a.NPSN = d.NPSN
left outer join  [Tb_Kompetensi_Keahlian] e on a.Kode_KK = e.Kode_KK
WHERE [id_asesor] = @id_asesor";

            context.AddParameter("@id_asesor", id_asesor);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Data_Asesor_cstm>(context, new Tb_Data_Asesor_cstm()).FirstOrDefault();

        }


        /// <summary>
        /// Execute Update to TABLE []
        /// </summary>  
        /// 
        public static Tb_Data_Asesor_cstm Update(Tb_Data_Asesor_cstm obj)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [Tb_Data_Asesor]
SET         [No_Reg_Met] = @No_Reg_Met,
            [Kode_KK] = @Kode_KK,
            [NPSN] = @NPSN,
            [Nama_Asesor] = @Nama_Asesor,
            [Tanggal_Sertifikat_Asesor] = @Tanggal_Sertifikat_Asesor,
            [isDeleted] = @isDeleted,

            [edited] = @edited,
            [editor] = @editor
WHERE   [id_asesor] = @id_asesor

SET @Err = @@Error

SELECT id_asesor, No_Reg_Met, Kode_KK, NPSN, Nama_Asesor, Tanggal_Sertifikat_Asesor, isDeleted, created, creator, edited, editor
FROM [Tb_Data_Asesor]
WHERE [id_asesor] = @id_asesor";
            context.AddParameter("@id_asesor", obj.id_asesor);
            context.AddParameter("@No_Reg_Met", string.Format("{0}", obj.No_Reg_Met));
            context.AddParameter("@Kode_KK", obj.Kode_KK);
            context.AddParameter("@NPSN", obj.NPSN);
            context.AddParameter("@Nama_Asesor", string.Format("{0}", obj.Nama_Asesor));
            context.AddParameter("@Tanggal_Sertifikat_Asesor", obj.Tanggal_Sertifikat_Asesor);
            context.AddParameter("@isDeleted", obj.isDeleted);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));


            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Data_Asesor_cstm>(context, new Tb_Data_Asesor_cstm()).FirstOrDefault();

        }


        public static List<Tb_Data_Asesor_cstm> GetAllByNPSN(Int32 npsn)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_asesor, No_Reg_Met, Nama_Asesor, a.NPSN, b.Nama_Sekolah, c.NamaKabupaten , a.Kode_KK, Nama_KK, Tanggal_Sertifikat_Asesor, a.isDeleted, a.created, a.creator, a.edited, a.editor
FROM [Tb_Data_Asesor] a
left outer join  [Tb_SMK] b on a.NPSN = b.NPSN
left outer join  [Tb_Kabupaten] c on b.Kode_Kabupaten=c.Kode_Kabupaten
left outer join  [Tb_Jejaring] d on a.NPSN = d.NPSN
left outer join  [Tb_Kompetensi_Keahlian] e on a.Kode_KK = e.Kode_KK 
where a.NPSN = @NPSN";

            context.AddParameter("@NPSN", npsn);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Data_Asesor_cstm>(context, new Tb_Data_Asesor_cstm());
        }

    }
}
