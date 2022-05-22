using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;

namespace NEW.LSP.Dto
{
    public class Tb_Data_Asesor : IDataMapper<Tb_Data_Asesor>
    {
        #region Tb_Data_Asesor Properties
        public Int32? id_asesor { get; set; }
        public string No_Reg_Met { get; set; }
        public Int32? Kode_KK { get; set; }
        public Int32? NPSN { get; set; }
        public string Nama_Asesor { get; set; }
        public DateTime? Tanggal_Sertifikat_Asesor { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }

        #endregion  
        public Tb_Data_Asesor Map(System.Data.IDataReader reader)
        {
            Tb_Data_Asesor obj = new Tb_Data_Asesor();
            obj.id_asesor = Convert.ToInt32(reader["id_asesor"]);
            obj.No_Reg_Met = string.Format("{0}", reader["No_Reg_Met"]);
            obj.Kode_KK = reader["Kode_KK"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["Kode_KK"]);
            obj.NPSN = reader["NPSN"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["NPSN"]);
            obj.Nama_Asesor = reader["Nama_Asesor"] == DBNull.Value ? null : reader["Nama_Asesor"].ToString();


            obj.Tanggal_Sertifikat_Asesor = reader["Tanggal_Sertifikat_Asesor"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Tanggal_Sertifikat_Asesor"]);
            obj.isDeleted = reader["isDeleted"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["isDeleted"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}
