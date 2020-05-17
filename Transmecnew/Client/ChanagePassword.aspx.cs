using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Client_ChanagePassword : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    string pwd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Emailid"] != null)
        {
            if (!Page.IsPostBack)
            {

            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        string query = string.Empty;
        SqlCommand cmd = new SqlCommand("select * from  LoginMaster where UserName='" + Session["Emailid"].ToString() + "'", objmyclass.con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt != null)
        {
            pwd = dt.Rows[0]["UserPass"].ToString();
            checkpwd(pwd);
        }
        else
        {
            // Response.Write("<script>alert('Invalid Email Id ')</script>");
        }
    }
    public void checkpwd(string pass)
    {
        if (pass == txtOldPass.Text)
        {
            string newpsw = txtNewPass.Text;
            string cnfmpsw = txtCnfmPass.Text;
            if (newpsw == cnfmpsw)
            {
                SqlCommand cmd = new SqlCommand("Update LoginMaster set Userpass='" + cnfmpsw + "' where UserName='" + Session["Emailid"].ToString() + "'", objmyclass.con);
                SqlCommand cmd1 = new SqlCommand("Update ClientDetail set Password='" + cnfmpsw + "' where Emailid='" + Session["Emailid"].ToString() + "'", objmyclass.con);
                objmyclass.con.Open();
                int i = cmd.ExecuteNonQuery();
                int i1 = cmd1.ExecuteNonQuery();
                if (i > 0 && i1 > 0)
                {
                    Response.Write("<script>alert('Password is updated ')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Password is not updated ')</script>");
                }
                objmyclass.con.Close();


            }
            else
            {
                Response.Write("<script>alert('Both password are not Match')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Invalid old password ')</script>");
        }
    }

}