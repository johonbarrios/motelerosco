namespace motelerosco.INGRESOS
{
    using System;
    using System.Windows.Forms;
    public partial class frmVentaNormal : Form
    {
        public frmVentaNormal()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelOpc_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelAdic_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDesc_Paint(object sender, PaintEventArgs e)
        {

        }



        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }



        private void btnAdicionales_Click(object sender, EventArgs e)
        {
            showSubMenu(panelAdic);
        }

        private void hideSubMenu()
        {
            panelAdic.Visible = false;
        }

        private void frmVentaNormal_Load(object sender, EventArgs e)
        {

        }
    }
}
