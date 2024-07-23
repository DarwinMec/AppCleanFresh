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
    public partial class FrmReporteDetalleVentasMarca : Form
    {

        nProducto objnP = new nProducto();

        nDetalleVenta objnDV = new nDetalleVenta();


        public FrmReporteDetalleVentasMarca()
        {
            InitializeComponent();
        }

        private void FrmReporteDetalleVentasMarca_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objnP.N_listar_marcas_productos();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbxMarca.Items.Add(dt.Rows[i]["Marca"]);
            }
        }

        private void cbxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgVentas.DataSource = objnDV.N_reporte_productos_vendidos_marca(cbxMarca.Text);
            dgVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
