using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmTarjeta : Form
    {
        int IDventa;
        public FrmTarjeta(int id_venta)
        {
            InitializeComponent();
            IDventa = id_venta;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (txtNumT.Text != "" && txtMes.Text != "" && txtYear.Text != "" && txtTitular.Text != "" && txtCVC.Text != "")
            {
                FrmBoleta boleta = new FrmBoleta(IDventa);
                boleta.ShowDialog();
                Close();
            }
            else MessageBox.Show("Rellene todos los datos necesarios de la tarjeta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
