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
    public class dProveedor
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CleanFresh"].ConnectionString);

        public DataTable D_listar_proveedor()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_proveedor", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_proveedor_nombre(string nombre)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_proveedor_nombre", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public String D_mantenimiento_proveedor(eProveedor obje, string accion)
        {
            String mensaje = "";

            SqlCommand cmd = new SqlCommand("sp_mantenimiento_proveedor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obje.IDProveedor);
            cmd.Parameters.AddWithValue("@nombre", obje.NombreProveedor);
            cmd.Parameters.AddWithValue("@celular", obje.CelularProveedor);
            cmd.Parameters.AddWithValue("@distrito", obje.DistritoProveedor);

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
