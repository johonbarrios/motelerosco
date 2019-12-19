


namespace motelerosco.LOGIN
{
    using System;
    using System.Windows.Forms;
    using CADmotelerosco;
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                errorProvider1.SetError(txtUsuario, "Debe ingresar un usuario");
                txtUsuario.Focus();
                return;
            }
            errorProvider1.SetError(txtUsuario, "");

            if (txtClave.Text == "")
            {
                errorProvider1.SetError(txtClave, "Debe ingresar una clave");
                txtClave.Focus();
                return;
            }
            errorProvider1.SetError(txtClave, "");



            if (CADusuario.ValidarUsuario(txtUsuario.Text, txtClave.Text))
            {
                frmFecha miFormm = new frmFecha();
                miFormm.UsuarioLogueado = CADusuario.ConsultarRegistroUsuario(txtUsuario.Text);
                miFormm.ClaveUsuario = txtUsuario.Text;
                miFormm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o clave no admitida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Text = "";
                txtClave.Text = "";
                txtUsuario.Focus();
                return;
            }
            errorProvider1.SetError(txtClave, "");
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Aberiguar si existe un usuario predeterminado asingnado
            // -------------------------------------------------------
            //Informacion del cliente
            CADrecordarme miRecuerdo = CADrecordarme.GetRecordarmeID(1);

            if (miRecuerdo.Estado == "AC")
            {
                txtUsuario.Text = miRecuerdo.Usuario;
                txtClave.Text = miRecuerdo.Clave;
                txtUsuario.Enabled = false;
                txtClave.Enabled = false;
                recordarmeCheckBox.Checked = true;
            }
            else
            {
                txtUsuario.Enabled = true;
                txtClave.Enabled = true;
                txtUsuario.Text = string.Empty;
                txtClave.Text = string.Empty;
                recordarmeCheckBox.Checked = false;
            }
        }

        private void recordarmeCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (recordarmeCheckBox.Checked == false)
            {
                txtUsuario.Enabled = true;
                txtClave.Enabled = true;
                txtUsuario.Text = string.Empty;
                txtClave.Text = string.Empty;
                CADrecordarme.EditarRecordarme(1, txtUsuario.Text, txtClave.Text, "DE");
            }
            else
            {
                // Asignación de usuario predeterminado
                // ------------------------------------
                if (txtUsuario.Text == "")
                {
                    errorProvider1.SetError(txtUsuario, "Debe ingresar un usuario");
                    txtUsuario.Focus();
                    return;
                }
                errorProvider1.SetError(txtUsuario, "");

                if (txtClave.Text == "")
                {
                    errorProvider1.SetError(txtClave, "Debe ingresar una clave");
                    txtClave.Focus();
                    return;
                }
                errorProvider1.SetError(txtClave, "");



                if (CADusuario.ValidarUsuario(txtUsuario.Text, txtClave.Text))
                {
                    txtUsuario.Enabled = false;
                    txtClave.Enabled = false;
                    CADrecordarme.EditarRecordarme(1, txtUsuario.Text, txtClave.Text, "AC");
                }
                else
                {
                    MessageBox.Show("Usuario o clave no admitida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    recordarmeCheckBox.Checked = false;
                    txtUsuario.Text = "";
                    txtClave.Text = "";
                    txtUsuario.Focus();
                    return;
                }
                errorProvider1.SetError(txtClave, "");
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
