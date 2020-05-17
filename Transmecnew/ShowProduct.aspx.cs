using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class ShowProduct : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUserName.Visible = false;

        if (!Page.IsPostBack)
        {

            addCategory();
            BindData();
            if (Session["username"] != null)
            {
                lblUserName.Text = Session["username"].ToString();
                //                lblusername.Text = Request.QueryString["username"].ToString();
                Session["username"] = lblUserName.Text;
            }
        }


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
            ddlProdCate.DataSource = ds.Tables[0].DefaultView;

            ddlProdCate.DataTextField = "Product_Category_Name";
            ddlProdCate.DataValueField = "Product_Category_Id";

            ddlProdCate.DataBind();
            // ddlCountryId.Items.Insert(0, "Select");
        }
    }


    void addsubCategory()
    {
        string str;
        str = "select * from SubCategory";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "SubCategory");


        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlSubCat.DataSource = ds.Tables[0].DefaultView;

            ddlSubCat.DataTextField = "Sub_Cat_Name";
            ddlSubCat.DataValueField = "Sub_Cat_Id";

            ddlSubCat.DataBind();
            // ddlCountryId.Items.Insert(0, "Select");
        }
    }

    public void BindData()
    {

        objmyclass.con.Open();
        string str;
        str = "select * from Product_Master";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Product_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }
        objmyclass.con.Close();

    }

    //void ShowData()
    //{
    //    string str;
    //    str = "select * from Product_Master";
    //    SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds, "Product_Master");
    //    GridView1.DataSource = ds.Tables[0].DefaultView;
    //    GridView1.DataBind();
    //}
    protected void ddlProdCate_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSubCat.Items.Clear();
        string str;
        str = "select * from SubCategory where Product_Category_Id=" + ddlProdCate.SelectedValue;
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "SubCategory");


        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlSubCat.DataSource = ds.Tables[0].DefaultView;

            ddlSubCat.DataTextField = "Sub_Cat_Name";
            ddlSubCat.DataValueField = "Sub_Cat_Id";

            ddlSubCat.DataBind();
            // ddlCountryId.Items.Insert(0, "Select");
        }
    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Cart")
        {
            int Productid;
            Productid = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("AddtoCart.aspx?pid=" + Productid);
        }
    }
    protected void ddlSubCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        objmyclass.con.Open();
        string str;
        str = "select * from Product_Master where sub_Cat_Id=" + ddlSubCat.SelectedValue;
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Product_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }
        objmyclass.con.Close();
    }
}