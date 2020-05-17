using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class ShoppingCarts : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection();

    SqlTransaction tran;

    myclass objmyclass = new myclass();
    float total = 0, gtotal = 0;
    CartDB cart = new CartDB();
    int id = 1;
    string purdate, warperiod = "1 Year";
    int shipcharge = 150;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["shipcharge"] = shipcharge;
        Session["warrantyPeriod"] = warperiod;
        Session["purdate"] = DateTime.Now.ToString();
        Session["cartidd"] = cart;
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["msg"] != "")
            {
                lblMSg.Text = Request.QueryString["msg"];
            }
            if (Session["username"] != null)
            {
                lblusername.Text = Session["username"].ToString();
                Session["username"] = lblusername.Text;
            }
            BindData();

        }
    }

    public void BindData()
    {
        objmyclass.con.Open();
        String cartId = cart.GetShoppingCartId();
        string str;
        str = "SELECT  dbo.Product_Master.Product_name, dbo.Product_Master.Prod_image, dbo.OrderMaster.Product_ID,  dbo.OrderMaster.OrderMasterID,dbo.OrderMaster.Qty, dbo.OrderMaster.CartID,dbo.OrderMaster.Grossamount, OrderMaster.OrderMasterID,cast(dbo.OrderMaster.Price as decimal(18,2)) as Price FROM         dbo.OrderMaster INNER JOIN   dbo.Product_Master ON          dbo.OrderMaster.Product_ID = dbo.Product_Master.Product_ID          where OrderMaster.CartID='" + cartId + "'";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "OrderMaster");



        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                int prodid;


                prodid = Convert.ToInt32(GridView1.DataKeys[0].Value);
                Image imgProd = (Image)GridView1.Rows[i].FindControl("Image2");
                TextBox txtqty = (TextBox)GridView1.Rows[i].FindControl("txtQty");
                Label lbltotal = (Label)GridView1.Rows[i].FindControl("lbltotal");


                imgProd.ImageUrl = ds.Tables[0].Rows[i]["Prod_image"].ToString();
                txtqty.Text = ds.Tables[0].Rows[i]["Qty"].ToString();
                total = float.Parse(ds.Tables[0].Rows[i]["Price"].ToString()) * float.Parse(ds.Tables[0].Rows[i]["Qty"].ToString());

                if (total.ToString().Contains("."))
                    lbltotal.Text = total.ToString(); //+ ".00";
                else
                    lbltotal.Text = total.ToString() + ".00";

                gtotal = gtotal + total;
            }
            if (gtotal.ToString().Contains("."))
                lblTotalAmount.Text = gtotal.ToString(); //+".00";bj
            else
                lblTotalAmount.Text = gtotal.ToString() + ".00";
            UpdateGrossAmount();



        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
        objmyclass.con.Close();
    }
    public void UpdateGrossAmount()
    {
        String cartId = cart.GetShoppingCartId();

        purdate = DateTime.Now.ToString();
        warperiod = "1 Year";
        shipcharge = 150;
        string str;
        str = "update OrderMaster set Grossamount=" + gtotal + ",warrentyperiod='" + warperiod + "',shippingcharge=" + shipcharge + " where OrderMaster.CartID='" + cartId + "'";
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        cmd.ExecuteNonQuery();






    }
    protected void BtnCalculate_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            //int OrderItemID = (int)GridView1.DataKeys[i].Value;
            int OrderItemID = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtqty = (TextBox)GridView1.Rows[i].FindControl("txtQty");
            try
            {
                objmyclass.con.Open();

                purdate = DateTime.Now.ToString();
                warperiod = "1 Year";
                shipcharge = 150;

                string str;
                str = "UPDATE OrderMaster SET Grossamount=" + gtotal + ",Qty=" + Int32.Parse(txtqty.Text) + "  WHERE 	      OrderMasterID=" + OrderItemID;
                SqlCommand cmd = new SqlCommand(str, objmyclass.con);
                cmd.ExecuteNonQuery();

                objmyclass.con.Close();
            }
            catch (Exception ex)
            {
                tran.Rollback();
            }
            finally
            {
                con.Close();
            }
        }
        BindData();
        lblMSg.Text = "Product Quantity Updated Successfully..!!";
    }
    protected void BtnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("BuyProduct.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //Session["CartId"] = cartId;
        Session["PurchaseDt"] = purdate;
        Session["warrantyPeriod"] = warperiod;
        Session["ShipCharge"] = shipcharge;
        Session["Gamt"] = lblTotalAmount.Text;
        Session["username"] = lblusername.Text;






        Response.Redirect("Billing.aspx");
        //Session["PurchaseDt"] = purdate;
        // Session["warrantyPeriod"] = warperiod;
        // Session["ShippingCharge"] = shipcharge;

        
    }
    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            int OrderItemID = (int)GridView1.DataKeys[i].Value;
            Label lblProductId = (Label)GridView1.Rows[i].FindControl("Label1");
            TextBox txtqty = (TextBox)GridView1.Rows[i].FindControl("txtQty");
            try
            {
                string str2;
                str2 = "select * from Product_Master where Product_Id = " + lblProductId.Text;
                DataTable dt = new DataTable();
                dt = objmyclass.GetDataTable(str2);


                Int32 qty, uqty;

                qty = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());

                uqty = (Convert.ToInt32(qty) - Convert.ToInt32(txtqty.Text));

                objmyclass.con.Open();
                string str;

                str = "UPDATE Product_Master SET Quantity=" + uqty + " WHERE Product_Id=" + lblProductId.Text;
                SqlCommand cmd = new SqlCommand(str, objmyclass.con);
                cmd.ExecuteNonQuery();
                objmyclass.con.Close();
            }
            catch (Exception ex)
            {
                tran.Rollback();
            }
            finally
            {
                con.Close();
            }
        }

        // Response.Redirect("Default2.aspx");

    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        objmyclass.con.Open();
        LinkButton lnkRemoveID = (LinkButton)sender;

        try
        {
            string str;
            str = "DELETE FROM OrderMaster WHERE OrderMasterID=" + Convert.ToInt32(lnkRemoveID.CommandArgument.ToString());
            SqlCommand cmd = new SqlCommand(str, objmyclass.con);
            cmd.ExecuteNonQuery();
            objmyclass.con.Close();

            BindData();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            objmyclass.con.Close();
        }
    }
}