using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class historynobooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
        if (Session["email"] == null)
        {
            Response.Redirect("wlc.aspx");
        }
        try
        {
            string email = Session["email"].ToString();
            SqlConnection con;
            string connectionString = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
            con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmdbr;
            SqlCommand cmdbm;
            SqlCommand cmdbw;
            SqlCommand cmdbc;
            SqlCommand cmdbcm;
            SqlCommand cmdbcw;

            string togetbr = @"select COUNT(*) from bookingRegistration where email='" + email + "'";
            string togetbm = @"select COUNT(*) from bookingRegistrationMonthly where email='" + email + "'";
            string togetbw = @"select COUNT(*) from bookingRegistrationWeekly where email='" + email + "'";
            string togetbc = @"select COUNT(*) from bookingCancelled where email='" + email + "'";
            string togetbcm = @"select COUNT(*) from bookingCancelledMonthly where email='" + email + "'";
            string togetbcw = @"select COUNT(*) from bookingCancelledWeekly where email='" + email + "'";

            cmdbr = new SqlCommand(togetbr, con);
            cmdbm = new SqlCommand(togetbm, con);
            cmdbw = new SqlCommand(togetbw, con);
            cmdbc = new SqlCommand(togetbc, con);
            cmdbcm = new SqlCommand(togetbcm, con);
            cmdbcw = new SqlCommand(togetbcw, con);

            int presencebr = Convert.ToInt16(cmdbr.ExecuteScalar());
            int presencebm = Convert.ToInt16(cmdbm.ExecuteScalar());
            int presencebw = Convert.ToInt16(cmdbw.ExecuteScalar());
            int presencebc = Convert.ToInt16(cmdbc.ExecuteScalar());
            int presencebcm = Convert.ToInt16(cmdbcm.ExecuteScalar());
            int presencebcw = Convert.ToInt16(cmdbcw.ExecuteScalar());

            if (presencebr > 0)
            {
                Response.Redirect("history.aspx");
            }
            else if (presencebm > 0)
            {
                Response.Redirect("history.aspx");
            }
            else if (presencebw > 0)
            {
                Response.Redirect("history.aspx");
            }
            else if (presencebc > 0)
            {
                //Response.Redirect("historynobooking.aspx");
            }
            else if (presencebcm > 0)
            {
               // Response.Redirect("historynobooking.aspx");
            }
            else if (presencebcw > 0)
            {
               // Response.Redirect("historynobooking.aspx");
            }
            else
            {
                Response.Redirect("afterloggedinNU.aspx");
            }
            con.Close();
        }
        catch (Exception)
        {

        }
    }
}