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
    public class dDetalleVenta
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CleanFresh"].ConnectionString);

        public DataTable D_listar_detalle_venta_id_venta(int id_venta)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_Detalle_venta_id_venta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_VENTA", id_venta);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable D_datos_boleta(int id_venta)
        {
            SqlCommand cmd = new SqlCommand("sp_Datos_boleta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_VENTA", id_venta);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string D_eliminar_detalle_venta(int id_venta)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar_Detalle_venta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_venta", id_venta);
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            return "Venta cancelada";
        }
        public DataTable D_reporte_productos_vendidos_categoria(string categoria)
        {
            SqlCommand cmd = new SqlCommand("sp_reporte_productos_categoria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@categoria", categoria);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_reporte_productos_vendidos_marca(string marca)
        {
            SqlCommand cmd = new SqlCommand("sp_reporte_detalles_ventas_marca", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MarcaProducto", marca);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable D_reporte_detalles_ventas_un_distrito(string distrito)
        {
            SqlCommand cmd = new SqlCommand("sp_reporte_detalles_ventas_distrito", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@distrito", distrito);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_venta_del_mes(string mes)
        {
            SqlCommand cmd = new SqlCommand("sp_venta_del_mes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mes", mes);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable D_detalle_ventas_mes(string mes)
        {
            SqlCommand cmd = new SqlCommand("sp_detalle_ventas_mes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mes", mes);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable D_reporte_ventas_distritos()
        {
            SqlCommand cmd = new SqlCommand("sp_reporte_ventas_distritos", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public String D_mantenimiento_detalle_venta(eDetalleVenta obje, string accion)
        {
            String mensaje = "";

            SqlCommand cmd = new SqlCommand("sp_mantenimiento_Detalle_venta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obje.IDDetalleVenta);
            cmd.Parameters.AddWithValue("@id_venta", obje.IDVenta);
            cmd.Parameters.AddWithValue("@id_producto", obje.IDProducto);
            cmd.Parameters.AddWithValue("@cantidad", obje.CantidadP);
            cmd.Parameters.AddWithValue("@precio", obje.PrecioP);
            cmd.Parameters.AddWithValue("@subtotal", obje.SubtotalP);

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
