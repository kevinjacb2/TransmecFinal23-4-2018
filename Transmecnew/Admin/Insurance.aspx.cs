using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_Insurance : System.Web.UI.Page
{
    myclass class1 = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            addcarid();
            showdata();
        }
    }

    void showdata()
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from Insurance_Master", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Insurance_Master");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }


    void addcarid()
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from Car_Master ", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Car_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddcarid.DataSource = ds.Tables[0].DefaultView;
            ddcarid.DataTextField = "Car_name";
            ddcarid.DataValueField = "Car_id";
            ddcarid.DataBind();
            ddcarid.Items.Insert(0, "Select");
        }
    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        string str;
        str = "insert into Insurance_Master values ('" + txtcmpanyname.Text + "','" + txtdescription.Text + "'," + ddcarid.SelectedValue + "," + txtinsuranceamt.Text + ",'" + Convert.ToDateTime(txtinsurancedate.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(txtexpirydate.Text).ToString("yyyy/MM/dd") + "')";
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
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        string str;
        str = "delete from Insurance_Master where Insuance_id= " + txtinsuranceid.Text;
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
            Response.Write("<script>alert('Error.....')</script>");
        }
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        string str;
        str = " Update Insurance_Master set Insurance_name='" + txtcmpanyname.Text + "',Insurance_desc='" + txtdescription.Text + "',Car_id= " + ddcarid.SelectedValue + ",Insurance_amt=" + txtinsuranceamt.Text + ",Insurance_date= '" + txtinsurancedate.Text + "',Insurance_expdate='" + txtexpirydate.Text + "' where Insurance_id=" + txtinsuranceid.Text;

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
        txtcmpanyname.Text = "";
        txtdescription.Text = "";
        txtexpirydate.Text = "";
        txtinsuranceamt.Text = "";
        txtinsurancedate.Text = "";
        txtinsuranceid.Text = "";

    }
    protected void link_edit_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "select * from Insurance_Master where Insurance_id=" + Convert.ToInt32(lnk.CommandArgument.ToString());
        SqlDataAdapter da = new SqlDataAdapter(str, class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Insurance_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtinsuranceid.Text = ds.Tables[0].Rows[0]["Insurance_id"].ToString();
            txtcmpanyname.Text = ds.Tables[0].Rows[0]["Insurance_name"].ToString();
            txtdescription.Text = ds.Tables[0].Rows[0]["Insurance_desc"].ToString();
            ddcarid.SelectedValue = ds.Tables[0].Rows[0]["Car_id"].ToString();

            txtinsuranceamt.Text = ds.Tables[0].Rows[0]["Insurance_amt"].ToString();
            txtinsurancedate.Text = ds.Tables[0].Rows[0]["Insurance_date"].ToString();
            txtexpirydate.Text = ds.Tables[0].Rows[0]["Insurance_expdate"].ToString();

        }
    }
    protected void link_delete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "Delete from Insurance_Master where Insurance_id=" + Convert.ToInt32(lnk.CommandArgument.ToString()); ;
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
            Response.Write("<script>alert('Error.....')</script>");
        }
        class1.con.Close();
    }
}