using DataAccessLayer;
using NEW.LSP.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Dta.Custom
{
    public class Tb_Pengumuman_cstmItem
    {
        public static Tb_Pengumuman GetByNo(string no)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_pengumuman, [no], tanggal, tanggal_hingga, judul, picture, pictureData, isi, creator, created, editor, edited FROM Tb_Pengumuman
            WHERE [no]  = @no";
            context.AddParameter("@no", no);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Pengumuman>(context, new Tb_Pengumuman()).FirstOrDefault();
        }

        public static List<Tb_Pengumuman> GetByDateAktif()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_pengumuman, [no], tanggal, tanggal_hingga, judul, picture, pictureData,  isi, creator, created, editor, edited FROM Tb_Pengumuman
            WHERE CONVERT(date, GETDATE()) between CONVERT(date, tanggal) and CONVERT(date, tanggal_hingga) ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Tb_Pengumuman>(context, new Tb_Pengumuman());
        }
    }
}
