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
    public partial class afisare_carti : System.Web.UI.Page
    {
        //initializare obiect nou de tip sqlconnection ce permite accesul la informatia din baza de date si manipularea informatiei 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\beili\OneDrive\Desktop\Practica\Biblioteca\App_Data\lms.mdf;Integrated Security=True");
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

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from carti";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable(); //tabel  in C# cu datele din baza de date
            SqlDataAdapter da = new SqlDataAdapter(cmd);//pod intre tabelul din C# si SQL Server pentru recuperarea si salvarea datelor
            da.Fill(dt);
            r1.DataSource = dt;//repeta asezarea in tabel completand cu datele din baza de date 
            r1.DataBind();//
        }
        public string verificavideo(object myvalue, object id)
        {
            if(myvalue.ToString() =="")
            {
                return myvalue.ToString();
            }
            else
            {
                return "<a href='sterge.aspx?id="+ id  +"' style='color:red'>șterge video</a>";
            }
        }
        public string verificapdf(object myvalue1, object id1)
        {
            if (myvalue1.ToString() == "")
            {
                return myvalue1.ToString();
            }
            else
            {
                return "<a href='sterge.aspx?id1="+ id1 +"' style='color:red'>șterge pdf</a>";
            }
        }

    }
}