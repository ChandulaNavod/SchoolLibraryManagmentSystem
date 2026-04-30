using System;
using System.Windows.Forms;

namespace School_Library_Managment_System
{
    public partial class AccessCode : Form
    {
        public AccessCode()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("School Library Management System \n\nThis system is currently in development, and what you are seeing is only a demonstration. As a result, only the admins are currently able to register on the system via entering the passcode provided to them in here. However, we will be adding the option for students to register soon, along with the ability to search for and obtain more information about books.", "Why This?");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Passwordtxt1.Text == "testpassword123")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Passwordtxt1.Text = "";

                Passwordtxt1.Focus();
            }
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ShowPassCheckbox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (ShowPassCheckbox.Checked)
            {
                Passwordtxt1.PasswordChar = '\0';
            }
            else
            {
                Passwordtxt1.PasswordChar = '•';
            }
        }
    }
}
