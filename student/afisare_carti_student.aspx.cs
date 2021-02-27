using System;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.student
{
    public partial class afisare_carti_student : System.Web.UI.Page
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
            //daca incercam sa accesam pagina dupa link redirectioneaza carte pagina de conectare 
            if (Session["student"] == null)
            {
                Response.Redirect("conectare_student.aspx");
            }
            //creeaza o comanda ce atribuie datele din baza de date coloanelor corespunzatoare din interfata
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from carti";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd); 
            da.Fill(dt);
            r1.DataSource = dt; //manipuleaza date, le selecteaza, Managing connection
            r1.DataBind(); //bind data from a source to a server control.
        }

        //verifica daca exista un video, daca nu returneaza mesaj altfel returneaza path ul catre video
        public string verificavideo (object myvalue, object id)
        {
            if (myvalue.ToString() == "")
            {
                return "Nu este disponibil.";
               
            }
            else
            {
                myvalue = "../bibliotecar/"+myvalue. ToString();
                return "<a href='"+ myvalue.ToString() +"' style='color:green'>vezi video</a>";
            }
        }
        //verifica daca exista un pdf, daca nu returneaza mesaj altfel returneaza path ul catre pdf

        public string verificapdf(object myvalue1, object id1)
        {
            if (myvalue1.ToString() == "")
            {
                return "Nu este disponibil.";
            }
            else
            {
                myvalue1 = "../bibliotecar/" + myvalue1.ToString();
                return "<a href='" + myvalue1.ToString() + "' style='color:green'>vezi pdf</a>";
            }
        }
    }
}