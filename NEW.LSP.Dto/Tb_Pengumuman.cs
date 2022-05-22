using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;

namespace NEW.LSP.Dto
{
    public class Tb_Pengumuman : IDataMapper<Tb_Pengumuman>
    {
        #region Tb_Pengumuman Propeties
        public Int32 id_pengumuman { get; set; }
        public string no { get; set; }
        public DateTime? tanggal { get; set; }
        public DateTime? tanggal_hingga { get; set; }
        public string judul { get; set; }
        public string picture { get; set; }
        public byte[] pictureData { get; set; }
        public string isi { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public string editor { get; set; }
        public DateTime? edited { get; set; }
        #endregion    
        public Tb_Pengumuman Map(System.Data.IDataReader reader)
        {
            Tb_Pengumuman obj = new Tb_Pengumuman();
            obj.id_pengumuman = Convert.ToInt32(reader["id_pengumuman"]);
            obj.no = reader["no"] == DBNull.Value ? null : reader["no"].ToString();
            obj.tanggal = reader["tanggal"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["tanggal"]);
            obj.tanggal_hingga = reader["tanggal_hingga"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["tanggal_hingga"]);
            obj.judul = reader["judul"] == DBNull.Value ? null : reader["judul"].ToString();
            obj.picture = reader["picture"] == DBNull.Value ? null : reader["picture"].ToString();
            obj.pictureData = reader["pictureData"] == DBNull.Value ? (byte[])null : (byte[])reader["pictureData"];
            obj.isi = reader["isi"] == DBNull.Value ? null : reader["isi"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["edited"]);
            return obj;
        }
    }
}
