using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


public partial class Car_Master : System.Web.UI.Page
{
    myclass class1 =new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            showdata();
        }
    }

     void showdata()
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from Car_Master", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Car_Master");
        grvCarMaster.DataSource = ds.Tables[0].DefaultView;
        grvCarMaster.DataBind();
    }
protected void  btnSave_Click(object sender, EventArgs e)
{
    string str;
        str = "insert into Car_Master values('" + txtCarName.Text + "','" + txtCarBrand.Text + "','" + txtCarQuantity.Text + "')";
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
}