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
    public partial class FrmReporteVentasMes : Form
    {
        nDetalleVenta objnDV = new nDetalleVenta();
        public FrmReporteVentasMes()
        {
            InitializeComponent();
        }

        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            dgVentasMes.DataSource = objnDV.N_detalle_ventas_mes((cbxMes.SelectedIndex + 1).ToString());

            if (cbxMes.SelectedIndex != -1)
            {
                 string mes = cbxMes.SelectedItem.ToString();

                 int ProVendidos = 0;
                 DataTable ventames = objnDV.n_venta_del_mes((cbxMes.SelectedIndex + 1).ToString());
                 if (ventames.Rows.Count > 0)
                 {
                     foreach (DataRow row in ventames.Rows)
                     {
                         if (row["CantidadProductos"] != DBNull.Value)
                         {
                             ProVendidos += Convert.ToInt32(row["CantidadProductos"]);
                         }
                     }
                 }

                 txtMes.Text = mes;
                 txtCantidad.Text = ProVendidos.ToString();

            }


        }

        private void FrmReporteVentasMes_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objnDV.N_detalle_ventas_mes(cbxMes.SelectedIndex.ToString());

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbxMes.Items.Add(dt.Rows[i]["Mes"]);
            }
            dgVentasMes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
