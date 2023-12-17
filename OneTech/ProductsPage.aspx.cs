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
    public partial class ProductsPage : System.Web.UI.Page
    {
        Class1 obj = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                string query = "select * from ProductTable where CatogaryId=" + Convert.ToInt32(id) + "";
                DataSet ds = obj.Fn_DataAdapter(query);

                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int itemIndex = e.Item.ItemIndex;
            Label lbl = DataList1.Items[itemIndex].FindControl("label5") as Label;
            Response.Redirect("ProductsView.aspx?id=" + lbl.Text + "");
        }
    }
}