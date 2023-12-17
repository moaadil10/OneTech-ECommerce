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

    public partial class AddProduct : System.Web.UI.Page
    {
        Class1 obj = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string query = "select CatogaryId, CatogaryName from Catogary";
                DataSet ds = obj.Fn_DataAdapter(query);
                DropDownList2.DataSource = ds;
                DropDownList2.DataTextField = "CatogaryName";
                DropDownList2.DataValueField = "CatogaryId";
                DropDownList2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string image = "~/images/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(image));

            string query = "insert into ProductTable values(" + Convert.ToInt32(DropDownList2.SelectedItem.Value) + ", '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + image + "', " + Convert.ToInt32(TextBox3.Text) + ", " + Convert.ToInt32(TextBox4.Text) + ", '" + DropDownList1.SelectedItem.Value + "')";
            int i = obj.Fn_Nonquery(query);

            if (i != 0)
            {
                Label1.Visible = true;
                Label1.Text = "Success";
            }
        }
    }
}