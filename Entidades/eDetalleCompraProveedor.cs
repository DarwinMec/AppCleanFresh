using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eDetalleCompraProveedor
    {
       
        private int ID_CompraProveedor;
        private int ID_Proveedor;
        private DateTime Fecha_Ingreso;
        private int Monto;

        public int IDCompraProveedor
        {
            get { return ID_CompraProveedor; }
            set { ID_CompraProveedor = value; }
        }

        public int IDProveedor
        {
            get { return ID_Proveedor; }
            set { ID_Proveedor = value; }
        }

        public DateTime FechaIngreso
        {
            get { return Fecha_Ingreso; }
            set { Fecha_Ingreso = value; }
        }

        public int MontoDCP
        {
            get { return Monto; }
            set { Monto = value; }
        }


    }
}
