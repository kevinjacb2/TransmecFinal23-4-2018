using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_ProdCate : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtprocatId.Visible = false;
        if (!Page.IsPostBack)
        {
            ShowData();
        }
    }

    void ShowData()
    {
        string str;
        str = "select * from Product_Category_Master";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Product_Category_Master");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        string str;
        str = "insert into Product_Category_Master values ('" + txtprocatName.Text + "')";
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "DATA IS INSERTED";
            txtprocatName.Text = "";
        }
        else
        {
            lblMsg.Visible = true;
            lblMsg.Text = "NOT INSERTED";
        }

        objmyclass.con.Close();
        ShowData();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string str;
        str = "update Product_Category_Master set Product_Category_Name='" + txtprocatName.Text + "' where Product_Category_Id=" + txtprocatId.Text;
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "DATA IS UPDATED";
            txtprocatName.Text = "";
        }
        else
        {
            lblMsg.Visible = true;
            lblMsg.Text = "NOT UPDATE";
        }
        objmyclass.con.Close();
        ShowData();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string str;
        str = "delete from Product_Category_Master where Product_Category_Id=" + txtprocatId.Text;
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "DATA IS DELETED";
            txtprocatName.Text = "";
        }
        else
        {
            lblMsg.Visible = true;
            lblMsg.Text = "DATA IS NOT DELETED";
        }
        objmyclass.con.Close();
        ShowData();
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str = "select * from Product_Category_Master where Product_Category_Id=" + Convert.ToInt32(lnk.CommandArgument.ToString());
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Product_Category_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtprocatId.Text = ds.Tables[0].Rows[0]["Product_Category_Id"].ToString();
            txtprocatName.Text = ds.Tables[0].Rows[0]["Product_Category_Name"].ToString();

        }
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        txtprocatId.Text = "";
        txtprocatName.Text = "";
    }
}