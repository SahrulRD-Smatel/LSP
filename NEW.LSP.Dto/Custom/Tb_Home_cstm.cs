using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dto.Custom
{
    public class Tb_Home_cstm : IDataMapper<Tb_Home_cstm>
    {
        public Int32? jmlSMK { get; set; }
        public Int32? jmlAsesor { get; set; }
        public Int32? jmlLSP { get; set; }
        public Int32? jmlKKT { get; set; }
        public Int32? jmlPS { get; set; }
        public string descript { get; set; }
        public Tb_Home_cstm Map(System.Data.IDataReader reader)
        {
            Tb_Home_cstm obj = new Tb_Home_cstm();
            obj.jmlSMK = reader["jmlSMK"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["jmlSMK"]);
            obj.jmlAsesor = reader["jmlAsesor"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["jmlAsesor"]);
            obj.jmlLSP = reader["jmlLSP"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["jmlLSP"]);
            obj.jmlKKT = reader["jmlKKT"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["jmlKKT"]);
            obj.jmlPS = reader["jmlPS"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["jmlPS"]);
            obj.descript = reader["descript"] == DBNull.Value ? null : reader["descript"].ToString();

            return obj;
        }
    }
}
