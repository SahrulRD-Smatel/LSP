
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace NEW.LSP.Dto
{
    public class Tb_Kabupaten : IDataMapper<Tb_Kabupaten>
    {
        #region Tb_Kabupaten Properties
        public Int32 Kode_Kabupaten { get; set; }
        public string NamaKabupaten { get; set; }
        public string IbuKotaKabupaten { get; set; }
        #endregion    
        public Tb_Kabupaten Map(System.Data.IDataReader reader)
        {
            Tb_Kabupaten obj = new Tb_Kabupaten();   
            obj.Kode_Kabupaten = Convert.ToInt32(reader["Kode_Kabupaten"]);
            obj.NamaKabupaten = reader["NamaKabupaten"] == DBNull.Value ? null : reader["NamaKabupaten"].ToString();
            obj.IbuKotaKabupaten = reader["IbuKotaKabupaten"] == DBNull.Value ? null : reader["IbuKotaKabupaten"].ToString();
            return obj;
        }
    }
}