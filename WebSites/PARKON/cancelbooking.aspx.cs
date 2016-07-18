using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using ASPSnippets.SmsAPI;
using System.IO;
using System.Net;
using System.Net.Mail;

public partial class cancelbooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        if (Session["email"] == null)
        {
            Response.Redirect("wlc.aspx");
        }
        if (!IsPostBack)
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
                //Response.Redirect("cancelbooking.aspx");
            }

            else if (presencebm > 0)
            {
                // Response.Redirect("cancelbooking.aspx");
            }
           else if (presencebw > 0)
            {
                //  Response.Redirect("cancelbooking.aspx");
            }
            else if (presencebc > 0)
            {
                Response.Redirect("afterloggedinOUnobooking.aspx");
            }
            else if (presencebcm > 0)
            {
                Response.Redirect("afterloggedinOUnobooking.aspx");
            }
            else if (presencebcw > 0)
            {
                Response.Redirect("afterloggedinOUnobooking.aspx");

            }
            else
            {
                Response.Redirect("afterloggedinNU.aspx");
            }
        }
    }
    //======================     submiit button Actions  =====================
    protected void submitclick(object sender, EventArgs e)
    {
        
        cancelledimage.Visible = false;
        dailygridview.Visible = true;
        monthlygridview.Visible = true;
        weeklygridview.Visible = true;
        warningimage.Visible = false;
        string email = Session["email"].ToString();
        SqlConnection con;
        string connectionstring = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
        con = new SqlConnection(connectionstring);
        con.Open();
        SqlCommand cmdbr;
        SqlCommand cmdbm;
        SqlCommand cmdbw;

        string togetbr = @"select COUNT(*) from bookingRegistration where booking_no='" + cbid.Text + "'";
        string togetbm = @"select COUNT(*) from bookingRegistrationMonthly where booking_no='" + cbid.Text + "'";
        string togetbw = @"select COUNT(*) from bookingRegistrationWeekly where booking_no='" + cbid.Text + "'";

        cmdbr = new SqlCommand(togetbr, con);
        cmdbm = new SqlCommand(togetbm, con);
        cmdbw = new SqlCommand(togetbw, con);

        int presencebr = Convert.ToInt16(cmdbr.ExecuteScalar());
        int presencebm = Convert.ToInt16(cmdbm.ExecuteScalar());
        int presencebw = Convert.ToInt16(cmdbw.ExecuteScalar());

        if (presencebr > 0)
        {
            SqlCommand cmdvalidatebr;
            string tovalidatebr = @"select COUNT(*) from bookingRegistration where email='" + email + "' and booking_no='" + cbid.Text + "' ";
            cmdvalidatebr = new SqlCommand(tovalidatebr, con);
            int presencevalidatebr = Convert.ToInt16(cmdvalidatebr.ExecuteScalar());
            if (presencevalidatebr > 0)
            {
                warningimage.Visible = false;
                cbcancel.Visible = true;
                cbcancel.Enabled = true;
                norecord.Visible = false;
                unsuccessfulcancelmsg.Text = "";
            }
            else
            {
                warningimage.Visible = true;
                unsuccessfulcancelmsg.Text = "You are not allowed to Cancel";
                this.unsuccessfulcancelmsg.ForeColor = Color.Red;
                cbcancel.Visible = true;
                cbcancel.Enabled = false;
                norecord.Visible = false;
            }
        }
        else if (presencebm > 0)
        {
            SqlCommand cmdvalidatebm;
            string tovalidatebm = @"select COUNT(*) from bookingRegistrationMonthly where email='" + email + "' and booking_no='" + cbid.Text + "' ";
            cmdvalidatebm = new SqlCommand(tovalidatebm, con);
            int presencevalidatebm = Convert.ToInt16(cmdvalidatebm.ExecuteScalar());
            if (presencevalidatebm > 0)
            {
                warningimage.Visible = false;
                cbcancel.Visible = true;
                cbcancel.Enabled = true;
                norecord.Visible = false;
                unsuccessfulcancelmsg.Text = "";
            }
            else
            {
                warningimage.Visible = true;
                unsuccessfulcancelmsg.Text = "You are not allowed to Cancel";
                this.unsuccessfulcancelmsg.ForeColor = Color.Red;
                cbcancel.Visible = true;
                cbcancel.Enabled = false;
                norecord.Visible = false;
            }
        }
        else if (presencebw > 0)
        {
            SqlCommand cmdvalidatebw;
            string tovalidatebw = @"select COUNT(*) from bookingRegistrationWeekly where email='" + email + "' and booking_no='" + cbid.Text + "' ";
            cmdvalidatebw = new SqlCommand(tovalidatebw, con);
            int presencevalidatebw = Convert.ToInt16(cmdvalidatebw.ExecuteScalar());
            if (presencevalidatebw > 0)
            {
                norecord.Visible = false;
                warningimage.Visible = false;
                cbcancel.Visible = true;
                cbcancel.Enabled = true;
                unsuccessfulcancelmsg.Text = "";

            }
            else
            {
                norecord.Visible = false;
                warningimage.Visible = true;
                unsuccessfulcancelmsg.Text = "You are not allowed to Cancel";
                this.unsuccessfulcancelmsg.ForeColor = Color.Red;
                cbcancel.Visible = true;
                cbcancel.Enabled = false;
            }
        }
        else
        {
            norecord.Visible = true;
            unsuccessfulcancelmsg.Text = "";
            warningimage.Visible = false;
            cbcancel.Visible = false;
            dailygridview.Visible = false;
            monthlygridview.Visible = false;
            weeklygridview.Visible = false;
            successfulcancelmsg.Visible = false;

        }
        con.Close();
    }
    //====================   Cancelling the booking   ===============
    protected void cbcancel_click(object sender, EventArgs e)
    {
      
        cbid.Text.ToUpper();
        norecord.Visible = false;
        warningimage.Visible = false;
        string email = Session["email"].ToString();
        SqlConnection con;
        string connectionstring = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
        con = new SqlConnection(connectionstring);
        con.Open();
        SqlCommand cmdbr;
        SqlCommand cmdbm;
        SqlCommand cmdbw;
        SqlCommand cmdname;

        string togetbr = @"select COUNT(*) from bookingRegistration where email='" + email + "' and booking_no='" + cbid.Text + "'";
        string togetbm = @"select COUNT(*) from bookingRegistrationMonthly where email='" + email + "' and booking_no='" + cbid.Text + "'";
        string togetbw = @"select COUNT(*) from bookingRegistrationWeekly where email='" + email + "' and booking_no='" + cbid.Text + "'";
        string togetname = @"select Name from reg WHERE boo='"+email+"'";

        cmdbr = new SqlCommand(togetbr, con);
        cmdbm = new SqlCommand(togetbm, con);
        cmdbw = new SqlCommand(togetbw, con);
        cmdname = new SqlCommand(togetname, con);

        string nameofcust = cmdname.ExecuteScalar().ToString();

        int presencebr = Convert.ToInt16(cmdbr.ExecuteScalar());
        int presencebm = Convert.ToInt16(cmdbm.ExecuteScalar());
        int presencebw = Convert.ToInt16(cmdbw.ExecuteScalar());

        if (presencebr > 0)
        {
            try
            {

                SqlCommand tocopyrow;
                SqlCommand todeleterowfrombooked;

                string commandtocopyrow = @"insert into bookingCancelled select * from bookingRegistration where booking_no='" + cbid.Text + "' and email='" + email + "'";
                string commandtodeleterow = @"delete from bookingRegistration where booking_no='" + cbid.Text + "'";


                tocopyrow = new SqlCommand(commandtocopyrow, con);
                todeleterowfrombooked = new SqlCommand(commandtodeleterow, con);
                int cr = tocopyrow.ExecuteNonQuery();
                if (cr > 0)
                {

                    int dr = todeleterowfrombooked.ExecuteNonQuery();

                    if (dr > 0)
                    {
                      
                        successfulcancelmsg.Visible = true;
                        cancelledimage.Visible = true;
                        successfulcancelmsg.Text = "Booking Cancelled For :" + cbid.Text;
                        dailygridview.Visible = false;
                        cbcancel.Visible = false;
                        cbcancel.Enabled = false;
//  ========   Sending an email  ====
                        try
                        {
                            using (MailMessage mm = new MailMessage("onpark4@gmail.com", email))
                            {
                                mm.Subject = "Booking Cancelled";
                                mm.Body = "Hello " + nameofcust + " , Your booking has been cancelled with Booking No :" + cbid.Text + " and your amount has been refunded to your account ,Thank You";

                                mm.IsBodyHtml = false;
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = "smtp.gmail.com";
                                smtp.EnableSsl = true;
                                NetworkCredential NetworkCred = new NetworkCredential("onpark4@gmail.com", "9892155183");
                                smtp.UseDefaultCredentials = true;
                                smtp.Credentials = NetworkCred;
                                smtp.Port = 587;
                                smtp.Send(mm);
                                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('An Email has been sent to your registered email.');", true);
                            }
                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Failed to Send email check your Internet Connectivity');", true);
                        }

                    }
                    else
                    {
                        unsuccessfulcancelmsg.Visible = true;
                        unsuccessfulcancelmsg.Text = "Failed to cancel booking for :" + cbid.Text + " please retry";
                        dailygridview.Visible = false;
                        successfulcancelmsg.Visible = false;
                        cancelledimage.Visible = false;
                        cbcancel.Visible = false;
                        cbcancel.Enabled = false;

                    }
                }
                else
                {
                    unsuccessfulcancelmsg.Visible = true;
                    unsuccessfulcancelmsg.Text = "Failed to cancel booking for :" + cbid.Text + " please retry";
                    dailygridview.Visible = false;
                    successfulcancelmsg.Visible = false;
                    cancelledimage.Visible = false;
                    cbcancel.Visible = false;
                    cbcancel.Enabled = false;
                }

            }

            catch (Exception)
            { }
        }
        else if (presencebm > 0)
        {
            try
            {

                SqlCommand tocopyrowbm;
                SqlCommand todeleterowfrombookedbm;

                string commandtocopyrowbm = @"insert into bookingCancelledMonthly select * from bookingRegistrationMonthly where booking_no='" + cbid.Text + "' and email='" + email + "'";
                string commandtodeleterowbm = @"delete from bookingRegistrationMonthly where booking_no='" + cbid.Text + "'";


                tocopyrowbm = new SqlCommand(commandtocopyrowbm, con);
                todeleterowfrombookedbm = new SqlCommand(commandtodeleterowbm, con);
                int crbm = tocopyrowbm.ExecuteNonQuery();
                if (crbm > 0)
                {

                    int drbm = todeleterowfrombookedbm.ExecuteNonQuery();

                    if (drbm > 0)
                    {
                        
                        successfulcancelmsg.Visible = true;
                        cancelledimage.Visible = true;
                        successfulcancelmsg.Text = "Booking Cancelled For :" + cbid.Text;
                        dailygridview.Visible = false;
                        cbcancel.Visible = false;
                        cbcancel.Enabled = false;
                        //   ============    Sending  an email to email id   
                        try
                        {
                            using (MailMessage mm = new MailMessage("onpark4@gmail.com", email))
                            {
                                mm.Subject = "Booking Cancelled";
                                mm.Body = "Hello " + nameofcust + " , Your booking has been cancelled with Booking No :" + cbid.Text + " Your amount has been refunded to your account ,Thank You";

                                mm.IsBodyHtml = false;
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = "smtp.gmail.com";
                                smtp.EnableSsl = true;
                                NetworkCredential NetworkCred = new NetworkCredential("onpark4@gmail.com", "9892155183");
                                smtp.UseDefaultCredentials = true;
                                smtp.Credentials = NetworkCred;
                                smtp.Port = 587;
                                smtp.Send(mm);
                                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('An Email has been sent to your registered email.');", true);
                            }
                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Failed to Send email check your Internet Connectivity');", true);
                        }

                    }
                    else
                    {
                        unsuccessfulcancelmsg.Visible = true;
                        unsuccessfulcancelmsg.Text = "Failed to cancel booking for :" + cbid.Text + " please retry";
                        dailygridview.Visible = false;
                        successfulcancelmsg.Visible = false;
                        cancelledimage.Visible = false;
                        cbcancel.Visible = false;
                        cbcancel.Enabled = false;

                    }
                }
                else
                {
                    unsuccessfulcancelmsg.Visible = true;
                    unsuccessfulcancelmsg.Text = "Failed to cancel booking for :" + cbid.Text + " please retry";
                    dailygridview.Visible = false;
                    successfulcancelmsg.Visible = false;
                    cancelledimage.Visible = false;
                    cbcancel.Visible = false;
                    cbcancel.Enabled = false;
                }

            }
            catch (Exception)
            { }
        }
        else if (presencebw > 0)
        {
            try
            {

                SqlCommand tocopyrowbw;
                SqlCommand todeleterowfrombookedbw;

                string commandtocopyrowbw = @"insert into bookingCancelledWeekly select * from bookingRegistrationWeekly where booking_no='" + cbid.Text + "' and email='" + email + "'";
                string commandtodeleterowbw = @"delete from bookingRegistrationWeekly where booking_no='" + cbid.Text + "'";


                tocopyrowbw = new SqlCommand(commandtocopyrowbw, con);
                todeleterowfrombookedbw = new SqlCommand(commandtodeleterowbw, con);
                int crbw = tocopyrowbw.ExecuteNonQuery();
                if (crbw > 0)
                {

                    int drbw = todeleterowfrombookedbw.ExecuteNonQuery();

                    if (drbw > 0)
                    {
                        successfulcancelmsg.Visible = true;
                        cancelledimage.Visible = true;
                        successfulcancelmsg.Text = "Booking Cancelled For :" + cbid.Text;
                        dailygridview.Visible = false;
                        cbcancel.Visible = false;
                        cbcancel.Enabled = false;
                        //  ===== Sending Email to Email    =========
                        try
                        {
                            using (MailMessage mm = new MailMessage("onpark4@gmail.com", email))
                            {
                                mm.Subject = "Booking Cancelled";
                                mm.Body = "Hello " + nameofcust + " , Your booking has been cancelled with Booking No :" + cbid.Text + " Your amount has been refunded to your account ,Thank You";

                                mm.IsBodyHtml = false;
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = "smtp.gmail.com";
                                smtp.EnableSsl = true;
                                NetworkCredential NetworkCred = new NetworkCredential("onpark4@gmail.com", "9892155183");
                                smtp.UseDefaultCredentials = true;
                                smtp.Credentials = NetworkCred;
                                smtp.Port = 587;
                                smtp.Send(mm);
                                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('An Email has been sent to your registered email.');", true);
                            }
                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Failed to Send email check your Internet Connectivity');", true);
                        }

                    }
                    else
                    {
                        unsuccessfulcancelmsg.Visible = true;
                        unsuccessfulcancelmsg.Text = "Failed to cancel booking for :" + cbid.Text + " please retry";
                        dailygridview.Visible = false;
                        successfulcancelmsg.Visible = false;
                        cancelledimage.Visible = false;
                        cbcancel.Visible = false;
                        cbcancel.Enabled = false;

                    }
                }
                else
                {
                    unsuccessfulcancelmsg.Visible = true;
                    unsuccessfulcancelmsg.Text = "Failed to cancel booking for :" + cbid.Text + " please retry";
                    dailygridview.Visible = false;
                    successfulcancelmsg.Visible = false;
                    cancelledimage.Visible = false;
                    cbcancel.Visible = false;
                    cbcancel.Enabled = false;
                    warningimage.Visible = false;

                }

            }
            catch (Exception)
            { }
        }
        else
        {
            unsuccessfulcancelmsg.Text = "Failed to Cancel Booking for Booking No" + cbid.Text;
            dailygridview.Visible = false;
            monthlygridview.Visible = false;
            weeklygridview.Visible = false;
            cancelledimage.Visible = false;
        }

        
        SqlCommand toredirect;
        SqlCommand toredirectbm;
        SqlCommand toredirectbw;

        string commandtoredirect = @"select COUNT(*) from bookingRegistration where email='" + email + "'";
        string commandtoredirectbm = @"select COUNT(*) from bookingRegistrationMonthly where email='" + email + "'";
        string commandtoredirectbw = @"select COUNT(*) from bookingRegistrationWeekly where email='" + email + "'";
        toredirect = new SqlCommand(commandtoredirect, con);
        toredirectbm = new SqlCommand(commandtoredirectbm, con);
        toredirectbw = new SqlCommand(commandtoredirectbw, con);

        int presenceofemail = Convert.ToInt16(toredirect.ExecuteScalar());
        int presenceofemailbm = Convert.ToInt32(toredirectbm.ExecuteScalar());
        int presenceofemailbw = Convert.ToInt16(toredirectbw.ExecuteScalar());

        if (presenceofemail > 0)
        {
            //successfulcancelmsg.Text = "Booking Cancelled For :" + cbid.Text;
            //this.successfulcancelmsg.ForeColor = Color.Green;
            //cancelledimage.Visible = true;

        }
        else if (presenceofemailbm > 0)
        {
            //successfulcancelmsg.Text = "Booking Cancelled For :" + cbid.Text;
            //this.successfulcancelmsg.ForeColor = Color.Green;
            //cancelledimage.Visible = true;
        }
        else if (presenceofemailbw > 0)
        {
            //successfulcancelmsg.Text = "Booking Cancelled For :" + cbid.Text;
            //this.successfulcancelmsg.ForeColor = Color.Green;
            //cancelledimage.Visible = true;
        }
        else
        {
            Response.Redirect("cancelack.aspx?bookingno=" + cbid.Text);
        }
        con.Close();
    }
}
