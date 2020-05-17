using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_Givecar : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //string bookingid = Request.QueryString["BookingId"].ToString();
            showdata();
            addDriver();
            divDetail.Visible = false;
        }
    }

    public void addDriver()
    {
        string str = "select * from Driver_Master where Status='Available'";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            ddlDriver.DataSource = dt.DefaultView;
            ddlDriver.DataTextField = "Driver_Name";
            ddlDriver.DataValueField = "Driver_id";
            ddlDriver.DataBind();
            ddlDriver.Items.Insert(0, "Select");
        }
    }
    public void showdata()
    {

        string str = "select Appove_id,CLient_id,Booking_id,ClientChoice_Type,CarDetail_id,Car_Rate from ApproveBooking_Car where Start_Date = '" + System.DateTime.Now.Date.ToString("yyyy/MM/dd") + "' AND Status='Advance By Client'";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str, str1, str2;
        str = "insert into Given_Car values('" + ApproveId.Text + "','" + lblBookingId.Text + "','" + lblClientId.Text + "','" + lblChoiceID.Text + "','" + lblTourType.Text + "','" + lblCarId.Text + "','" + Convert.ToDouble(lblCarRate.Text) + "','" + Convert.ToDouble(lblAdvanceRupees.Text) + "','" + System.DateTime.Now.Date + "','" + ddlDriver.SelectedValue + "','" + Convert.ToDouble(txtReading.Text) + "','null',0,0,0,0,'Given')";
        str1 = "Update ApproveBooking_Car set Status='Given To Client' where Appove_id='" + ApproveId.Text + "'";
        str2 = "Update Driver_Master set Status='UnAvailable' where Driver_id='" + ddlDriver.SelectedValue + "'";
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        SqlCommand cmd1 = new SqlCommand(str1, objmyclass.con);
        SqlCommand cmd2 = new SqlCommand(str2, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        cmd2.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Data Enter successfully.....')</script>");

        }
        else
        {
            Response.Write("<script>alert('Error.....')</script>");
        }
        objmyclass.con.Close();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        divDetail.Visible = true;
        LinkButton lnkview = (LinkButton)sender;
        string approveid = lnkview.CommandArgument.ToString();
        string str = "select * from ApproveBooking_Car where Appove_id = " + approveid;
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            ApproveId.Text = dt.Rows[0]["Appove_id"].ToString();
            lblBookingId.Text = dt.Rows[0]["Booking_id"].ToString();
            lblClientId.Text = dt.Rows[0]["Client_id"].ToString();
            lblChoiceID.Text = dt.Rows[0]["ClientChoice_id"].ToString();
            lblTourType.Text = dt.Rows[0]["ClientChoice_Type"].ToString();
            lblStartdate.Text = dt.Rows[0]["Start_Date"].ToString();
            lblEndDate.Text = dt.Rows[0]["End_Date"].ToString();
            lblAppKm.Text = dt.Rows[0]["Appro_Km"].ToString();
            lblAppRupees.Text = dt.Rows[0]["Appro_Rupees"].ToString();
            lblAdvanceRupees.Text = dt.Rows[0]["Advace_Ruppes"].ToString();
            lblRemainingRupees.Text = dt.Rows[0]["Remaining_Rupees"].ToString();
            lblPaymentType.Text = dt.Rows[0]["Payment_Type"].ToString();
            lblCarId.Text = dt.Rows[0]["CarDetail_Id"].ToString();
            lblCarRate.Text = dt.Rows[0]["Car_Rate"].ToString();
        }
    }
}