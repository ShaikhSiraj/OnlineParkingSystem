using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class checkdetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
    }
    protected void button_click(object sender, EventArgs e)
    {
        SqlConnection con;
        string connectionstring = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
        con = new SqlConnection(connectionstring);
        con.Open();

        SqlCommand cmdbr;
        SqlCommand cmdbm;
        SqlCommand cmdbw;

        string strbr = @"select COUNT(*) from bookingRegistration where booking_no='" + chebid.Text + "' ";
        string strbm = @"select COUNT(*) from bookingRegistrationMonthly where booking_no='" + chebid.Text + "' ";
        string strbw = @"select COUNT(*) from bookingRegistrationWeekly where booking_no='" + chebid.Text + "' ";

        cmdbr = new SqlCommand(strbr, con);
        cmdbm = new SqlCommand(strbm, con);
        cmdbw = new SqlCommand(strbw, con);

        int presencebr = Convert.ToInt32(cmdbr.ExecuteScalar());
        int presencebm = Convert.ToInt32(cmdbm.ExecuteScalar());
        int presencebw = Convert.ToInt32(cmdbw.ExecuteScalar());

        if (presencebr > 0)
        {

            norecord.Visible = false;
        }
        else if (presencebw > 0)
        {

            norecord.Visible = false;
        }
        else if (presencebm > 0)
        {

            norecord.Visible = false;
        }
        else
        {
            norecord.Visible = true;
        }

        con.Close();
    }
}

   

