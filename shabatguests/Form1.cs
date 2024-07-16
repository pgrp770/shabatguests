using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Guest_Shabbat_Host_App.DAL;
using Microsoft.VisualBasic.ApplicationServices;

namespace shabatguests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DBContext db = new DBContext("Server = PINISHTERNIGOLD; Database = ShabatDB; User Id = sa; Password = 1234;");
            DataTable dt = db.ExecuteQuery("select name from Categories", null);
            List<string> ls = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                ls.Add(row[0].ToString());
            }

            listBox1.DataSource = ls;


        }


        public static void AddNewCategory(string name)
        {
            DBContext db = new DBContext("Server = PINISHTERNIGOLD; Database = ShabatDB; User Id = sa; Password = 1234;");
            int a = (int)db.ExecuteNonQuery($"insert into Categories(name) values(@name)", [new SqlParameter("@name", name)]);
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            AddNewCategory(textBox1.Text);
            DBContext db = new DBContext("Server = PINISHTERNIGOLD; Database = ShabatDB; User Id = sa; Password = 1234;");
            DataTable dt = db.ExecuteQuery("select name from Categories", null);
            List<string> ls = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                ls.Add(row[0].ToString());
            }

            listBox1.DataSource = ls;
            textBox1.Text = "";
        }
    }
}
