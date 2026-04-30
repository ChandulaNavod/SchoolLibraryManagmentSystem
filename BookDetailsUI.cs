using System;
using System.Windows.Forms;

namespace School_Library_Managment_System
{
    public partial class BookDetailsUI : Form
    {
        public BookDetailsUI()
        {
            InitializeComponent();
        }

        private void BookDetailsUI_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libMngDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.libMngDataSet.Books);

        }
    }
}
