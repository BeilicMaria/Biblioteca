using System;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.bibliotecar
{
    public partial class returnare_carte : System.Web.UI.Page
    {
        //initializare obiect nou de tip sqlconnection ce permite accesul la informatia din baza de date si manipularea informatiei 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        string sanctiune = "0";
        double nrzile = 0;
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
            //comanda ce preia suma alocata sanctiunii din baza de date
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
            // trasmite datele in baza de date temporara
            //datatable temporara
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("id");
            dt.Columns.Add("numar_inregistrare_student");
            dt.Columns.Add("isbn_carte");
            dt.Columns.Add("data_imprumut");
            dt.Columns.Add("data_returnare_aproximativa");
            dt.Columns.Add("utilizator_student");
            dt.Columns.Add("este_returnata");
            dt.Columns.Add("data_returnare");
            dt.Columns.Add("zile_intarziere");
            dt.Columns.Add("sanctiune");
            //comanda pentru completarea tabelului din interfata
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from imprumut_carti where este_returnata='no'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = dr1["id"].ToString();
                dr["numar_inregistrare_student"] = dr1["numar_inregistrare_student"].ToString();
                dr["isbn_carte"] = dr1["isbn_carte"].ToString();
                dr["data_imprumut"] = dr1["data_imprumut"].ToString();
                dr["data_returnare_aproximativa"] = dr1["data_returnare_aproximativa"].ToString();
                dr["utilizator_student"] = dr1["utilizator_student"].ToString();
                dr["este_returnata"] = dr1["este_returnata"].ToString();
                dr["data_returnare"] = dr1["data_returnare"].ToString();
                //calcul zile intarziere + calculul sanctiunii
                DateTime d1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                DateTime d2 = Convert.ToDateTime(dr1["data_returnare_aproximativa"].ToString());
                if (d1 <= d2)
                {
                    dr["zile_intarziere"] = "0";
                }
                else
                {
                    TimeSpan t = d1 - d2;
                    nrzile = t.TotalDays;
                    dr["zile_intarziere"] = nrzile.ToString();
                }
                dr["sanctiune"] = Convert.ToString(Convert.ToDouble(nrzile) * Convert.ToDouble(sanctiune));

                dt.Rows.Add(dr);
            }
            d1.DataSource = dt;
            d1.DataBind();

        }
    }
}