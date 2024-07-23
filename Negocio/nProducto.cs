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
    public class nProducto
    {
        dProducto objdP = new dProducto();

        public DataTable N_listar_producto()
        {
            return objdP.D_listar_producto();
        }

        public DataTable N_buscar_producto_nombre(string nombre)
        {
            return objdP.D_buscar_producto_nombre(nombre);
        }
        public string N_actualizar_stock_producto(int id_producto, int nueva_cant)
        {
            return objdP.D_actualizar_stock_producto(id_producto, nueva_cant);
        }
        public DataTable N_buscar_producto_categoria(string categoria)
        {
            return objdP.D_buscar_producto_categoria(categoria);
        }
        public String N_mantenimiento_producto(eProducto obje, string accion)
        {
            return objdP.D_mantenimiento_producto(obje, accion);
        }
        public DataTable N_listar_marcas_productos()
        {
            return objdP.D_Listar_Marcas_Productos();
        }
    }
}
