using NEW.LSP.Dta.Custom;
using NEW.LSP.Dto;
using NEW.LSP.Dto.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Logic
{
    public class ChecNPSNKK
    {

        public static bool IsAlreadyNPSNKK(Int32 Kode_Penerima_Sertifikat, string Nomer_Lisensi, Int32 Kode_KK, string aeMode)
        {
            bool status;

            Tb_Penerima_Sertifikat objS = new Tb_Penerima_Sertifikat();
            if (aeMode == "EDIT")
            {
                objS = Tb_Penerima_Sertifikat_cstmItem.GetByLisensiKK(Kode_Penerima_Sertifikat, Nomer_Lisensi, Kode_KK);
            }
            else
            {
                objS = Tb_Penerima_Sertifikat_cstmItem.GetByLisensiKK(Nomer_Lisensi, Kode_KK);
            }


            if (objS != null)
            {
                //Already registered  
                status = false;
            }
            else
            {
                //Available to use  
                status = true;
            }

            return status;
        }
    }
}
