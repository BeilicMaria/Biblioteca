﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca.bibliotecar
{
    public partial class comunicare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["bibliotecar"] == null)
            {
                Response.Redirect("conectare.aspx");
            }
        }
    }
}