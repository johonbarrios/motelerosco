using System;
using System.Windows.Forms;
using CADmotelerosco;


namespace motelerosco.LOGIN
{
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

        }
    }
}
