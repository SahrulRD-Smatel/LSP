using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dto.Custom
{
    public class Tb_SMK_cstm : IDataMapper<Tb_SMK_cstm>
    {
        #region Tb_SMK_cstm Properties
        public Int32 NPSN { get; set; }
        public Int32? Kode_Kabupaten { get; set; }
        public string Nama_Sekolah { get; set; }
        public string Status_Sekolah { get; set; }
        public string Status_LSP { get; set; }
        public Int32? Kode_KK { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        public string NamaKabupaten { get; set; }
        public string Nama_KK { get; set; }
        #endregion
        public Tb_SMK_cstm Map(System.Data.IDataReader reader)
        {
            Tb_SMK_cstm obj = new Tb_SMK_cstm();
            obj.NPSN = Convert.ToInt32(reader["NPSN"]);
            obj.Kode_Kabupaten = reader["Kode_Kabupaten"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["Kode_Kabupaten"]);
            obj.Nama_Sekolah = reader["Nama_Sekolah"] == DBNull.Value ? null : reader["Nama_Sekolah"].ToString();
            obj.Status_Sekolah = reader["Status_Sekolah"] == DBNull.Value ? null : reader["Status_Sekolah"].ToString();
            obj.Status_LSP = reader["Status_LSP"] == DBNull.Value ? null : reader["Status_LSP"].ToString();
            obj.Kode_KK = reader["Kode_KK"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["Kode_KK"]);
             
            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();

            obj.NamaKabupaten = reader["NamaKabupaten"] == DBNull.Value ? null : reader["NamaKabupaten"].ToString();
            obj.Nama_KK = reader["Nama_KK"] == DBNull.Value ? null : reader["Nama_KK"].ToString();
            return obj;
        }
    }
}
