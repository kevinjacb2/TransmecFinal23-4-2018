using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class ContactUs : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            showdata();

        }
    }
    void showdata()
    {

        SqlDataAdapter da = new SqlDataAdapter("SELECT  From Trip WHERE Desigid 1", objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Staff");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }
}