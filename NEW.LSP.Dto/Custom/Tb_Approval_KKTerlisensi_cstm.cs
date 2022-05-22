using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dto.Custom
{
    public class Tb_Approval_KKTerlisensi_cstm : IDataMapper<Tb_Approval_KKTerlisensi_cstm>
    {
        #region Tb_Approval_KKTerlisensi_cstm Properties
        public Int32? NPSN { get; set; }
        public Int32 id_app { get; set; }
        public Int32? Kode_KK_Terlisensi { get; set; }
        public string NamaKabupaten { get; set; }
        public string Nama_KK { get; set; }
        public string Nama_Sekolah { get; set; }
        public string Status_KK_Terlisensi { get; set; }
        public Int32? Jumlah_asesor { get; set; }
        public bool? Status { get; set; }
        public string Name { get; set; }
        #endregion    
        public Tb_Approval_KKTerlisensi_cstm Map(System.Data.IDataReader reader)
        {
            Tb_Approval_KKTerlisensi_cstm obj = new Tb_Approval_KKTerlisensi_cstm();
            obj.NPSN = reader["NPSN"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["NPSN"]);
            obj.id_app = Convert.ToInt32(reader["id_app"]);
            obj.Kode_KK_Terlisensi = reader["Kode_KK_Terlisensi"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["Kode_KK_Terlisensi"]);
            obj.NamaKabupaten = reader["NamaKabupaten"] == DBNull.Value ? null : reader["NamaKabupaten"].ToString();
            obj.Nama_KK = reader["Nama_KK"] == DBNull.Value ? null : reader["Nama_KK"].ToString();
            obj.Nama_Sekolah = reader["Nama_Sekolah"] == DBNull.Value ? null : reader["Nama_Sekolah"].ToString();
            obj.Status_KK_Terlisensi = reader["Status_KK_Terlisensi"] == DBNull.Value ? null : reader["Status_KK_Terlisensi"].ToString();
            obj.Jumlah_asesor = reader["Jumlah_asesor"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["Jumlah_asesor"]);
            obj.Status = reader["Status"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["Status"]);
            obj.Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString();

            return obj;
        }
    }
}
