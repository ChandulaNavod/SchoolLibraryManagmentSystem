using System;
using System.Windows.Forms;

namespace School_Library_Managment_System
{
    public partial class MainUI : Form
    {
        private readonly string _username;
        private Form _currentSubform;

        public MainUI(string username)
        {
            InitializeComponent();

            _username = username;
            Mainlbl.Text = username;
            //Mainlbl2.Text = "Welcome, " + username;
            ShowDashboard();

            //DashbordUI dashbordUI = new DashbordUI(username) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //dashbordUI.Show();

        }

        private void ShowDashboard()
        {
            _currentSubform?.Close();

            DashboardUI dashboardUI = new DashboardUI(_username);

            ShowSubform(dashboardUI);
        }

        // Other methods for showing different subforms...

        private void ShowSubform(Form subform)
        {
            _currentSubform?.Close();

            subform.TopLevel = false;
            subform.FormBorderStyle = FormBorderStyle.None;
            subform.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(subform);
            subform.Show();

            _currentSubform = subform;
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginUI loginForm = new LoginUI();
            loginForm.Show();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboardbtn_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void Userbtn_Click(object sender, EventArgs e)
        {
            StudentUI studentUI = new StudentUI();

            ShowSubform(studentUI);
        }

        private void Booksbtn_Click(object sender, EventArgs e)
        {
            BooksUI booksUI = new BooksUI();

            ShowSubform(booksUI);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookDetailsUI bookDetailsUI = new BookDetailsUI();

            ShowSubform(bookDetailsUI);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginUI loginForm = new LoginUI();
            loginForm.Show();
        }
    }
}
