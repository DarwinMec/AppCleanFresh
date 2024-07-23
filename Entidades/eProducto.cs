using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eProducto
    {
     

        private int ID_Producto;
        private int ID_Categoria;
        private string Nombre_Producto;
        private string Marca;
        private float Precio_Producto;
        private int Stock_Inicial;
        private int Stock_Actual;
        private int Stock_Reposicion;

        public int IDProducto
        {
            get { return ID_Producto; }
            set { ID_Producto = value; }
        }

        public int IDCategoria
        {
            get { return ID_Categoria; }
            set { ID_Categoria = value; }
        }
        public string NombreProducto
        {
            get { return Nombre_Producto; }
            set { Nombre_Producto = value; }
        }

        public string MarcaP
        {
            get { return Marca; }
            set { Marca = value; }
        }

        public float PrecioProducto
        {
            get { return Precio_Producto; }
            set { Precio_Producto = value; }
        }

        public int StockInicial
        {
            get { return Stock_Inicial; }
            set { Stock_Inicial = value; }
        }
        public int StockActual
        {
            get { return Stock_Actual; }
            set { Stock_Actual = value; }
        }
        public int StockReposicion
        {
            get { return Stock_Reposicion; }
            set { Stock_Reposicion = value; }
        }

    }
}
