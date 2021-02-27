using System;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.bibliotecar
{
    public partial class incarca_mesaje : System.Web.UI.Page
    {
        //initializare obiect nou de tip sqlconnection ce permite accesul la informatia din baza de date si manipularea informatiei 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\beili\OneDrive\Desktop\Practica\Biblioteca\App_Data\lms.mdf;Integrated Security=True");
        string utilizator = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica daca conexiunea este deschisa, daca aceasta nu este o deschide
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
            //preluarea utilizatorului
            utilizator = Request.QueryString["utilizator"].ToString();
            //selectarea informatiei din baza de date 
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from mesaje where (sutilizator='"+utilizator.ToString() + "' and dutilizator='bibliotecar') or (dutilizator='" + utilizator.ToString() + "' and sutilizator='bibliotecar')";
            cmd.ExecuteNonQuery();
            //modul de afisare
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                Response.Write("<p>");
                Response.Write(dr["sutilizator"].ToString() + ":"  + dr["msg"].ToString());
                Response.Write("</p>");
                Response.Write("<hr>");

                //schimbare status
                if(dr["dutilizator"].ToString()=="bibliotecar")
                {
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update mesaje set plasat='yes' where id="+ dr["id"].ToString() +"";
                    cmd1.ExecuteNonQuery();
                }
            }
        }
      
        
        
    }
}