using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_ViewParticularClient : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblBookingId.Text = Request.QueryString["Bookingid"].ToString();
            string bookingid = Request.QueryString["Bookingid"].ToString();
            showdata(bookingid);
            addStateid();
            //lblAppKm.Visible = false;
            //Button1.Visible = false;
            //lblAppRupees.Visible = false;
            //lblapproRupees.Visible = false;

            //txtApproKm.Visible = false;
        }
    }

    public void addStateid()
    {
        string str = "select * from State_Master";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "State_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlstateid.DataSource = ds.Tables[0].DefaultView;
            ddlstateid.DataTextField = "State_name";
            ddlstateid.DataValueField = "State_id";
            ddlstateid.DataBind();

        }
    }
    public void showdata(string bookingid)
    {
        string str = "select * from Booking_Car where Booking_id='" + bookingid + "'";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtBookingId.Text = bookingid;
            lblClientId.Text = dt.Rows[0]["ClientId"].ToString();
            string str1 = "select * from ClientDetail where ClientId='" + lblClientId.Text + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(str1, objmyclass.con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                txtClientName.Text = dt1.Rows[0]["ClientName"].ToString();
                string gndr;
                gndr = dt1.Rows[0]["Gender"].ToString();
                if (gndr == "Male")
                {
                    rdomale.Checked = true;
                    rdofemale.Checked = false;
                }
                else
                {
                    rdofemale.Checked = true;
                    rdomale.Checked = false;
                }
                txtaddr.Text = dt1.Rows[0]["Address"].ToString();
                ddlstateid.Text = dt1.Rows[0]["StateId"].ToString();
                txtcity.Text = dt1.Rows[0]["City"].ToString();
                txtcontactno.Text = dt1.Rows[0]["ContactNo"].ToString();
                txtemailid.Text = dt1.Rows[0]["EmailId"].ToString();
            }
            lblChoiceId.Text = dt.Rows[0]["ClientChoice_Id"].ToString();
            lblChoiceType.Text = dt.Rows[0]["Car_Type"].ToString();
            addChoice();
            lblStartDate.Text = dt.Rows[0]["Start_Date"].ToString();
            lblEndDate.Text = dt.Rows[0]["End_Date"].ToString();
            lblPickuptime.Text = dt.Rows[0]["Start_Time"].ToString();
            lblCarId.Text = dt.Rows[0]["Car_id"].ToString();

            addcardetail();
        }
    }
    public void addcardetail()
    {

        string str = "select * from Car_Details where CarDetail_id='" + lblCarId.Text + "'";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            if (lblChoiceType.Text == "OutStation")
            {
                lblRate.Text = dt.Rows[0]["Car_Rate"].ToString();
                lblAppKm.Visible = true;
                Button1.Visible = true;
                lblAppRupees.Visible = true;
                lblapproRupees.Visible = true;

                txtApproKm.Visible = true;
            }
            else if (lblChoiceType.Text == "Local")
            {
                lblLocalCityRate.Text = dt.Rows[0]["Car_LocalRate"].ToString();
                lblAppKm.Visible = false;
                Button1.Visible = false;
                lblAppRupees.Visible = false;
                lblapproRupees.Visible = false;

                txtApproKm.Visible = false;
            }
        }

    }
    public void addChoice()
    {
        if (lblChoiceType.Text == "OutStation")
        {
            string str = "select Out_City,Out_DestiCity from Client_ChoiceMaster where ClientChoice_id='" + lblChoiceId.Text + "'";
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
            string str = "select Local_City,Per_Hrs from Client_ChoiceMaster where ClientChoice_id='" + lblChoiceId.Text + "'";
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        double approximatekm = Convert.ToDouble(txtApproKm.Text);
        double Rate = Convert.ToDouble(lblRate.Text);
        double approrupees = approximatekm * Rate;
        lblapproRupees.Text = approrupees.ToString();
    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
        string str = "";
        if (lblChoiceType.Text == "OutStation")
        {
            double approrupees = Convert.ToDouble(lblapproRupees.Text);
            double advanceruppes = Convert.ToDouble(txtAdvanceRupees.Text);
            double remainingRuppess = approrupees - advanceruppes;
            str = "insert into ApproveBooking_Car values('" + lblClientId.Text + "','" + lblBookingId.Text + "','" + lblChoiceId.Text + "','" + lblChoiceType.Text + "','" + lblCarId.Text + "','" + Convert.ToDouble(lblRate.Text) + "','" + Convert.ToDateTime(lblStartDate.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(lblEndDate.Text).ToString("yyyy/MM/dd") + "','" + lblPickuptime.Text + "','" + txtApproKm.Text + "','" + lblapproRupees.Text + "','" + txtAdvanceRupees.Text + "','" + remainingRuppess + "',0,'Pending')";
        }
        else if (lblChoiceType.Text == "Local")
        {
            double approrupees = Convert.ToDouble(lblLocalCityRate.Text);
            double advanceruppes = Convert.ToDouble(txtAdvanceRupees.Text);
            double remainingRuppess = approrupees - advanceruppes;
            str = "insert into ApproveBooking_Car values('" + lblClientId.Text + "','" + lblBookingId.Text + "','" + lblChoiceId.Text + "','" + lblChoiceType.Text + "','" + lblCarId.Text + "','" + Convert.ToDouble(lblLocalCityRate.Text) + "','" + Convert.ToDateTime(lblStartDate.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(lblEndDate.Text).ToString("yyyy/MM/dd") + "','" + lblPickuptime.Text + "',0,0,'" + txtAdvanceRupees.Text + "','" + remainingRuppess + "',0,'Pending')";
        }
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Inserted successfully.....')</script>");
            // Response.Redirect("~/Admin/GiveCar.aspx?BookingId=" + txtBookingId.Text);
        }
        else
        {
            Response.Write("<script>alert('Error.....')</script>");
        }
        objmyclass.con.Close();
        string str1 = "update Booking_Car set Status='Given To Client' where Booking_id='" + txtBookingId.Text + "'";
        SqlCommand cmd1 = new SqlCommand(str1, objmyclass.con);
        objmyclass.con.Open();
        int i1 = cmd1.ExecuteNonQuery();
        if (i1 > 0)
        {
            //Response.Write("<script>alert('Updated successfully.....')</script>");
            //Response.Redirect("~/Admin/GiveCar.aspx?BookingId=" + txtBookingId.Text);
        }
        else
        {
            Response.Write("<script>alert('Error.....')</script>");
        }
        objmyclass.con.Close();
        
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        string str = "update Booking_Car set Status='Reject' where Booking_id='" + txtBookingId.Text + "'";
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Reject Booking.....')</script>");

        }
        else
        {
            Response.Write("<script>alert('Error.....')</script>");
        }
        objmyclass.con.Close();
    }
}