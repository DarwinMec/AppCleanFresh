using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;

namespace Negocio
{
    public class nDetalleComprobante
    {
        dDetalleComprobante objdDCompro = new dDetalleComprobante();

        public DataTable N_listar_detalle_comprobante()
        {
            return objdDCompro.D_listar_detalle_comprobante();
        }

        public DataTable N_buscar_detalle_comprobante_id(int id)
        {
            return objdDCompro.D_buscar_detalle_comprobante_id(id);
        }
        public string N_actualizar_monto_venta(int id, float monto)
        {
            return objdDCompro.D_actualizar_monto_venta(id, monto);
        }
        public String N_mantenimiento_detalle_comprobante(eDetalleComprobante obje, string accion)
        {
            return objdDCompro.D_mantenimiento_detalle_comprobante(obje, accion);
        }
    }
}
