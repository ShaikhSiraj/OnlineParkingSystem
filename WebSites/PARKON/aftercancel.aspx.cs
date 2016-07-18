using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class aftercancel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void canhome_Click(object sender, EventArgs e)
    {
        Response.Redirect("afterloggedinOU.aspx");
    }
    protected void canbook_Click(object sender, EventArgs e)
    {
        Response.Redirect("bookingOU.aspx");
    }
}