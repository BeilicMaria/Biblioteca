using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.student
{
    public partial class conectare_student : System.Web.UI.Page
    {
        //legatura cu baza de date in SQL server care face posibila accesarea elementelor 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\beili\OneDrive\Desktop\Practica\Biblioteca\App_Data\lms.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica daca conexiunea este deschisa, o inchide si deschide
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            //verifica datele introduse (utilizator, parola) de utilizator cu cele din baza de date si daca coincid redirectioneaza spre pagina acasa, daca nu afiseaza un mesaj de eroare
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student_conectare where utilizator='" + utilizator.Text + "' and parola='" + parola.Text + "' and aprobat='yes'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i > 0)
            {
                Session["student"] = utilizator.Text;
                Response.Redirect("acasa.aspx");
            }
            else
            {
                error.Style.Add("display", "block");
            }
        }
    }
}