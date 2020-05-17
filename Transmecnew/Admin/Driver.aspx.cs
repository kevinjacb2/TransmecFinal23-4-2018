using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_Driver : System.Web.UI.Page
{
    myclass class1 = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "DriverMaster-Car Rental System";
        if (!Page.IsPostBack)
        {

            addstate();
            addlicensetype();
            showdata();

        }
    }

    void addstate()
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from State_Master", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "State_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddstate.DataSource = ds.Tables[0].DefaultView;
            ddstate.DataTextField = "State_name";
            ddstate.DataValueField = "State_id";
            ddstate.DataBind();
            ddstate.Items.Insert(0, "Select");
        }
    }
    void addCity()
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from City_Master", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "City_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCity.DataSource = ds.Tables[0].DefaultView;
            ddlCity.DataTextField = "City_name";
            ddlCity.DataValueField = "City_id";
            ddlCity.DataBind();
        }
    }
    void addlicensetype()
    {

        ddlicensetype.Items.Add("Select");
        ddlicensetype.Items.Add("4 Whealer");
        ddlicensetype.Items.Add("Heavy Vehical");
    }
    void showdata()
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT Driver_Master.Driver_id, Driver_Master.Driver_name, Driver_Master.Driver_address, Driver_Master.Driver_Dob, City_Master.City_name FROM Driver_Master INNER JOIN City_Master ON Driver_Master.Driver_city = City_Master.City_id", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Driver_Master");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        if (ddlicensetype.SelectedValue != "Select")
        {
            String str;
            str = "insert into Driver_Master values('" + txtdrivername.Text + "','" + txtdriveraddress.Text + "'," + ddstate.SelectedValue + "," + ddlCity.SelectedValue + ",'" + Convert.ToDateTime(txtDateofBirth.Text).ToString("yyyy/MM/dd") + "','" + txtdriverlicenseno.Text + "','" + Convert.ToDateTime(txtlicensedate.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(txtlicensexpdate.Text).ToString("yyyy/MM/dd") + "','" + ddlicensetype.SelectedValue + "','Available')";
            SqlCommand cmd = new SqlCommand(str, class1.con);
            class1.con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Write("<script>alert('Saved successfully.....')</script>");
                showdata();
            }
            else
            {
                Response.Write("<script>alert('Error.....')</script>");
            }
            class1.con.Close();
        }
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        string str;
        str = " delete from Driver_Master where Driver_id= " + txtdriverid.Text;
        SqlCommand cmd = new SqlCommand(str, class1.con);
        class1.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Deleted successfully.....')</script>");
            showdata();
        }
        else
        {
            Response.Write("<script>alert('Error....')</script>");
        }
        class1.con.Close();
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        string str;
        str = "update Driver_Master set Driver_name='" + txtdrivername.Text + "',Driver_address='" + txtdriveraddress.Text + "',Driver_state='" + ddstate.SelectedValue + "',Driver_city='" + ddlCity.SelectedValue + "',Driver_age=" + txtDateofBirth.Text + ",Driver_licenseno='" + txtdriverlicenseno.Text + "',License_date='" + txtlicensedate.Text + "',License_expiry='" + txtlicensexpdate.Text + "',License_type='" + ddlicensetype.SelectedValue + "'where Driver_id=" + txtdriverid.Text;

        SqlCommand cmd = new SqlCommand(str, class1.con);
        class1.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Updated successfully.....')</script>");
            showdata();
        }
        else
        {
            Response.Write("<script>alert('Error.....')</script>");
        }
        class1.con.Close();
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        txtDateofBirth.Text = "";
        txtdriveraddress.Text = "";
        ddlCity.Text = "";
        txtdriverid.Text = "";
        txtdriverlicenseno.Text = "";
        txtdrivername.Text = "";
        txtlicensedate.Text = "";
        txtlicensexpdate.Text = "";
    }
    protected void link_edit_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "select * from Driver_master where Driver_id=" + Convert.ToInt32(lnk.CommandArgument.ToString());
        SqlDataAdapter da = new SqlDataAdapter(str, class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Driver_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtdriverid.Text = ds.Tables[0].Rows[0]["Driver_id"].ToString();
            txtdrivername.Text = ds.Tables[0].Rows[0]["Driver_name"].ToString();
            txtdriveraddress.Text = ds.Tables[0].Rows[0]["Driver_address"].ToString();

            ddstate.Text = ds.Tables[0].Rows[0]["Driver_state"].ToString();
            addCity();
            ddlCity.Text = ds.Tables[0].Rows[0]["Driver_city"].ToString();
            txtDateofBirth.Text = ds.Tables[0].Rows[0]["Driver_Dob"].ToString();
            txtdriverlicenseno.Text = ds.Tables[0].Rows[0]["Driver_licenseno"].ToString();
            txtlicensedate.Text = ds.Tables[0].Rows[0]["License_date"].ToString();
            txtlicensexpdate.Text = ds.Tables[0].Rows[0]["License_expiry"].ToString();
            ddlicensetype.SelectedValue = ds.Tables[0].Rows[0]["License_type"].ToString();

        }
    }
    protected void link_delete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "Delete from Driver_Master where Driver_id =" + Convert.ToInt32(lnk.CommandArgument.ToString()); ;
        SqlCommand cmd = new SqlCommand(str, class1.con);
        class1.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Deleted successfully.....')</script>");
            showdata();
        }
        else
        {
            Response.Write("<script>alert('Error....')</script>");
        }
        class1.con.Close();
    }
    protected void ddstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from City_Master where State_Id=" + ddstate.SelectedValue, class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "City_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCity.DataSource = ds.Tables[0].DefaultView;
            ddlCity.DataTextField = "City_name";
            ddlCity.DataValueField = "City_id";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, "Select");
        }
    }
}