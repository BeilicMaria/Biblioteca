using System;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.bibliotecar
{
    public partial class returnarecarte : System.Web.UI.Page
    {
        //initializare obiect nou de tip sqlconnection ce permite accesul la informatia din baza de date si manipularea informatiei 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        int id;
        string isbn_carte = "";
        protected void Page_Load(object sender, EventArgs e)
        { //verifica daca conexiunea este deschisa, daca aceasta nu este o deschide
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            //dupa o perioada de inactivitate sau daca incercam sa ne conectam direct la pagina de adaugare suntem trimisi in pagina de conectare
            if (Session["bibliotecar"] == null)
            {
                Response.Redirect("conectare.aspx");
            }
            //comanda care actualizeaza baza de date cu data returnarii si schimba statusul cartii (este_returnata= yes)
            id =Convert.ToInt32( Request.QueryString["id"].ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update imprumut_carti set este_returnata='yes', data_returnare='"+ DateTime.Now.ToString("yyyy/MM/dd") +"' where id="+ id +"";
            cmd.ExecuteNonQuery();

            //comanda care actualizeaza stocul cartilor dupa returnarea exemplarului
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from imprumut_carti where id="+ id +"";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach(DataRow dr1 in dt1.Rows)
            {
                isbn_carte = dr1["isbn_carte"].ToString();
            }         
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "update carti set cantitate_carte=cantitate_carte + 1 where isbn_carte='"+ isbn_carte.ToString() +"'";
            cmd2.ExecuteNonQuery();

            Response.Redirect("returnare_carte.aspx");
        }
    }
}