using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Drawing;


public partial class availabilityOU : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] == null)
        {
            Response.Redirect("availability.aspx");
        }

        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        Application["parkingspace"] = 15;
        Application["parkingspacemonthly"] = 30;
        Application["parkingspaceweekly"] = 25;
        if (!IsPostBack)
        {

            selectplace.SelectedIndex = 0;
            availtext.Text = DateTime.Now.ToShortDateString();
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
                //Response.Redirect("availabilityOU.aspx");
            }
            else if (presencebm > 0)
            {
                //  Response.Redirect("availabilityOU.aspx");
            }
            else if (presencebw > 0)
            {
                // Response.Redirect("availabilityOU.aspx");
            }
            else if (presencebc > 0)
            {
                Response.Redirect("availabilityOUnobooking.aspx");
            }
            else if (presencebcm > 0)
            {
                Response.Redirect("availabilityOUnobooking.aspx");
            }
            else if (presencebcw > 0)
            {
                Response.Redirect("availabilityOUnobooking.aspx");
            }
            else
            {
                Response.Redirect("availabilityNU.aspx");
            }
            con.Close();
        }
        catch (Exception)
        {

        }
    }

    protected void radiobutton_checked(object sender, EventArgs e)
    {
        if (daily.Checked)
        {
            actualplace.Visible = false;
            selectplace.DataSource = placeObjects;
            selectplace.DataTextField = "placeObjects";
            selectplace.DataValueField = "placeObjects";
            selectplace.DataBind();

            availerror.Text = " ";

        }
        else if (monthly.Checked)
        {
            actualplace.Visible = false;
            selectplace.DataSource = placeObjectsfulldatasource;
            selectplace.DataTextField = "placeObjectsMW";
            selectplace.DataValueField = "placeObjectsMW";
            selectplace.DataBind();
            availerror.Text = " ";
        }
        else if (weekly.Checked)
        {
            actualplace.Visible = false;
            selectplace.DataSource = placeObjectsfulldatasource;
            selectplace.DataTextField = "placeObjectsMW";
            selectplace.DataValueField = "placeObjectsMW";
            selectplace.DataBind();
            availerror.Text = " ";
        }
    }

    protected void selectplace_SelectedIndexChanged(object sender, EventArgs e)
    {
        availerror.Text = "";
        int placeselectedbyuser = selectplace.SelectedIndex;
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

    protected void checkavailability_Click(object sender, EventArgs e)
    {
        int parkingspace = (int)Application["parkingspace"];
        int parkingspacemonthly = (int)Application["parkingspacemonthly"];
        int parkingspaceweekly = (int)Application["parkingspaceweekly"];

        DateTime datenow = Convert.ToDateTime(availtext.Text);
        DateTime currentdate = DateTime.Now;
        currentdate = currentdate.Date;
        DateTime dateonlyentered = datenow.Date;
        if (dateonlyentered < currentdate)
        {
            availerror.Text = "Enter a valid date";
            availableimage.Visible = false;
            acknoledgement.Text = "";
        }

        else
        {
            ///=========== paln selected or not  ============
            if (daily.Checked == false && weekly.Checked == false && monthly.Checked == false)
            {
                availerror.Text = "Select a Plan";
            }
            else
            {
                //==== === Location Selected Or Not    =============
                if (actualplace.SelectedIndex == 0)
                {
                    availerror.Text = "Select Location";
                }
                else
                {
                    availerror.Text = "";
                    try
                    {
                        //  ============= Changing the formatof the date to check availability ====================
                        DateTime entereddate = Convert.ToDateTime(availtext.Text);
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

                        int brdatacount = Convert.ToInt16(cmdbr.ExecuteScalar());
                        int bmdatacount = Convert.ToInt16(cmdbm.ExecuteScalar());
                        int bwdatacount = Convert.ToInt16(cmdbw.ExecuteScalar());

                        if (daily.Checked)
                        {

                            if (brdatacount >= parkingspace)
                            {
                                bookingfullimage.Visible = true;
                                acknoledgement.Text = "Sorry No Bookings Available for " + actualplace.Text + " On" + availtext.Text + " for " + daily.Text;
                                availableimage.Visible = false;
                            }
                            else
                            {
                                bookingfullimage.Visible = false;
                                availableimage.Visible = true;
                                acknoledgement.Text = "Booking Available for " + actualplace.Text + " On " + availtext.Text + " for " + daily.Text;
                            }
                        }
                        else if (monthly.Checked)
                        {

                            if (bmdatacount >= parkingspacemonthly)
                            {
                                bookingfullimage.Visible = true;
                                acknoledgement.Text = "Sorry No Bookings Available for " + actualplace.Text + " On" + availtext.Text + " for " + monthly.Text;
                                availableimage.Visible = false;
                            }
                            else
                            {
                                bookingfullimage.Visible = false;
                                availableimage.Visible = true;
                                acknoledgement.Text = "Booking Available for " + actualplace.Text + " On " + availtext.Text + " for " + monthly.Text;

                            }
                        }
                        else if (weekly.Checked)
                        {

                            if (bwdatacount >= parkingspaceweekly)
                            {
                                bookingfullimage.Visible = true;
                                acknoledgement.Text = "Sorry No Bookings Available for " + actualplace.Text + " On" + availtext.Text + " for " + weekly.Text;
                                availableimage.Visible = false;
                            }
                            else
                            {
                                bookingfullimage.Visible = false;
                                availableimage.Visible = true;
                                acknoledgement.Text = "Booking Available for " + actualplace.Text + " On " + availtext.Text + " for " + weekly.Text;
                            }
                        }
                        con.Close();
                    }
                    catch (Exception)
                    {
                        availerror.Text = "Could Not Process your Request check whether all data are correctly filled";
                    }

                }
            }
        }
    }
    protected void availtext_TextChanged(object sender, EventArgs e)
    {
        availableimage.Visible = false;
        acknoledgement.Text = "";
        try
        {
            DateTime datenow = Convert.ToDateTime(availtext.Text);
            string datestr = datenow.ToShortDateString();
            DateTime predate = datenow.AddDays(-31);
            string predatestr = predate.ToShortDateString();
            availerror.Text = "";

            //  ============  Checks the correct date entered  ========
            DateTime currentdate = DateTime.Now;
            currentdate = currentdate.Date;
            DateTime dateonlyentered = datenow.Date;
            if (dateonlyentered < currentdate)
            {
                availerror.Text = "Enter a valid date";
               
            }

        }

        catch (Exception)
        {
            availerror.Text = "Please Enter Date In Proper Format";
        }
    }



    protected void actualplace_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (actualplace.SelectedIndex == 0)
        {
            availerror.Text = "Select Location";
        }
        else
        {
            availerror.Text = "";
        }
    }
}