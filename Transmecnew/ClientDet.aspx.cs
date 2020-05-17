using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class ClientDet : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtClientId.Visible = false;
        if (!Page.IsPostBack)
        {

            addState();
        }

    }

    public void addState()
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
            ddlstateid.Items.Insert(0, "Select");
        }
    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from ClientDetail where EmailId='" + txtemailid.Text + "'", objmyclass.con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblEMailid.Text = "Emailid is Already Registered";
        }
        else
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
            string str;
            str = "insert into ClientDetail values('" + txtClientName.Text + "','" + x + "','" + txtaddr.Text + "'," + ddlstateid.SelectedValue + ",'" + txtcity.Text + "','" + txtcontactno.Text + "','" + txtemailid.Text + "','" + Convert.ToDateTime(txtbrthdate.Text).ToString("yyyy/MM/dd") + "','" + txtPwd.Text + "')";


            SqlCommand cmd = new SqlCommand(str, objmyclass.con);
            objmyclass.con.Open();
            int i = cmd.ExecuteNonQuery();


            if (i > 0)
            {
                lblMsg.Text = "Record is saved...";
            }
            objmyclass.con.Close();

            string str1;
            str1 = "insert into LoginMaster values('" + txtemailid.Text + "','" + txtPwd.Text + "','" + DropDownList1.SelectedItem + "')";
            SqlCommand cmd1 = new SqlCommand(str1, objmyclass.con);
            objmyclass.con.Open();
            cmd1.ExecuteNonQuery();
            objmyclass.con.Close();
            //Response.Redirect("~/Login.aspx");
        }

    }
}