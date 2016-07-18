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
using System.IO;
using System.Net;
using System.Net.Mail;
public partial class wbcbl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        
    }

    protected void login_Click(object sender, EventArgs e)
    {
        try
        {
            loerror.Text = "";
            SqlConnection con;
            string connectionString = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
            con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            String str = @"select COUNT(*) from reg WHERE boo COLLATE Latin1_General_CS_AS ='" + loemail.Text + "' and Password COLLATE Latin1_General_CS_AS ='" + lopass.Text + "'";

            cmd = new SqlCommand(str, con);
            int r;
            r = Convert.ToInt32(cmd.ExecuteScalar());

            if (r > 0)
            {
                Session["email"] = loemail.Text;
                Session["password"] = lopass.Text;

                SqlCommand cmdbr;
                SqlCommand cmdbm;
                SqlCommand cmdbw;
                SqlCommand cmdbc;
                SqlCommand cmdbcm;
                SqlCommand cmdbcw;

                string togetbr = @"select COUNT(*) from bookingRegistration where email='" + loemail.Text + "'";
                string togetbm = @"select COUNT(*) from bookingRegistrationMonthly where email='" + loemail.Text + "'";
                string togetbw = @"select COUNT(*) from bookingRegistrationWeekly where email='" + loemail.Text + "'";
                string togetbc = @"select COUNT(*) from bookingCancelled where email='" + loemail.Text + "'";
                string togetbcm = @"select COUNT(*) from bookingCancelledMonthly where email='" + loemail.Text + "'";
                string togetbcw = @"select COUNT(*) from bookingCancelledWeekly where email='" + loemail.Text + "'";

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
                    Response.Redirect("bookingOU.aspx");
                }
                else if (presencebm > 0)
                {
                    Response.Redirect("bookingOU.aspx");
                }
                else if (presencebw > 0)
                {
                    Response.Redirect("bookingOU.aspx");
                }
                else if (presencebc > 0)
                {
                    Response.Redirect("bookingOUnobooking.aspx");
                }
                else if (presencebcm > 0)
                {
                    Response.Redirect("bookingOUnobooking.aspx");
                }
                else if (presencebcw > 0)
                {
                    Response.Redirect("bookingOUnobooking.aspx");
                }
                else
                {
                    Response.Redirect("bookingNU.aspx");
                }

            }

            else
            {
                loerror.Text = "Invalid Email ID or Password";
                this.loerror.ForeColor = Color.Red;
            }
            con.Close();
        }





        catch
        {
            loerror.Text = "Login Unsuccessful Please Retry";
            this.loerror.ForeColor = Color.Red;
        }
    }
    protected void register1_Click(object sender, EventArgs e)
    {

        try
        {
            reerror.Text = "";
            SqlConnection con;
            

            //con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\AHMED\Documents\Visual Studio 2015\WebSites\PARKON\App_Data\project.mdf';Integrated Security=True;");
            //con.Open();

            //SqlCommand cmd;
            //String str = @"insert into reg (boo,Name,Password) values  ('" + reemail.Text + "','" + rename.Text + "','" + repass.Text + "')";
            string connectionString = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
            con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SPinsertreg", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", reemail.Text);
            cmd.Parameters.AddWithValue("@name", rename.Text);
            cmd.Parameters.AddWithValue("@password", repass.Text);
           
          //  cmd = new SqlCommand(str, con);
            int r = cmd.ExecuteNonQuery();

            if (r > 0)
            {
                Session["email"] = reemail.Text;
                Session["password"] = repass.Text;

                Response.Redirect("bookingNU.aspx");


            }

            else
            {
                reerror.Text = "Please Retry Registration Unsuccessful";
            }
            con.Close();

        }
        catch
        {
            reerror.Text = "email id registered please try different";
        }
    }
    protected void forgot(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        LinkButton1.Enabled = false;
    }


    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        try
        {


            SqlConnection con;
            SqlCommand cmd;
            SqlCommand cmdname;
            string togetpassword = @"select Password from reg where boo='" + forgotpasstext.Text + "'";
            string togetname = @"select Name from reg where boo='" + forgotpasstext.Text + "'";

            string cs = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand(togetpassword, con);
            cmdname = new SqlCommand(togetname, con);
            string name = cmdname.ExecuteScalar().ToString();
            string password1 = cmd.ExecuteScalar().ToString();
            try
            {
                using (MailMessage mm = new MailMessage("onpark4@gmail.com", forgotpasstext.Text))
                {
                    mm.Subject = "Password Request";
                    mm.Body = "Hello " + name + " your ParkON Password is :" + password1;

                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("onpark4@gmail.com", "9892155183");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('An Email has been sent to " + forgotpasstext.Text + "');", true);
                }
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Failed to Send email check your Internet Connectivity');", true);
            }
            con.Close();

        }

        catch (Exception)
        {
            ferror.Text = "Email Not Found";
        }

    }



    protected void forgotpasstext_TextChanged(object sender, EventArgs e)
    {
        ferror.Text = " ";
    }
}