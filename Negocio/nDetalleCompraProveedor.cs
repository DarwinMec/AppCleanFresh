using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;
using System.Xml;

namespace Negocio
{
    public class nDetalleCompraProveedor
    {
        dDetalleCompraProveedor objdDCompra = new dDetalleCompraProveedor();

        public DataTable N_listar_compra_proveedor()
        {
            return objdDCompra.D_listar_compra_proveedor();
        }

        public DataTable N_Reporte_Compra_proveedor()
        {
            return objdDCompra.D_Reporte_Compra_proveedor();
        }

        public DataTable N_listar_detalle_compra_proveedor(string NombreP)
        {
            return objdDCompra.D_listar_detalles_compra_proveedor(NombreP);
        }

        public DataTable N_buscar_detalle_compra_proveedor_id(int id)
        {
            return objdDCompra.D_buscar_detalle_compra_proveedor_id(id);
        }
        public string N_actualizar_monto_ingreso_proveedor(int id, float monto)
        {
            return objdDCompra.D_actualizar_monto_ingreso_proveedor(id, monto);
        }
        public String N_mantenimiento_detalle_compra_proveedor(eDetalleCompraProveedor obje, string accion)
        {
            return objdDCompra.D_mantenimiento_detalle_compra_proveedor(obje, accion);
        }
    }
}
