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
    public class nEmpleado
    {
        dEmpleado objdE = new dEmpleado();
        public static int id_empleado { get; set; }
        public DataTable N_listar_empleado()
        {
            return objdE.D_listar_empleado();
        }

        public DataTable N_buscar_empleado_id(int id)
        {
            return objdE.sp_buscar_empleado_id(id);
        }
        public DataTable N_listar_empleado_reporte()
        {

            return objdE.D_listar_empleado_reporte();
        }
        public String N_mantenimiento_empleado(eEmpleado obje, string accion)
        {
            return objdE.D_mantenimiento_empleado(obje, accion);
        }
    }
}
