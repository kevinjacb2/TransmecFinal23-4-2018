using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for CartDB
/// </summary>
public class CartDB
{
    public String GetShoppingCartId()
    {
        // Obtain current HttpContext of ASP+ Request
        System.Web.HttpContext context = System.Web.HttpContext.Current;

        // If the user is authenticated, use their customerId as a permanent shopping cart id
        if (context.User.Identity.Name != "")
        {
            return context.User.Identity.Name;
        }

        // If user is not authenticated, either fetch (or issue) a new temporary cartID
        if (context.Request.Cookies["funstore_CartID"] != null)
        {
            return context.Request.Cookies["funstore_CartID"].Value;
        }
        else
        {
            // Generate a new random GUID using System.Guid Class
            Guid tempCartId = Guid.NewGuid();

            // Send tempCartId back to client as a cookie
            context.Response.Cookies["funstore_CartID"].Value = tempCartId.ToString();

            // Return tempCartId
            return tempCartId.ToString();
        }
    }
	public CartDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
