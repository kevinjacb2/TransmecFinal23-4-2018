using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for myclass
/// </summary>
public class myclass
{
    public SqlConnection con = new SqlConnection();
	public myclass()
	{
        con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\TransmecFinal23-4-2018\Transmecnew\App_Data\Transmec.mdf;Integrated Security=True;User Instance=True";
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet GetDataSet(string str, string tbl)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(ds, tbl);
        }
        catch
        {
            ds = null;
        }
        finally
        {

        }
        return ds;
    }


    /// <summary>
    /// Get All Rcords
    /// </summary>
    /// <param name="tbl">Table Name Only</param>
    /// <returns>Retun DataSet</returns>
    public DataSet GetDataSet(string tbl)
    {
        DataSet ds = new DataSet();
        string str;
        str = "SELECT * FROM " + tbl;
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(ds, tbl);
        }
        catch
        {
            ds = null;
        }
        finally
        {

        }
        return ds;
    }


    /// <summary>
    /// GET ALL RECORD 

    /// </summary>
    /// <param name="str">Query String</param>
    /// <returns>Return DataTable</returns>
    //public DataTable GetDataTableAll(string tbl)
    //{
    //    DataTable dt = new DataTable();
    //    string str;
    //    str = "SELECT * FROM " + tbl;
    //    try
    //    {
    //        SqlDataAdapter da = new SqlDataAdapter(str, cn);
    //        da.Fill(dt);
    //    }
    //    catch
    //    {
    //        dt = null;
    //    }
    //    finally
    //    {

    //    }
    //    return dt;
    //}


    /// <summary>
    /// GET SELECTED RECORD 

    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public DataTable GetDataTable(string str)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(dt);
        }
        catch
        {
            dt = null;
        }
        finally
        {

        }
        return dt;
    }


    /// <summary>
    /// RETURN ONE ROW AND ONE COL
    /// </summary>
    /// <param name="str">Query String</param>
    /// <returns>Return Type Object</returns>
    public object ExecuteScalar(string str)
    {
        object i = 0;
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            i = cmd.ExecuteScalar();

        }
        catch
        {
            i = 0;
        }
        finally
        {
            con.Close();
        }
        return i;
    }


    /// <summary>

    /// </summary>
    /// <param name="col">Col Name</param>
    /// <param name="val">Val</param>
    /// <param name="tbl">Table Name</param>
    /// <returns></returns>
    public DataTable GetDataTable(string col, string val, string tbl)
    {
        DataTable dt = new DataTable();
        try
        {

            string str;
            str = "select * from " + tbl + " WHERE  " + col + "  LIKE '" + val + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(dt);
        }
        catch
        {
            dt = null;
        }

        return dt;
    }

}