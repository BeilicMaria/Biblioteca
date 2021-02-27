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
    public partial class modifica_carte : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\beili\OneDrive\Desktop\Practica\Biblioteca\App_Data\lms.mdf;Integrated Security=True");
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (Session["bibliotecar"] == null)
            {
                Response.Redirect("conectare.aspx");
            }
            id =Convert.ToInt32( Request.QueryString["id"].ToString());

            if (IsPostBack) return;


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from carti where id="+id+" ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                titlu.Text = dr["titlu_carte"].ToString();
                autor.Text = dr["autor_carte"].ToString();
                isbn.Text = dr["isbn_carte"].ToString();
                cantitate.Text = dr["cantitate_carte"].ToString();
                copertacarte.Text = dr["coperta_carte"].ToString();
                pdfcarte.Text= dr["pdf_carte"].ToString();
                videocarte.Text= dr["video_carte"].ToString();
            }           
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            string nume_coperta = "";
            string pdf_carte = "";
            string video_carte = "";


            string path = "";
            string path2 = "";
            string path3 = "";
           

            if(f1.FileName.ToString()!="")
            {
                nume_coperta = Class1.GetRandomPassword(10) + ".jpg";
                f1.SaveAs(Request.PhysicalApplicationPath + "/bibliotecar/coperta/" + nume_coperta.ToString());
                path = "coperta/" + nume_coperta.ToString();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update carti set titlu_carte='"+titlu.Text+"',coperta_carte='"+path.ToString()+"',autor_carte='"+autor.Text+"', isbn_carte='"+isbn.Text+"', cantitate_carte='"+cantitate.Text+"' where id="+id+"";
                cmd.ExecuteNonQuery();
            }

            if (f2.FileName.ToString() != "")
            {
                pdf_carte = Class1.GetRandomPassword(10) + ".pdf";

                f2.SaveAs(Request.PhysicalApplicationPath + "/bibliotecar/pdf_carte/" + pdf_carte.ToString());
                path2 = "pdf_carte/" + pdf_carte.ToString();


                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update carti set titlu_carte='" + titlu.Text + "',pdf_carte='" + path2.ToString() + "',autor_carte='" + autor.Text + "', isbn_carte='" + isbn.Text + "', cantitate_carte='" + cantitate.Text + "' where id=" + id + "";
                cmd.ExecuteNonQuery();
            }

            if (f3.FileName.ToString() != "")
            {
                video_carte = Class1.GetRandomPassword(10) + ".mp4";

                f3.SaveAs(Request.PhysicalApplicationPath + "/bibliotecar/video_carte/" + video_carte.ToString());
                path3 = "video_carte/" + video_carte.ToString();


                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update carti set titlu_carte='" + titlu.Text + "',video_carte='" + path3.ToString() + "',autor_carte='" + autor.Text + "', isbn_carte='" + isbn.Text + "', cantitate_carte='" + cantitate.Text + "' where id=" + id + "";
                cmd.ExecuteNonQuery();
            }


            if(f1.FileName.ToString()==""&& f2.FileName.ToString() == ""&& f3.FileName.ToString() == "")
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update carti set titlu_carte='" + titlu.Text + "',autor_carte='" + autor.Text + "', isbn_carte='" + isbn.Text + "', cantitate_carte='" + cantitate.Text + "' where id=" + id + "";
                cmd.ExecuteNonQuery();
            }


            Response.Redirect("afisare_carti.aspx");
        }
    }
}