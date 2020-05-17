using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Client_ViewAmount : System.Web.UI.Page
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
        SqlDataAdapter da = new SqlDataAdapter("select * from ApproveBooking_Car where Status='Pending' AND Client_Id=" + Session["ClientId"].ToString(), objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "ApproveBooking_Car");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlGivenId.DataSource = ds.Tables[0].DefaultView;
            ddlGivenId.DataTextField = "Appove_id";
            ddlGivenId.DataValueField = "Appove_id";
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
        string str1 = "";
        if (lblChoiceType.Text == "OutStation")
        {
            double advance = Convert.ToDouble(txtAdvanceRupees.Text);
            double TotalAppRupees = Convert.ToDouble(lblApproximateRupees.Text);
            double remaining = TotalAppRupees - advance;
            str1 = "update ApproveBooking_Car set Status='Advance By Client',Payment_Type='" + ddlPaymentType.SelectedValue + "',Advace_Ruppes='" + txtAdvanceRupees.Text + "',Remaining_Rupees='" + remaining + "' where Appove_id='" + ddlGivenId.SelectedValue + "'";
        }
        else if (lblChoiceType.Text == "Local")
        {
            double advance = Convert.ToDouble(txtAdvanceRupees.Text);
            double TotalAppRupees = Convert.ToDouble(lblRate.Text);
            double remaining = TotalAppRupees - advance;
            str1 = "update ApproveBooking_Car set Status='Advance By Client',Payment_Type='" + ddlPaymentType.SelectedValue + "',Advace_Ruppes='" + txtAdvanceRupees.Text + "',Remaining_Rupees='" + remaining + "' where Appove_id='" + ddlGivenId.SelectedValue + "'";
        }
        SqlCommand cmd1 = new SqlCommand(str1, objmyclass.con);
        objmyclass.con.Open();
        int i1 = cmd1.ExecuteNonQuery();
        if (i1 > 0)
        {
            Response.Write("<script>alert('Updated successfully.....')</script>");

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
    protected void ddlGivenId_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from ApproveBooking_Car where Appove_id=" + ddlGivenId.SelectedValue, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "ApproveBooking_Car");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtBookingId.Text = ds.Tables[0].Rows[0]["Booking_id"].ToString();
            txtClientId.Text = ds.Tables[0].Rows[0]["Client_Id"].ToString();
            txtClientChoiceId.Text = ds.Tables[0].Rows[0]["ClientChoice_id"].ToString();
            lblChoiceType.Text = ds.Tables[0].Rows[0]["ClientChoice_Type"].ToString();
            lblRate.Text = ds.Tables[0].Rows[0]["Car_Rate"].ToString();
            lblPickupTime.Text = ds.Tables[0].Rows[0]["Start_Time"].ToString();
            lblApproximateKm.Text = ds.Tables[0].Rows[0]["Appro_Km"].ToString();
            lblApproximateRupees.Text = ds.Tables[0].Rows[0]["Appro_Rupees"].ToString();
            txtAdvanceRupees.Text = ds.Tables[0].Rows[0]["Advace_Ruppes"].ToString();
            addChoice();
        }
    }

    public void addChoice()
    {
        if (lblChoiceType.Text == "OutStation")
        {
            string str = "select Out_City as FROMCITY,Out_DestiCity as TOCITY from Client_ChoiceMaster where ClientChoice_id='" + txtClientChoiceId.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DetailsView1.DataSource = dt.DefaultView;
                DetailsView1.DataBind();

            }
        }
        else if (lblChoiceType.Text == "Local")
        {
            string str = "select Local_City,Per_Hrs from Client_ChoiceMaster where ClientChoice_id='" + txtClientChoiceId.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DetailsView1.DataSource = dt.DefaultView;
                DetailsView1.DataBind();

            }
        }
        else if (lblChoiceType.Text == "")
        {

        }
        else
        {

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


        }
        else if (ddlPaymentType.SelectedItem.Text == "Paypal")
        {

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

        }
    }
    protected void btnCreditCard_Click(object sender, EventArgs e)
    {
        string str1 = "";
        if (lblChoiceType.Text == "OutStation")
        {
            double advance = Convert.ToDouble(txtAdvanceRupees.Text);
            double TotalAppRupees = Convert.ToDouble(lblApproximateRupees.Text);
            double remaining = TotalAppRupees - advance;
            str1 = "update ApproveBooking_Car set Status='Advance By Client',Payment_Type='" + ddlPaymentType.SelectedValue + "',Advace_Ruppes='" + txtAdvanceRupees.Text + "',Remaining_Rupees='" + remaining + "' where Appove_id='" + ddlGivenId.SelectedValue + "'";
        }
        else if (lblChoiceType.Text == "Local")
        {
            double advance = Convert.ToDouble(txtAdvanceRupees.Text);
            double TotalAppRupees = Convert.ToDouble(lblRate.Text);
            double remaining = TotalAppRupees - advance;
            str1 = "update ApproveBooking_Car set Status='Advance By Client',Payment_Type='" + ddlPaymentType.SelectedValue + "',Advace_Ruppes='" + txtAdvanceRupees.Text + "',Remaining_Rupees='" + remaining + "' where Appove_id='" + ddlGivenId.SelectedValue + "'";
        }
        SqlCommand cmd1 = new SqlCommand(str1, objmyclass.con);
        objmyclass.con.Open();
        int i1 = cmd1.ExecuteNonQuery();
        if (i1 > 0)
        {
            //Response.Write("<script>alert('Updated successfully.....')</script>");
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            Response.Write("<script>alert('Error.....')</script>");
        }
        objmyclass.con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Paypal.aspx?billid=" + txtBookingId.Text + "&amount=" + txtAdvanceRupees.Text);
    }
}