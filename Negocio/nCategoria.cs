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
    public class nCategoria
    {
        dCategoria objdCa = new dCategoria();

        public DataTable N_listar_Categoria()
        {
            return objdCa.D_listar_Categoria();
        }

        public DataTable N_buscar_categoria_nombre(string nombre)
        {
            return objdCa.D_buscar_categoria_nombre(nombre);
        }

        public String N_mantenimiento_Categoria(eCategoria obje, string accion)
        {
            return objdCa.D_mantenimiento_Categoria(obje, accion);
        }
    }
}
