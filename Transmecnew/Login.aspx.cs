using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (objmyclass.con.State == ConnectionState.Closed)
        {
            objmyclass.con.Open();
        }
        Session["UserName"] = "";
        if (txtuname.Text == "admin@gmail.com" && txtpwd.Text == "admin")
        {
            Session["UserName"] = txtuname.Text;
            Response.Redirect("~/Admin/adminhome.aspx");
        }
        else if (txtuname.Text != "admin@gmail.com" && txtpwd.Text != "admin")
        {
            if (objmyclass.con.State == ConnectionState.Closed)
            {
                objmyclass.con.Open();
            }
            string s;
            s = "select * from Loginmaster where Username like '" + txtuname.Text + "' and Userpass like '" + txtpwd.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(s, objmyclass.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Loginmaster");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserRole"].ToString() == "A")
                {
                    Session["UserName"] = txtuname.Text;
                    Response.Redirect("~/Admin/city_master.aspx");
                }
                else if (ds.Tables[0].Rows[0]["UserRole"].ToString() == "E")
                {
                    Session["username"] = txtuname.Text;
                    if (objmyclass.con.State == ConnectionState.Closed)
                    {

                        objmyclass.con.Open();
                    }
                    string str;
                    str = "select * from Employee where Emailid = '" + txtuname.Text + "' and Password ='" + txtpwd.Text + "'";
                    SqlDataAdapter da101 = new SqlDataAdapter(str, objmyclass.con);
                    DataSet ds101 = new DataSet();
                    da101.Fill(ds101, "Employee");

                    if (ds101.Tables[0].Rows.Count > 0)
                    {

                        Session["UserName"] = ds101.Tables[0].Rows[0]["EmpName"].ToString();
                        Session["Emailid"] = txtuname.Text.ToString();
                        Session["EmpId"] = ds101.Tables[0].Rows[0]["EmpId"].ToString();
                        string designation = ds101.Tables[0].Rows[0]["Desigid"].ToString();
                        if (designation == "")
                        {

                        }
                        else if (designation == "")
                        {

                        }
                        else
                        {

                        }
                        Response.Redirect("~/Employee/EmployeeHome.aspx");
                    }
                    else
                    {
                        lblMsg.Text = "Username and password not match..";
                        lblMsg.CssClass = "error";
                    }
                }

                else if (ds.Tables[0].Rows[0]["UserRole"].ToString() == "S")
                {
                    Session["username"] = txtuname.Text;
                    if (objmyclass.con.State == ConnectionState.Closed)
                    {

                        objmyclass.con.Open();
                    }
                    Session["username"] = txtuname.Text;
                    Response.Redirect("admin/countrymaster.aspx");
                }
                else if (ds.Tables[0].Rows[0]["UserRole"].ToString() == "CarRental")
                {

                    string str;
                    str = "select * from ClientDetail where emailid = '" + txtuname.Text + "' and password ='" + txtpwd.Text + "'";
                    SqlDataAdapter da101 = new SqlDataAdapter(str, objmyclass.con);
                    DataSet ds101 = new DataSet();
                    da101.Fill(ds101, "ClientDetail");

                    if (ds101.Tables[0].Rows.Count > 0)
                    {

                        Session["UserName"] = ds101.Tables[0].Rows[0]["ClientName"].ToString();
                        Session["Emailid"] = txtuname.Text.ToString();
                        Session["ClientId"] = ds101.Tables[0].Rows[0][0].ToString();

                     Response.Redirect("~/Client/ClientProfile.aspx");
                       // Response.Redirect("~/ShowBuyProduct.aspx");
                    }


                    else
                    {
                        lblMsg.Text = "Username and password not match..";
                        lblMsg.CssClass = "error";
                    }
                }

                else if (ds.Tables[0].Rows[0]["UserRole"].ToString() == "BuySpare")
                {

                    string str;
                    str = "select * from ClientDetail where emailid = '" + txtuname.Text + "' and password ='" + txtpwd.Text + "'";
                    SqlDataAdapter da101 = new SqlDataAdapter(str, objmyclass.con);
                    DataSet ds101 = new DataSet();
                    da101.Fill(ds101, "ClientDetail");

                    if (ds101.Tables[0].Rows.Count > 0)
                    {

                        Session["UserName"] = ds101.Tables[0].Rows[0]["ClientName"].ToString();
                        Session["Emailid"] = txtuname.Text.ToString();
                        Session["ClientId"] = ds101.Tables[0].Rows[0][0].ToString();

                      //  Response.Redirect("~/Client/ClientProfile.aspx");
                        Response.Redirect("~/BuyProduct.aspx");
                    }


                    else
                    {
                        lblMsg.Text = "Username and password not match..";
                        lblMsg.CssClass = "error";
                    }
                }
                else
                {
                    Session["username"] = txtuname.Text;
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Username and Password are Incorrect";

            }
        }
        else
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Username and Password are Incorrect";
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        txtuname.Text = "";
        txtpwd.Text = "";
    }
}