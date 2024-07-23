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
    public partial class FrmProducto : Form
    {
        eProducto objeProd = new eProducto();
        nProducto objnProd = new nProducto();

        eCategoria objeCa = new eCategoria();
        nCategoria objnCa = new nCategoria();

        public FrmProducto()
        {
            InitializeComponent();
        }

        void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtNombre.Focus();
            txtMarca.Clear();
            txtPrecio.Clear();
            nudStockI.Value = 0;
            nudStockR.Value = 0;
            cbxCategoria.SelectedIndex = -1;

            dgProducto.DataSource = objnProd.N_listar_producto();
        }

        void mantenimiento(String accion)
        {

            objeProd.NombreProducto = txtNombre.Text;
            objeProd.MarcaP = txtMarca.Text;

            DataTable dt = new DataTable();
            dt = objnCa.N_buscar_categoria_nombre(cbxCategoria.Text);
            int id_categoria = Convert.ToInt32(dt.Rows[0]["ID_Categoria"]);


            objeProd.IDCategoria = id_categoria;
            objeProd.PrecioProducto = (float)Convert.ToDouble(txtPrecio.Text);
            objeProd.StockInicial = Convert.ToInt32(nudStockI.Text);
            objeProd.StockActual = Convert.ToInt32(nudStockI.Text);
            objeProd.StockReposicion = Convert.ToInt32(nudStockR.Text);

            String men = objnProd.N_mantenimiento_producto(objeProd, accion);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != "")
            {
                DataTable dt = new DataTable();
                dt = objnProd.N_buscar_producto_nombre(txtBusqueda.Text);
                dgProducto.DataSource = dt;
            }
            else
            {
                dgProducto.DataSource = objnProd.N_listar_producto();
            }
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            dgProducto.DataSource = objnProd.N_listar_producto();
            dgProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataTable dt = new DataTable();
            dt = objnCa.N_listar_Categoria();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbxCategoria.Items.Add(dt.Rows[i]["Nombre_Categoria"]);
            }
        }

        private void dgProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgProducto.CurrentCell.RowIndex;

            objeProd.IDProducto = Convert.ToInt32(dgProducto[0, fila].Value);

            txtID.Text = dgProducto[0, fila].Value.ToString();
            txtNombre.Text = dgProducto[1, fila].Value.ToString();
            txtMarca.Text = dgProducto[2, fila].Value.ToString();
            cbxCategoria.Text = dgProducto[3, fila].Value.ToString();
            txtPrecio.Text = dgProducto[4, fila].Value.ToString();
            nudStockI.Value = Convert.ToInt32(dgProducto[5, fila].Value);
            nudStockR.Value = Convert.ToInt32(dgProducto[7, fila].Value);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            bool solonumerocoma = true;
            if (MessageBox.Show("¿Deseas registrar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtNombre.Text != "" && txtMarca.Text != "" && txtPrecio.Text != "" && cbxCategoria.SelectedIndex != -1)
                {
                    
                    foreach (char caracter in txtPrecio.Text.Trim())
                    {
                        if (!char.IsDigit(caracter) && caracter!=',')
                        {
                            solonumerocoma = false;
                            break;
                        }
                    }
                    if (solonumerocoma)
                    {
                        mantenimiento("1");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("El precio tiene caracteres invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show("Por favor complete todos los datos.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool solonumerocoma = true;
            if (MessageBox.Show("¿Deseas modificar a " + txtNombre.Text + "?", "Mensaje",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtNombre.Text != "" && txtMarca.Text != "" && txtPrecio.Text != "" && cbxCategoria.SelectedIndex != -1)
                {
                    
                    foreach (char caracter in txtPrecio.Text.Trim())
                    {
                        if (!char.IsDigit(caracter) && caracter != ',')
                        {
                            solonumerocoma = false;
                            break;
                        }
                    }
                    if (solonumerocoma)
                    {
                        mantenimiento("2");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("El precio tiene caracteres invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else MessageBox.Show("No puede modificar los datos con espacios vacios.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool solonumerocoma = true;
            if (MessageBox.Show("¿Deseas eliminar a " + txtNombre.Text + "?", "Mensaje",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtNombre.Text != "" && txtMarca.Text != "" && txtPrecio.Text != "" && cbxCategoria.SelectedIndex != -1)
                {
                    
                    foreach (char caracter in txtPrecio.Text.Trim())
                    {
                        if (!char.IsDigit(caracter) && caracter != ',')
                        {
                            solonumerocoma = false;
                            break;
                        }
                    }
                    if (solonumerocoma)
                    {
                        mantenimiento("3");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("El precio tiene caracteres invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show("Vuelve a seleccionar los datos.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
