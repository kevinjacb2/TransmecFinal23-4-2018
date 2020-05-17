using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

public partial class Forgotpass : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    string pwd;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void sendMail(string pass)
    {
        string from = "yourEmailid@gmail.com";

        string to = txtEmailId.Text;
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.From = new MailAddress(from, "Admin for User Password Varification", System.Text.Encoding.UTF8);

        mail.Subject = "Your Car Rental Password";
        mail.SubjectEncoding = System.Text.Encoding.UTF8;

        mail.Body = "Please refer this password when login..." + pass;
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();

        client.Credentials = new System.Net.NetworkCredential("yourEmailid@gmail.com", "Your Gmail Password");
        client.Port = 587;
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true;
        try
        {
            client.Send(mail);
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string query = string.Empty;
        SqlDataAdapter da = new SqlDataAdapter("select * from LoginMaster where UserName='" + txtEmailId.Text + "'", objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "LoginMaster");
        if (ds.Tables[0].Rows.Count > 0)
        {
            pwd = ds.Tables[0].Rows[0]["UserPass"].ToString();
            sendMail(pwd);
        }
        else
        {
            Response.Write("<script>alert('Invalid Email Id ')</script>");
        }
    }
}