using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_City : System.Web.UI.Page
{
    myclass class1 = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            addstateid();

            showdata();

        }
    }

    void showdata()
    {
        //SqlDataAdapter da = new SqlDataAdapter("SELECT City_Master.City_id, State_Master.State_name, City_Master.City_name FROM  State_Master INNER JOIN  City_Master ON State_Master.State_id = City_Master.State_id", class1.con);
        SqlDataAdapter da = new SqlDataAdapter("SELECT        City_Master.City_id, City_Master.City_name, State_Master.State_name FROM City_Master INNER JOIN State_Master ON City_Master.State_id = State_Master.State_id", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "City_Master");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }

    public void addstateid()
    {

        SqlDataAdapter da = new SqlDataAdapter("select * from state_master", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "state_master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddstate.DataSource = ds.Tables[0].DefaultView;
            ddstate.DataTextField = "State_name";
            ddstate.DataValueField = "State_id";
            ddstate.DataBind();
            ddstate.Items.Insert(0, "Select");
        }
    }

    protected void btn_insert_Click(object sender, EventArgs e)
    {
        string str;
        str = "insert into City_Master values (" + ddstate.SelectedValue + ",'" + txtcityname.Text + "')";
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
        str = "delete from City_Master where City_id =" + txtcityid.Text;
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
    protected void btn_update_Click(object sender, EventArgs e)
    {
        string str;
        str = "Update City_Master set City_name ='" + txtcityname.Text + "',State_id=" + ddstate.SelectedValue + "  where City_id =" + txtcityid.Text;
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
        showdata();
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        txtcityid.Text = "";
        txtcityname.Text = "";
    }
    protected void linkbtnedit_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "select * from City_Master where City_id=" + Convert.ToInt32(lnk.CommandArgument.ToString());
        SqlDataAdapter da = new SqlDataAdapter(str, class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "City_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtcityid.Text = ds.Tables[0].Rows[0]["City_id"].ToString();
            txtcityname.Text = ds.Tables[0].Rows[0]["City_name"].ToString();

            ddstate.Text = ds.Tables[0].Rows[0]["State_id"].ToString();



        }
    }
    protected void linkbtndelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "delete from City_Master where City_id =" + Convert.ToInt32(lnk.CommandArgument.ToString()); ;
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