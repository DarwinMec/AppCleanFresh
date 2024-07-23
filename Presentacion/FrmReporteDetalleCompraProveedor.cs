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
    public partial class FrmReporteDetalleCompraProveedor : Form
    {
        nDetalleCompraProveedor objnComP = new nDetalleCompraProveedor();

        public FrmReporteDetalleCompraProveedor()
        {
            InitializeComponent();
        }

        private void FrmReporteDetalleCompraProveedor_Load(object sender, EventArgs e)
        {
            dgProveedor.DataSource = objnComP.N_Reporte_Compra_proveedor();
            dgProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dgProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgProveedor.CurrentCell.RowIndex;
            string proveedor = dgProveedor[0, fila].Value.ToString();
            txtProveedor.Text = proveedor;
            dgComprasProveedor.DataSource = objnComP.N_listar_detalle_compra_proveedor(proveedor);

            dgComprasProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
