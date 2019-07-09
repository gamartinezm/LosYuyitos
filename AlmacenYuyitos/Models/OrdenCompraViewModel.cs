using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace AlmacenYuyitos.Models
{
    public class OrdenCompraViewModel
    {
        public IEnumerable<SelectListItem> GetProveedor()
        {
            var data = new YuyitosModel();
            return data.PROVEEDOR.Select(x => new SelectListItem
            {
                Text = x.RAZONSOCIAL,
                Value = x.PROVEEDORID.ToString()
            }).ToList();
        }


        public IEnumerable<SelectListItem> GetOrdenPedido(int PROVEEDORID)
        {
            var data = new YuyitosModel();
            return data.ORDENPEDIDO.Where(x => x.PROVEEDOR_PROVEEDORID == PROVEEDORID).OrderBy(x => x.ORDENPEDIDOID).Select(x => new SelectListItem
            {
                Text = x.ORDENPEDIDOID.ToString(),
                Value = x.PROVEEDOR_PROVEEDORID.ToString()
            }).ToList();
        }

        //public IEnumerable<SelectListItem> GetDetallePedido(int ORDENPEDIDOID)
        //{
        //    var data = new YuyitosModel();
        //    return data.DETALLEPEDIDO.Where(x => x.ORDENPEDIDO_ORDENPEDIDOID == ORDENPEDIDOID).OrderBy(x => x.ORDENPEDIDO_ORDENPEDIDOID).Select(x => new SelectListItem
        //    {
        //        Text = x.ORDENPEDIDO_ORDENPEDIDOID.ToString(),
        //        Value = x.ORDENPEDIDO_ORDENPEDIDOID.ToString()
        //    }).ToList();
        //}
    }
}