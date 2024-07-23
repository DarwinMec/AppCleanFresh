using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class dCategoria
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CleanFresh"].ConnectionString);
        public DataTable D_listar_Categoria()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_categoria", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_categoria_nombre(string nombre)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_categoria_nombre", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public String D_mantenimiento_Categoria(eCategoria obje, string accion)
        {
            String mensaje = "";

            SqlCommand cmd = new SqlCommand("sp_mantenimiento_categoria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obje.IDCategoria);
            cmd.Parameters.AddWithValue("@nombre", obje.NombreCategoria);

            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;


            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            mensaje = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return mensaje;
        }
    }
}
