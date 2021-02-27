using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Biblioteca.bibliotecar
{
    public partial class bibliotecar : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\beili\OneDrive\Desktop\Practica\Biblioteca\App_Data\lms.mdf;Integrated Security=True");
        int contor = 0;
        int nr = 15;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from mesaje where dutilizator='bibliotecar' and plasat='no'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            contor =Convert.ToInt32( dt.Rows.Count.ToString());
            notificare1.Text = contor.ToString();
            notificare2.Text = contor.ToString();
            r1.DataSource = dt;
            r1.DataBind();

        }


        public string get20decaractere(object myvalue)
        {
            string a;
            a = Convert.ToString(myvalue.ToString());
            string b = "";
            if(a.Length>=nr)
            {
                b = a.Substring(0, 15);
                return b.ToString() + "...";
            }
            else
            {
                b = a.ToString();
                return b.ToString();

            }
        }
    }
}