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
    public partial class UserPage : System.Web.UI.Page
    {
        Class1 obj = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "select * from Catogary";
                DataSet ds = obj.Fn_DataAdapter(query);

                if (ds.Tables[0] != null)
                {
                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                }
                else
                {
                    Label1.Text = "No categories available";
                }
            }


        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int itemIndex = e.Item.ItemIndex;
            Label lbl = DataList1.Items[itemIndex].FindControl("label3") as Label;
            Response.Redirect("ProductsPage.aspx?id=" + lbl.Text + "");
        }
    }
}