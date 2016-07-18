using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;

public partial class usersettingsNU : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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
                Response.Redirect("usersettings.aspx");
            }
            else if (presencebm > 0)
            {
                Response.Redirect("usersettings.aspx");
            }
            else if (presencebw > 0)
            {
                Response.Redirect("usersettings.aspx");
            }
            else if (presencebc > 0)
            {
                Response.Redirect("usersettingsOUnobooking.aspx");
            }
            else if (presencebcm > 0)
            {
                Response.Redirect("usersettingsOUnobooking.aspx");
            }
            else if (presencebcw > 0)
            {
                Response.Redirect("usersettingsOUnobooking.aspx");
            }
            else
            {
                // Response.Redirect("usersettingsNU.aspx");
            }
            con.Close();
        }
        catch (Exception)
        {

        }
    }

    protected void uspass_Click(object sender, EventArgs e)
    {
        //string email = Request.Cookies["email"].Value;---not working
        string email = Session["email"].ToString();
        string password = Session["password"].ToString();
        string oldpassword = usoldpass.Text;
        try
        {

            usperror.Text = "";
            SqlConnection con;
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string connectionString = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
            con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            // SqlCommand cmdp;
            String str = @"update reg set Password ='" + usconnewpass.Text + "' where boo='" + email + "' and Password COLLATE Latin1_General_CS_AS  ='" + usoldpass.Text + "'";
            String strp = @"select Password from reg where boo='" + email + "'";
            cmd = new SqlCommand(str, con);
            //cmdp = new SqlCommand(strp,con);
            da = new SqlDataAdapter(strp, con);
            da.Fill(ds);
            string pass = ds.Tables[0].Rows[0][0].ToString();
            if (pass == oldpassword)
            {

                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {

                    usperror.Text = "Password Changed Succesfully";
                    useerror.Text = "";
                    this.usperror.ForeColor = Color.Maroon;



                }

                else
                {
                    usperror.Text = "Try Entering your Correct Old Password ";
                    this.usperror.ForeColor = Color.Red;
                }


            }
            else
            {
                usperror.Text = "Old Password Not Proper";
                this.usperror.ForeColor = Color.Red;
            }
            string newpass = usconnewpass.Text;
            password.Replace(password, newpass);
            con.Close();


        }
        catch (Exception boom)
        {
            Response.Write(boom.Message);
        }
    }




    protected void usemail_Click(object sender, EventArgs e)
    {
        string email = Session["email"].ToString();
        string oldemail = usemailold.Text;
        try
        {

            useerror.Text = "";
            SqlConnection con;
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string connectionString = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
            con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            // SqlCommand cmdp;
            String str = @"update reg set Name='" + usemailnew.Text + "' where boo='" + email + "' ";
            String strp = @"select Name from reg where boo='" + email + "'";
            cmd = new SqlCommand(str, con);
            //cmdp = new SqlCommand(strp,con);
            da = new SqlDataAdapter(strp, con);
            da.Fill(ds);
            string pass = ds.Tables[0].Rows[0][0].ToString();
            if (pass == oldemail)
            {

                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {

                    string msg = "Name changed successfully from  " + usemailold.Text + "  to  " + usemailnew.Text;
                    useerror.Text = msg;
                    this.useerror.ForeColor = Color.Green;
                    usemailold.Text = "";
                    usemailnew.Text = "";
                    usperror.Text = "";


                }

                else
                {
                    useerror.Text = "Please Retry ";
                }


            }
            else
            {
                usperror.Text = "Old Name Not Proper";
                this.useerror.ForeColor = Color.Red;
            }

            con.Close();


        }
        catch (Exception boom)
        {
            Response.Write(boom.Message);
        }
    }
}


