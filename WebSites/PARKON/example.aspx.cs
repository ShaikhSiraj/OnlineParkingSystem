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
using ASPSnippets.SmsAPI;
using System.IO;
using System.Net;
using System.Net.Mail;

public partial class example : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string hello = "helloxxx";
        //SMS.APIType = SMSGateway.Site2SMS;
        //SMS.MashapeKey = "<lZtKyQpShKmshOLbh2Vg9uFtxkKGp1oaclTjsng9rEGzDNOumas>";
        //SMS.Username = "<7208834285>";
        //SMS.Password = "<258741>";
        //SMS.SendSms("<9967441514>", hello);



        //    using (MailMessage mm = new MailMessage("onpark4@gmail.com","aqureshi536@gmail.com"))
        //    {
        //        mm.Subject = "heloo";
        //        mm.Body = "How are You";
        //        //if (fuAttachment.HasFile)
        //        //{
        //        //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
        //        //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
        //        //}
        //        mm.IsBodyHtml = false;
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.EnableSsl = true;
        //        NetworkCredential NetworkCred = new NetworkCredential("onpark4@gmail.com","9892155183");
        //        smtp.UseDefaultCredentials = true;
        //        smtp.Credentials = NetworkCred;
        //        smtp.Port = 587;
        //        smtp.Send(mm);
        //        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
        //    }
        //}
    }


    protected void butto(object sender, EventArgs e)
    {
        Response.Write("hello");
        Button1.Enabled = true; 

    }
}

