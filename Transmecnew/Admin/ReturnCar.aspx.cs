using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_ReturnCar : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            divReturnCar.Visible = false;
            showdata();
        }
    }
    void showdata()
    {
        string str = "select Appove_id,Client_id,Booking_id,ClientChoice_Type,CarDetail_id,Start_Date,End_Date from ApproveBooking_Car where End_Date = '" + System.DateTime.Now.Date.ToString("yyyy/MM/dd") + "' AND Status='Given To Client'";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
        }

    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        double Endingreading = Convert.ToDouble(txtReturnReading.Text);
        double StartingReading = Convert.ToDouble(lblReading.Text);
        double totalReading = Endingreading - StartingReading;
        txtKilometer.Text = totalReading.ToString();
        double Rate = totalReading * Convert.ToDouble(lblCarRate.Text);
        txtAmount.Text = Rate.ToString();
        txtRemainingAmount.Text = (Rate - Convert.ToDouble(lblAdvanceRupees.Text)).ToString();
    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
        string str = "", str1 = "", str2 = "";
        if (lblChoiceType.Text == "OutStation")
        {

            str = "UPDATE Given_Car SET Return_Date='" + Convert.ToDateTime(txtCarReturn.Text).ToString("yyyy/MM/dd") + "',EndingMeter=" + Convert.ToDouble(txtReturnReading.Text) + ",TotalRate=" + txtAmount.Text + ",TotalKilometer=" + txtKilometer.Text + ",Status='Return By Client',Remaining_Amount='" + txtRemainingAmount.Text + "' where CarGiven_Id='" + lblGivenId.Text + "'";
        }
        else
        {
            str = "UPDATE Given_Car SET Status='Return By Client',Remaining_Amount='" + txtRemainingAmount.Text + "' where CarGiven_Id='" + lblGivenId.Text + "'";
        }
        str1 = "Update ApproveBooking_Car set Status='Return By Client' where Appove_id='" + lblApproveID.Text + "'";
        str2 = "Update Driver_Master set Status='Available' where Driver_id='" + lblDriverId.Text + "'";
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        SqlCommand cmd1 = new SqlCommand(str1, objmyclass.con);
        SqlCommand cmd2 = new SqlCommand(str2, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery(); cmd2.ExecuteNonQuery();
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
    protected void btnReject_Click(object sender, EventArgs e)
    {

    }

    protected void linkbtnedit_Click(object sender, EventArgs e)
    {
        LinkButton lnkview = (LinkButton)sender;
        string BookingId = lnkview.CommandArgument.ToString();
        string str = "delete from Booking_Car where Booking_id='" + BookingId + "'";
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Data Updated successfully.....')</script>");

        }
        else
        {
            Response.Write("<script>alert('Error.....')</script>");
        }
        objmyclass.con.Close();

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        divReturnCar.Visible = true;
        LinkButton lnkview = (LinkButton)sender;
        string approveid = lnkview.CommandArgument.ToString();
        string str = "select * from Given_Car where Approve_id = " + approveid;
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblGivenId.Text = dt.Rows[0]["CarGiven_Id"].ToString();
            lblApproveID.Text = approveid;
            lblBookingId.Text = dt.Rows[0]["Booking_id"].ToString();
            lblClientId.Text = dt.Rows[0]["Clientid"].ToString();
            lblChoiceID.Text = dt.Rows[0]["ClientChoice_id"].ToString();
            string str1 = "select * from Client_ChoiceMaster where ClientChoice_id = '" + lblChoiceID.Text + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(str1, objmyclass.con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                lblLocalCarRateperhr.Text = dt1.Rows[0]["Per_Hrs"].ToString();
            }
            lblChoiceType.Text = dt.Rows[0]["ClientChoice_Type"].ToString();
            lblCarId.Text = dt.Rows[0]["CarDetail_Id"].ToString();
            lblDriverId.Text = dt.Rows[0]["Driver_id"].ToString();
            lblCarRate.Text = dt.Rows[0]["Car_Rate"].ToString();
            lblAdvanceRupees.Text = dt.Rows[0]["Advance_Rupees"].ToString();
            lblGivenDate.Text = dt.Rows[0]["Given_Date"].ToString();
            lblReading.Text = dt.Rows[0]["StartingMeter"].ToString();
            if (lblChoiceType.Text == "OutStation")
            {
                divOutstation.Visible = true;

            }
            else
            {
                divOutstation.Visible = false;
                double localrate = Convert.ToDouble(lblCarRate.Text);
                double advance = Convert.ToDouble(lblAdvanceRupees.Text);
                double totalamount = localrate - advance;
                txtRemainingAmount.Text = totalamount.ToString();
            }

        }
    }
}