using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;

public partial class historyack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] == null)
        {
            Response.Redirect("wlc.aspx");
        }
        string bookingcode = Request.QueryString["bookingno"].ToString();
        string bookingnotopass = bookingcode.ToUpper();
        try
        {
            string email = Session["email"].ToString();
        SqlConnection con;
        SqlCommand cmdname;
        string togetname= @"select Name from reg WHERE boo='" + email + "'";
        string connectionstring = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
        con = new SqlConnection(connectionstring);
        con.Open();

        cmdname = new SqlCommand(togetname,con);
        string nameofcust = cmdname.ExecuteScalar().ToString();


       
            using (MailMessage mm = new MailMessage("onpark4@gmail.com", email))
            {
                mm.Subject = "Booking Cancelled";
                mm.Body = "Hello " + nameofcust + " , Your booking has been cancelled with Booking No :" + bookingnotopass + " Your amount has been refunded to your account ,Thank You";

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
        if (Request.QueryString["bookingno"] != null)
        {
            Label1.Text = "Booking Cancelled for Booking Number  :";
            Label2.Text = bookingnotopass;
            this.Label2.ForeColor = Color.Purple;
        }
        else
        {
            Response.Write("exception");
        }
    }

    protected void home_Click(object sender, EventArgs e)
    {
        Response.Redirect("afterloggedinOUnobooking.aspx");
    }

    protected void book_Click(object sender, EventArgs e)
    {
        Response.Redirect("bookingOUnobooking.aspx");
    }
}