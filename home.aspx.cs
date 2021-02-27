using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Biblioteca
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void b1_Click(object sender, EventArgs e)
        {
            Response.Redirect("bibliotecar/conectare.aspx");
        }

        protected void b2_Click(object sender, EventArgs e)
        {
            Response.Redirect("student/conectare_student.aspx");
        }
    }
}