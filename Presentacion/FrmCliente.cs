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
    public partial class FrmCliente : Form
    {
        eCliente objeC = new eCliente();
        nCliente objnC = new nCliente();

        public FrmCliente()
        {
            InitializeComponent();
        }

        void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
            txtCelular.Clear();
            txtCorreo.Clear();
            txtNombre.Focus();
            cbxDistrito.SelectedIndex = -1;

            dgCliente.DataSource = objnC.N_listar_cliente();
        }

        void mantenimiento(String accion)
        {
            objeC.NombreCliente= txtNombre.Text;
            objeC.DNICliente = Convert.ToInt32(txtDNI.Text);
            objeC.DistritoCliente = cbxDistrito.Text;
            objeC.CelularCliente = txtCelular.Text;
            objeC.CorreoCliente = txtCorreo.Text;

            String men = objnC.N_mantenimiento_cliente(objeC, accion);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != "")
            {
                DataTable dt = new DataTable();
                dt = objnC.N_buscar_cliente_nombre(txtBusqueda.Text);
                dgCliente.DataSource = dt;
            }
            else
            {
                dgCliente.DataSource = objnC.N_listar_cliente();
            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            dgCliente.DataSource = objnC.N_listar_cliente();

            dgCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dgCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgCliente.CurrentCell.RowIndex;

            objeC.IDCliente = Convert.ToInt32(dgCliente[0, fila].Value);

            txtID.Text = dgCliente[0, fila].Value.ToString();
            txtNombre.Text = dgCliente[1, fila].Value.ToString();
            txtDNI.Text = dgCliente[2, fila].Value.ToString();
            cbxDistrito.Text = dgCliente[3, fila].Value.ToString();
            txtCelular.Text = dgCliente[4, fila].Value.ToString();
            txtCorreo.Text = dgCliente[5, fila].Value.ToString();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            bool contienenumero = false;
            bool dniletra = false;
            if (MessageBox.Show("¿Deseas registrar a " + txtNombre.Text + "?", "Mensaje",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtNombre.Text != "" && txtDNI.Text != ""  && txtCelular.Text != "" && txtCorreo.Text != "" && cbxDistrito.SelectedIndex != -1)
                {
                    
                    foreach (char caracter in txtNombre.Text.Trim())
                    {
                        if (char.IsDigit(caracter))
                        {
                            contienenumero = true;
                            break;
                        }
                    }
                    
                    foreach (char caracter in txtDNI.Text.Trim())
                    {
                        if (!char.IsDigit(caracter))
                        {
                            dniletra = true;
                            break;
                        }
                    }
                    if (contienenumero)
                    {
                        MessageBox.Show("El nombre no puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        
                        if (dniletra)
                        {
                            MessageBox.Show("El dni solo puede contener numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            mantenimiento("1");
                            Limpiar();
                        }
                    }

                }
                else MessageBox.Show("Por favor complete todos los datos.","Atencion", MessageBoxButtons.OK ,MessageBoxIcon.Information);

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool contienenumero = false;
            bool dniletra = false;
            if (MessageBox.Show("¿Deseas modificar a " + txtNombre.Text + "?", "Mensaje",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtNombre.Text != "" && txtDNI.Text != "" && txtCelular.Text != "" && txtCorreo.Text != "" && cbxDistrito.SelectedIndex != -1)
                {
                   
                    foreach (char caracter in txtNombre.Text.Trim())
                    {
                        if (char.IsDigit(caracter))
                        {
                            contienenumero = true;
                            break;
                        }
                    }
                    
                    foreach (char caracter in txtDNI.Text.Trim())
                    {
                        if (!char.IsDigit(caracter))
                        {
                            dniletra = true;
                            break;
                        }
                    }
                    if (contienenumero)
                    {
                        MessageBox.Show("El nombre no puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        
                        if (dniletra)
                        {
                            MessageBox.Show("El dni solo puede contener numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            mantenimiento("2");
                            Limpiar();
                        }
                    }

                }
                else MessageBox.Show("No puede modificar los datos con espacios vacios.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool dniletra = false;
            if (MessageBox.Show("¿Deseas eliminar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtNombre.Text != "" && txtDNI.Text != "" && txtCelular.Text != "" && txtCorreo.Text != "" && cbxDistrito.SelectedIndex != -1)
                {
                    
                    foreach (char caracter in txtDNI.Text.Trim())
                    {
                        if (!char.IsDigit(caracter))
                        {
                            dniletra = true;
                            break;
                        }
                    }
                    
                    if (dniletra)
                    {
                        MessageBox.Show("El dni solo puede contener numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        mantenimiento("3");
                        Limpiar();
                    }
                }
                else MessageBox.Show("Vuelve a seleccionar los datos.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }
    }
}
