using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_Designation : System.Web.UI.Page
{
    myclass class1 = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        showdata();
    }

    void showdata()
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from Designation_Master", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Designation_Master");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        txtdesigid.Text = "";
        txtdesigname.Text = "";
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        string str;
        str = " Update Designation_Master set Desig_name='" + txtdesigname.Text + "' where Desig_id=" + txtdesigid.Text;
        SqlCommand cmd = new SqlCommand(str, class1.con);
        class1.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("Updated Successfully....");
            showdata();
        }
        else
        {
            Response.Write("Error.....");
        }
        class1.con.Close();
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        string str;
        str = " delete from Designation_Master where desig_id = " + txtdesigid.Text;
        SqlCommand cmd = new SqlCommand(str, class1.con);
        class1.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("Deleted successfully.....");
            showdata();
        }
        else
        {
            Response.Write("Error....");
        }
        class1.con.Close();
    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        string str;
        str = "insert into Designation_Master values('" + txtdesigname.Text + "')";
        SqlCommand cmd = new SqlCommand(str, class1.con);
        class1.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("Saved Successfully....");
            showdata();
        }
        else
        {
            Response.Write("Error.....");
        }
        class1.con.Close();
    }
    protected void linkbtnedit_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "select * from Designation_Master where Desig_id=" + Convert.ToInt32(lnk.CommandArgument.ToString());
        SqlDataAdapter da = new SqlDataAdapter(str, class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Designation_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtdesigid.Text = ds.Tables[0].Rows[0]["Desig_id"].ToString();
            txtdesigname.Text = ds.Tables[0].Rows[0]["Desig_name"].ToString();
        }    
    }
    protected void linkbtndelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "Delete from Designation_Master where Desig_id=" + Convert.ToInt32(lnk.CommandArgument.ToString()); ;
        SqlCommand cmd = new SqlCommand(str, class1.con);
        class1.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("Deleted Successfully....");
            showdata();
        }
        else
        {
            Response.Write("Error....");
        }
        class1.con.Close();
    }
}