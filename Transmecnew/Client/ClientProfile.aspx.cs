using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Client_ClientProfile : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Emailid"] != null)
        {
            if (!Page.IsPostBack)
            {
                txtClientId.Text = Session["ClientId"].ToString();
                showdata();
                addStateid();
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    public void addStateid()
    {
        string str = "select * from State_Master";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "State_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlstateid.DataSource = ds.Tables[0].DefaultView;
            ddlstateid.DataTextField = "State_name";
            ddlstateid.DataValueField = "State_id";
            ddlstateid.DataBind();


        }
    }
    public void showdata()
    {
        string str1 = "select * from ClientDetail where ClientId='" + txtClientId.Text + "'";
        SqlDataAdapter da1 = new SqlDataAdapter(str1, objmyclass.con);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            txtClientName.Text = dt1.Rows[0]["ClientName"].ToString();
            string gndr;
            gndr = dt1.Rows[0]["Gender"].ToString();
            if (gndr == "Male")
            {
                rdomale.Checked = true;
                rdofemale.Checked = false;
            }
            else
            {
                rdofemale.Checked = true;
                rdomale.Checked = false;
            }
            txtaddr.Text = dt1.Rows[0]["Address"].ToString();
            ddlstateid.Text = dt1.Rows[0]["StateId"].ToString();
            txtcity.Text = dt1.Rows[0]["City"].ToString();
            txtcontactno.Text = dt1.Rows[0]["ContactNo"].ToString();
            txtemailid.Text = dt1.Rows[0]["EmailId"].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string x;
        if (rdomale.Checked == true)
        {
            x = "Male";
        }
        else
        {
            x = "Female";
        }
        string str = "update ClientDetail set ClientName='" + txtClientName.Text + "',Gender='" + x + "',Address='" + txtaddr.Text + "',StateId='" + ddlstateid.SelectedValue + "',City='" + txtcity.Text + "',ContactNo='" + txtcontactno.Text + "' where ClientId=" + txtClientId.Text;
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();


        if (i > 0)
        {
            lblMsg.Text = "Record is Updated...";
        }
        objmyclass.con.Close();
    }
}