using CADmotelerosco;
using motelerosco.MENU;
using System;
using System.Windows.Forms;

namespace motelerosco.LOGIN
{
    public partial class frmFecha : Form
    {
        private CADusuario usuarioLogueado;

        public CADusuario UsuarioLogueado
        {
            get { return usuarioLogueado; }
            set { usuarioLogueado = value; }
        }

        private string claveUsuario;

        public string ClaveUsuario
        {
            get { return claveUsuario; }
            set { claveUsuario = value; }
        }

        DateTime reffecha2;

        
        public frmFecha()
        {
            InitializeComponent();
        }

        private void frmFecha_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            frmPrincipal miFormm = new frmPrincipal();
            miFormm.UsuarioLogueado = CADusuario.ConsultarRegistroUsuario(ClaveUsuario);
            miFormm.FechaMto = fechaactualDateTimePicker.Value;
            miFormm.Show();
            this.Hide();
        }
    }
}
