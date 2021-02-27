using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.bibliotecar
{
    public partial class afisare_studenti : System.Web.UI.Page
    {
        //initializare obiect nou de tip sqlconnection ce permite accesul la informatia din baza de date si manipularea informatiei 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
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

            //comanda pentru preluarea informatiei din baza de date 
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student_conectare";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();//tabel  in C# cu datele din baza de date
            SqlDataAdapter da = new SqlDataAdapter(cmd); //pod intre tabelul din C# si SQL Server pentru recuperarea si salvarea datelor
            da.Fill(dt);
            r1.DataSource = dt;
            r1.DataBind();
        }
    }
}