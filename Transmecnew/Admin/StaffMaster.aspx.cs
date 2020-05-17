using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_StaffMaster : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            addCityid();
            adddesig();
            addStateid();
            showdata();
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
            ddlstateid.Items.Insert(0, "Select");

        }
    }
    public void addCityid()
    {
        string str = "select * from City_Master";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "City_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlcityid.DataSource = ds.Tables[0].DefaultView;
            ddlcityid.DataTextField = "City_name";
            ddlcityid.DataValueField = "City_id";
            ddlcityid.DataBind();
            ddlcityid.Items.Insert(0, "Select");

        }
    }

    public void showdata()
    {
        SqlDataAdapter da = new SqlDataAdapter("select StaffId,StaffName,StaffGndr,CityId,Emailid from Staff", objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Staff");
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataBind();
        }
    }



    public void adddesig()
    {
        string str;
        str = "select * from Designation_Master";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Designation_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddldesig.DataSource = ds.Tables[0].DefaultView;
            ddldesig.DataTextField = "Desig_name";
            ddldesig.DataValueField = "Desig_id";
            ddldesig.DataBind();
            ddldesig.Items.Insert(0, "Select");
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
        string str;
        str = "insert into Staff values('" + txtStaffname.Text + "','" + x + "','" + txtStaffaddr.Text + "'," + ddlstateid.SelectedValue + "," + ddlcityid.SelectedValue + ",'" + Convert.ToDateTime(txtStaffdob.Text).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtStaffdoj.Text).ToString("yyyy-MM-dd") + "'," + ddldesig.SelectedValue + "," + txtStaffslr.Text + ",'" + txtEmailid.Text + "')";
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            // Response.Write("<script>alert('Record is successfully saved....')</script>");
            lblmsg.Text = "Record " + txtStaffid.Text + " is Saved...";
        }
        else
        {
            lblmsg.Text = "Error";
        }
        objmyclass.con.Close();


        showdata();
    }
    protected void btnupdate_Click(object sender, EventArgs e)
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
        str = " Update Staff set StaffName='" + txtStaffname.Text + "',StaffGndr='" + x + "',StaffAddr='" + txtStaffaddr.Text + "',StateId='" + ddlstateid.SelectedValue + "',CityId='" + ddlcityid.SelectedValue + "',Dob='" + Convert.ToDateTime(txtStaffdob.Text).ToString("yyyy-MM-dd") + "',Doj='" + Convert.ToDateTime(txtStaffdoj.Text).ToString("yyyy-MM-dd") + "',Desigid=" + ddldesig.SelectedValue + ",Salary=" + txtStaffslr.Text + ",Emailid='" + txtEmailid.Text + "' where StaffId=" + txtStaffid.Text;
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            lblmsg.Text = "Record " + txtStaffid.Text + " is Updated...";
        }
        else
        {
            lblmsg.Text = "Error...";
        }
        objmyclass.con.Close();
        showdata();
    }
    protected void btndelete_Click(object sender, EventArgs e)
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
        string str = "delete from Staff where Staffid=" + txtStaffid.Text;
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            lblmsg.Text = "Record " + txtStaffid.Text + " is Deleted...";
        }
        else
        {
            lblmsg.Text = "Error...";
        }
        objmyclass.con.Close();
        showdata();
    }
    protected void LinkButton2_Click1(object sender, EventArgs e)
    {
        LinkButton linkbutton2 = (LinkButton)sender;
        string str = "select * from Staff where Staffid=" + Convert.ToInt32(linkbutton2.CommandArgument.ToString());
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Staff");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtStaffid.Text = ds.Tables[0].Rows[0]["Staffid"].ToString();
            txtStaffname.Text = ds.Tables[0].Rows[0]["Staffname"].ToString();
            string gndr;
            gndr = ds.Tables[0].Rows[0]["Staffgndr"].ToString();
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
            txtStaffaddr.Text = ds.Tables[0].Rows[0]["Staffaddr"].ToString();

            ddlstateid.SelectedValue = ds.Tables[0].Rows[0]["StateId"].ToString();
            ddlcityid.SelectedValue = ds.Tables[0].Rows[0]["CityId"].ToString();
            txtStaffdob.Text = ds.Tables[0].Rows[0]["dob"].ToString();
            txtStaffdoj.Text = ds.Tables[0].Rows[0]["doj"].ToString();
            ddldesig.SelectedValue = ds.Tables[0].Rows[0]["desigid"].ToString();
            txtStaffslr.Text = ds.Tables[0].Rows[0]["salary"].ToString();

            txtEmailid.Text = ds.Tables[0].Rows[0]["Emailid"].ToString();


        }
    }
    protected void ddlstateid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstateid.SelectedValue != "Select")
        {
            string str;
            str = "select * from City_Master where state_id=" + ddlstateid.SelectedValue;
            SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "City_Master");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlcityid.DataSource = ds.Tables[0].DefaultView;
                ddlcityid.DataTextField = "City_name";
                ddlcityid.DataValueField = "City_id";
                ddlcityid.DataBind();
                ddlcityid.Items.Insert(0, "Select");
            }
        }
        else
        {
            lblmsg.Text = "Select valid country or state...";
        }
    }
}