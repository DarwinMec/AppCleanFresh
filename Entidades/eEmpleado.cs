using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eEmpleado
    {
        
        private int ID_Empleado;
        private string Nombre_Empleado;
        private string Contraseña;

        public int IDEmpleado
        {
            get { return ID_Empleado; }
            set { ID_Empleado = value; }
        }

        public string NombreEmpleado
        {
            get { return Nombre_Empleado; }
            set { Nombre_Empleado = value; }
        }

        public string ContraseñaE
        {
            get { return Contraseña; }
            set { Contraseña = value; }
        }
    }
}
