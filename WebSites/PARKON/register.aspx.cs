using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void register1_Click(object sender, EventArgs e)
    {

        /*
         try
         {
             reerror.Text = "";
             SqlConnection con;
             SqlDataAdapter da;
             //string connectionString = ConfigurationSettings.AppSettings["SqlConnectionString"].ToString();
             //con = new SqlConnection(connectionString);
             //con.Open();
             //SqlCommand cmd = new SqlCommand("SPinsertreg", con);
             //cmd.CommandType = CommandType.StoredProcedure;
             //cmd.Parameters.AddWithValue("@email", reemail.Text);
             //cmd.Parameters.AddWithValue("@name", rename.Text);
             //cmd.Parameters.AddWithValue("@password", repass.Text);


             SqlCommand cmd;

             //String str = @"insert into reg (boo,Name,Password) values  ('" + reemail.Text + "','" + rename.Text + "','" + repass.Text + "')";


                //cmd = new SqlCommand(str, con);
             int r = cmd.ExecuteNonQuery();

                 if (r > 0)
                 {
                Application["email"] = reemail.Text;
                Application["password"] = repass.Text;

                 Response.Redirect("afterloggedinNU.aspx");


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
 }*/


        /*  

             // con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\AHMED\Documents\Visual Studio 2015\WebSites\PARKON\App_Data\project.mdf;Integrated Security=True;");
                        //con.Open();
                        //Response.Write(str);



        //DataSet ds = new DataSet();
                    //string cem = "select * from reg where boo='" + reemail.Text+"'" ;
                    /* da = new SqlDataAdapter(cem, con);
                      da.Fill(ds);
                      string emai = ds.Tables[0].Rows[1][1].ToString();
                      Response.Write(emai);*/
        //  String emai = null;



        //Response.Redirect("afterloggedinNU.aspx");

        /*
                string name = rename.Text;
                string email = reemail.Text;
                string pass = repass.Text;
                */





        /*not working----  


     SqlDataReader reader = null;
               SqlConnection conn = new SqlConnection("");
               conn.Open();
               SqlCommand cmd1 = new SqlCommand("select * from register where email_ID==email",conn);
               cmd1.Parameters.AddWithValue
       */

        /* try
         {
             conn = new SqlConnection("Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=C: /User/AHMED/Desktop/parkon/Visual Studio 2010/WebSites/Master1/App_Data\register.mdf;Integrated Security=True");
             conn.Open();
             using (SqlCommand cmd = new SqlCommand())

             {
                 cmd.Connection = conn;
                 cmd.CommandType = CommandType.Text;
                 cmd.CommandType = "insert into register Values('" + email + "','" + name + "','" + pass + "')";
                 cmd.Parameters.AddWithValue("name", name);
                 cmd.Parameters.AddWithValue("email", email);
                 cmd.Parameters.AddWithValue("pass", pass);
                 int rowsAffected = cmd.ExecuteNonQuery();
                 if (rowsAffected == 1)
                 {
                     Response.Redirect("afterloggedinNU.aspx");
                 }

                 else
                 {
                     reerror.Text = "Please try Again";
                 }
             }
         catch (Exception ex)
         {

         }
         finally
         {
             if (conn != null)
             {
                 conn.Close();
             }*/
    }
}








