using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneTech
{
    public partial class AddCatogary : System.Web.UI.Page
    {
        Class1 obj = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string image = "~/images/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(image));

            string ins = "insert into Catogary values ('" + TextBox1.Text + "','" + TextBox2.Text + "' ,'" + image + "' ,'" + DropDownList1.SelectedItem.Value + "')";
            int i = obj.Fn_Nonquery(ins);

            if (i != 0)
            {
                Label1.Visible = true;
                Label1.Text = "Inserted successfully";
            }
        }
    }
}