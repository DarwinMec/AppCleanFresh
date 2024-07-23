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
    public class nDetalleVenta
    {
        dDetalleVenta objdDV = new dDetalleVenta();

        public DataTable N_listar_detalle_venta_id_venta(int ID_VENTA)
        {
            return objdDV.D_listar_detalle_venta_id_venta(ID_VENTA);
        }
        public DataTable N_datos_boleta(int id_venta)
        {
            return objdDV.D_datos_boleta(id_venta);
        }
        public DataTable N_reporte_detalles_ventas_un_distrito(string distrito)
        {

            return objdDV.D_reporte_detalles_ventas_un_distrito(distrito);
        }
        public DataTable n_venta_del_mes(string mes)
        {
            return objdDV.D_venta_del_mes(mes);
        }

        public DataTable N_detalle_ventas_mes(string mes)
        {

            return objdDV.D_detalle_ventas_mes(mes);
        }
        public DataTable N_reporte_ventas_distritos()
        {

            return objdDV.D_reporte_ventas_distritos();
        }
        public DataTable N_reporte_productos_vendidos_categoria(string categoria)
        {

            return objdDV.D_reporte_productos_vendidos_categoria(categoria);
        }
        public DataTable N_reporte_productos_vendidos_marca(string marca)
        {
            return objdDV.D_reporte_productos_vendidos_marca(marca);
        }

        public string N_eliminar_detalle_venta(int id_venta)
        {
            return objdDV.D_eliminar_detalle_venta(id_venta);
        }
        public String N_mantenimiento_detalle_venta(eDetalleVenta obje, string accion)
        {
            return objdDV.D_mantenimiento_detalle_venta(obje, accion);
        }

    }
}
