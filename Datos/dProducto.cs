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
    public class dProducto
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CleanFresh"].ConnectionString);

        public DataTable D_listar_producto()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_producto", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_producto_nombre(string nombre)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_producto_nombre", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string D_actualizar_stock_producto(int id_producto, int nueva_cant)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizar_stock_producto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id_producto);
            cmd.Parameters.AddWithValue("@nuevo", nueva_cant);
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            return "Stock actualizado";
        }
        public DataTable D_buscar_producto_categoria(string categoria)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_producto_categoria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@categoria", categoria);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_Listar_Marcas_Productos()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_marcas_productos", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public String D_mantenimiento_producto(eProducto obje, string accion)
        {
            String mensaje = "";

            SqlCommand cmd = new SqlCommand("sp_mantenimiento_producto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obje.IDProducto);
            cmd.Parameters.AddWithValue("@nombre", obje.NombreProducto);
            cmd.Parameters.AddWithValue("@marca", obje.MarcaP);
            cmd.Parameters.AddWithValue("@id_categoria", obje.IDCategoria);
            cmd.Parameters.AddWithValue("@precio", obje.PrecioProducto);
            cmd.Parameters.AddWithValue("@stock_inicial", obje.StockInicial);
            cmd.Parameters.AddWithValue("@stock_actual", obje.StockActual);
            cmd.Parameters.AddWithValue("@stock_repo", obje.StockReposicion);


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
