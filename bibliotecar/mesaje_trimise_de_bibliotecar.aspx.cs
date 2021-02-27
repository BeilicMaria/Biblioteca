using System;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.bibliotecar
{
    public partial class mesaje_trimise_de_bibliotecar : System.Web.UI.Page
    {
        //initializare obiect nou de tip sqlconnection ce permite accesul la informatia din baza de date si manipularea informatiei 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\beili\OneDrive\Desktop\Practica\Biblioteca\App_Data\lms.mdf;Integrated Security=True");
        string utilizator = "";
        string msg = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica daca conexiunea este deschisa, daca aceasta nu este o deschide
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            //dupa o perioada de inactivitate sau daca incercam sa ne conectam direct la pagina de adaugare suntem trimisi in pagina de conectare
            if (Session["bibliotecar"] == null)
            {
                Response.Redirect("conectare.aspx");
            }
            //preluarea utilizatorului si a mesajului
            utilizator = Request.QueryString["utilizator"].ToString();
            msg = Request.QueryString["msg"].ToString();
            //comanda pentru inserarea valorilor in baza de date
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into mesaje values('bibliotecar','"+ utilizator.ToString() +"','"+ msg.ToString()  +"','no')";
            cmd.ExecuteNonQuery();
        }
    }
}