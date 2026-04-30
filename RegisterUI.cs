using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School_Library_Managment_System
{
    public partial class RegisterUI : Form
    {
        public RegisterUI()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2V8NCPN\SQLEXPRESS;Initial Catalog=LibMng;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private void LoginPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Regbtn_Click(object sender, EventArgs e)
        {
            if (UserNametxt.Text == "" && Passtxt.Text == "" && ConfirmPasstxt.Text == "" && Emailtxt.Text == "")
            {
                MessageBox.Show("Username, Password and Email fields are empty", "Registeration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Passtxt.Text == ConfirmPasstxt.Text)
            {
                con.Open();
                string register = "INSERT INTO [User] (UserName, Email, Password) VALUES (@UserName, @Email, @Password)";
                cmd = new SqlCommand(register, con);
                cmd.Parameters.AddWithValue("@UserName", UserNametxt.Text);
                cmd.Parameters.AddWithValue("@Password", Passtxt.Text);
                cmd.Parameters.AddWithValue("@Email", Emailtxt.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                UserNametxt.Text = "";
                Passtxt.Text = "";
                ConfirmPasstxt.Text = "";
                Emailtxt.Text = "";

                MessageBox.Show("Great! Your account has been successfully created with admin privileges.", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Password does not match, Please Re-enter the password", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Passtxt.Text = "";
                ConfirmPasstxt.Text = "";
                Passtxt.Focus();
            }
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void RegisterUI_Load(object sender, EventArgs e)
        {

        }

        private void ShowPassCheckbox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            new LoginUI().Show();
            this.Hide();
        }
    }
}
