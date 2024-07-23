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
    public partial class FrmCategoria : Form
    {
        eCategoria objeCa = new eCategoria();
        nCategoria objnCa = new nCategoria();

        public FrmCategoria()
        {
            InitializeComponent();
        }

        void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
           
            dgCategoria.DataSource = objnCa.N_listar_Categoria();
        }

        void mantenimiento(String accion)
        {
            objeCa.NombreCategoria = txtNombre.Text;

            String men = objnCa.N_mantenimiento_Categoria(objeCa, accion);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != "")
            {
                DataTable dt = new DataTable();
                dt = objnCa.N_buscar_categoria_nombre(txtBusqueda.Text);
                dgCategoria.DataSource = dt;
            }
            else
            {
                dgCategoria.DataSource = objnCa.N_listar_Categoria();
            }
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            dgCategoria.DataSource = objnCa.N_listar_Categoria();
            dgCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgCategoria.CurrentCell.RowIndex;

            objeCa.IDCategoria = Convert.ToInt32(dgCategoria[0, fila].Value);

            txtID.Text = dgCategoria[0, fila].Value.ToString();
            txtNombre.Text = dgCategoria[1, fila].Value.ToString();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            bool sololetras = true;
            if (MessageBox.Show("¿Deseas registrar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtNombre.Text != "")
                {
                    foreach (char caracter in txtNombre.Text.Trim())
                    {
                        if (!char.IsLetter(caracter))
                        {
                            sololetras = false;
                            break;
                        }
                    }
                    if (sololetras)
                    {
                        mantenimiento("1");
                        Limpiar();

                    }
                    else
                    {
                        MessageBox.Show("El nombre solo puede contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else MessageBox.Show("No se puede registrar una categoria en blanco.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool sololetras = true;
            if (MessageBox.Show("¿Deseas modificar a " + txtNombre.Text + "?", "Mensaje",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtNombre.Text != "")
                {
                    foreach (char caracter in txtNombre.Text.Trim())
                    {
                        if (!char.IsLetter(caracter))
                        {
                            sololetras = false;
                            break;
                        }
                    }
                    if (sololetras)
                    {
                        mantenimiento("2");
                        Limpiar();

                    }
                    else
                    {
                        MessageBox.Show("El nombre solo puede contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else MessageBox.Show("No se puede modificar a una categoria en blanco.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas eliminar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtNombre.Text != "")
                {
                    mantenimiento("3");
                    Limpiar();
                }
                else MessageBox.Show("Vuelve a seleccionar los datos.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
