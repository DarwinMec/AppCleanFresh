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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmCliente fcliente = new FrmCliente();
            fcliente.ShowDialog();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            FrmProducto fproducto = new FrmProducto();
            fproducto.ShowDialog();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            FrmProveedor fproveedor = new FrmProveedor();
            fproveedor.ShowDialog();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FrmCategoria fcategoria = new FrmCategoria();
            fcategoria.ShowDialog();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            FrmAbastecimientoProductos fabastecimiento = new FrmAbastecimientoProductos();
            fabastecimiento.ShowDialog();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            FrmVenta fventa = new FrmVenta();
            fventa.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmReporteDetalleCompraProveedor fReportDeProveedor = new FrmReporteDetalleCompraProveedor();
            fReportDeProveedor.ShowDialog();

        }

        private void btnReporte2_Click(object sender, EventArgs e)
        {
            FrmReporteDetalleVentasDistrito fReportDVDistrito = new FrmReporteDetalleVentasDistrito();
            fReportDVDistrito.ShowDialog();
        }

        private void btnReporte3_Click(object sender, EventArgs e)
        {
            FrmReporteProductoCategoria fReportPCategoria = new FrmReporteProductoCategoria();
            fReportPCategoria.ShowDialog();
        }

        private void btnReporte4_Click(object sender, EventArgs e)
        {
            FrmReporteDetalleVentasMarca fReportVMarca = new FrmReporteDetalleVentasMarca();
            fReportVMarca.ShowDialog();
        }

        private void btnReporte5_Click(object sender, EventArgs e)
        {
            FrmReporteVentasMes fReportVMes = new FrmReporteVentasMes();
            fReportVMes.ShowDialog();
        }
    }
}
