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
    public class nAbastecimientoProductos
    {
        dAbastecimientoProductos objdAProd = new dAbastecimientoProductos();

        public DataTable N_listar_Abastecimiento_producto(int id_comp_proveedor)
        {
            return objdAProd.D_listar_Abastecimiento_producto(id_comp_proveedor);
        }
        public string N_eliminar_Abastecimiento_producto(int id_comp_proveedor)
        {
            return objdAProd.D_eliminar_Abastecimiento_producto(id_comp_proveedor);
        }
        public String N_mantenimiento_Abastecimiento_producto(eAbastecimientoProductos obje, string accion)
        {
            return objdAProd.D_mantenimiento_Abastecimiento_producto(obje, accion);
        }
    }
}
