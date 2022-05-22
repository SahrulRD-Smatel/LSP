using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dto.Custom
{
    public class Tb_Kompetensi_Keahlian_Terlisensi_cstm : IDataMapper<Tb_Kompetensi_Keahlian_Terlisensi_cstm>
    {
        #region Tb_Kompetensi_Keahlian_Terlisensi_cstm Properties
        public Int32 Kode_KK_Terlisensi { get; set; }
        public string Nomer_Lisensi { get; set; }
        public Int32 Kode_KK { get; set; }
        public Int32 Kode_Skema { get; set; }
        public string Status_KK_Terlisensi { get; set; }
        public Int32? Jumlah_asesor { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        public Int32? NPSN { get; set; }
        public string Nama_KK { get; set; }
        public string Nama_Sekolah { get; set; }
        public string NamaKabupaten { get; set; }
        public string Skema { get; set; }
        #endregion
        public Tb_Kompetensi_Keahlian_Terlisensi_cstm Map(System.Data.IDataReader reader)
        {
            Tb_Kompetensi_Keahlian_Terlisensi_cstm obj = new Tb_Kompetensi_Keahlian_Terlisensi_cstm();
            obj.Kode_KK_Terlisensi = Convert.ToInt32(reader["Kode_KK_Terlisensi"]);
            obj.Nomer_Lisensi = string.Format("{0}", reader["Nomer_Lisensi"]);
            obj.Kode_KK = Convert.ToInt32(reader["Kode_KK"]);
            obj.Status_KK_Terlisensi = reader["Status_KK_Terlisensi"] == DBNull.Value ? null : reader["Status_KK_Terlisensi"].ToString();
            obj.Jumlah_asesor = reader["Jumlah_asesor"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["Jumlah_asesor"]);
             
            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();

            obj.NPSN = reader["NPSN"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["NPSN"]);
            obj.Nama_KK = reader["Nama_KK"] == DBNull.Value ? null : reader["Nama_KK"].ToString();
            obj.Nama_Sekolah = reader["Nama_Sekolah"] == DBNull.Value ? null : reader["Nama_Sekolah"].ToString();
            obj.NamaKabupaten = reader["NamaKabupaten"] == DBNull.Value ? null : reader["NamaKabupaten"].ToString();
            obj.Kode_Skema = Convert.ToInt32(reader["Kode_Skema"]);
            obj.Skema = reader["Skema"] == DBNull.Value ? null : reader["Skema"].ToString();

            return obj;
        }
    }
}
