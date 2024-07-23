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
    public partial class FrmMetodoPago : Form
    {
        nDetalleComprobante nDCompro= new nDetalleComprobante();
        int IDventa;
        public FrmMetodoPago(int id_venta)
        {
            InitializeComponent();
            IDventa = id_venta;
        }

        private void FrmMetodoPago_Load(object sender, EventArgs e)
        {
            DataTable comprobante = new DataTable();
            comprobante = nDCompro.N_buscar_detalle_comprobante_id(IDventa);
            txtMonto.Text = comprobante.Rows[0]["Monto"].ToString();

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (cbxMetodo.Text != "")
            {
                if (cbxMetodo.Text == "Efectivo")
                {
                    FrmBoleta boleta = new FrmBoleta(IDventa);
                    boleta.ShowDialog();
                    Close();
                }
                if (cbxMetodo.Text == "Tarjeta de Credito")
                {
                    FrmTarjeta tarjeta = new FrmTarjeta(IDventa);
                    tarjeta.ShowDialog();
                    Close();
                }

            }
            else MessageBox.Show("Elija un metodo de pago", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
