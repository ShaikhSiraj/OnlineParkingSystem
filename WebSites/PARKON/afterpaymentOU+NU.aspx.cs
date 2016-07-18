using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using ASPSnippets.SmsAPI;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;

public partial class afterpaymentOU_NU : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] == null)
        {
            Response.Redirect("wlc.aspx");
        }
        if (!IsPostBack)
        {
            Session["bvehicleno"] = null;
            string email = Session["email"].ToString();
        string bookingcode = Session["bookingcode"].ToString();
        string name = Session["bname"].ToString();
        string phone = Session["bphone"].ToString();
        string msg = "Congratulations " + name + " your booking has been confirmed with booking id=" + bookingcode+" Please preserve it and produce it at your parking place"; 
      
            try
            {
                using (MailMessage mm = new MailMessage("onpark4@gmail.com", email))
                {
                    mm.Subject = "Booking Details";
                    mm.Body = "Hello " + name + " , Your booking has been confirmed with Booking No :" + bookingcode + " Please show your booking no at your parking place";

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
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Failed to Send an email to your registered Email Id check your Internet Connectivity and click Resend Email');", true);
            }

            
          
            bookingid.Text = bookingcode;
            this.bookingid.ForeColor = Color.Maroon;

            
        }
    }

    protected void afpayhome_Click(object sender, EventArgs e)
    {
        Response.Redirect("afterloggedinOU.aspx");
    }

    protected void afpaybook_Click(object sender, EventArgs e)
    {
        Response.Redirect("bookingOU.aspx");
    }

    protected void afresendemail_Click(object sender, EventArgs e)
    {
        string email = Session["email"].ToString();
        string bookingcode = Session["bookingcode"].ToString();
        string name = Session["bname"].ToString();
        string phone = Session["bphone"].ToString();
        string msg = "Congratulations " + name + " your booking has been confirmed with booking id=" + bookingcode + " Please preserve it and produce it at your parking place";
      

            try
            {
                using (MailMessage mm = new MailMessage("onpark4@gmail.com", email))
                {
                    mm.Subject = "Booking Details";
                    mm.Body = "Hello " + name + " , Your booking has been confirmed with Booking No  :" + bookingcode + " Please show your booking no at your parking place";

                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("onpark4@gmail.com", "9892155183");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
              //  emailtext.Text= "An Email has been sent to your registered email.";
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('An Email has been sent to your registered email.');", true);
                }
            }
            catch (Exception)
            {
          //  emailtext.Text = "Failed to Send an email to your registered Email Id Click   Resend Email    and check your Internet Connectivity";
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Failed to Send an email to your registered Email Id  check your Internet Connectivity and click Resend Email');", true);
            }
        }
}