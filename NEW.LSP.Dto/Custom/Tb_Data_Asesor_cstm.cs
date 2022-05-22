using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dto.Custom
{
    public class Tb_Data_Asesor_cstm : IDataMapper<Tb_Data_Asesor_cstm>
    {
        #region Tb_Data_Asesor_cstm Properties
        public Int32? id_asesor { get; set; }
        public string No_Reg_Met { get; set; }
        public Int32? NPSN { get; set; }
        public string Nama_Asesor { get; set; }
        public Int32? Kode_KK { get; set; }
        public DateTime? Tanggal_Sertifikat_Asesor { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        public string Nama_Sekolah { get; set; }
        public string NamaKabupaten { get; set; }
        public string Nama_KK { get; set; }
        #endregion
        public Tb_Data_Asesor_cstm Map(System.Data.IDataReader reader)
        {
            Tb_Data_Asesor_cstm obj = new Tb_Data_Asesor_cstm();
            obj.id_asesor = Convert.ToInt32(reader["id_asesor"]);
            obj.No_Reg_Met = string.Format("{0}", reader["No_Reg_Met"]);
            obj.NPSN = reader["NPSN"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["NPSN"]);
            obj.Nama_Asesor = reader["Nama_Asesor"] == DBNull.Value ? null : reader["Nama_Asesor"].ToString();

            obj.Kode_KK = reader["Kode_KK"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["Kode_KK"]);
            obj.Tanggal_Sertifikat_Asesor = reader["Tanggal_Sertifikat_Asesor"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Tanggal_Sertifikat_Asesor"]);

            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();

            obj.Nama_Sekolah = reader["Nama_Sekolah"] == DBNull.Value ? null : reader["Nama_Sekolah"].ToString();
            obj.NamaKabupaten = reader["NamaKabupaten"] == DBNull.Value ? null : reader["NamaKabupaten"].ToString();
            obj.Nama_KK = reader["Nama_KK"] == DBNull.Value ? null : reader["Nama_KK"].ToString();


            return obj;
        }
    }
}
