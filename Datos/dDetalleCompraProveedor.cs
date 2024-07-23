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
    public class dDetalleCompraProveedor
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CleanFresh"].ConnectionString);

        public DataTable D_listar_compra_proveedor()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_detalle_compra_proveedor", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable D_Reporte_Compra_proveedor()
        {
            SqlCommand cmd = new SqlCommand("sp_reporte_compra_proveedor",cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_listar_detalles_compra_proveedor(string NombreProveedor)
        {
            SqlCommand cmd = new SqlCommand("sp_reporte_detalles_Compra_Proveedor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombreProveedor", NombreProveedor);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_detalle_compra_proveedor_id(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_detalle_comp_proveedor_id", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string D_actualizar_monto_ingreso_proveedor(int id, float monto)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizar_monto_ingreso_proveedor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@monto", monto);
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            return "Monto actualizado";
        }

        public String D_mantenimiento_detalle_compra_proveedor(eDetalleCompraProveedor obje, string accion)
        {
            String mensaje = "";

            SqlCommand cmd = new SqlCommand("sp_mantenimiento_detalle_compra_proveedor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obje.IDCompraProveedor);
            cmd.Parameters.AddWithValue("@id_proveedor", obje.IDProveedor);
            cmd.Parameters.AddWithValue("@fecha", obje.FechaIngreso);
            cmd.Parameters.AddWithValue("@monto", obje.MontoDCP);

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
