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

    public partial class incarcare_mesaje : System.Web.UI.Page
    {
        //legatura cu baza de date in SQL server care face posibila accesarea elementelor 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\beili\OneDrive\Desktop\Practica\Biblioteca\App_Data\lms.mdf;Integrated Security=True");
        string utilizator = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica daca conexiunea este deschisa, o inchide si deschide 
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            //daca incercam sa accesam pagina dupa link redirectioneaza carte pagina de conectare 
            if (Session["student"] == null)
            {
                Response.Redirect("conectare_student.aspx");
            }

            utilizator =Session["student"].ToString();
            //comanda care preia sursa, destinatarul si afiseaza mesajul in formatul dorit si shimba statusul mesajului din nu in da

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from mesaje where (sutilizator='" + utilizator.ToString() + "' and dutilizator='bibliotecar') or (dutilizator='" + utilizator.ToString() + "' and sutilizator='bibliotecar')";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Response.Write("<p>");
                Response.Write(dr["sutilizator"].ToString() + ":" + dr["msg"].ToString());
                Response.Write("</p>");
                Response.Write("<hr>");


                if (dr["dutilizator"].ToString() == utilizator.ToString())
                {
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update mesaje set plasat='yes' where id=" + dr["id"].ToString() + "";
                    cmd1.ExecuteNonQuery();
                }
            }
        }
    }
}