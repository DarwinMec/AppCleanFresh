using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eDetalleComprobante
    {
        
        private int ID_Venta;
        private int ID_Empleado;
        private int ID_Cliente;
        private DateTime Fecha_Venta;
        private float Monto;

        public int IDVenta
        {
            get { return ID_Venta; }
            set { ID_Venta = value; }
        }
        public int IDEmpleado
        {
            get { return ID_Empleado; }
            set { ID_Empleado = value; }
        }
        public int IDCliente
        {
            get { return ID_Cliente; }
            set { ID_Cliente = value; }
        }
        public DateTime FechaVenta
        {
            get { return Fecha_Venta; }
            set { Fecha_Venta = value; }
        }
        public float MontoDC
        {
            get { return Monto; }
            set { Monto = value; }
        }



    }
}
