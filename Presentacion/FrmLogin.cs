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
    public partial class FrmLogin : Form
    {
        nEmpleado objnE = new nEmpleado();
        public FrmLogin()
        {
            InitializeComponent();
        }

        void Limpiar()
        {
            txtContraseña.Clear();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objnE.N_listar_empleado();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbxID.Items.Add(dt.Rows[i]["ID_Empleado"]);
            }
        }

        private void cbxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objnE.N_buscar_empleado_id(Convert.ToInt32(cbxID.Text));
            txtNombre.Text = dt.Rows[0]["Nombre_Empleado"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbxID.SelectedIndex != -1 && txtNombre.Text != "" && txtContraseña.Text != "")
            {
                DataTable dt = new DataTable();
                dt = objnE.N_buscar_empleado_id(Convert.ToInt32(cbxID.Text));
                nEmpleado.id_empleado = Convert.ToInt32(dt.Rows[0]["ID_Empleado"]);
                if (txtContraseña.Text == dt.Rows[0]["Contraseña"].ToString())
                {
                    FrmMenu menu = new FrmMenu();
                    this.Visible = false;
                    menu.ShowDialog();
                    this.Visible = true;
                    Limpiar();
                }
                else
                    MessageBox.Show("Contraseña incorrecta, intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Complete los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
