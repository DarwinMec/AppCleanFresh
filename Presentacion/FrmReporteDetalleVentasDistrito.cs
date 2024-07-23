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
    public partial class FrmReporteDetalleVentasDistrito : Form
    {
        nDetalleVenta objnDV = new nDetalleVenta();

        public FrmReporteDetalleVentasDistrito()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmReporteVentasDistrito_Load(object sender, EventArgs e)
        {
            dgDistritos.DataSource = objnDV.N_reporte_ventas_distritos();
            dgDistritos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgDistritos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgDistritos.CurrentCell.RowIndex;

            string distrito = dgDistritos[0, fila].Value.ToString();
            txtDistrito.Text = distrito;
            dgVentasDistrito.DataSource = objnDV.N_reporte_detalles_ventas_un_distrito(distrito);
            dgVentasDistrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
       
        }

        private void dgVentasDistrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
    }
}
