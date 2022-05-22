
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class Tb_Penerima_Sertifikat : IDataMapper<Tb_Penerima_Sertifikat>
    {
        #region Tb_Penerima_Sertifikat Properties
        public Int32 Kode_Penerima_Sertifikat { get; set; }
        public string Nomer_Lisensi { get; set; }
        public Int32? Kode_KK { get; set; }
        public Int32? IDTahun_pelajaran { get; set; }
        public Int32? Jumlah_penerima_sertifikat { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public Tb_Penerima_Sertifikat Map(System.Data.IDataReader reader)
        {
            Tb_Penerima_Sertifikat obj = new Tb_Penerima_Sertifikat();   
            obj.Kode_Penerima_Sertifikat = Convert.ToInt32(reader["Kode_Penerima_Sertifikat"]);
            obj.Nomer_Lisensi = reader["Nomer_Lisensi"] == DBNull.Value ? null : reader["Nomer_Lisensi"].ToString();
            obj.Kode_KK = reader["Kode_KK"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Kode_KK"]);
            obj.IDTahun_pelajaran = reader["IDTahun_pelajaran"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["IDTahun_pelajaran"]);
            obj.Jumlah_penerima_sertifikat = reader["Jumlah_penerima_sertifikat"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Jumlah_penerima_sertifikat"]);
            obj.isDeleted = reader["isDeleted"] == DBNull.Value ? (bool?) null  : Convert.ToBoolean(reader["isDeleted"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}