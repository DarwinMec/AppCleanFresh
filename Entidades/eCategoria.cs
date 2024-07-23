using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eCategoria
    {
        
        private int ID_Categoria;
        private string Nombre_Categoria;


        public int IDCategoria
        {
            get { return ID_Categoria; }
            set { ID_Categoria = value; }
        }

        public string NombreCategoria
        {
            get { return Nombre_Categoria; }
            set { Nombre_Categoria = value; }
        }

    }
}
