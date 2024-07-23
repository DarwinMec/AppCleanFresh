using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eCliente
    {

        private int ID_Cliente;
        private string Nombre_Cliente;
        private int DNI_Cliente;
        private string Distrito_Cliente;
        private string Celular_Cliente;
        private string Correo;

        public int IDCliente
        {
            get { return ID_Cliente; }
            set { ID_Cliente = value; }
        }

        public string NombreCliente
        {
            get { return Nombre_Cliente; }
            set { Nombre_Cliente = value; }
        }
        public int DNICliente
        {
            get { return DNI_Cliente; }
            set { DNI_Cliente = value; }
        }

        public string DistritoCliente
        {
            get { return Distrito_Cliente; }
            set { Distrito_Cliente = value; }
        }

        public string CelularCliente
        {
            get { return Celular_Cliente; }
            set { Celular_Cliente = value; }
        }

        public string CorreoCliente
        {
            get { return Correo; }
            set { Correo = value; }
        }

    }
}
