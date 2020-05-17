using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Client_BookCab : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmailId"] != null)
        {
            if (!Page.IsPostBack)
            {
                lblClientId.Text = Session["ClientId"].ToString();
                //string carid = Request.QueryString["carid"].ToString();
                // lblCarid.Text = carid;
                // showdata(carid);
                // GetBookingDate();
                divOutStation.Visible = false;
                divAirport.Visible = false;
                divLocal.Visible = false;
                addCityid();
                bindHrs();
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    public void bindHrs()
    {
        ddlHrs.Items.Add("Select");
        ddlHrs.Items.Add("8 Hrs/ 100 Kms");

    }
    public void addCityid()
    {
        string str = "select * from City_Master";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "City_Master");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCityOutStation.DataSource = ds.Tables[0].DefaultView;
            ddlCityOutStation.DataTextField = "City_name";
            ddlCityOutStation.DataValueField = "City_id";
            ddlCityOutStation.DataBind();
            ddlCityOutStation.Items.Insert(0, "Select");

            ddlDestinationCity.DataSource = ds.Tables[0].DefaultView;
            ddlDestinationCity.DataTextField = "City_name";
            ddlDestinationCity.DataValueField = "City_id";
            ddlDestinationCity.DataBind();
            ddlDestinationCity.Items.Insert(0, "Select");

            ddlLocalCity.DataSource = ds.Tables[0].DefaultView;
            ddlLocalCity.DataTextField = "City_name";
            ddlLocalCity.DataValueField = "City_id";
            ddlLocalCity.DataBind();
            ddlLocalCity.Items.Insert(0, "Select");


            //ddlAirportCity.DataSource = ds.Tables[0].DefaultView;
            //ddlAirportCity.DataTextField = "City_name";
            //ddlAirportCity.DataValueField = "City_id";
            //ddlAirportCity.DataBind();
            //ddlAirportCity.Items.Insert(0, "Select");

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string str;
        if (DropDownList1.SelectedValue == "OutStation")
        {
            str = "insert into Client_ChoiceMaster values('" + DropDownList1.SelectedValue + "','" + ddlCityOutStation.SelectedItem + "','" + ddlDestinationCity.SelectedItem + "',0,0,0,0,0,'" + lblClientId.Text + "','Pending')";

            SqlCommand cmd = new SqlCommand(str, objmyclass.con);

            objmyclass.con.Open();
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                Response.Write("<script>alert('Book successfully.....')</script>");
                string str1 = "select MAX(ClientChoice_id) as LastId from Client_ChoiceMaster where Client_Id=" + lblClientId.Text;
                SqlDataAdapter da = new SqlDataAdapter(str1, objmyclass.con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Client_ChoiceMaster");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string ClientChoiceId = ds.Tables[0].Rows[0]["LastId"].ToString();
                    Response.Redirect("~/Client/ViewCar.aspx?cartype=" + DropDownList1.SelectedValue + "&ChoiceId=" + ClientChoiceId);
                }
            }
            else
            {
                Response.Write("<script>alert('Error.....')</script>");
            }
            objmyclass.con.Close();
        }
        else if (DropDownList1.SelectedValue == "Local")
        {
            if (ddlHrs.SelectedValue != "Select")
            {
                str = "insert into Client_ChoiceMaster values('" + DropDownList1.SelectedValue + "',0,0,'" + ddlLocalCity.SelectedItem + "','" + ddlHrs.SelectedValue + "',0,0,0,'" + lblClientId.Text + "','Pending')";

                SqlCommand cmd = new SqlCommand(str, objmyclass.con);

                objmyclass.con.Open();
                int i = cmd.ExecuteNonQuery();


                if (i > 0)
                {
                    Response.Write("<script>alert('Book successfully.....')</script>");
                    string str1 = "select MAX(ClientChoice_id) as LastId from Client_ChoiceMaster where Client_Id=" + lblClientId.Text;
                    SqlDataAdapter da = new SqlDataAdapter(str1, objmyclass.con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Client_ChoiceMaster");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string ClientChoiceId = ds.Tables[0].Rows[0]["LastId"].ToString();
                        Response.Redirect("~/Client/ViewCar.aspx?cartype=" + DropDownList1.SelectedValue + "&ChoiceId=" + ClientChoiceId);
                    }
                }
                else
                {
                    Response.Write("<script>alert('Error.....')</script>");
                }
                objmyclass.con.Close();
            }
        }
        //else if (DropDownList1.SelectedValue == "Airport")
        //{
        //    str = "insert into Client_ChoiceMaster values(0,0,0,0,0,0,0,0,'" + ddlAirport.SelectedValue + "','" + ddlAirportCity.SelectedValue + "','" + Convert.ToDateTime(txtAirportDate.Text).ToString("yyyy/MM/dd") + "','" + lblClientId.Text + "')";

        //    SqlCommand cmd = new SqlCommand(str, objmyclass.con);

        //    objmyclass.con.Open();
        //    int i = cmd.ExecuteNonQuery();

        //    if (i > 0)
        //    {
        //        // Response.Write("<script>alert('Book successfully.....')</script>");
        //        Response.Redirect("~/Client/ViewCar.aspx?cartype=" + DropDownList1.SelectedValue);
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Error.....')</script>");
        //    }
        //    objmyclass.con.Close();
        //}
        else
        {

        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "OutStation")
        {
            divOutStation.Visible = true;
            divAirport.Visible = false;
            divLocal.Visible = false;
        }
        else if (DropDownList1.SelectedValue == "Local")
        {
            divOutStation.Visible = false;
            divAirport.Visible = false;
            divLocal.Visible = true;
        }
        else if (DropDownList1.SelectedValue == "Airport")
        {
            divOutStation.Visible = false;
            divAirport.Visible = true;
            divLocal.Visible = false;
        }
        else
        {
            divOutStation.Visible = false;
            divAirport.Visible = false;
            divLocal.Visible = false;
        }
    }
}