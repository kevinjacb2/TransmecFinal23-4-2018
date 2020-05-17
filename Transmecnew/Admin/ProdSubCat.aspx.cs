using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_ProdSubCat : System.Web.UI.Page
{
    myclass objmyclass =new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
         txtsubcatid.Visible = false;
        if (!Page.IsPostBack)
        {
            addCategory();
            ShowData();
        }
    }

     void ShowData()
    {
        string str;
        str = "select * from subCategory";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "subCategory");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }

    void addCategory()
    {
        string str;
        str = "select * from Product_Category_Master";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Product_Category_Master");


        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlProdcate.DataSource = ds.Tables[0].DefaultView;

            ddlProdcate.DataTextField = "Product_Category_Name";
            ddlProdcate.DataValueField = "Product_Category_Id";

            ddlProdcate.DataBind();
            // ddlCountryId.Items.Insert(0, "Select");
        }
    }
protected void  btnInsert_Click(object sender, EventArgs e)
{
     string str;
        str = "insert into subCategory values ('" + txtSubCatName.Text + "'," + ddlProdcate.SelectedValue + ")";
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            lblMsg.Text = "DATA IS INSERTED";
        }
        else
        {
            lblMsg.Text = "NOT INSERTED";
        }

        objmyclass.con.Close();
        ShowData();
}
protected void  btn_Update_Click(object sender, EventArgs e)
{
    string str;
        str = "update SubCategory set Sub_Cat_Name='" + txtSubCatName.Text + "' where Sub_Cat_Id=" + txtsubcatid.Text;
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            lblMsg.Text = "DATA IS UPDATED";
        }
        else
        {
            lblMsg.Text = "NOT UPDATE";

        }
        objmyclass.con.Close();
        ShowData();
}
protected void  btn_Delete_Click(object sender, EventArgs e)
{
     string str;
        str = "delete from SubCategory where Sub_Cat_Id=" + txtsubcatid.Text;
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            lblMsg.Text = "DATA IS DELETED";
        }
        else
        {
            lblMsg.Text = "NOT DELETED";

        }
        objmyclass.con.Close();
        ShowData();
}
protected void  Lnk_Edit_Click(object sender, EventArgs e)
{
     LinkButton lnk = (LinkButton)sender;
        string str;
        str = "select * from SubCategory where Sub_Cat_Id=" + Convert.ToInt32(lnk.CommandArgument.ToString());
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "SubCategory");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        if (GridView1.Rows.Count > 0)
        {
            txtsubcatid.Text = ds.Tables[0].Rows[0][0].ToString();
            txtSubCatName.Text = ds.Tables[0].Rows[0][1].ToString();
        }
}
protected void btn_Clear_Click(object sender, EventArgs e)
{
    txtsubcatid.Text = "";
    txtSubCatName.Text="";
}
}