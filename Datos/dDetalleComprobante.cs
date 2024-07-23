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
    public class dDetalleComprobante
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CleanFresh"].ConnectionString);

        public DataTable D_listar_detalle_comprobante()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_Detalle_comprobante", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_detalle_comprobante_id(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_detalle_comprobante_id", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string D_actualizar_monto_venta(int id, float monto)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizar_monto_venta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@monto", monto);
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            return "Monto actualizado";
        }

        public String D_mantenimiento_detalle_comprobante(eDetalleComprobante obje, string accion)
        {
            String mensaje = "";

            SqlCommand cmd = new SqlCommand("sp_mantenimiento_Detalle_comprobante", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obje.IDVenta);
            cmd.Parameters.AddWithValue("@id_empleado", obje.IDEmpleado);
            cmd.Parameters.AddWithValue("@id_cliente", obje.IDCliente);
            cmd.Parameters.AddWithValue("@fecha", obje.FechaVenta);
            cmd.Parameters.AddWithValue("@monto", obje.MontoDC);


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
