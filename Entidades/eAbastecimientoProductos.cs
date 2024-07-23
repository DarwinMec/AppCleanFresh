using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eAbastecimientoProductos
    {
        
        private int ID_IngresoProductos;
        private int ID_CompraProveedor;
        private int ID_Producto;
        private int Cantidad_Producto;
        private float Subtotal_Monto;

        public int IDIngresoProductos
        {
            get { return ID_IngresoProductos; }
            set { ID_IngresoProductos = value; }
        }

        public int IDCompraProveedor
        {
            get { return ID_CompraProveedor; }
            set { ID_CompraProveedor = value; }
        }
        public int IDProducto
        {
            get { return ID_Producto; }
            set { ID_Producto = value; }
        }

        public int CantidadProducto
        {
            get { return Cantidad_Producto; }
            set { Cantidad_Producto = value; }
        }

        public float SubtotalMonto
        {
            get { return Subtotal_Monto; }
            set { Subtotal_Monto = value; }
        }

    }
}
