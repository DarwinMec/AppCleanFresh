using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eDetalleVenta
    {
        
        private int ID_DetalleVenta;
        private int ID_Venta;
        private int ID_Producto;
        private int Cantidad;
        private float Precio;
        private float Subtotal;

        public int IDDetalleVenta
        {
            get { return ID_DetalleVenta; }
            set { ID_DetalleVenta = value; }
        }

        public int IDVenta
        {
            get { return ID_Venta; }
            set { ID_Venta = value; }
        }

        public int IDProducto
        {
            get { return ID_Producto; }
            set { ID_Producto = value; }
        }

        public int CantidadP
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }

        public float PrecioP
        {
            get { return Precio; }
            set { Precio = value; }
        }

        public float SubtotalP
        {
            get { return Subtotal; }
            set { Subtotal = value; }
        }



    }
}
