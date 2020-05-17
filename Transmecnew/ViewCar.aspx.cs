using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class ViewCar : System.Web.UI.Page
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
        SqlDataAdapter da = new SqlDataAdapter("select * from Car_Master", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Car_Master");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();

    }
    protected void linkbtnedit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }
}