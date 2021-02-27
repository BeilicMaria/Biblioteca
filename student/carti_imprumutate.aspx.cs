using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.student
{
    public partial class carti_imprumutate : System.Web.UI.Page
    {
        //legatura cu baza de date in SQL server care face posibila accesarea elementelor 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        string sanctiune = "0";
        double nrzile = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica daca conexiunea este deschisa, o inchide si deschide 
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            //daca incercam sa accesam pagina dupa link redirectioneaza carte pagina de conectare 
            if (Session["student"]==null)
            {
                Response.Redirect("conectare_student.aspx");
            }


            //comanda ce atribuie coloeanei respective valoarea din baza de date
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from sanctiuni";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {

                sanctiune = dr2["sanctiune"].ToString();
            }





            //datatable temporara
            //Temporary tables are tables that exist temporarily on the SQL Server. The temporary tables are useful for storing the immediate result sets that are accessed multiple times.
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("numar_inregistrare_student");
            dt.Columns.Add("isbn_carte");
            dt.Columns.Add("data_imprumut");
            dt.Columns.Add("data_returnare_aproximativa");
            dt.Columns.Add("utilizator_student");
            dt.Columns.Add("este_returnata");
            dt.Columns.Add("data_returnare");
            dt.Columns.Add("zile_intarziere");
            dt.Columns.Add("sanctiune");



            //comanda ce preia datele din imprumut_carti in funtie de utilizator si realizeaza o copie
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from imprumut_carti where utilizator_student='" + Session["student"].ToString() + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach(DataRow dr1 in dt1.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["numar_inregistrare_student"] = dr1["numar_inregistrare_student"].ToString();
                dr["isbn_carte"] = dr1["isbn_carte"].ToString();
                dr["data_imprumut"] = dr1["data_imprumut"].ToString();
                dr["data_returnare_aproximativa"] = dr1["data_returnare_aproximativa"].ToString();
                dr["utilizator_student"] = dr1["utilizator_student"].ToString();
                dr["este_returnata"] = dr1["este_returnata"].ToString();
                dr["data_returnare"] = dr1["data_returnare"].ToString();
                //calcul zile intarziere
                DateTime d1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                DateTime d2 = Convert.ToDateTime(dr1["data_returnare_aproximativa"].ToString());

                if(d1<=d2)
                {
                    dr["zile_intarziere"] = "0";
                    
                }
                else
                {
                    TimeSpan t = d1 - d2;
                    nrzile = t.TotalDays;
                    dr["zile_intarziere"] = nrzile.ToString();
                }


                dr["sanctiune"] =Convert.ToString(Convert.ToDouble(nrzile) *Convert.ToDouble(sanctiune));

                dt.Rows.Add(dr);

            }

            d1.DataSource = dt;
            d1.DataBind();


        }
    }
}