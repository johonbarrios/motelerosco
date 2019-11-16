using CADmotelerosco;
using motelerosco.CLASES;
using System;
using System.Windows.Forms;

namespace motelerosco.INGRESOS
{
    public partial class frmMenuVentas : Form
    {
        private CADusuario usuarioLogueado;
        public CADusuario UsuarioLogueado
        {
            get { return usuarioLogueado; }
            set { usuarioLogueado = value; }
        }


        private DateTime fechaMto;

        public DateTime FechaMto
        {
            get { return fechaMto; }
            set { fechaMto = value; }
        }
        public frmMenuVentas()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMenuVentas_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            fechamtoDateTimePicker.Value = Convert.ToDateTime(VariablesUso.FeMovimiento);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void fechamtoDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void HoraSistema_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String myHora = DateTime.Now.ToString();
            DateTime h = Convert.ToDateTime(myHora);
            HoraSistema.Text = (myHora.Substring(11, 8));
        }

        private void ett01_Click(object sender, EventArgs e)
        {
            showSubMenu(paHab1);
        }


        private void showSubMenu(Panel paHab1)
        {
            if (paHab1.Visible == false)
            {
                paHab1.Visible = true;
            }
            else
                paHab1.Visible = false;
        }

        private void ett02_Click(object sender, EventArgs e)
        {
            showHab2(paHab2);
        }

        private void showHab2(Panel paHab2)
        {
            if (paHab2.Visible == false)
            {
                paHab2.Visible = true;
            }
            else
                paHab2.Visible = false;
        }
    }
}
