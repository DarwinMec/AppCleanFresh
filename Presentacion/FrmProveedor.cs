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
    public partial class FrmProveedor : Form
    {
        eProveedor objeProv = new eProveedor();
        nProveedor objnProv = new nProveedor();
        public FrmProveedor()
        {
            InitializeComponent();
        }

        void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtCelular.Clear();
            txtNombre.Focus();
            cbxDistrito.SelectedIndex = -1;

            dgProveedor.DataSource = objnProv.N_listar_proveedor();
        }

        void mantenimiento(String accion)
        {
            objeProv.NombreProveedor = txtNombre.Text;
            objeProv.CelularProveedor = txtCelular.Text;
            objeProv.DistritoProveedor = cbxDistrito.Text;

            String men = objnProv.N_mantenimiento_proveedor(objeProv, accion);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

            if (txtBusqueda.Text != "")
            {
                DataTable dt = new DataTable();
                dt = objnProv.N_buscar_proveedor_nombre(txtBusqueda.Text);
                dgProveedor.DataSource = dt;
            }
            else
            {
                dgProveedor.DataSource = objnProv.N_listar_proveedor();
            }
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            dgProveedor.DataSource = objnProv.N_listar_proveedor();
            dgProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgProveedor.CurrentCell.RowIndex;

            objeProv.IDProveedor = Convert.ToInt32(dgProveedor[0, fila].Value);

            txtID.Text = dgProveedor[0, fila].Value.ToString();
            txtNombre.Text = dgProveedor[1, fila].Value.ToString();
            txtCelular.Text = dgProveedor[2, fila].Value.ToString();
            cbxDistrito.Text = dgProveedor[3, fila].Value.ToString();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            bool solonumero = true;
            if (MessageBox.Show("¿Deseas registrar a " + txtNombre.Text + "?", "Mensaje",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtNombre.Text != "" && txtCelular.Text != "" && cbxDistrito.SelectedIndex != -1)
                {
                    foreach (char caracter in txtCelular.Text.Trim())
                    {
                        if (!char.IsDigit(caracter))
                        {
                            solonumero = false;
                            break;
                        }
                    }
                    if (solonumero)
                    {
                        mantenimiento("1");
                        Limpiar();
                        
                    }
                    else
                    {
                        MessageBox.Show("El celular solo puede contener numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else MessageBox.Show("Por favor complete todos los datos.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool solonumero = true;
            if (MessageBox.Show("¿Deseas modificar a " + txtNombre.Text + "?", "Mensaje",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtNombre.Text != "" && txtCelular.Text != "" && cbxDistrito.SelectedIndex != -1)
                {
                    foreach (char caracter in txtCelular.Text.Trim())
                    {
                        if (!char.IsDigit(caracter))
                        {
                            solonumero = false;
                            break;
                        }
                    }
                    if (solonumero)
                    {
                        mantenimiento("2");
                        Limpiar();

                    }
                    else
                    {
                        MessageBox.Show("El celular solo puede contener numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                }
                else MessageBox.Show("No puede modificar los datos con espacios vacios.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Deseas eliminar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                mantenimiento("3");
                Limpiar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
