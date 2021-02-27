using System;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.bibliotecar
{
    public partial class adaugare_carti : System.Web.UI.Page
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
            if (Session["bibliotecar"]==null)
            {
                Response.Redirect("conectare.aspx");
            }
        }
        protected void b1_Click(object sender, EventArgs e)
        {
            string nume_coperta=Class1.GetRandomPassword(10)+".jpg";
            string pdf_carte = "";
            string video_carte = "";


            string path = "";
            string path2 = "";
            string path3 = "";
            f1.SaveAs(Request.PhysicalApplicationPath + "/bibliotecar/coperta/" + nume_coperta.ToString());
            path = "coperta/"+nume_coperta.ToString();
            if (f2.FileName.ToString() != "")
            {
                pdf_carte = Class1.GetRandomPassword(10)+".pdf";
              
                f2.SaveAs(Request.PhysicalApplicationPath + "/bibliotecar/pdf_carte/" + pdf_carte.ToString());
                path2 = "pdf_carte/" + pdf_carte.ToString();
            }
            if (f3.FileName.ToString() != "")
            {
                video_carte = Class1.GetRandomPassword(10) + ".mp4";
              
                f3.SaveAs(Request.PhysicalApplicationPath + "/bibliotecar/video_carte/" +video_carte.ToString());
                path3 = "video_carte/" + video_carte.ToString();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into carti values('"+ titlu.Text +"','"+ path.ToString() +"','"+ path2.ToString() +"','"+ path3.ToString() +"','"+ autor.Text +"','"+ isbn.Text +"','"+ cantitate.Text +"')";
            cmd.ExecuteNonQuery();
            msg.Style.Add("display", "block");
        }
    }
}