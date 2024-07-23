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
    public partial class FrmReporteProductoCategoria : Form
    {
        nCategoria objnCat = new nCategoria();
        nDetalleVenta objnDVen = new nDetalleVenta();
        public FrmReporteProductoCategoria()
        {
            InitializeComponent();
        }

        private void FrmReporteProductoCategoria_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objnCat.N_listar_Categoria();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbxCategoria.Items.Add(dt.Rows[i]["Nombre_Categoria"]);
            }
        }

        private void cbxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgProductos.DataSource = objnDVen.N_reporte_productos_vendidos_categoria(cbxCategoria.Text);
            dgProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
