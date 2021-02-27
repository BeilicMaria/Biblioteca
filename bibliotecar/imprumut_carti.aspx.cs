using System;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.bibliotecar
{
    public partial class imprumut_carti : System.Web.UI.Page
    {
        //initializare obiect nou de tip sqlconnection ce permite accesul la informatia din baza de date si manipularea informatiei 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\beili\OneDrive\Desktop\Practica\Biblioteca\App_Data\lms.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica daca conexiunea este deschisa, daca aceasta nu este o deschide
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            //dupa o perioada de inactivitate sau daca incercam sa ne conectam direct la pagina de adaugare suntem trimisi in pagina de conectare
            if (Session["bibliotecar"] == null)
            {
                Response.Redirect("conectare.aspx");
            }

            if (IsPostBack) return;
            //comanda pentru preluarea numarului de inregistrare al studentului din baza de date și adăugarea lui intr-un control de tip DropDownList
            nrinr.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select numar from student_conectare";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                nrinr.Items.Add(dr["numar"].ToString());
            }

            //comanda pentru preluarea isbn-ului din baza de date și adăugarea lui intr-un control de tip DropDownList
            isbn.Items.Clear();
            isbn.Items.Add("Select");
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select isbn_carte from carti";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                isbn.Items.Add(dr2["isbn_carte"].ToString());
            }



        }

        protected void b1_Click(object sender, EventArgs e)
        {
            //verificare daca cartea este selectata sau nu
            if (isbn.SelectedItem.ToString() == "Select")
            {
                Response.Write("<script>alert('Alege o carte!');window.location.href=window.location.href;</script>");
            }
            else
            {
                //verificare daca studentul a imprumutat deja cartea aleasa sau nu
                int gasit = 0;
                SqlCommand cmd0 = con.CreateCommand();
                cmd0.CommandType = CommandType.Text;
                cmd0.CommandText = "select * from imprumut_carti where numar_inregistrare_student='" + nrinr.SelectedItem.ToString() + "' and isbn_carte='" + isbn.SelectedItem.ToString() + "' and este_returnata='no'";
                cmd0.ExecuteNonQuery();
                DataTable dt0 = new DataTable();
                SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
                da0.Fill(dt0);

                gasit = Convert.ToInt32(dt0.Rows.Count.ToString());
                if (gasit > 0)
                {
                    Response.Write("<script>alert('Carte împrumutată deja studentului selectat!');</script>");
                }
                else
                {
                    //verificare daca exista cartea in stoc sau nu
                    if (instoc.Text == "0")
                    {
                        Response.Write("<script>alert('Cartea selectată nu este disponibilă momentan!');</script>");
                    }
                    else
                    {
                        //inserarea informatiei in baza de date
                        string data_imprumut = DateTime.Now.ToString("yyyy/MM/dd");
                        string data_returnare_aproximativa = DateTime.Now.AddDays(10).ToString("yyyy/MM/dd");
                        string utilizator = "";

                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select * from student_conectare where numar='" + nrinr.SelectedItem.ToString() + "'";
                        cmd2.ExecuteNonQuery();
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                        da2.Fill(dt2);
                        foreach (DataRow dr2 in dt2.Rows)
                        {
                            utilizator = dr2["utilizator"].ToString();
                        }
                        SqlCommand cmd3 = con.CreateCommand();
                        cmd3.CommandType = CommandType.Text;
                        cmd3.CommandText = "insert into imprumut_carti values('" + nrinr.SelectedItem.ToString() + "','" + isbn.SelectedItem.ToString() + "','" + data_imprumut.ToString() + "','" + data_returnare_aproximativa.ToString() + "','" + utilizator.ToString() + "','no','no')";
                        cmd3.ExecuteNonQuery();
                        //actualizarea numarului de exemplare dupa imprumut
                        SqlCommand cmd4 = con.CreateCommand();
                        cmd4.CommandType = CommandType.Text;
                        cmd4.CommandText = "update carti set cantitate_carte=cantitate_carte-1 where isbn_carte='" + isbn.SelectedItem.ToString() + "'";
                        cmd4.ExecuteNonQuery();

                        Response.Write("<script>alert('Cartea a fost imprumutata cu succes!');window.location.href=window.location.href;</script>");

                    }
                }
            }
        }


        protected void isbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comanda pentru afisarea imaginii, numelui si cantitatii (carte) la selectia isbn-ului din controlul de tip  DropDownList
            i1.ImageUrl = "";
            numecarte.Text = "";
            instoc.Text = "";

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from carti where isbn_carte='"+isbn.SelectedItem.ToString()+"'";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                i1.ImageUrl = dr2["coperta_carte"].ToString();
                numecarte.Text = dr2["titlu_carte"].ToString();
                instoc.Text = dr2["cantitate_carte"].ToString();
            }

        }
    }
}