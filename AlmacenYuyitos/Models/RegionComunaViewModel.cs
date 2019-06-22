using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace AlmacenYuyitos.Models
{
    public class RegionComunaViewModel
    {
        public IEnumerable<SelectListItem> GetRegiones()
        {
            var data = new YuyitosModel();
            return data.REGION.Select(x => new SelectListItem
            {
                Text = x.NOMBRE,
                Value = x.REGIONID.ToString()
            }).ToList();
        }


        public IEnumerable<SelectListItem> GetComunas(int REGIONID)
        {
            var data = new YuyitosModel();
            return data.COMUNA.Where(x => x.REGIONID == REGIONID).OrderBy(x => x.NOMBRE).Select(x => new SelectListItem
            {
                Text = x.NOMBRE,
                Value = x.COMUNAID.ToString()
            }).ToList();
        }


    }
}