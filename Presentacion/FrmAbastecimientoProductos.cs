using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class FrmAbastecimientoProductos : Form
    {
        // 1
        eDetalleCompraProveedor eDCompra = new eDetalleCompraProveedor();
        nDetalleCompraProveedor nDCompra = new nDetalleCompraProveedor();

        // 2
        eAbastecimientoProductos eAProd = new eAbastecimientoProductos();
        nAbastecimientoProductos nAProd = new nAbastecimientoProductos();

        // 3
        eProducto eProdu = new eProducto();
        nProducto nProdu = new nProducto();

        // 4
        eProveedor eProve = new eProveedor();
        nProveedor nProve = new nProveedor();

        int IDComprobante;

        public FrmAbastecimientoProductos()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CargarDatos()
        {
            dgProveedor.DataSource = nProve.N_listar_proveedor();
            dgProducto.DataSource = nProdu.N_listar_producto();
            dgAbastecimientoProductos.DataSource = nAProd.N_listar_Abastecimiento_producto(IDComprobante);

            dgProveedor.ClearSelection();
            dgProducto.ClearSelection();
            dgAbastecimientoProductos.ClearSelection();
            btnEliminar.Enabled = false;
            btnFinalizar.Enabled = false;
        }

        void mantenimientoCompra(String accion)
        {
            eDCompra.IDCompraProveedor = IDComprobante;
            
            eDCompra.FechaIngreso = dtpFecha.Value;
            eDCompra.MontoDCP = 0;

            String men = nDCompra.N_mantenimiento_detalle_compra_proveedor(eDCompra, accion);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void mantenimientoAbaste(String accion)
        {
            
            eAProd.IDCompraProveedor = IDComprobante;
          
            eAProd.CantidadProducto= Convert.ToInt32(nudCantidad.Value);
           

            String men = nAProd.N_mantenimiento_Abastecimiento_producto(eAProd, accion);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBuscarProveedor_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarProveedor.Text != "")
            {
                DataTable dt = new DataTable();
                dt = nProve.N_buscar_proveedor_nombre(txtBuscarProveedor.Text);
                dgProveedor.DataSource = dt;
            }
            else
            {
                dgProveedor.DataSource = nProve.N_listar_proveedor();
            }
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarProducto.Text != "")
            {
                DataTable dt = new DataTable();
                dt = nProdu.N_buscar_producto_nombre(txtBuscarProducto.Text);
                dgProducto.DataSource = dt;
            }
            else
            {
                dgProducto.DataSource = nProdu.N_listar_producto();
            }
        }

        private void FrmAbastecimientoProductos_Load(object sender, EventArgs e)
        {
            DataTable tablacomprobantes = new DataTable();
            tablacomprobantes = nDCompra.N_listar_compra_proveedor();
            dgProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int filas = tablacomprobantes.Rows.Count;
            IDComprobante = 1000 + filas;
            txtIDComprobante.Text = IDComprobante.ToString();

            CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgProveedor.CurrentCell.Selected == true && dgProducto.CurrentCell.Selected == true)
            {
                if (Convert.ToInt32(nudCantidad.Value) != 0)
                {
                    
                    int existecomprobante = nDCompra.N_buscar_detalle_compra_proveedor_id(IDComprobante).Rows.Count;
                    if (existecomprobante == 0)
                    {
                        if (MessageBox.Show("¿Deseas crear un comprobante con ID: " + IDComprobante.ToString() + " ?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                        {
                            mantenimientoCompra("1");
                        }
                    }
                    if (existecomprobante == 1)
                    {
                        float submonto;
                        submonto = (float)(Convert.ToDouble(nudCantidad.Value) * eProdu.PrecioProducto);
                        eAProd.SubtotalMonto = submonto;


                        if (MessageBox.Show("¿Deseas agregar " + nudCantidad.Value.ToString() + " " + eProdu.NombreProducto + " a la lista?", "Mensaje",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                        {
                            mantenimientoAbaste("1");
                           
                            DataTable dt = new DataTable();
                            dt = nAProd.N_listar_Abastecimiento_producto(IDComprobante);
                            float montototal = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                montototal = montototal + (float)Convert.ToDouble(dt.Rows[i]["Subtotal_monto"]);
                            }
                            nDCompra.N_actualizar_monto_ingreso_proveedor(IDComprobante, montototal);
                            txtMonto.Text = montototal.ToString();
                            
                            dgAbastecimientoProductos.DataSource = nAProd.N_listar_Abastecimiento_producto(IDComprobante);
                            dgAbastecimientoProductos.ClearSelection();
                            btnEliminar.Enabled = true;
                            btnFinalizar.Enabled = true;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad valida", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Seleccione el proveedor y/o producto.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            
            DataTable tablaingresos = new DataTable();
            tablaingresos = nAProd.N_listar_Abastecimiento_producto(IDComprobante);

            if (tablaingresos.Rows.Count != 0)
            {
                for (int i = 0; i < tablaingresos.Rows.Count; i++)
                {
                    int cantidad = Convert.ToInt32(tablaingresos.Rows[i]["Cantidad_Producto"]);
                    int id_producto = Convert.ToInt32(tablaingresos.Rows[i]["ID_Producto"]);
                    nProdu.N_actualizar_stock_producto(id_producto, cantidad);
                }

                DataTable tablacomprobantes = new DataTable();
                tablacomprobantes = nDCompra.N_listar_compra_proveedor();
                int filas = tablacomprobantes.Rows.Count;
                IDComprobante = 1000 + filas;
                txtIDComprobante.Text = IDComprobante.ToString();
                txtMonto.Text = "0";


                eDCompra = null;
                eDCompra = new eDetalleCompraProveedor();
                eAProd = null;
                eAProd = new eAbastecimientoProductos();
                eProdu = null;
                eProdu = new eProducto();
                eProve = null;
                eProve = new eProveedor();
                CargarDatos();
            }
            else MessageBox.Show("No hay ningun producto agregado.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgAbastecimientoProductos.CurrentCell.Selected == true)
            {
                int fila = dgAbastecimientoProductos.CurrentCell.RowIndex;
                string nombreproducto = dgAbastecimientoProductos[3, fila].Value.ToString();
                
                if (MessageBox.Show("¿Deseas eliminar el producto a ingresar " + nombreproducto + " ?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimientoAbaste("2");
                    
                    dgAbastecimientoProductos.DataSource = nAProd.N_listar_Abastecimiento_producto(IDComprobante);
                }
            }
            else MessageBox.Show("Seleccione el producto a eliminar.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            int existecomprobante = nDCompra.N_buscar_detalle_compra_proveedor_id(IDComprobante).Rows.Count;
            if (existecomprobante == 1)
            {
                nAProd.N_eliminar_Abastecimiento_producto(IDComprobante);
                mantenimientoCompra("2");
            }
            Close();
        }

        private void dgProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgProveedor.CurrentCell.RowIndex;
            eDCompra.IDProveedor = Convert.ToInt32(dgProveedor[0, fila].Value);
        }

        private void dgProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgProducto.CurrentCell.RowIndex;
            eAProd.IDProducto = Convert.ToInt32(dgProducto[0, fila].Value);
            eProdu.NombreProducto = dgProducto[1, fila].Value.ToString();

            eProdu.PrecioProducto = (float)Convert.ToDouble(dgProducto[4, fila].Value);
        }

        private void dgAbastecimientoProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgAbastecimientoProductos.CurrentCell.RowIndex;
            eAProd.IDIngresoProductos = Convert.ToInt32(dgAbastecimientoProductos[0, fila].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          
        }

        private void dgAbastecimientoProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }



}
