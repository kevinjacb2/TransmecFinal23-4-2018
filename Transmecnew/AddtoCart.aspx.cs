using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.SqlClient;


public partial class AddtoCart : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();

    SqlTransaction tran;

    myclass objmyclass = new myclass();


    CartDB cart = new CartDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        //objmyclass.con.Open();
        String cartId = cart.GetShoppingCartId();
        string price = "";
        string msg;
        if (!Page.IsPostBack)
        {
            objmyclass.con.Open();
            string str;
            str = "SELECT  CartID, Product_ID FROM  OrderMaster where Product_ID=" + Convert.ToInt32(Request.QueryString["pid"].ToString()) + " and CartID='" + cartId + "'";

            SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
            DataSet dss = new DataSet();
            da.Fill(dss, "OrderMaster");

            if (dss.Tables[0].Rows.Count > 0)
            {
                msg = "Product Already Exist..!";
                Response.Redirect("ShoppingCart.aspx?msg=" + msg);
            }
            else
            {
                string str1;
                str1 = "SELECT *, '$ ' + Rate  FROM Product_Master WHERE Product_ID=" + Int32.Parse(Request.QueryString["pid"]);
                SqlDataAdapter da1 = new SqlDataAdapter(str1, objmyclass.con);
                DataSet ds = new DataSet();
                da1.Fill(ds, "Product_Master");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    price = ds.Tables[0].Rows[0]["Rate"].ToString();
                }
                try
                {

                    string strinsert;
                    strinsert = "INSERT INTO OrderMaster(ClientId,CartID, Product_ID, Qty,price) VALUES(" + Convert.ToInt32(Session["ClientId"].ToString()) + ",'" + cartId + "', " + Int32.Parse(Request.QueryString["pid"]) + ",1," + price + ") ";
                    // strinsert = "INSERT INTO OrderMaster(CartID, Product_ID, Qty,price,Deleteflag) VALUES('" + cartId + "', " + Int32.Parse(Request.QueryString["pid"]) + ",1," + price + ",1) ";
                    SqlCommand cmd = new SqlCommand(strinsert, objmyclass.con);
                    cmd.ExecuteNonQuery();


                    string dstrinsert;
                    dstrinsert = "INSERT INTO BackupOrderMaster(ClientId,CartID, Product_ID, Qty,price) VALUES(" + Convert.ToInt32(Session["ClientId"].ToString()) + ",'" + cartId + "', " + Int32.Parse(Request.QueryString["pid"]) + ",1," + price + ") ";
                    // dstrinsert = "INSERT INTO BackupOrderMaster(CartID, Product_ID, Qty,price,Deleteflag) VALUES('" + cartId + "', " + Int32.Parse(Request.QueryString["pid"]) + ",1," + price + ",1) ";
                    SqlCommand cmd1 = new SqlCommand(dstrinsert, objmyclass.con);
                    cmd1.ExecuteNonQuery();
                    objmyclass.con.Close();





                    objmyclass.con.Close();




                    msg = "Product Add to Cart Successfully..!!";
                    Response.Redirect("~/ShoppingCart.aspx?msg=" + msg);
                }
                catch (Exception ex)
                {
                    //tran.Rollback();
                }
                finally
                {
                    objmyclass.con.Close();
                }
            }
        }
    }
}
