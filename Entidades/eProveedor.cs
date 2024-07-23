using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eProveedor
    {
        
        private int ID_Proveedor;
        private string Nombre_Proveedor;
        private string Celular_Proveedor;
        private string Distrito_Proveedor;


        public int IDProveedor
        {
            get { return ID_Proveedor; }
            set { ID_Proveedor = value; }
        }

        public string NombreProveedor
        {
            get { return Nombre_Proveedor; }
            set { Nombre_Proveedor = value; }
        }
        public string CelularProveedor
        {
            get { return Celular_Proveedor; }
            set { Celular_Proveedor = value; }
        }

        public string DistritoProveedor
        {
            get { return Distrito_Proveedor; }
            set { Distrito_Proveedor = value; }
        }

    }
}
