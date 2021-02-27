using System;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Net;
using System.IO;

namespace Biblioteca.student
{
    public partial class inregistrare_student : System.Web.UI.Page
    {
        //legatura cu baza de date in SQL server care face posibila accesarea elementelor 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\beili\OneDrive\Desktop\Practica\Biblioteca\App_Data\lms.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica daca conexiunea este deschisa, o inchide si deschide 
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();            
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            int count = 0;
            int contor = 0;
            if (IsReCaptchValid())
            {
                //comanda care selecteaza din baza de date studentul dupa nr de inregistrare
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select * from student_conectare where numar='"+nrinregistrare.Text +"'";
                cmd1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(dt1);
                count = Convert.ToInt32(dt1.Rows.Count.ToString());
                //daca numarul este gasit utilizator primeste un mesaj de avertizare
                if (count > 0)
                {
                    Response.Write("<script>alert('Numărul ales există deja!');</script>");
                }
                else
                {
                    // comanda care selecteaza din baza de date studentul dupa utilizator
                     //verificare utilizator (daca exista deja username-ul, utilizatorul este atentionat)
                     SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select * from student_conectare where utilizator='" + utilizator.Text + "'";
                    cmd2.ExecuteNonQuery();
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    da2.Fill(dt2);
                    contor = Convert.ToInt32(dt2.Rows.Count.ToString());
                    //
                    if (contor > 0)
                    {
                        Response.Write("<script>alert('Utilizatorul ales există deja!');</script>");
                    }
                    else
                    {
                        //modifica numele imaginii de profil cu un nume random prin functia  GetRandomPassword din Class1
                        string randomno = Class1.GetRandomPassword(10) + ".jpg";
                        string path = "";
                        f1.SaveAs(Request.PhysicalApplicationPath + "/student/imaginedeprofil/" + randomno.ToString());
                        path = "student/imaginedeprofil/" + randomno.ToString();
                        //adauga datele in baza de date dupa validari
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into student_conectare values('" + prenume.Text + "','" + nume.Text + "','" + nrinregistrare.Text + "','" + utilizator.Text + "','" + parola.Text + "','" + email.Text + "','" + contact.Text + "','" + path.ToString() + "','no')";
                        cmd.ExecuteNonQuery();                      
                        Response.Redirect("conectare_student.aspx");
                    }
                }
            }
            //altfel mesaj de atentionare
            else
            {
                lblMessage1.Text = "Înregitrare nereușită!";
            }         
        }


        //verificare robot
        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = "6LfaDsQZAAAAACIgrZc0JBreStvcglsqwKWbDPcQ";
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }
    }
}