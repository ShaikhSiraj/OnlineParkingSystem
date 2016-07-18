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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetImageUrl();
        }
        DateTime date1 = DateTime.Now;
        string datee = date1.ToShortDateString();
        string dt = DateTime.Parse(datee.Trim()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        Session["nowdate"] = dt;
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();

        Application["parkingspace"] = 15;
        Application["parkingspacemonthly"] = 30;
        Application["parkingspaceweekly"] = 25;
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (ViewState["ImageDisplayed"] == null)
        {
            return;
        }
        else
        {
            int i = (int)ViewState["ImageDisplayed"];

            i = i + 1;
            ViewState["ImageDisplayed"] = i;

            DataRow imageDataRow = ((DataSet)ViewState["ImageData"]).Tables["images"].Select().FirstOrDefault(x => x["order"].ToString() == i.ToString());
            if (imageDataRow != null)
            {
                Image1.ImageUrl = "~/Images/" + imageDataRow["Name"].ToString();
                //lblImageName.Text = imageDataRow["name"].ToString();
                //lblImageOrder.Text = imageDataRow["order"].ToString();
            }
            else
            {
                SetImageUrl();
            }
        }
    }

        private void SetImageUrl()
    {
        DataSet ds = new DataSet();
        string CS = ConfigurationManager.AppSettings["SqlConnectionString"].ToString();
        SqlConnection con = new SqlConnection(CS);
        SqlDataAdapter da = new SqlDataAdapter("imageadd", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.Fill(ds, "images");
        ViewState["ImageData"] = ds;
        ViewState["ImageDisplayed"] = 1;

        DataRow imageDataRow = ds.Tables["images"].Select().FirstOrDefault(x => x["order"].ToString() == "1");
        Image1.ImageUrl = "~/Images/" + imageDataRow["Name"].ToString();
      
        // lblImageOrder.Text = imageDataRow["order"].ToString();
    }
}