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
    public partial class FrmBoleta : Form
    {
        eDetalleComprobante eDCompro = new eDetalleComprobante();
        nDetalleComprobante nDCompro = new nDetalleComprobante();

        eDetalleVenta eDVent = new eDetalleVenta();
        nDetalleVenta nDVent = new nDetalleVenta();

        eCliente eClient = new eCliente();
        nCliente nClient = new nCliente();

        int IDventa;
        public FrmBoleta(int id_venta)
        {
            InitializeComponent();
            IDventa = id_venta;
        }

        private void FrmBoleta_Load(object sender, EventArgs e)
        {
            dgBoleta.DataSource = nDVent.N_datos_boleta(IDventa);

            DataTable dt = new DataTable();
            dt = nDCompro.N_buscar_detalle_comprobante_id(IDventa);
            dgBoleta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtMonto.Text = dt.Rows[0]["Monto"].ToString();
            txtFecha.Text = dt.Rows[0]["Fecha_Venta"].ToString();
            txtIDventa.Text = IDventa.ToString();


            int id_cliente = Convert.ToInt32(dt.Rows[0]["ID_Cliente"]);
            DataTable Cliente = new DataTable();
            Cliente = nDCompro.N_buscar_detalle_comprobante_id(IDventa);
            Cliente = nClient.N_buscar_cliente_ID(id_cliente);
            txtNombre.Text = Cliente.Rows[0]["Nombre_Cliente"].ToString();
            txtDNI.Text = Cliente.Rows[0]["DNI_Cliente"].ToString();


        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
