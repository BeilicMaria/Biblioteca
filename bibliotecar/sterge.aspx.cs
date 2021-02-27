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
    public partial class sterge : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\beili\OneDrive\Desktop\Practica\Biblioteca\App_Data\lms.mdf;Integrated Security=True");

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


            if (Request.QueryString["id"]!=null)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update carti set video_carte=''where id=' "+ Request.QueryString["id"].ToString() +"' ";
                cmd.ExecuteNonQuery();
            }
            else if(Request.QueryString["id1"] != null)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update carti set pdf_carte='' where id=' " + Request.QueryString["id1"].ToString() + "' ";
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete carti  where id=' " + Request.QueryString["id2"].ToString() + "' ";
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("afisare_carti.aspx");
           
        }
    }
}