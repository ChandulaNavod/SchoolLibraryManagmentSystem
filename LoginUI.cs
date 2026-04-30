using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School_Library_Managment_System
{
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2V8NCPN\SQLEXPRESS;Initial Catalog=LibMng;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click_1(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();

            AccessCode accessCodeForm = new AccessCode();
            if (accessCodeForm.ShowDialog() == DialogResult.OK)
            {

                RegisterUI registerForm = new RegisterUI();
                registerForm.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string username = UserNametxt.Text;
            con.Open();
            string login = "SELECT * FROM [User] WHERE username LIKE '" + UserNametxt.Text + "' or email LIKE '" + UserNametxt.Text + "' and password LIKE '" + Passtxt.Text + "'";
            cmd = new SqlCommand(login, con);
            cmd.Parameters.AddWithValue("@UserName", UserNametxt.Text);
            cmd.Parameters.AddWithValue("@Password", Passtxt.Text);
            cmd.Parameters.AddWithValue("@Email", UserNametxt.Text);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new MainUI(username).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserNametxt.Text = "";
                Passtxt.Text = "";
                UserNametxt.Focus();
            }
            con.Close();
        }

        private void ShowPassCheckbox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (ShowPassCheckbox.Checked)
            {
                Passtxt.PasswordChar = '\0';
            }
            else
            {
                Passtxt.PasswordChar = '•';
            }
        }
    }
}
