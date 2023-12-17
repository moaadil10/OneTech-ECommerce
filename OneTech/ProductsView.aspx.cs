using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace OneTech
{
    public partial class ProductsView : System.Web.UI.Page
    {
        Class1 obj = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                string query = "select * from ProductTable where ProductId=" + Convert.ToInt32(id) + "";
                SqlDataReader dr = obj.Fn_DataReader(query);

                while (dr.Read())
                {
                    Image1.ImageUrl = dr["ProductImage"].ToString();
                    Label1.Text = dr["ProductName"].ToString();
                    Label2.Text = dr["ProductDescription"].ToString();
                    Label3.Text = dr["ProductPrice"].ToString();
                    Label4.Text = dr["ProductStock"].ToString();
                    Label5.Text = dr["ProductStatus"].ToString();
                }
            }

        }

    }
}