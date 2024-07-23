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
    public class dAbastecimientoProductos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CleanFresh"].ConnectionString);

        public DataTable D_listar_Abastecimiento_producto(int id_comp_proveedor)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_Abastecimiento_producto_id_compra_proveedor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_compraProveedor", id_comp_proveedor);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string D_eliminar_Abastecimiento_producto(int id_comprobante)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar_Abastecimiento_producto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_comprobante", id_comprobante);
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            return "Ingreso de productos cancelado";
        }

        public String D_mantenimiento_Abastecimiento_producto(eAbastecimientoProductos obje, string accion)
        {
            String mensaje = "";

            SqlCommand cmd = new SqlCommand("sp_mantenimiento_Abastecimiento_producto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obje.IDIngresoProductos);
            cmd.Parameters.AddWithValue("@id_compraProveedor", obje.IDCompraProveedor);
            cmd.Parameters.AddWithValue("@id_producto", obje.IDProducto);
            cmd.Parameters.AddWithValue("@cantidad", obje.CantidadProducto);
            cmd.Parameters.AddWithValue("@subtotal", obje.SubtotalMonto);

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
