using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Library_Managment_System
{
    public partial class BooksUI : Form
    {
        private string connectionString = @"Data Source=DESKTOP-2V8NCPN\SQLEXPRESS;Initial Catalog=LibMng;Integrated Security=True";
        private string apiKey = "API_KEY_HERE";

        public BooksUI()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2V8NCPN\SQLEXPRESS;Initial Catalog=LibMng;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void Retrievebtn_Click(object sender, EventArgs e)
        {
            string bookName = Titletxt.Text;

            var bookInfo = await RetrieveBookInfo(bookName, apiKey);

            Authortxt.Text = bookInfo.Author;
            Publishertxt.Text = bookInfo.Publisher;
            ISBNtxt.Text = bookInfo.ISBN;
            Categorytxt.Text = bookInfo.Category;
        }

        private async Task<BookInfo> RetrieveBookInfo(string bookName, string apiKey)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://www.googleapis.com/books/v1/volumes?q={bookName}&key={apiKey}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var bookData = JsonConvert.DeserializeObject<GoogleBooksApiResponse>(json);

                    var bookInfo = new BookInfo
                    {
                        Author = bookData.items[0].volumeInfo.authors?.FirstOrDefault(),
                        Publisher = bookData.items[0].volumeInfo.publisher,
                        ISBN = bookData.items[0].volumeInfo.industryIdentifiers?.FirstOrDefault()?.identifier,
                        Category = bookData.items[0].volumeInfo.categories?.FirstOrDefault()
                    };

                    return bookInfo;
                }
                else
                {
                    return null;
                }
            }
        }

        private void AddBookbtn_Click(object sender, EventArgs e)
        {
            string title = Titletxt.Text;
            string author = Authortxt.Text;
            string publisher = Publishertxt.Text;
            string isbn = ISBNtxt.Text;
            string category = Categorytxt.Text;

            UpdateDatabase(title, author, publisher, isbn, category);
        }

        private void UpdateDatabase(string title, string author, string publisher, string isbn, string category)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Books (Title, Author, Publisher, ISBN, Category) VALUES (@Title, @Author, @Publisher, @ISBN, @Category)";
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Author", author);
                command.Parameters.AddWithValue("@Publisher", publisher);
                command.Parameters.AddWithValue("@ISBN", isbn);
                command.Parameters.AddWithValue("@Category", category);
                command.ExecuteNonQuery();
            }
        }
    }

    public class GoogleBooksApiResponse
    {
        public GoogleBookItem[] items { get; set; }
    }

    public class GoogleBookItem
    {
        public VolumeInfo volumeInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string title { get; set; }
        public string[] authors { get; set; }
        public string publisher { get; set; }
        public IndustryIdentifier[] industryIdentifiers { get; set; }
        public string[] categories { get; set; }
    }

    public class IndustryIdentifier
    {
        public string type { get; set; }
        public string identifier { get; set; }
    }

    public class BookInfo
    {
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
    }
}
