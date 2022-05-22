using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NEW.LSP.Logic
{
    public class dropDownGenerate
    {
        public static SelectList toSelectCustom(Dictionary<string, string> tmp)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "", Value = "" });

            foreach (var s in tmp)
            {
                list.Add(new SelectListItem()
                {
                    Text = s.Value,
                    Value = s.Key
                });
            }
            return new SelectList(list, "Value", "Text");
        }
    }
}
