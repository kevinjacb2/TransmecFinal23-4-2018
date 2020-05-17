using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_Car : System.Web.UI.Page
{
    myclass class1 = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            addfueltype();
            showdata();
            addCarName();
        }
    }
    void showdata()
    {
        SqlDataAdapter da = new SqlDataAdapter("select CarDetail_id,Car_Name,Car_Model,Car_brand,Car_Color,Car_Rate from Car_Details", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Car_Details");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }
    void addfueltype()
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from Fuel_Master", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Fuel_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddfueltype.DataSource = ds.Tables[0].DefaultView;
            ddfueltype.DataTextField = "Fuel_type";
            ddfueltype.DataValueField = "Fuel_id";
            ddfueltype.DataBind();
            ddfueltype.Items.Insert(0, "Select");
        }
    }
    void addCarName()
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from Car_Master", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Car_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCarName.DataSource = ds.Tables[0].DefaultView;
            ddlCarName.DataTextField = "Car_Name";
            ddlCarName.DataValueField = "Car_Id";
            ddlCarName.DataBind();
            ddlCarName.Items.Insert(0, "Select");
        }
    }

    public void cleardata()
    {
        txtcarbrand.Text = "";
        txtcarcapacity.Text = "";
        txtcarcc.Text = "";
        txtcarid.Text = "";
        txtcarmileage.Text = "";
        ddlCarName.Text = "Select";
        txtcartype.Text = "";
        txtchassesno.Text = "";
        txtengineno.Text = "";
        txtRemainingCar.Text = "";
        txtRate.Text = "";
        ddfueltype.Text = "Select";

    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("~/CarImages/" + FileUpload1.FileName));
            Image3.ImageUrl = "~/CarImages/" + FileUpload1.FileName;
        }
        string img;
        img = "~/CarImages/" + FileUpload1.FileName;
        string str, str1;
        //str = "insert into Car_Details values('" + ddlCarName.SelectedItem + "','" + txtcarbrand.Text + "','" + txtcartype.Text + "','" + txtcarbrand.Text + "','" + txtColor.Text + "'," + txtcarcapacity.Text + ",'" + ddfueltype.SelectedValue + "'," + txtcarcc.Text + "," + txtcarmileage.Text + ",'" + txtchassesno.Text + "','" + txtengineno.Text + "','" + txtRate.Text + "','" + txtLocalCityRate.Text + "','" + img + "','Available')";
        str = "insert into Car_Details values('" + ddlCarName.SelectedItem + "','" + txtcarbrand.Text + "','" + txtcartype.Text + "','" + txtColor.Text + "'," + txtcarcapacity.Text + ",'" + ddfueltype.SelectedValue + "'," + txtcarcc.Text + "," + txtcarmileage.Text + ",'" + txtchassesno.Text + "','" + txtengineno.Text + "','" + txtRate.Text + "','" + txtLocalCityRate.Text + "','" + img + "','Available')";
        int tatolcar = Convert.ToInt32(txtRemainingCar.Text);
        int remainingcar = tatolcar - 1;
        str1 = "update  Car_Master set Car_Quantity='" + remainingcar + "' where car_id=" + ddlCarName.SelectedValue;
        SqlCommand cmd = new SqlCommand(str, class1.con);
        SqlCommand cmd1 = new SqlCommand(str1, class1.con);
        class1.con.Open();
        int i = cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Save successfully.....')</script>");
            showdata();
            cleardata();
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
        str = " delete from Car_Details where CarDetail_id= " + txtcarid.Text;
        SqlCommand cmd = new SqlCommand(str, class1.con);
        class1.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Deleted successfully.....')</script>");
            showdata();
            cleardata();
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
        str = "update Car_Details set Car_name='" + ddlCarName.SelectedValue + "',Car_Model='" + txtcartype.Text + "',Car_brand='" + txtcarbrand.Text + "',Car_Color='" + txtColor.Text + "',Car_capacity=" + txtcarcapacity.Text + ",Fuel_type='" + ddfueltype.SelectedValue + "',Car_cc=" + txtcarcc.Text + ",Car_mileage=" + txtcarmileage.Text + ",Chasses_no='" + txtchassesno.Text + "',Engine_no='" + txtengineno.Text + "',Car_Rate='" + txtRate.Text + "' where CarDetail_id=" + txtcarid.Text + "";
        SqlCommand cmd = new SqlCommand(str, class1.con);
        class1.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Updated successfully.....')</script>");
            showdata();
            cleardata();
        }
        else
        {
            Response.Write("<script>alert('Error.....')</script>");
        }
        class1.con.Close();
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        cleardata();
    }
    protected void link_edit_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "select * from Car_Details where CarDetail_id=" + Convert.ToInt32(lnk.CommandArgument.ToString());
        SqlDataAdapter da = new SqlDataAdapter(str, class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Car_Details");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtcarid.Text = ds.Tables[0].Rows[0]["CarDetail_id"].ToString();
            // ddlCarName.Text= ds.Tables[0].Rows[0]["Car_name"].ToString();
            txtcartype.Text = ds.Tables[0].Rows[0]["Car_Model"].ToString();
            txtcarbrand.Text = ds.Tables[0].Rows[0]["Car_brand"].ToString();
            txtColor.Text = ds.Tables[0].Rows[0]["Car_Color"].ToString();
            txtcarcapacity.Text = ds.Tables[0].Rows[0]["Car_capacity"].ToString();
            ddfueltype.SelectedValue = ds.Tables[0].Rows[0]["Fuel_type"].ToString();
            txtcarcc.Text = ds.Tables[0].Rows[0]["Car_cc"].ToString();
            txtcarmileage.Text = ds.Tables[0].Rows[0]["Car_mileage"].ToString();
            txtchassesno.Text = ds.Tables[0].Rows[0]["Chasses_no"].ToString();
            txtengineno.Text = ds.Tables[0].Rows[0]["Engine_no"].ToString();
            txtRate.Text = ds.Tables[0].Rows[0]["Car_Rate"].ToString();



        }
    }
    protected void link_delete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "Delete from Car_Details where CarDetail_id =" + Convert.ToInt32(lnk.CommandArgument.ToString()); ;
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
    protected void ddlCarName_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from Car_Master where Car_Id=" + ddlCarName.SelectedValue, class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Car_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtcarbrand.Text = ds.Tables[0].Rows[0]["Car_Brand"].ToString();
            txtRemainingCar.Text = ds.Tables[0].Rows[0]["Car_Quantity"].ToString();
        }
    }
}