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
using System.Globalization;
using System.IO;

public partial class bookingOU : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(this.bbook);
        if (!IsPostBack)
            Application["parkingspace"] = 15;
        Application["parkingspacemonthly"] = 30;
        Application["parkingspaceweekly"] = 25;
        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        if (Session["email"] == null)
        {
            Response.Redirect("wbcbl.aspx");
        }
        if (!IsPostBack)
        {
            bdate.Text = DateTime.Now.Date.ToShortDateString();

            string email = Session["email"].ToString();

            if (!IsPostBack)
            {
                try
                {
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
                        //Response.Redirect("bookingOU.aspx");
                    }
                    else if (presencebm > 0)
                    {
                        //Response.Redirect("bookingOU.aspx");
                    }
                    else if (presencebw > 0)
                    {
                        //  Response.Redirect("bookingOU.aspx");
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
                    SqlCommand cmdn;
                    String str = @"select Name from reg WHERE boo='" + email + "'";

                    cmdn = new SqlCommand(str, con);
                    string r = cmdn.ExecuteScalar().ToString();


                    bname.Text = r.ToString();
                    con.Close();
                }
                catch (Exception boom)
                {
                    Response.Write(boom.Message);
                }


            }
        }
    }


    //========   Performs Action on radio button select Plan       =========================
    protected void radiobutton_checked(object sender, EventArgs e)
    {
        try
        {
            DateTime datenow = Convert.ToDateTime(bdate.Text);
            DateTime dateonlyentered = datenow.Date;

            DateTime currentdate = DateTime.Now;
            currentdate = currentdate.Date;

            if (dateonlyentered < currentdate)
            {
                berror.Text = "Enter a valid date";
                bedate.Text = "";
            }
            else
            {
                berror.Text = "";
                if (daily.Checked)
                {
                    actualplace.Visible = false;
                    selectplace.DataSource = placeObjects;
                    selectplace.DataTextField = "placeObjects";
                    selectplace.DataValueField = "placeObjects";
                    selectplace.DataBind();
                    bedate.Text = "";
                    berror.Text = " ";

                }
                else if (monthly.Checked)
                {
                    actualplace.Visible = false;
                    selectplace.DataSource = placeObjectsfulldatasource;
                    selectplace.DataTextField = "placeObjectsMW";
                    selectplace.DataValueField = "placeObjectsMW";
                    selectplace.DataBind();

                    DateTime startdatetext = Convert.ToDateTime(bdate.Text);
                    startdatetext.ToShortDateString();
                    DateTime tilldate = startdatetext.AddDays(30);
                    bedate.Text = tilldate.ToShortDateString();
                    berror.Text = " ";
                }
                else if (weekly.Checked)
                {
                    actualplace.Visible = false;
                    selectplace.DataSource = placeObjectsfulldatasource;
                    selectplace.DataTextField = "placeObjectsMW";
                    selectplace.DataValueField = "placeObjectsMW";
                    selectplace.DataBind();

                    DateTime startdatetext = Convert.ToDateTime(bdate.Text);
                    startdatetext.ToShortDateString();
                    DateTime tilldate = startdatetext.AddDays(7);
                    bedate.Text = tilldate.ToShortDateString();
                    berror.Text = " ";
                }
            }
        }
        catch (Exception)
        {
            berror.Text = "Enter a valid date";
        }
    }

    //-------------- Sets the total time on the label with id hours----
    protected void itemselected(object sender, EventArgs e)
    {



        int hr1 = Convert.ToInt16(shrs.SelectedItem.Value);
        int hr2 = Convert.ToInt16(ehrs.SelectedItem.Value);
        int min1 = Convert.ToInt16(smin.SelectedItem.Value);
        int min2 = Convert.ToInt16(emin.SelectedItem.Value);
        TimeSpan stime = new TimeSpan(hr1, min1, 0);
        TimeSpan etime = new TimeSpan(hr2, min2, 0);
        TimeSpan duration = etime - stime;

        //string hourstodisplay= duration.Hours.ToString();
        //string minutestodisplay = duration.Minutes.ToString();

        // ============  Checks VAlid date entered ====
        DateTime mydatetime = DateTime.Now;
        mydatetime = mydatetime.AddMinutes(15);
        DateTime myTime = default(DateTime).Add(mydatetime.TimeOfDay);

        DateTime starttimetocheckgot = Convert.ToDateTime(stime.ToString());
        DateTime starttimetocheck = default(DateTime).Add(starttimetocheckgot.TimeOfDay);

        DateTime datenow = Convert.ToDateTime(bdate.Text);
        DateTime dateonlyentered = datenow.Date;

        DateTime currentdate = DateTime.Now;
        currentdate = currentdate.Date;


        if (starttimetocheck < myTime && dateonlyentered == currentdate)
        {
            hours.Text = "Select valid Start Time";
        }
        else
        {
            if (stime < etime)
            {
                //=-==-=-=-=-=-=-=-=-=-...............>>>>>>>>>> displays specific time on to the label   ===========
                if (duration.Hours == 0 && duration.Minutes < 30)
                {
                    hours.Text = "You must book for atleast 30 Minutes";
                }

                else if (duration.Hours == 0 && duration.Minutes > 1)
                {
                    hours.Text = "You are booking for " + duration.Minutes.ToString() + " Minutes";
                }
                else if (duration.Hours > 1 && duration.Minutes == 0)
                {
                    hours.Text = "You are booking for " + duration.Hours.ToString() + " Hours";
                }
                else if (duration.Hours < 2 && duration.Minutes == 0)
                {
                    hours.Text = "You are booking for " + duration.Hours.ToString() + "Hour ";
                }
                else if (duration.Hours > 1 && duration.Minutes < 2)
                {
                    hours.Text = "You are booking for " + duration.Hours.ToString() + "Hours " + duration.Minutes.ToString() + "Minute";
                }
                else if (duration.Hours < 2 && duration.Minutes > 1)
                {
                    hours.Text = "You are booking for " + duration.Hours.ToString() + "Hour " + duration.Minutes.ToString() + "Minutes";
                }
                else if (duration.Hours > 1 && duration.Minutes > 1)
                {
                    hours.Text = "You are booking for " + duration.Hours.ToString() + "Hours " + duration.Minutes.ToString() + "Minutes";
                }
                else if (duration.Hours < 2 && duration.Minutes < 2)
                {
                    hours.Text = "You are booking for " + duration.Hours.ToString() + "Hour " + duration.Minutes.ToString() + "Minute";
                }

                this.hours.ForeColor = Color.Maroon;

            }
            else
            {
                hours.Text = "Please Enter Proper Time";
                this.hours.ForeColor = Color.Red;
            }

        }
    }




    //------- calculates time when items of type of vehicle list changed------
    protected void typeofvehicle_SelectedIndexChanged(object sender, EventArgs e)
    {

        int hr1 = Convert.ToInt16(shrs.SelectedItem.Value);
        int hr2 = Convert.ToInt16(ehrs.SelectedItem.Value);
        int min1 = Convert.ToInt16(smin.SelectedItem.Value);
        int min2 = Convert.ToInt16(emin.SelectedItem.Value);
        TimeSpan stime = new TimeSpan(hr1, min1, 0);
        TimeSpan etime = new TimeSpan(hr2, min2, 0);
        TimeSpan duration = etime - stime;
        if (stime < etime)
        {
            //=-==-=-=-=-=-=-=-=-=-...............>>>>>>>>>> displays specific time on to the label   ===========
            if (duration.Hours == 0 && duration.Minutes < 30)
            {
                hours.Text = "You must book for atleast 30 Minutes";
            }
            else if (duration.Hours == 0 && duration.Minutes > 1)
            {
                hours.Text = "You are booking for " + duration.Minutes.ToString() + " Minutes";
            }
            else if (duration.Hours > 1 && duration.Minutes == 0)
            {
                hours.Text = "You are booking for " + duration.Hours.ToString() + " Hours";
            }
            else if (duration.Hours < 2 && duration.Minutes == 0)
            {
                hours.Text = "You are booking for " + duration.Hours.ToString() + "Hour ";
            }
            else if (duration.Hours > 1 && duration.Minutes < 2)
            {
                hours.Text = "You are booking for " + duration.Hours.ToString() + "Hours " + duration.Minutes.ToString() + "Minute";
            }
            else if (duration.Hours < 2 && duration.Minutes > 1)
            {
                hours.Text = "You are booking for " + duration.Hours.ToString() + "Hour " + duration.Minutes.ToString() + "Minutes";
            }
            else if (duration.Hours > 1 && duration.Minutes > 1)
            {
                hours.Text = "You are booking for " + duration.Hours.ToString() + "Hours " + duration.Minutes.ToString() + "Minutes";
            }
            else if (duration.Hours < 2 && duration.Minutes < 2)
            {
                hours.Text = "You are booking for " + duration.Hours.ToString() + "Hour " + duration.Minutes.ToString() + "Minute";
            }

            this.hours.ForeColor = Color.Maroon;

        }
        else
        {
            return;
        }
    }



    protected void selectplace_SelectedIndexChanged(object sender, EventArgs e)
    {
        int placeselectedbyuser = selectplace.SelectedIndex;
        b2error.Text = "";
        if (daily.Checked)
        {

            if (placeselectedbyuser == 0)
            {
                actualplace.Visible = false;
            }
            else if (placeselectedbyuser == 1)
            {
                actualplace.Visible = true;
                actualplace.DataSource = placeHoteldatasource;
                actualplace.DataTextField = "Hotel";
                actualplace.DataValueField = "Hotel";
                actualplace.DataBind();
            }
            else if (placeselectedbyuser == 2)
            {
                actualplace.Visible = true;
                actualplace.DataSource = placeMalldatasource;
                actualplace.DataTextField = "Mall";
                actualplace.DataValueField = "Mall";
                actualplace.DataBind();
            }
            else if (placeselectedbyuser == 3)
            {
                actualplace.Visible = true;
                actualplace.DataSource = placeAirportdatasource;
                actualplace.DataTextField = "Airport";
                actualplace.DataValueField = "Airport";
                actualplace.DataBind();
            }
            else if (placeselectedbyuser == 4)
            {
                actualplace.Visible = true;
                actualplace.DataSource = placeRailwaystationdatasource;
                actualplace.DataTextField = "Railway_Station";
                actualplace.DataValueField = "Railway_Station";
                actualplace.DataBind();
            }
            else if (placeselectedbyuser == 5)
            {
                actualplace.Visible = true;
                actualplace.DataSource = placeLocaldatasource;
                actualplace.DataTextField = "Local_Place";
                actualplace.DataValueField = "Local_Place";
                actualplace.DataBind();
            }
        }
        else
        {
            if (placeselectedbyuser == 0)
            {
                actualplace.Visible = false;
            }
            else if (placeselectedbyuser == 1)
            {
                actualplace.Visible = true;
                actualplace.DataSource = placeRailwaystationdatasource;
                actualplace.DataTextField = "Railway_Station";
                actualplace.DataValueField = "Railway_Station";
                actualplace.DataBind();
            }
            else if (placeselectedbyuser == 2)
            {
                actualplace.Visible = true;
                actualplace.DataSource = placeLocaldatasource;
                actualplace.DataTextField = "Local_Place";
                actualplace.DataValueField = "Local_Place";
                actualplace.DataBind();
            }

        }

    }


    protected void bbook_Click(object sender, EventArgs e)

    {
        bookingfullimage.Visible = false;
        int parkingspace = (int)Application["parkingspace"];
        int parkingspacemonthly = (int)Application["parkingspacemonthly"];
        int parkingspaceweekly = (int)Application["parkingspaceweekly"];

        //=======    Passess sessions Cost Calculation ===============
        try
        {
            string textboxdatevalue = bdate.Text;
            DateTime datevalueoftextbox = Convert.ToDateTime(textboxdatevalue);
            // datevalueoftextbox.ToShortDateString();

            // bdate.Text = datevalueoftextbox.ToShortDateString();
            //-------- sends time on payment page in terms of string to be entered in the database------ 



            string starthours = shrs.SelectedItem.Value;
            string startminutes = smin.SelectedItem.Value;
            string endhours = ehrs.SelectedItem.Value;
            string endminutes = emin.SelectedItem.Value;
            string begin = starthours + ":" + startminutes;
            string terminate = endhours + ":" + endminutes;
            string selectplacetext = selectplace.SelectedItem.Text;
            string actualplacetext = actualplace.SelectedItem.Text;

            //----Session  -to be send to the payment page------
            Session["begintime"] = begin;
            Session["terminatetime"] = terminate;




            int hr1 = Convert.ToInt16(shrs.SelectedItem.Value);
            int hr2 = Convert.ToInt16(ehrs.SelectedItem.Value);
            int min1 = Convert.ToInt16(smin.SelectedItem.Value);
            int min2 = Convert.ToInt16(emin.SelectedItem.Value);
            TimeSpan stime = new TimeSpan(hr1, min1, 0);
            TimeSpan etime = new TimeSpan(hr2, min2, 0);
            TimeSpan duration = stime - etime;
            Session["timeduration"] = duration;
            //========    Calculates Cost Of Boooking      =================

            int seconds = (int)duration.TotalSeconds; int price;
            if (stime < etime)
            {
                if (typeofvehicle.SelectedValue == "twowheeler")
                {
                    if (monthly.Checked)
                    {
                        price = (int)(seconds * 0.0083);
                        price = price * (-1);
                        price = price - 3;
                        price = price * 30;
                        Session["cost"] = price;
                    }
                    else if (weekly.Checked)
                    {
                        price = (int)(seconds * 0.0083);
                        price = price * (-1);
                        price = price - 2;
                        price = price * 7;
                        Session["cost"] = price;
                    }
                    else if (daily.Checked)
                    {
                        price = (int)(seconds * 0.0083);
                        price = price * (-1);
                        Session["cost"] = price;
                    }

                }
                if (typeofvehicle.SelectedValue == "threewheeler")
                {
                    if (monthly.Checked)
                    {
                        price = (int)(seconds * 0.0097);
                        price = price * (-1);
                        price = price - 3;
                        price = price * 30;
                        Session["cost"] = price;
                    }
                    else if (weekly.Checked)
                    {
                        price = (int)(seconds * 0.0097);
                        price = price * (-1);
                        price = price - 2;
                        price = price * 7;
                        Session["cost"] = price;
                    }
                    else if (daily.Checked)
                    {
                        price = (int)(seconds * 0.0097);
                        price = price * (-1);
                        Session["cost"] = price;
                    }
                }
                if (typeofvehicle.SelectedValue == "fourwheeler")
                {
                    if (monthly.Checked)
                    {
                        price = (int)(seconds * 0.011);
                        price = price * (-1);
                        price = price - 3;
                        price = price * 30;
                        Session["cost"] = price;
                    }
                    else if (weekly.Checked)
                    {
                        price = (int)(seconds * 0.011);
                        price = price * (-1);
                        price = price - 2;
                        price = price * 7;
                        Session["cost"] = price;
                    }
                    else if (daily.Checked)
                    {
                        price = (int)(seconds * 0.011);
                        price = price * (-1);
                        Session["cost"] = price;
                    }

                }




                //---------sessions to be passed----------
                if (monthly.Checked)
                {
                    Session["monthly"] = monthly.Text;
                    Session["enddate"] = bedate.Text;
                    Session["weekly"] = null;
                    Session["daily"] = null;
                }
                else if (weekly.Checked)
                {
                    Session["weekly"] = weekly.Text;
                    Session["enddate"] = bedate.Text;
                    Session["monthly"] = null;
                    Session["daily"] = null;
                }
                else if (daily.Checked)
                {
                    Session["daily"] = daily.Text;
                    Session["enddate"] = null;
                    Session["monthly"] = null;
                    Session["weekly"] = null;
                }
                Session["bname"] = bname.Text;
                Session["bphone"] = bphone.Text;
                Session["typeofvehicle"] = typeofvehicle.SelectedItem.Text;
                Session["bvehicleno"] = bvhno1.Text;
                Session["bdate"] = datevalueoftextbox.ToShortDateString();
                Session["selectplace"] = selectplacetext;
                Session["actualplace"] = actualplacetext;

                int num = (int)duration.TotalMinutes;
                num = num * (-1);
                if (num < 30)
                {
                    hours.Text = "You must Book For Atleast 30 Minutes";
                    this.hours.ForeColor = Color.Red;
                }
                else
                {

                    try
                    {
                        //  ============= Changing the formatof the date to check availability ====================
                        DateTime entereddate = Convert.ToDateTime(bdate.Text);
                        string entereddatestring = entereddate.ToShortDateString();
                        string date1 = DateTime.Parse(entereddatestring.Trim()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                        DateTime previousdate = entereddate.AddDays(-30);
                        string previousdatestring = previousdate.ToShortDateString();
                        string predate = DateTime.Parse(previousdatestring.Trim()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                       

                        DateTime previousdateweekly = entereddate.AddDays(-7);
                        string previousdatestringweekly = previousdateweekly.ToShortDateString();
                        string predateweekly = DateTime.Parse(previousdatestringweekly.Trim()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                        //   ============   connection Started   =================
                        SqlConnection con;
                        string connectionString = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
                        con = new SqlConnection(connectionString);
                        con.Open();


                        SqlCommand cmdbr;
                        SqlCommand cmdbm;
                        SqlCommand cmdbw;


                        string querybr = @"select COUNT(*) from bookingregistration where  location='" + actualplace.Text + "' and date ='" + date1 + "'";
                        string querybm = @"select COUNT(*) from bookingRegistrationMonthly where  location='" + actualplace.Text + "' AND start_date BETWEEN  '" + date1 + "' AND '" + predate + "'";
                        string querybw = @"select COUNT(*) from bookingRegistrationWeekly where location='" + actualplace.Text + "' AND start_date BETWEEN '" + date1 + "' AND '" + predateweekly + "'";

                        cmdbr = new SqlCommand(querybr, con);
                        cmdbm = new SqlCommand(querybm, con);
                        cmdbw = new SqlCommand(querybw, con);
                        //==============   Execution of actions when booking available or not    ===================

                        int brdatacount = Convert.ToInt16(cmdbr.ExecuteScalar());
                        int bmdatacount = Convert.ToInt16(cmdbm.ExecuteScalar());
                        int bwdatacount = Convert.ToInt16(cmdbw.ExecuteScalar());

                        if (daily.Checked == false && weekly.Checked == false && monthly.Checked == false)
                        {
                            //===   Plan Selected   ===
                            b2error.Text = "Select a Plan";
                        }
                        else
                        {
                            //======== Check Locatin Selected  =====
                            if (actualplace.SelectedIndex == 0)
                            {
                                b2error.Text = "Select Location";
                            }
                            else
                            {
                                try
                                {
                                    // ========   Check A valid Date
                                    DateTime datenow = Convert.ToDateTime(bdate.Text);
                                    DateTime dateonlyentered = datenow.Date;

                                    DateTime currentdate = DateTime.Now;
                                    currentdate = currentdate.Date;

                                    if (dateonlyentered < currentdate)
                                    {
                                        berror.Text = "Enter a valid date";
                                    }
                                    else
                                    {
                                        // ============  Checks VAlid TIME entered ====
                                        DateTime mydatetime = DateTime.Now;
                                        mydatetime = mydatetime.AddMinutes(15);
                                        DateTime myTime = default(DateTime).Add(mydatetime.TimeOfDay);

                                        DateTime starttimetocheckgot = Convert.ToDateTime(stime.ToString());
                                        DateTime starttimetocheck = default(DateTime).Add(starttimetocheckgot.TimeOfDay);



                                        if (starttimetocheck < myTime && dateonlyentered == currentdate)
                                        {
                                            hours.Text = "Select valid Start Time";
                                            this.hours.ForeColor = Color.Red;
                                        }
                                        else
                                        {//====================              to check same booing is presentt oor not  ================
                                           
                                            SqlCommand tochecksamebookingbr;
                                            SqlCommand tochecksamebookingbm;
                                            SqlCommand tochecksamebookingbw;

                                            string cmdtochecksamebookingbr = @"select COUNT(*) from bookingRegistration where date='" + date1 + "' and vehicle_no='" + bvhno1.Text + "' and start_time BETWEEN '" + stime + "' and '" + etime + "'";
                                            string cmdtochecksamebookingbm = @"select COUNT(*) from bookingRegistrationMonthly where start_date='" + date1 + "' and vehicle_no='" + bvhno1.Text + "' and start_time BETWEEN '" + stime + "' and '" + etime + "'";
                                            string cmdtochecksamebookingbw = @"select COUNT(*) from bookingRegistrationWeekly where start_date='" + date1 + "'and vehicle_no='" + bvhno1.Text + "' and start_time BETWEEN '" + stime + "' and '" + etime + "'";

                                            tochecksamebookingbr = new SqlCommand(cmdtochecksamebookingbr, con);
                                            tochecksamebookingbm = new SqlCommand(cmdtochecksamebookingbm, con);
                                            tochecksamebookingbw = new SqlCommand(cmdtochecksamebookingbw, con);

                                            int presencebrsame = Convert.ToInt16(tochecksamebookingbr.ExecuteScalar());
                                            int presencebmsame = Convert.ToInt16(tochecksamebookingbm.ExecuteScalar());
                                            int presencebwsame = Convert.ToInt16(tochecksamebookingbw.ExecuteScalar());

                                            if (presencebrsame > 0)
                                            {
                                                SqlCommand bcinbr;
                                                string togetbcinbr = @"select booking_no from bookingRegistration where date='" + date1 + "'and vehicle_no='" + bvhno1.Text + "' and start_time BETWEEN '" + stime + "' and '" + etime + "'";
                                                bcinbr = new SqlCommand(togetbcinbr, con);
                                                string bookingcodebr = bcinbr.ExecuteScalar().ToString();
                                                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('A booking exists for the same vehicle on another place with Booking No " + bookingcodebr + "');", true);
                                                //  Response.Write("heklo");
                                            }


                                            else if (presencebmsame > 0)
                                            {
                                                SqlCommand bcinbm;
                                                string togetbcinbm = @"select booking_no from bookingRegistrationMonthly where start_date='" + date1 + "' and vehicle_no='" + bvhno1.Text + "' and start_time BETWEEN '" + stime + "' and '" + etime + "'";
                                                bcinbm = new SqlCommand(togetbcinbm, con);
                                                string bookingcodebm = bcinbm.ExecuteScalar().ToString();
                                                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('A booking exists for the same vehicle on another place with Booking No " + bookingcodebm + "');", true);
                                            }



                                            else if (presencebwsame > 0)
                                            {
                                                SqlCommand bcinbw;
                                                string togetbcinbw = @"select booking_no from bookingRegistrationWeekly where start_date='" + date1 + "' and vehicle_no='" + bvhno1.Text + "' and start_time BETWEEN '" + stime + "' and '" + etime + "'";
                                                bcinbw = new SqlCommand(togetbcinbw, con);
                                                string bookingcodebw = bcinbw.ExecuteScalar().ToString();
                                                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('A booking exists for the same vehicle on another place with Booking No " + bookingcodebw + "');", true);

                                            }

                                            else
                                            {
                                                if (daily.Checked)
                                                {

                                                    if (brdatacount >= parkingspace)
                                                    {
                                                        bookingfullimage.Visible = true;

                                                    }
                                                    else
                                                    {
                                                        bookingfullimage.Visible = false;
                                                        Response.Redirect("paymentOU.aspx");
                                                    }
                                                }
                                                else if (monthly.Checked)
                                                {

                                                    if (bmdatacount >= parkingspacemonthly)
                                                    {
                                                        bookingfullimage.Visible = true;
                                                    }
                                                    else
                                                    {
                                                        bookingfullimage.Visible = false;
                                                        Response.Redirect("paymentOU.aspx");
                                                    }
                                                }
                                                else if (weekly.Checked)
                                                {

                                                    if (bwdatacount >= parkingspaceweekly)
                                                    {
                                                        bookingfullimage.Visible = true;
                                                    }
                                                    else
                                                    {
                                                        bookingfullimage.Visible = false;
                                                        Response.Redirect("paymentOU.aspx");
                                                    }
                                                }
                                                else
                                                {
                                                    b2error.Text = "Failed to Process your request Please Retry";
                                                }
                                                con.Close();
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                    berror.Text = "Enter a valid date";
                                }
                            }
                        }
                    }


                    catch (Exception)
                    {
                        b2error.Text = "Could not processs your request please verify all filled data";
                    }


                }
            }
            else
            {
                hours.Text = "Please Enter Proper Time";
                this.hours.ForeColor = Color.Red;
            }
        }
        catch (Exception)
        {
            berror.Text = "Please Verify All fields ";
        }
    }

    //= ========  controls txtbox date======
    protected void bdate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DateTime datenow = Convert.ToDateTime(bdate.Text);
            DateTime dateonlyentered = datenow.Date;

            DateTime currentdate = DateTime.Now;
            currentdate = currentdate.Date;



            if (dateonlyentered < currentdate)
            {
                berror.Text = "Enter a valid date";
                bedate.Text = "";
                hours.Text = "";

            }
            else
            {

                berror.Text = "";
                itemselected(sender, e);

                try
                {
                    if (monthly.Checked)
                    {
                        DateTime startdatetext = Convert.ToDateTime(bdate.Text);
                        startdatetext.ToShortDateString();
                        DateTime tilldate = startdatetext.AddDays(30);
                        bedate.Text = tilldate.ToShortDateString();
                        berror.Text = " ";
                    }
                    else if (weekly.Checked)
                    {
                        DateTime startdatetext = Convert.ToDateTime(bdate.Text);
                        startdatetext.ToShortDateString();
                        DateTime tilldate = startdatetext.AddDays(7);
                        bedate.Text = tilldate.ToShortDateString();
                        berror.Text = " ";
                    }
                    else if (daily.Checked)
                    {
                        bedate.Text = "";
                        berror.Text = " ";
                    }
                }
                catch (Exception)
                {
                    berror.Text = "Please Enter Date In Proper Format";
                }
            }
        }
        catch (Exception)
        {
            berror.Text = "Enter a valid date";
        }
    }

    protected void actualplace_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (actualplace.SelectedIndex == 0)
        {
            b2error.Text = "Select Location";
        }
        else
        {
            b2error.Text = "";
        }
    }
}



//  ======================   Unecesssary Code For Extraction of Booking Count   ===============


//try
//{
//    //  ============= Changing the formatof the date ====================
//    DateTime entereddate = Convert.ToDateTime(bdate.Text);
//    string entereddatestring = entereddate.ToShortDateString();
//    string date1 = DateTime.Parse(entereddatestring.Trim()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

//    DateTime previousdate = entereddate.AddDays(-31);
//    string previousdatestring = previousdate.ToShortDateString();
//    string predate = DateTime.Parse(previousdatestring.Trim()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

//    //   ============   connection Started   =================
//    SqlConnection con;
//    string connectionString = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
//    con = new SqlConnection(connectionString);
//    con.Open();

//    SqlDataAdapter dabr;
//    SqlDataAdapter dabm;
//    SqlDataAdapter dabw;

//    DataSet dsbr = new DataSet();
//    DataSet dsbm = new DataSet();
//    DataSet dsbw = new DataSet();

//    string querybr = @"select COUNT(*) from bookingregistration where  location='" + actualplace.Text + "' and date BETWEEN '" + date1 + "' AND '" + predate + "'";
//    string querybm = @"select COUNT(*) from bookingRegistrationMonthly where  location='" + actualplace.Text + "' AND start_date BETWEEN  '" + date1 + "' AND '" + predate + "'";
//    string querybw = @"select COUNT(*) from bookingRegistrationWeekly where location='" + actualplace.Text + "' AND start_date BETWEEN '" + date1 + "' AND '" + predate + "'";

//    dabr = new SqlDataAdapter(querybr, con);
//    dabm = new SqlDataAdapter(querybm, con);
//    dabw = new SqlDataAdapter(querybw, con);

//dabr.Fill(dsbr);
//string brdata = dsbr.Tables["bookingRegistration"].Rows[0][0].ToString();
//int brdatacount = Convert.ToInt16(brdata);

//dabm.Fill(dsbm);
//string bmdata = dsbm.Tables["bookingegistrationMonthly"].Rows[0][0].ToString();
//int bmdatacount = Convert.ToInt16(bmdata);

//dabw.Fill(dsbw);
//string bwdata = dsbw.Tables["bookingRegistrationWeekly"].Rows[0][0].ToString();
//int bwdatacount = Convert.ToInt16(bwdata);