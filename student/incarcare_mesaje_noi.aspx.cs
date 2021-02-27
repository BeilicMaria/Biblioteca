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

    public partial class incarcare_mesaje_noi : System.Web.UI.Page
    {
        //legatura cu baza de date in SQL server care face posibila accesarea elementelor
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\beili\OneDrive\Desktop\Practica\Biblioteca\App_Data\lms.mdf;Integrated Security=True");
        string msg = "";
        int contor = 0; //numara mesaje
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
            //comanda selecteaza mesajul de la destinatar daca acesta are statusul nu si il afiseaza, actualizeaza mesajele
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from mesaje where dutilizator='"+ utilizator.ToString() +"' and plasat='no' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                contor = contor + 1;
                if (contor == 1)
                {
                    msg = dr["sutilizator"].ToString() + ":" + dr["msg"].ToString();
                }
                else
                {
                    msg = msg + "||abcd||" + dr["sutilizator"].ToString() + ":" + dr["msg"].ToString();
                }

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update mesaje set plasat='yes' where id=" + dr["id"].ToString() + " ";
                cmd1.ExecuteNonQuery();

            }

            if (contor == 0)
            {
                Response.Write("0");
            }
            else
            {
                Response.Write(msg.ToString());
            }
        }
    }
}