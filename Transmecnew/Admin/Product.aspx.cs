using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_Product : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtProdId.Visible = false;
        if (!Page.IsPostBack)
        {
            ShowData();
            addCategory();
            addsubCategory();
           
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
            ddlprodCate.DataSource = ds.Tables[0].DefaultView;

            ddlprodCate.DataTextField = "Product_Category_Name";
            ddlprodCate.DataValueField = "Product_Category_Id";

            ddlprodCate.DataBind();
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
            ddlsubCat.DataSource = ds.Tables[0].DefaultView;

            ddlsubCat.DataTextField = "Sub_Cat_Name";
            ddlsubCat.DataValueField = "Sub_Cat_Id";

            ddlsubCat.DataBind();
            // ddlCountryId.Items.Insert(0, "Select");
        }
    }

    void ShowData()
    {
        string str;
        str = "select Product_Id,Product_Name,Product_Des,Quantity,Rate from Product_Master";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Product_Master");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("~/images/" + FileUpload1.FileName));
            Image3.ImageUrl = "~/images/" + FileUpload1.FileName;
        }
        string img;
        img = "~/images/" + FileUpload1.FileName;
        string str;
        str = "insert into Product_Master  values ('" + txtProdName.Text + "','" + txtprodDesc.Text + "','" + img + "'," + txtquan.Text + "," + txtRate.Text + "," + ddlprodCate.SelectedValue + "," + ddlsubCat.SelectedValue + ")";
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            lblMsg.Text = "Saved..";
        }
        else
        {
            lblMsg.Text = "Error..";
        }
        objmyclass.con.Close();
        ShowData();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("~/images/" + FileUpload1.FileName));
            Image3.ImageUrl = "~/images/" + FileUpload1.FileName;
        }
        string img;
        img = "~/images/" + FileUpload1.FileName;
        string str;
        str = "update Product_Master set Product_Name='" + txtProdName.Text + "',Product_Des='" + txtprodDesc.Text + "',Prod_Image='" + img + "',Quantity='" + Convert.ToInt32(txtquan.Text) + "',Rate='" + Convert.ToInt32(txtRate.Text) + "',Product_Category_Id='" + ddlprodCate.SelectedValue + "',Sub_Cat_Id='" + ddlsubCat.SelectedValue + "' where Product_Id=" + txtProdId.Text;
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i= cmd.ExecuteNonQuery();
        if (i > 0)
        {
            lblMsg.Text = "Updated..";
        }
        else
        {
            lblMsg.Text = "Error..";
        }
        objmyclass.con.Close();
        ShowData();
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        string str;
        str = "delete from Product_Master where Product_Id=" + txtProdId.Text;
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            lblMsg.Text = "Deleted...";
        }
        else
        {
            lblMsg.Text = "Err..";

        }
        objmyclass.con.Close();
        ShowData();

        txtProdId.Text = "";
        txtProdName.Text = "";
        txtprodDesc.Text = "";
        txtquan.Text = "";
        txtRate.Text = "";
       
        
    }
    protected void Lnk_Ed_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "select * from Product_Master where Product_Id=" + Convert.ToInt32(lnk.CommandArgument.ToString());
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Product_Master");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        if (GridView1.Rows.Count > 0)
        {
            txtProdId.Text = ds.Tables[0].Rows[0][0].ToString();
            txtProdName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtprodDesc.Text = ds.Tables[0].Rows[0][2].ToString();
            txtquan.Text = ds.Tables[0].Rows[0][4].ToString();
            txtRate.Text = ds.Tables[0].Rows[0][5].ToString();
           
            ddlprodCate.SelectedValue = ds.Tables[0].Rows[0][6].ToString();
            ddlsubCat.SelectedValue = ds.Tables[0].Rows[0][7].ToString();
         //   ddlSupplier.SelectedValue = ds.Tables[0].Rows[0][9].ToString();

        }
    }
    protected void ddlprodCate_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlsubCat.Items.Clear();
        string str;
        str = "select * from SubCategory where Product_Category_Id=" + ddlprodCate.SelectedValue;
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "SubCategory");


        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlsubCat.DataSource = ds.Tables[0].DefaultView;

            ddlsubCat.DataTextField = "Sub_Cat_Name";
            ddlsubCat.DataValueField = "Sub_Cat_Id";

            ddlsubCat.DataBind();
            // ddlCountryId.Items.Insert(0, "Select");
        }
    }
    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        
        txtprodDesc.Text = "";
        txtProdId.Text = "";
        txtProdName.Text = "";
        txtquan.Text = "";
        txtRate.Text = "";
       
    }
}