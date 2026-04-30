using System;
using System.Windows.Forms;

namespace School_Library_Managment_System
{
    public partial class DashboardUI : Form
    {
        public DashboardUI(string username)
        {
            InitializeComponent();

            Mainlbl2.Text = "Welcome, " + username;
        }

        private void bunifuCircleProgress1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuCircleProgress.ProgressChangedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginUI loginForm = new LoginUI();
            loginForm.Show();
        }
    }
}
