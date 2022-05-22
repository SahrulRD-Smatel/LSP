using DataAccessLayer;
using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.Linq;


namespace NEW.LSP.Dta.Custom
{
    public class Tb_Penerima_Sertifikat_cstmItem
    {
        public static List<Tb_Penerima_Sertifikat_cstm> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT a.Kode_Penerima_Sertifikat
                  ,a.[Nomer_Lisensi]
                  ,a.[Kode_KK] 	  
	              ,c.Nama_KK
				  ,g.Kode_Skema
				  ,g.Skema
                  ,b.NPSN
	              ,d.Nama_Sekolah
	              ,e.NamaKabupaten
                  ,a.IDTahun_pelajaran
                  ,f.Tahun_pelajaran
                  ,a.Jumlah_penerima_sertifikat ,a.created, a.creator, a.edited, a.editor
              FROM  Tb_Penerima_Sertifikat a      
			  left outer join  [Tb_LSP] b on a.Nomer_Lisensi= b.Nomer_Lisensi
			  left outer join  [Tb_Kompetensi_Keahlian] c on a.Kode_KK = c.Kode_KK
			  left outer join  [Tb_SMK] d on b.NPSN = d.NPSN
			  left outer join  [Tb_Kabupaten] e on d.Kode_Kabupaten = e.Kode_Kabupaten
			  left outer join  [Tb_Tahun_Pelajaran] f on a.IDTahun_pelajaran = f.ID
			  left outer join  [Tb_Skema] g on a.Kode_KK = g.Kode_KK";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Penerima_Sertifikat_cstm>(context, new Tb_Penerima_Sertifikat_cstm());
        }

        public static Tb_Penerima_Sertifikat_cstm GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @" SELECT a.Kode_Penerima_Sertifikat
                  ,a.[Nomer_Lisensi]
                  ,a.[Kode_KK] 	  
	              ,c.Nama_KK
                  ,g.Kode_Skema
				  ,g.Skema
                  ,b.NPSN
	              ,d.Nama_Sekolah
	              ,e.NamaKabupaten
                  ,a.IDTahun_pelajaran
                  ,f.Tahun_pelajaran
                  ,a.Jumlah_penerima_sertifikat ,a.created, a.creator, a.edited, a.editor
              FROM  Tb_Penerima_Sertifikat a      
			  left outer join  [Tb_LSP] b on a.Nomer_Lisensi= b.Nomer_Lisensi
			  left outer join  [Tb_Kompetensi_Keahlian] c on a.Kode_KK = c.Kode_KK
			  left outer join  [Tb_SMK] d on b.NPSN = d.NPSN
			  left outer join  [Tb_Kabupaten] e on d.Kode_Kabupaten = e.Kode_Kabupaten
			  left outer join  [Tb_Tahun_Pelajaran] f on a.IDTahun_pelajaran = f.ID
              left outer join  [Tb_Skema] g on a.Kode_KK = g.Kode_KK
			   where a.Kode_Penerima_Sertifikat  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Penerima_Sertifikat_cstm>(context, new Tb_Penerima_Sertifikat_cstm()).FirstOrDefault();
        }

        public static List<Tb_Penerima_Sertifikat_cstm> GetAllByNPSN(Int32 npsn)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"select a.Kode_Penerima_Sertifikat, a.Nomer_Lisensi, a.Kode_KK, a.IDTahun_pelajaran, e.Tahun_pelajaran, a.Jumlah_penerima_sertifikat, a.created, a.creator, a.edited, a.editor, Nama_KK, d.Nama_Sekolah,ee.NamaKabupaten,c.NPSN
                             from [Tb_Penerima_Sertifikat] a
                             left outer join Tb_Kompetensi_Keahlian b on a.Kode_KK = b.Kode_KK
							 left outer join Tb_LSP c on c.Nomer_Lisensi = a.Nomer_Lisensi
							 left outer join Tb_SMK d on d.NPSN = c.NPSN 
                             left outer join Tb_Tahun_Pelajaran e on a.IDTahun_pelajaran = e.id
                             left outer join  [Tb_Kabupaten] ee on d.Kode_Kabupaten = ee.Kode_Kabupaten    
                             left outer join  [Tb_Skema] g on a.Kode_KK = g.Kode_KK
                            where c.NPSN = @NPSN";
            context.AddParameter("@NPSN", npsn);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Penerima_Sertifikat_cstm>(context, new Tb_Penerima_Sertifikat_cstm());
        }

    }
}
