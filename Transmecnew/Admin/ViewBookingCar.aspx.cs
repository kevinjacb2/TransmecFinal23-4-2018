using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


public partial class Admin_ViewBookingCar : System.Web.UI.Page
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
        SqlDataAdapter da = new SqlDataAdapter("select * from Booking_Car where Status='Pending'", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Booking_Car");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();

    }
    protected void linkbtnedit_Click(object sender, EventArgs e)
    {
        LinkButton lnkview = (LinkButton)sender;
        string BookingId = lnkview.CommandArgument.ToString();
        Response.Redirect("~/Admin/ViewParticularClient.aspx?Bookingid=" + BookingId);
    }
}