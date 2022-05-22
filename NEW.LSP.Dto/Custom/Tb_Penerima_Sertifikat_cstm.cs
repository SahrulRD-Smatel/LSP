using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dto.Custom
{
   public class Tb_Penerima_Sertifikat_cstm : IDataMapper<Tb_Penerima_Sertifikat_cstm>
    {
        #region Tb_Penerima_Sertifikat_cstm Properties
        public Int32 Kode_Penerima_Sertifikat { get; set; }
        public string Nomer_Lisensi { get; set; }
        public Int32 Kode_KK { get; set; }
        public Int32? Kode_Skema { get; set; }
        public Int32? IDTahun_pelajaran { get; set; }
        public Int32? Jumlah_penerima_sertifikat { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }

        public string Tahun_pelajaran { get; set; }
        public Int32? NPSN { get; set; }
        public string Nama_KK { get; set; }
        public string Nama_Sekolah { get; set; }
        public string NamaKabupaten { get; set; }
        public string Skema { get; set; }

        #endregion
        public Tb_Penerima_Sertifikat_cstm Map(System.Data.IDataReader reader)
        {
            Tb_Penerima_Sertifikat_cstm obj = new Tb_Penerima_Sertifikat_cstm();
            obj.Kode_Penerima_Sertifikat = Convert.ToInt32(reader["Kode_Penerima_Sertifikat"]);
            obj.Nomer_Lisensi = string.Format("{0}", reader["Nomer_Lisensi"]);
            obj.Kode_KK = Convert.ToInt32(reader["Kode_KK"]);
            obj.IDTahun_pelajaran = reader["IDTahun_pelajaran"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["IDTahun_pelajaran"]);
            obj.Jumlah_penerima_sertifikat = reader["Jumlah_penerima_sertifikat"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["Jumlah_penerima_sertifikat"]);
             
            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();

            obj.Tahun_pelajaran = reader["Tahun_pelajaran"] == DBNull.Value ? null : reader["Tahun_pelajaran"].ToString();
            obj.Nama_KK = reader["Nama_KK"] == DBNull.Value ? null : reader["Nama_KK"].ToString();
            obj.Nama_Sekolah = reader["Nama_Sekolah"] == DBNull.Value ? null : reader["Nama_Sekolah"].ToString();
            obj.NamaKabupaten = reader["NamaKabupaten"] == DBNull.Value ? null : reader["NamaKabupaten"].ToString();
            obj.NPSN = reader["NPSN"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["NPSN"]);
            obj.Kode_Skema = reader["Kode_Skema"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["Kode_Skema"]);
            obj.Skema = reader["Skema"] == DBNull.Value ? null : reader["Skema"].ToString();

            return obj;
        }
    }
}
