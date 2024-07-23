using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class FrmVenta : Form
    {
        //1
        eDetalleComprobante eDCompro = new eDetalleComprobante();
        nDetalleComprobante nDCompro = new nDetalleComprobante();

        //2
        eDetalleVenta eDVent= new eDetalleVenta();
        nDetalleVenta nDVent = new nDetalleVenta();
        
        //3
        eProducto eProd = new eProducto();
        nProducto nProd = new nProducto();

        //4
        eCliente eClient = new eCliente();
        nCliente nClient = new nCliente();

        int IDventa;

        public FrmVenta()
        {
            InitializeComponent();
        }


        private void CargarDatos()
        {
            dgCliente.DataSource = nClient.N_listar_cliente();
            dgCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgProducto.DataSource = nProd.N_listar_producto();
            dgProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgDetalleVenta.DataSource = nDVent.N_listar_detalle_venta_id_venta(IDventa);
            dgDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgCliente.ClearSelection();
            dgProducto.ClearSelection();
            dgDetalleVenta.ClearSelection();

            btnRealizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            DataTable tablacomprobantes = new DataTable();
            tablacomprobantes = nDCompro.N_listar_detalle_comprobante();
            
            int filas = tablacomprobantes.Rows.Count;
            
            IDventa = 1000 + filas;
            txtIDVenta.Text = IDventa.ToString();

            CargarDatos();
        }

        void mantenimientoCompra(String accion)
        {
            eDCompro.IDVenta = IDventa;
            eDCompro.IDEmpleado = nEmpleado.id_empleado;
            
            eDCompro.FechaVenta = dtpFecha.Value;
            eDCompro.MontoDC = 0;

            String men = nDCompro.N_mantenimiento_detalle_comprobante(eDCompro, accion);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void mantenimientoDetalleVenta(String accion)
        {
            
            eDVent.IDVenta = IDventa;
           
            eDVent.CantidadP = Convert.ToInt32(nudCantidad.Value);
         
            String men = nDVent.N_mantenimiento_detalle_venta(eDVent, accion);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarProducto.Text != "")
            {
                DataTable dt = new DataTable();
                dt = nProd.N_buscar_producto_nombre(txtBuscarProducto.Text);
                dgProducto.DataSource = dt;
            }
            else
            {
                dgProducto.DataSource = nProd.N_listar_producto();
            }
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarCliente.Text != "")
            {
                DataTable dt = new DataTable();
                dt = nClient.N_buscar_cliente_nombre(txtBuscarCliente.Text);
                dgCliente.DataSource = dt;
            }
            else
            {
                dgCliente.DataSource = nClient.N_listar_cliente();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgCliente.CurrentCell.Selected == true && dgProducto.CurrentCell.Selected == true)
            {
                if (Convert.ToInt32(nudCantidad.Value) != 0)
                {

                    if (eProd.StockActual - Convert.ToInt32(nudCantidad.Value) >= eProd.StockReposicion)
                    {
                       
                        int existecomprobante = nDCompro.N_buscar_detalle_comprobante_id(IDventa).Rows.Count;
                        if (existecomprobante == 0)
                        {
                            if (MessageBox.Show("¿Deseas crear un comprobante con ID: " + IDventa.ToString() + " ?", "Mensaje",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                            {
                                mantenimientoCompra("1");
                            }
                        }
                        existecomprobante = nDCompro.N_buscar_detalle_comprobante_id(IDventa).Rows.Count;
                        if (existecomprobante == 1)
                        {
                            float submonto;
                            submonto = (float)Convert.ToInt32(nudCantidad.Value) * eDVent.PrecioP;
                            eDVent.SubtotalP = submonto;

                            
                            nProd.N_actualizar_stock_producto(eProd.IDProducto, Convert.ToInt32(nudCantidad.Value) * -1);
                           
                            dgProducto.DataSource = nProd.N_listar_producto();
                            if (MessageBox.Show("¿Deseas agregar " + nudCantidad.Value.ToString() + " " + eProd.NombreProducto + " a la lista de venta?", "Mensaje",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                            {
                                mantenimientoDetalleVenta("1");
                              
                                DataTable dt = new DataTable();
                                dt = nDVent.N_listar_detalle_venta_id_venta(IDventa);
                                float montototal = 0;
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    montototal = montototal + Convert.ToInt32(dt.Rows[i]["Subtotal"]);
                                }
                                nDCompro.N_actualizar_monto_venta(IDventa, montototal);
                                txtMonto.Text = montototal.ToString();
                              
                                dgDetalleVenta.DataSource = nDVent.N_listar_detalle_venta_id_venta(IDventa);
                                dgDetalleVenta.ClearSelection();
                                btnRealizar.Enabled = true;
                                btnEliminar.Enabled = true;
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("No hay suficiente cantidad de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad valida", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Seleccione el cliente y/o producto.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgDetalleVenta.CurrentCell.Selected == true)
            {
                int fila = dgDetalleVenta.CurrentCell.RowIndex;
                string nombreproducto = dgDetalleVenta[3, fila].Value.ToString();
             
                if (MessageBox.Show("¿Deseas eliminar el producto a vender " + nombreproducto + " ?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    
                    nProd.N_actualizar_stock_producto(eDVent.IDProducto, eDVent.CantidadP);

                    mantenimientoDetalleVenta("2");
               
                    dgDetalleVenta.DataSource = nDVent.N_listar_detalle_venta_id_venta(IDventa);
                
                    dgProducto.DataSource = nProd.N_listar_producto();

                }
            }
            else MessageBox.Show("Seleccione el producto a eliminar.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRealizar_Click(object sender, EventArgs e)
        {

            if (dgDetalleVenta.RowCount != 0)
            {
                 
                FrmMetodoPago metodo = new FrmMetodoPago(IDventa);
                metodo.ShowDialog();

                
                DataTable tablacomprobantes = new DataTable();
                tablacomprobantes = nDCompro.N_listar_detalle_comprobante();
                int filas = tablacomprobantes.Rows.Count;
                IDventa = 1000 + filas;
                txtIDVenta.Text = IDventa.ToString();
                txtMonto.Text = "0";

                eDCompro = null;
                eDCompro = new eDetalleComprobante();
                eDVent = null;
                eDVent = new eDetalleVenta();
                eProd = null;
                eProd = new eProducto();
                eClient = null;
                eClient = new eCliente();
                CargarDatos();
            }
            else MessageBox.Show("No hay ningun producto agregado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            int existecomprobante = nDCompro.N_buscar_detalle_comprobante_id(IDventa).Rows.Count;
            if (existecomprobante == 1)
            {
                
                DataTable tabladetallesventa = new DataTable();
                tabladetallesventa = nDVent.N_listar_detalle_venta_id_venta(IDventa);
                for (int i = 0; i < tabladetallesventa.Rows.Count; i++)
                {
                    nProd.N_actualizar_stock_producto(Convert.ToInt32(tabladetallesventa.Rows[i]["ID_Producto"]), Convert.ToInt32(tabladetallesventa.Rows[i]["Cantidad"]));
                }

                nDVent.N_eliminar_detalle_venta(IDventa);
                mantenimientoCompra("2");
            }
            Close();
        }

        private void dgCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgCliente.CurrentCell.RowIndex;
            eDCompro.IDCliente = Convert.ToInt32(dgCliente[0, fila].Value);
        }

        private void dgProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgProducto.CurrentCell.RowIndex;
            eDVent.IDProducto = Convert.ToInt32(dgProducto[0, fila].Value);
            eDVent.PrecioP = (float)Convert.ToDouble(dgProducto[4, fila].Value);


            eProd.IDProducto = Convert.ToInt32(dgProducto[0, fila].Value);
            eProd.NombreProducto = dgProducto[1, fila].Value.ToString();
            eProd.StockActual = Convert.ToInt32(dgProducto[6, fila].Value);
            eProd.StockReposicion = Convert.ToInt32(dgProducto[7, fila].Value);
        }

        private void dgDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgDetalleVenta.CurrentCell.RowIndex;
            eDVent.IDDetalleVenta = Convert.ToInt32(dgDetalleVenta[0, fila].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
