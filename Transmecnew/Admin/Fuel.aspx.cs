using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_Fuel : System.Web.UI.Page
{
    myclass class1 = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        showdata();
    }
    void showdata()
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from Fuel_Master", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Fuel_Master");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        string str;
        str = "insert into Fuel_Master values('" + txtfueltype.Text + "')";
        SqlCommand cmd = new SqlCommand(str, class1.con);
        class1.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Save successfully.....')</script>");
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
        str = " delete from Fuel_Master where Fuel_id= " + txtfuelid.Text;
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
        str = " Update Fuel_Master set Fuel_type='" + txtfueltype.Text + "' where Fuel_id=" + txtfuelid.Text;
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
        txtfuelid.Text = "";
        txtfueltype.Text = "";
    }
    protected void link_edit_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "select * from Fuel_master where Fuel_id=" + Convert.ToInt32(lnk.CommandArgument.ToString());
        SqlDataAdapter da = new SqlDataAdapter(str, class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Fuel_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtfuelid.Text = ds.Tables[0].Rows[0]["Fuel_id"].ToString();
            txtfueltype.Text = ds.Tables[0].Rows[0]["Fuel_type"].ToString();
        }

    }
    protected void link_delete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "Delete from Fuel_Master where Fuel_id =" + Convert.ToInt32(lnk.CommandArgument.ToString()); ;
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