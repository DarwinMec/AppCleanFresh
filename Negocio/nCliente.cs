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
    public class nCliente
    {
        dCliente objdC = new dCliente();

        public DataTable N_listar_cliente()
        {
            return objdC.D_listar_cliente();
        }
        public DataTable N_buscar_cliente_ID(int id_cliente)
        {
            return objdC.D_buscar_cliente_ID(id_cliente);
        }
        public DataTable N_buscar_cliente_nombre(string nombre)
        {
            return objdC.D_buscar_cliente_nombre(nombre);
        }

        public String N_mantenimiento_cliente(eCliente obje, string accion)
        {
            return objdC.D_mantenimiento_cliente(obje, accion);
        }
    }
}
