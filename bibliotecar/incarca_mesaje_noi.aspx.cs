using System;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.bibliotecar
{
    public partial class incarca_mesaje_noi : System.Web.UI.Page
    {
        //initializare obiect nou de tip sqlconnection ce permite accesul la informatia din baza de date si manipularea informatiei 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\beili\OneDrive\Desktop\Practica\Biblioteca\App_Data\lms.mdf;Integrated Security=True");
        string msg = "";
        int contor = 0; //numara mesaje
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
            //selecteaza mesajele care au destinatarul: bibliotecarul si statusul: no
            //actualizarea mesajelor
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from mesaje where dutilizator='bibliotecar' and plasat='no' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                contor = contor + 1;
                if(contor==1)
                {
                    msg = dr["sutilizator"].ToString() + ":" + dr["msg"].ToString();
                }
                else
                {
                    msg = msg +  "||abcd||" + dr["sutilizator"].ToString() + ":" + dr["msg"].ToString();
                }
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update mesaje set plasat='yes' where id="+ dr["id"].ToString() +" ";
                cmd1.ExecuteNonQuery();
            }

            if(contor==0)
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