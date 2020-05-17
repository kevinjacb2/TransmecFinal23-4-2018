using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Client_BookCar : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    private List<DateTime> Carbook = new List<DateTime>();
    private List<string> Availbility = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmailId"] != null)
        {
            if (!Page.IsPostBack)
            {
                lblClientId.Text = Session["ClientId"].ToString();
                string carid = Request.QueryString["carid"].ToString();
                lblCarid.Text = carid;
                showdata(carid);
                GetBookingDate();
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }

    }
    private void GetBookingDate()
    {
        try
        {
            objmyclass.con.Open();
            SqlCommand cmd = new SqlCommand("select * from Booking_Car where Car_id='" + lblCarid.Text + "'", objmyclass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Carbook.Add((DateTime)ds.Tables[0].Rows[i]["Date"]);
                Availbility.Add("Not Available On this Date");
            }
        }
        catch { }
        finally { objmyclass.con.Close(); }
    }
    public void showdata(string carid)
    {
        string cardetail = "select * from Car_Master where Car_id='" + carid + "'";
        SqlDataAdapter da = new SqlDataAdapter(cardetail, objmyclass.con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtcarid.Text = carid;
            txtcarname.Text = dt.Rows[0]["Car_name"].ToString();
            txtcartype.Text = dt.Rows[0]["Car_Model"].ToString();
            txtcarbrand.Text = dt.Rows[0]["Car_brand"].ToString();

            txtColor.Text = dt.Rows[0]["Car_Color"].ToString();
            txtcarcapacity.Text = dt.Rows[0]["Car_capacity"].ToString();
            txtFuelType.Text = dt.Rows[0]["Fuel_type"].ToString();
            txtcarcc.Text = dt.Rows[0]["Car_cc"].ToString();
            txtcarmileage.Text = dt.Rows[0]["Car_mileage"].ToString();
            txtRate.Text = dt.Rows[0]["Car_Rate"].ToString();
            Image1.ImageUrl = dt.Rows[0]["Car_Image"].ToString();
        }
    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        string str;
        str = "insert into Booking_Car values('" + lblClientId.Text + "','" + txtcarid.Text + "'," + txtRate.Text + ",'" + Convert.ToDateTime(txtSelectedDate.Text).ToString("yyyy/MM/dd") + "','Pending')";
        string str1 = "insert into DummyBooking_Car values('" + lblClientId.Text + "','" + txtcarid.Text + "','" + Convert.ToDateTime(txtSelectedDate.Text).ToString("yyyy/MM/dd") + "','Pending')";
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        SqlCommand cmd1 = new SqlCommand(str1, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Book successfully.....')</script>");

        }
        else
        {
            Response.Write("<script>alert('Error.....')</script>");
        }
        objmyclass.con.Close();

    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtSelectedDate.Text = Calendar1.SelectedDate.ToShortDateString();
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        string tooltip = string.Empty;
        if (IsEventDay(e.Day.Date, out tooltip))
        {
            e.Cell.BackColor = System.Drawing.Color.Pink;
            e.Day.IsSelectable = false;
            e.Cell.ToolTip = tooltip;
        }
        if (e.Day.IsWeekend)
        {
            //e.Cell.BackColor = System.Drawing.Color.Black;
            // e.Cell.ForeColor = System.Drawing.Color.White;
            // e.Day.IsSelectable = false;            
        }
    }
    private bool IsEventDay(DateTime day, out string tooltipvalue)
    {
        tooltipvalue = string.Empty;
        for (int i = 0; i < Carbook.Count; i++)
        {
            if (Carbook[i] == day)
            {
                tooltipvalue = Availbility[i];
                return true;
            }
        }
        return false;
    }
    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        GetBookingDate();
    }
}