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
    public partial class mesaje_trimise_de_student : System.Web.UI.Page
    {
        //legatura cu baza de date in SQL server care face posibila accesarea elementelor 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\beili\OneDrive\Desktop\Practica\Biblioteca\App_Data\lms.mdf;Integrated Security=True");
        string utilizator = "";
        string msg = "";
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


            utilizator = Session["student"].ToString();
            msg = Request.QueryString["msg"].ToString();

            //comanda care preia mesajele de la utilizator si le introduce in baza de date cu statusul no (nu a fost primit)
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into mesaje values('"+ utilizator.ToString() +"','bibliotecar','" + msg.ToString() + "','no')";
            cmd.ExecuteNonQuery();
        }
    }
}