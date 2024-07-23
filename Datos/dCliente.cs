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
    public class dCliente
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CleanFresh"].ConnectionString);

        public DataTable D_listar_cliente()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_cliente", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_cliente_nombre(string nombre)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_cliente_nombre", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable D_buscar_cliente_ID(int id_cliente)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_cliente_ID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id_cliente);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public String D_mantenimiento_cliente(eCliente obje, string accion)
        {
            String mensaje = "";

            SqlCommand cmd = new SqlCommand("sp_mantenimiento_cliente", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obje.IDCliente);
            cmd.Parameters.AddWithValue("@nombre", obje.NombreCliente);
            cmd.Parameters.AddWithValue("@DNI", obje.DNICliente);
            cmd.Parameters.AddWithValue("@distrito", obje.DistritoCliente);
            cmd.Parameters.AddWithValue("@celular", obje.CelularCliente);
            cmd.Parameters.AddWithValue("@correo", obje.CorreoCliente);

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
