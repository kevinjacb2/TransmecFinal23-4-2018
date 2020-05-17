using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Client_ViewFinalAmount : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            divPayment.Visible = false;
            showdata();
            btnCreditCard.Visible = false;
            lblBankName.Visible = false;
            lblBranch.Visible = false;
            lblChequeNo.Visible = false;
            txtBankName.Visible = false;
            txtBranchName.Visible = false;
            txtChequeNo.Visible = false;

        }
    }

    void showdata()
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from Given_Car where Status='Return By Client' AND ClientId=" + Session["ClientId"].ToString(), objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Given_Car");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlGivenId.DataSource = ds.Tables[0].DefaultView;
            ddlGivenId.DataTextField = "CarGiven_Id";
            ddlGivenId.DataValueField = "CarGiven_Id";
            ddlGivenId.DataBind();
            ddlGivenId.Items.Insert(0, "Select");
        }
        else
        {
            ddlGivenId.Items.Insert(0, "NO Any Information");
        }
    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
        string str1 = "update Given_Car set Status='Full Payment By Client' where CarGiven_Id='" + ddlGivenId.SelectedValue + "'";
        SqlCommand cmd1 = new SqlCommand(str1, objmyclass.con);
        objmyclass.con.Open();
        int i1 = cmd1.ExecuteNonQuery();
        if (i1 > 0)
        {
            Response.Write("<script>alert('Payment successfully.....')</script>");

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
    protected void btnCreditCard_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Paypal.aspx?billid=" + lblBookingId.Text + "&amount=" + lblRemainingAmount.Text);
    }
    protected void ddlGivenId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGivenId.SelectedValue != "Select")
        {
            string str = "select * from Given_Car where CarGiven_id = " + ddlGivenId.SelectedValue;
            SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                lblApproveID.Text = dt.Rows[0]["Approve_id"].ToString();
                lblBookingId.Text = dt.Rows[0]["Booking_id"].ToString();
                lblClientId.Text = dt.Rows[0]["Clientid"].ToString();
                lblChoiceType.Text = dt.Rows[0]["ClientChoice_Type"].ToString();
                lblCarId.Text = dt.Rows[0]["CarDetail_Id"].ToString();
                lblCarRate.Text = dt.Rows[0]["Car_Rate"].ToString();
                lblAdvanceRupees.Text = dt.Rows[0]["Advance_Rupees"].ToString();
                lblGivenDate.Text = dt.Rows[0]["Given_Date"].ToString();
                lblReading.Text = dt.Rows[0]["StartingMeter"].ToString();
                lblCarReturnDate.Text = dt.Rows[0]["Return_Date"].ToString();
                lblReturnMeterReading.Text = dt.Rows[0]["EndingMeter"].ToString();
                lblTotalKM.Text = dt.Rows[0]["TotalKilometer"].ToString();
                lblTotalAmount.Text = dt.Rows[0]["TotalRate"].ToString();
                lblRemainingAmount.Text = dt.Rows[0]["Remaining_Amount"].ToString();
                if (lblRemainingAmount.Text == "0")
                {
                    divPayment.Visible = false;
                }
                else
                {
                    divPayment.Visible = true;
                }
            }
        }
    }
    protected void ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaymentType.SelectedItem.Text == "CashOnDelivery")
        {

        }
        else if (ddlPaymentType.SelectedItem.Text == "ByCheque")
        {
            lblBankName.Visible = true;
            lblBranch.Visible = true;
            lblChequeNo.Visible = true;
            txtBankName.Visible = true;
            txtBranchName.Visible = true;
            txtChequeNo.Visible = true;
            Button1.Visible = false;
        }
        else if (ddlPaymentType.SelectedItem.Text == "ByCreditCard")
        {
            btnCreditCard.Visible = true;
            lblBankName.Visible = false;
            lblBranch.Visible = false;
            lblChequeNo.Visible = false;
            txtBankName.Visible = false;
            txtBranchName.Visible = false;
            txtChequeNo.Visible = false;
            Button1.Visible = false;

        }
        else if (ddlPaymentType.SelectedItem.Text == "Paypal")
        {
            Button1.Visible = true;
        }
        else
        {
            lblBankName.Visible = false;
            lblBranch.Visible = false;
            lblChequeNo.Visible = false;
            txtBankName.Visible = false;
            txtBranchName.Visible = false;
            txtChequeNo.Visible = false;
            btnCreditCard.Visible = false;
            Button1.Visible = false;
        }
    }
}