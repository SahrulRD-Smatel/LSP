using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dto.Custom
{
    public class Tb_LSP_cstm : IDataMapper<Tb_LSP_cstm>
    {
        #region Tb_LSP_cstm Properties
        public string Nomer_Lisensi { get; set; }
        public Int32? NPSN { get; set; }
        public string Status_LSP { get; set; }
        public DateTime? Berlaku_Sampai { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        public string Nama_Sekolah { get; set; }
        public string NamaKabupaten { get; set; }
        public string Username { get; set; }

        #endregion
        public Tb_LSP_cstm Map(System.Data.IDataReader reader)
        {
            Tb_LSP_cstm obj = new Tb_LSP_cstm();
            obj.Nomer_Lisensi = string.Format("{0}", reader["Nomer_Lisensi"]);
            obj.NPSN = reader["NPSN"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["NPSN"]);
            obj.Status_LSP = reader["Status_LSP"] == DBNull.Value ? null : reader["Status_LSP"].ToString();
            obj.Berlaku_Sampai = reader["Berlaku_Sampai"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Berlaku_Sampai"]);
             
            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();

            obj.Nama_Sekolah = reader["Nama_Sekolah"] == DBNull.Value ? null : reader["Nama_Sekolah"].ToString();
            obj.NamaKabupaten = reader["NamaKabupaten"] == DBNull.Value ? null : reader["NamaKabupaten"].ToString();
            obj.Username = string.Format("{0}", reader["Username"]);

            return obj;
        }
    }
}
