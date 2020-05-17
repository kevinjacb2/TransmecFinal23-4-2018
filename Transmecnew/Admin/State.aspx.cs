using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_State : System.Web.UI.Page
{
    myclass class1 = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            showdata();
        }
    }

    void showdata()
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from State_Master", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "State_master");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();

    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        string str;
        str = " insert into State_master values('" + txtstatename.Text + "')";
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
        str = "Delete from State_Master where State_id=" + txtstateid.Text;
        SqlCommand cmd = new SqlCommand(str, class1.con);
        class1.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Delated successfully.....')</script>");
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
        str = "update State_Master set State_name='" + txtstatename.Text + "'  where State_id=" + txtstateid.Text;
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
            Response.Write("<script>alert('Error....')</script>");
        }
        class1.con.Close();
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        txtstateid.Text = "";
        txtstatename.Text = "";
    }
    protected void linkbtnedit_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "select * from State_Master where State_id =" + Convert.ToInt32(lnk.CommandArgument.ToString());
        SqlDataAdapter da = new SqlDataAdapter(str, class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "State_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtstateid.Text = ds.Tables[0].Rows[0]["State_id"].ToString();

            txtstatename.Text = ds.Tables[0].Rows[0]["State_name"].ToString();
        }
    }
    protected void linkbtndelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "Delete from State_Master where State_id=" + Convert.ToInt32(lnk.CommandArgument.ToString()); ;
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