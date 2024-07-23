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
    public class nProveedor
    {
        dProveedor objdProv = new dProveedor();

        public DataTable N_listar_proveedor()
        {
            return objdProv.D_listar_proveedor();
        }

        public DataTable N_buscar_proveedor_nombre(string nombre)
        {
            return objdProv.D_buscar_proveedor_nombre(nombre);
        }

        public String N_mantenimiento_proveedor(eProveedor obje, string accion)
        {
            return objdProv.D_mantenimiento_proveedor(obje, accion);
        }
    }
}
