using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dto.Custom
{
    public class Tb_Jejaring_cstm : IDataMapper<Tb_Jejaring_cstm>
    {
        #region Tb_Jejaring_cstm Properties
        public Int32 Kode_Jejaring { get; set; }
        public string Nomer_Lisensi { get; set; }
        public Int32 Kode_KK_Terlisensi { get; set; }
        public Int32 NPSN { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }

        public string Nama_KK { get; set; }
        public string Nama_Sekolah { get; set; }
        public string NamaKabupaten { get; set; }
        public string NPSNJ { get; set; }
        public string Nama_SekolahJ { get; set; }
        public string NamaKabupatenJ { get; set; }
        #endregion
        public Tb_Jejaring_cstm Map(System.Data.IDataReader reader)
        {
            Tb_Jejaring_cstm obj = new Tb_Jejaring_cstm();
            obj.Kode_Jejaring = Convert.ToInt32(reader["Kode_Jejaring"]);
            obj.Nomer_Lisensi = string.Format("{0}", reader["Nomer_Lisensi"]);
            obj.Kode_KK_Terlisensi = Convert.ToInt32(reader["Kode_KK_Terlisensi"]);
            obj.NPSN = reader["NPSN"] == DBNull.Value ? 0 : Convert.ToInt32(reader["NPSN"]);

            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();

            obj.Nama_KK = reader["Nama_KK"] == DBNull.Value ? null : reader["Nama_KK"].ToString();
            obj.Nama_Sekolah = reader["Nama_Sekolah"] == DBNull.Value ? null : reader["Nama_Sekolah"].ToString();
            obj.NamaKabupaten = reader["NamaKabupaten"] == DBNull.Value ? null : reader["NamaKabupaten"].ToString();
            obj.NPSNJ = reader["NPSNJ"] == DBNull.Value ? null : reader["NPSNJ"].ToString();
            obj.Nama_SekolahJ = reader["Nama_SekolahJ"] == DBNull.Value ? null : reader["Nama_SekolahJ"].ToString();
            obj.NamaKabupatenJ = reader["NamaKabupatenJ"] == DBNull.Value ? null : reader["NamaKabupatenJ"].ToString();

            return obj;
        }
    }
}
