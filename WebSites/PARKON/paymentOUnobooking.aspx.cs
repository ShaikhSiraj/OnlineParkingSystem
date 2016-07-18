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

public partial class paymentOUnobooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(this.paynow);
        paynow.Enabled = false;

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
                Response.Redirect("paymentOU.aspx");
            }
            else if (presencebm > 0)
            {
                Response.Redirect("paymentOU.aspx");
            }
            else if (presencebw > 0)
            {
                 Response.Redirect("paymentOU.aspx");
            }
            else if (presencebc > 0)
            {
               // Response.Redirect("paymentOUnobooking.aspx");
            }
            else if (presencebcm > 0)
            {
                //Response.Redirect("paymentOUnobooking.aspx");
            }
            else if (presencebcw > 0)
            {
              //  Response.Redirect("paymentOUnobooking.aspx");
            }
            else
            {
                Response.Redirect("paymentNU.aspx");
            }
            con.Close();
        }
        catch (Exception)
        {

        }
    }
    protected void notempty(object sender, EventArgs e)
    {
        cash.Text = "";
        if (paycardno.Text == "" && paymonth.Text == "" && payyear.Text == "" && paycvv.Text == "")
        {
            paynow.Enabled = false;
        }
        else if (paycardno.Text == "")
        {
            paynow.Enabled = false;
        }
        else if (paymonth.Text == "")
        {
            paynow.Enabled = false;
        }
        else if (payyear.Text == "")
        {
            paynow.Enabled = false;
        }
        else if (paycvv.Text == "")
        {
            paynow.Enabled = false;
        }
        else
        {
            paynow.Enabled = true;
        }
    }

    protected void paynow_Click(object sender, EventArgs e)
    {
        if (Session["bvehicleno"] == null)
        {
            Response.Redirect("bookingOU.aspx");
        }
        SqlConnection con;
        string connectionString = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
        con = new SqlConnection(connectionString);
        con.Open();
        SqlCommand cvalid;
        string tochechkcardvalid = @"select COUNT(*) from card where cardno='" + paycardno.Text + "' AND month='" + paymonth.Text + "'AND year='" + payyear.Text + "' AND security='" + paycvv.Text + "' ";
        cvalid = new SqlCommand(tochechkcardvalid, con);
        int presenceofcard = Convert.ToInt16(cvalid.ExecuteScalar());
        if (presenceofcard > 0)
        {
            string name = Session["bname"].ToString();
            string phone = Session["bphone"].ToString();
            string typeofvehicle = Session["typeofvehicle"].ToString();
            string vehicleno = Session["bvehicleno"].ToString();
            string date = Session["bdate"].ToString();
            string begintime = Session["begintime"].ToString();
            string terminatetime = Session["terminatetime"].ToString();
            string duration = Session["timeduration"].ToString();
            string selectplace = Session["selectplace"].ToString();
            string actualplace = Session["actualplace"].ToString();
            int price = (int)Session["cost"];
            string email = Session["email"].ToString();
            name = name.ToUpper();
            vehicleno = vehicleno.ToUpper();


            DateTime datetobepassed = Convert.ToDateTime(date);
            datetobepassed.ToShortDateString();




            //===================    monthly booking insert    =============
            if (Session["weekly"] == null && Session["daily"] == null)
            //  if (Session["monthly"] != null)
            {
                string enddate = Session["enddate"].ToString();
                DateTime enddatetobepassed = Convert.ToDateTime(enddate);
                enddatetobepassed.ToShortDateString();

                try
                {
                    SqlCommand cmdMonthly = new SqlCommand("BRMinsert", con);
                    cmdMonthly.CommandType = CommandType.StoredProcedure;
                    cmdMonthly.Parameters.AddWithValue("@email", email);
                    cmdMonthly.Parameters.AddWithValue("@name", name);
                    cmdMonthly.Parameters.AddWithValue("@phone_no", phone);
                    cmdMonthly.Parameters.AddWithValue("@type_of_vehicle", typeofvehicle);
                    cmdMonthly.Parameters.AddWithValue("@vehicle_No", vehicleno);
                    cmdMonthly.Parameters.AddWithValue("@start_date", datetobepassed);
                    cmdMonthly.Parameters.AddWithValue("@end_date", enddatetobepassed);
                    cmdMonthly.Parameters.AddWithValue("@start_time", begintime);
                    cmdMonthly.Parameters.AddWithValue("@end_time", terminatetime);
                    cmdMonthly.Parameters.AddWithValue("@place", selectplace);
                    cmdMonthly.Parameters.AddWithValue("@location", actualplace);
                    cmdMonthly.Parameters.AddWithValue("@cost", price);


                    SqlParameter outputparametermonthly = new SqlParameter();
                    outputparametermonthly.ParameterName = "@Bid";
                    outputparametermonthly.SqlDbType = System.Data.SqlDbType.Int;
                    outputparametermonthly.Direction = System.Data.ParameterDirection.Output;
                    cmdMonthly.Parameters.Add(outputparametermonthly);
                    SqlParameter outputparametermonthly1 = new SqlParameter();
                    outputparametermonthly1.ParameterName = "@booking_no";
                    outputparametermonthly1.SqlDbType = System.Data.SqlDbType.VarChar;
                    outputparametermonthly1.Direction = System.Data.ParameterDirection.Output;
                    cmdMonthly.Parameters.Add(outputparametermonthly1);
                    outputparametermonthly1.Size = 50;

                    int monthlyinsert = cmdMonthly.ExecuteNonQuery();



                    if (monthlyinsert > 0)
                    {
                        string bookingcodemonthly = outputparametermonthly1.Value.ToString();
                        SqlCommand cmdmonthly;

                        string toextractbookingnomonthly = @"select [booking_no] from bookingRegistrationMonthly where Bid='" + bookingcodemonthly + "'";
                        cmdmonthly = new SqlCommand(toextractbookingnomonthly, con);
                        string executemonthly = cmdmonthly.ExecuteScalar().ToString();
                        Session["bookingcode"] = executemonthly;
                        //Session["bookingcodemonthly"] = bookingcodemonthly;
                        Response.Redirect("afterpaymentOU+NU.aspx");


                    }
                    else
                    {
                        cash.Text = "payment Cant be done please retry";
                    }


                }
                catch (Exception boom)
                {
                    Response.Write(boom.Message);
                }

                //Response.Write("MOnthly PAssed");
                //Response.Write(enddatetobepassed);
            }


            //============== insert of weekly   =================
            else if (Session["monthly"] == null && Session["daily"] == null)
            //  else if (Session["weekly"] != null)
            {
                string enddate = Session["enddate"].ToString();
                DateTime enddatetobepassed = Convert.ToDateTime(enddate);
                enddatetobepassed.ToShortDateString();

                try
                {
                    SqlCommand cmdWeekly = new SqlCommand("BRWinsert", con);
                    cmdWeekly.CommandType = CommandType.StoredProcedure;
                    cmdWeekly.Parameters.AddWithValue("@email", email);
                    cmdWeekly.Parameters.AddWithValue("@name", name);
                    cmdWeekly.Parameters.AddWithValue("@phone_no", phone);
                    cmdWeekly.Parameters.AddWithValue("@type_of_vehicle", typeofvehicle);
                    cmdWeekly.Parameters.AddWithValue("@vehicle_No", vehicleno);
                    cmdWeekly.Parameters.AddWithValue("@start_date", datetobepassed);
                    cmdWeekly.Parameters.AddWithValue("@end_date", enddatetobepassed);
                    cmdWeekly.Parameters.AddWithValue("@start_time", begintime);
                    cmdWeekly.Parameters.AddWithValue("@end_time", terminatetime);
                    cmdWeekly.Parameters.AddWithValue("@place", selectplace);
                    cmdWeekly.Parameters.AddWithValue("@location", actualplace);
                    cmdWeekly.Parameters.AddWithValue("@cost", price);


                    SqlParameter outputparameterweekly = new SqlParameter();
                    outputparameterweekly.ParameterName = "@Bid";
                    outputparameterweekly.SqlDbType = System.Data.SqlDbType.Int;
                    outputparameterweekly.Direction = System.Data.ParameterDirection.Output;
                    cmdWeekly.Parameters.Add(outputparameterweekly);
                    SqlParameter outputparameterweekly1 = new SqlParameter();
                    outputparameterweekly1.ParameterName = "@booking_no";
                    outputparameterweekly1.SqlDbType = System.Data.SqlDbType.VarChar;
                    outputparameterweekly1.Direction = System.Data.ParameterDirection.Output;
                    cmdWeekly.Parameters.Add(outputparameterweekly1);
                    outputparameterweekly1.Size = 50;

                    int weeklyinsert = cmdWeekly.ExecuteNonQuery();



                    if (weeklyinsert > 0)
                    {
                        string bookingcodeweekly = outputparameterweekly1.Value.ToString();

                        SqlCommand cmdweekly;
                        string toextractbookingnoweekly = @"select [booking_no] from bookingRegistrationWeekly where Bid='" + bookingcodeweekly + "'";
                        cmdweekly = new SqlCommand(toextractbookingnoweekly, con);
                        string executeweekly = cmdweekly.ExecuteScalar().ToString();
                        Session["bookingcode"] = executeweekly;
                        //Session["bookingcodeweekly"] = bookingcodeweekly;
                        Response.Redirect("afterpaymentOU+NU.aspx");


                    }
                    else
                    {
                        cash.Text = "payment Cant be done please retry";
                    }


                }
                catch (Exception boom)
                {
                    Response.Write(boom.Message);
                }


                //Response.Write("Weekly Passed");
                //Response.Write(enddatetobepassed);
            }

            //=====================   insert of daily    ====================
            else if (Session["monthly"] == null && Session["weekly"] == null)
            // else if (Session["daily"] != null)
            {
                try
                {
                    SqlCommand cmdDaily = new SqlCommand("BRinsert", con);
                    cmdDaily.CommandType = CommandType.StoredProcedure;
                    cmdDaily.Parameters.AddWithValue("@email", email);
                    cmdDaily.Parameters.AddWithValue("@name", name);
                    cmdDaily.Parameters.AddWithValue("@phone_no", phone);
                    cmdDaily.Parameters.AddWithValue("@type_of_vehicle", typeofvehicle);
                    cmdDaily.Parameters.AddWithValue("@vehicle_No", vehicleno);
                    cmdDaily.Parameters.AddWithValue("@date", datetobepassed);
                    cmdDaily.Parameters.AddWithValue("@start_time", begintime);
                    cmdDaily.Parameters.AddWithValue("@end_time", terminatetime);
                    cmdDaily.Parameters.AddWithValue("@place", selectplace);
                    cmdDaily.Parameters.AddWithValue("@location", actualplace);
                    cmdDaily.Parameters.AddWithValue("@cost", price);


                    SqlParameter outputparameterdaily = new SqlParameter();
                    outputparameterdaily.ParameterName = "@Bid";
                    outputparameterdaily.SqlDbType = System.Data.SqlDbType.Int;
                    outputparameterdaily.Direction = System.Data.ParameterDirection.Output;
                    cmdDaily.Parameters.Add(outputparameterdaily);
                    SqlParameter outputparameterdaily1 = new SqlParameter();
                    outputparameterdaily1.ParameterName = "@booking_no";
                    outputparameterdaily1.SqlDbType = System.Data.SqlDbType.VarChar;
                    outputparameterdaily1.Direction = System.Data.ParameterDirection.Output;
                    cmdDaily.Parameters.Add(outputparameterdaily1);
                    outputparameterdaily1.Size = 50;

                    int insertdaily = cmdDaily.ExecuteNonQuery();



                    if (insertdaily > 0)
                    {
                        string bookingcodedaily = outputparameterdaily1.Value.ToString();

                        SqlCommand cmddaily;
                        string toextractbookingnodaily = @"select [booking_no] from bookingRegistration where Bid='" + bookingcodedaily + "'";
                        cmddaily = new SqlCommand(toextractbookingnodaily, con);
                        string executedaily = cmddaily.ExecuteScalar().ToString();
                        Session["bookingcode"] = executedaily;
                        //Session["bookingcodedaily"] = bookingcodedaily;
                        Response.Redirect("afterpaymentOU+NU.aspx");
                    }
                    else
                    {
                        cash.Text = "payment Cant be done please retry";
                    }
                }
                catch (Exception boom)
                {
                    Response.Write(boom.Message);
                }
                //Response.Write("DAily PAssed");
            }
            con.Close();
            //  Response.Write(name + "   " + phone + "  " + typeofvehicle + "   " + vehicleno + "   " + date + "   " + begintime + "    " + terminatetime + "   " + price + " " + selectplace + " " + actualplace + "" + duration+" "+email);

        }
        else
        {
            cash.Text = "Invalid Card";
            this.cash.ForeColor = Color.Red;
            paynow.Enabled = false;
        }
    }
}
