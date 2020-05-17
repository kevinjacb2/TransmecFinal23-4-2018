using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Blog : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Visible=false;  
        if (!Page.IsPostBack)
        {

            showdata();

        }
       
    }
    void showdata()
    {

        SqlDataAdapter da = new SqlDataAdapter("SELECT *  From Blog", objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Blog");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }
    protected void btn_post_Click(object sender, EventArgs e)
    {
         if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("~/Blogimages/" + FileUpload1.FileName));
            Image1.ImageUrl = "~/Blogimages/" + FileUpload1.FileName;
        }
        string img;
        img = "~/Blogimages/" + FileUpload1.FileName;
        String str;
        str = "insert into Blog values('" + Blogtitle.Text + "','" + Blogcontent.Text + "','" + img + "')";
        
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
        showdata();
    }
    protected void btn_lnk_delete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "delete from Blog where BlogId =" + Convert.ToInt32(lnk.CommandArgument.ToString()); ;
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
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string str;
        str = "select * from Blog where BlogId=" + Convert.ToInt32(lnk.CommandArgument.ToString());
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Blog");
        if (ds.Tables[0].Rows.Count > 0)
        {

            Blogtitle.Text = ds.Tables[0].Rows[0][1].ToString();
            Blogcontent.Text = ds.Tables[0].Rows[0][2].ToString();
            TextBox1.Text = ds.Tables[0].Rows[0]["blogid"].ToString();


        }


    }
}