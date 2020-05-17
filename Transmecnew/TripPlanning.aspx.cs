using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class TripPlanning : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_TripID.Visible = false;
        if (!Page.IsPostBack)
        {

            showdata();

        }
    }
    void showdata()
    {

        SqlDataAdapter da = new SqlDataAdapter("SELECT *  From Trip", objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Trip");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }
    protected void btn_post_Click(object sender, EventArgs e)
    {
        String str;
        str = "insert into Trip values('" + txt_TripID.Text + "','" + TT.Text + "','" + TNA.Text + "','" + MUP.Text + "','" + DP.Text + "','" + DFT.Text + "','" + CE.Text + "')";
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Saved successfully.....')</script>");
        }
        else
        {
            Response.Write("<script>alert('Error.....')</script>");
        }
        objmyclass.con.Close();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "select * from Trip where TripID=" + Convert.ToInt32(lnk.CommandArgument.ToString());
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Trip");
        if (ds.Tables[0].Rows.Count > 0)
        {

            TT.Text = ds.Tables[0].Rows[0][1].ToString();
            TNA.Text = ds.Tables[0].Rows[0][2].ToString();
            txt_TripID.Text = ds.Tables[0].Rows[0]["TripID"].ToString();
            MUP.Text = ds.Tables[0].Rows[0][3].ToString();
            DP.Text = ds.Tables[0].Rows[0][4].ToString();
            DFT.Text = ds.Tables[0].Rows[0][5].ToString();
            CE.Text = ds.Tables[0].Rows[0][6].ToString();


        }
    }
    protected void btn_delete_lnk_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "delete from Blog where TripID =" + Convert.ToInt32(lnk.CommandArgument.ToString()); ;
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('Deleted successfully.....')</script>");
            showdata();
        }
        else
        {
            Response.Write("<script>alert('Error.....')</script>");
        }
        objmyclass.con.Close();
    }
}