using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;

namespace NEW.LSP.Dto
{
    public class Tb_Skema : IDataMapper<Tb_Skema>
    {
        #region Tb_Skema Properties

        public Int32 Kode_Skema { get; set; }
        public Int32 Kode_KK { get; set; }
        public string Skema { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion

        public Tb_Skema Map(System.Data.IDataReader reader)
        {
            Tb_Skema obj = new Tb_Skema();
            obj.Kode_Skema = Convert.ToInt32(reader["Kode_Skema"]);
            obj.Kode_KK = Convert.ToInt32(reader["Kode_KK"]);
            obj.Skema = string.Format("{0}", reader["Skema"]);
            obj.isDeleted = reader["isDeleted"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["isDeleted"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();

            return obj;
        }
    }
}