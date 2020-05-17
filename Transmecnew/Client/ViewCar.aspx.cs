using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Client_ViewCar : System.Web.UI.Page
{
    myclass class1 = new myclass();
    myclass objmyclass = new myclass();
    private List<DateTime> Carbook = new List<DateTime>();
    private List<string> Availbility = new List<string>();
    string cartype = "";
    string carcity = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmailId"] != null)
        {
            if (!Page.IsPostBack)
            {
                //GetBookingDate();
                showdata();
                divAirport.Visible = false;
                divLocal.Visible = false;
                divOutStation.Visible = false;
                lblCarType.Text = Request.QueryString["cartype"].ToString();
                lblClientId.Text = Session["ClientId"].ToString();
                lblChoiceId.Text = Request.QueryString["ChoiceId"].ToString();
                lblSelectDate.Visible = false;
                Calendar1.Visible = false;
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }

    }
    void showdata()
    {
        SqlDataAdapter da = new SqlDataAdapter("select CarDetail_id,Car_Name,Car_Brand,Car_Color,Fuel_Type,Car_Rate as Rate_KM,Car_Image from Car_Details", class1.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Car_Details");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
            {


                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();


            }
        }

    }
    protected void btnBook_Click(object sender, EventArgs e)
    {
        string str = "";
        if (lblCarType.Text == "OutStation")
        {
            str = "insert into Booking_Car values('" + lblClientId.Text + "','" + lblChoiceId.Text + "','" + lblCarId.Text + "','" + lblCarType.Text + "','" + Convert.ToDateTime(txtStartDate.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(txtEndDate.Text).ToString("yyyy/MM/dd") + "','" + txtOutPickUptime.Text + "','Pending')";
        }
        else if (lblCarType.Text == "Local")
        {
            str = "insert into Booking_Car values('" + lblClientId.Text + "','" + lblChoiceId.Text + "','" + lblCarId.Text + "','" + lblCarType.Text + "','" + Convert.ToDateTime(txtLocalDate.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(txtLocalDate.Text).ToString("yyyy/MM/dd") + "','" + txtLocalPickUptime.Text + "','Pending')";
        }
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);

        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();

        if (i > 0)
        {
            Response.Write("<script>alert('Waiting For Admin Approval.....')</script>");

        }
        else
        {
            Response.Write("<script>alert('Error.....')</script>");
        }
        objmyclass.con.Close();
    }
    protected void linkbtnedit_Click(object sender, EventArgs e)
    {
        lblSelectDate.Visible = true;
        Calendar1.Visible = true;
        LinkButton lnkview = (LinkButton)sender;
        lblCarId.Text = lnkview.CommandArgument.ToString();
        GetBookingDate();
        if (lblCarType.Text == "OutStation")
        {
            divOutStation.Visible = true;
            divAirport.Visible = false;
            divLocal.Visible = false;
        }
        else if (lblCarType.Text == "Local")
        {
            divOutStation.Visible = false;
            divAirport.Visible = false;
            divLocal.Visible = true;
        }
        else if (lblCarType.Text == "Airport")
        {
            divOutStation.Visible = false;
            divAirport.Visible = true;
            divLocal.Visible = false;
        }
        else
        {

        }
    }

    private void GetBookingDate()
    {
        try
        {
            objmyclass.con.Open();
            SqlCommand cmd = new SqlCommand("select * from ApproveBooking_Car where CarDetail_id='" + lblCarId.Text + "' AND Status='Given To Client' OR Status='Advance By Client'", objmyclass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DateTime startingDate = (DateTime)ds.Tables[0].Rows[i]["Start_Date"];
                DateTime endingDate = (DateTime)ds.Tables[0].Rows[i]["End_Date"];
                //Carbook.Add((DateTime)ds.Tables[0].Rows[i]["Start_Date"]);
                for (DateTime date = startingDate; date <= endingDate; date = date.AddDays(1))
                {
                    Carbook.Add(date);
                    Availbility.Add("Not Available On this Date");
                }
                //Carbook.Add((DateTime)ds.Tables[0].Rows[i]["End_Date"]);

            }
        }
        catch { }
        finally { objmyclass.con.Close(); }
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

    protected void Calendar1_VisibleMonthChanged1(object sender, MonthChangedEventArgs e)
    {
        GetBookingDate();
    }
    //protected void btnBook_Click(object sender, EventArgs e)
    //{
    //    string str = "";
    //    if (lblCarType.Text == "OutStation")
    //    {
    //        str = "insert into Booking_Car values('" + lblClientId.Text + "','" + lblChoiceId.Text + "','" + lblCarId.Text + "','" + lblCarType.Text + "','" + Convert.ToDateTime(txtStartDate.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(txtEndDate.Text).ToString("yyyy/MM/dd") + "','" + txtOutPickUptime.Text + "','Pending')";
    //    }
    //    else if (lblCarType.Text == "Local")
    //    {
    //        str = "insert into Booking_Car values('" + lblClientId.Text + "','" + lblChoiceId.Text + "','" + lblCarId.Text + "','" + lblCarType.Text + "','" + Convert.ToDateTime(txtLocalDate.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(txtLocalDate.Text).ToString("yyyy/MM/dd") + "','" + txtLocalPickUptime.Text + "','Pending')";
    //    }
    //    SqlCommand cmd = new SqlCommand(str, objmyclass.con);

    //    objmyclass.con.Open();
    //    int i = cmd.ExecuteNonQuery();

    //    if (i > 0)
    //    {
    //        Response.Write("<script>alert('Waiting For Admin Approval.....')</script>");

    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Error.....')</script>");
    //    }
    //    objmyclass.con.Close();

    //}
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtStartDate.Text = Calendar1.SelectedDate.ToShortDateString();
        txtLocalDate.Text = Calendar1.SelectedDate.ToShortDateString();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[8].Visible = false;
    }
}