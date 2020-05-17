using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class BillingInfo : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
         
        //txtBankName.Text = "";
        //txtChequeNo.Text = "";
        //txtBranchName.Text = "";
        txtAmount.Text = Session["gamt"].ToString();
        txtUname.Text = Session["username"].ToString();
        txtPDate.Text = Session["purdate"].ToString();
        txtWarrantyPer.Text = Session["warrantyPeriod"].ToString();
        txtShipingCharge.Text = Session["ShipCharge"].ToString();
        TextBox6.Text = "Confirmation!!! please check your Total Amount details";
        txtCurrType.Text = "Rs";

        lblBankName.Visible = false;
        lblBranch.Visible = false;
        lblChequeNo.Visible = false;
        txtBankName.Visible = false;
        txtBranchName.Visible = false;
        txtChequeNo.Visible = false;
        btnCreditCard.Visible = false;
        btnPaypal.Visible = false;
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
      
        else
        {
            lblBankName.Visible = false;
            lblBranch.Visible = false;
            lblChequeNo.Visible = false;
            txtBankName.Visible = false;
            txtBranchName.Visible = false;
            txtChequeNo.Visible = false;
            btnCreditCard.Visible = false;
            btnPaypal.Visible = false;
        }

    }
    protected void btnCreditCard_Click(object sender, EventArgs e)
    {
        string str;
        str = "insert into Billing  values('" + txtUname.Text + "','" + Convert.ToDateTime(txtPDate.Text).ToString("yyyy/MM/dd") + "','" + txtWarrantyPer.Text + "'," + txtAmount.Text + "," + txtShipingCharge.Text + "," + txtTax.Text + "," + txtNetAmt.Text + ",'" + ddlPaymentType.SelectedItem + "','" + txtCurrType.Text + "','" + txtBankName.Text + "','" + txtChequeNo.Text + "','" + txtBranchName.Text + "')";
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

        Response.Redirect("default.aspx");
    }
    protected void btnPaypal_Click(object sender, EventArgs e)
    {
        // Session["OrderAmt"] =Convert.ToInt32(txtNetAmt.Text);
        Response.Redirect("orderform.aspx");
        string str;
        str = "insert into Billing  values('" + txtUname.Text + "','" + Convert.ToDateTime(txtPDate.Text).ToString("yyyy/MM/dd") + "','" + txtWarrantyPer.Text + "'," + txtAmount.Text + "," + txtShipingCharge.Text + "," + txtTax.Text + "," + txtNetAmt.Text + ",'" + ddlPaymentType.SelectedItem + "','" + txtCurrType.Text + "','" + txtBankName.Text + "','" + txtChequeNo.Text + "','" + txtBranchName.Text + "')";
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
        Response.Redirect("processing.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        double a, b, c, d;
        a = Convert.ToDouble(txtAmount.Text);
        b = Convert.ToDouble(txtShipingCharge.Text);
        // c = Convert.ToDouble(txtTax.Text);
        double Amount, NetAmt, FinalAmt, NgoAmt;
        Amount = a + b;
        NetAmt = Amount * 4 / 100;
        txtTax.Text = NetAmt.ToString();
        FinalAmt = Amount + NetAmt;
        //  NgoAmt = FinalAmt * 5 / 100;
        txtNetAmt.Text = FinalAmt.ToString();
        //  lblNgoAmt.Text = NgoAmt.ToString();




    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str;
        str = "insert into Billing  values('" + txtUname.Text + "','" + Convert.ToDateTime(txtPDate.Text).ToString("yyyy/MM/dd") + "','" + txtWarrantyPer.Text + "'," + txtAmount.Text + "," + txtShipingCharge.Text + "," + txtTax.Text + "," + txtNetAmt.Text + ",'" + ddlPaymentType.SelectedItem + "','" + txtCurrType.Text + "','" + txtBankName.Text + "','" + txtChequeNo.Text + "','" + txtBranchName.Text + "')";
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
    }
    protected void txtCurrType_TextChanged(object sender, EventArgs e)
    {

    }
}