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
    public partial class Login : System.Web.UI.Page
    {
        Class1 obj = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(RegId) from logTable where UserName= '" + TextBox1.Text + "' and Password= '" + TextBox2.Text + "'";
            string cid = obj.Fn_Scalar(str);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string str1 = "select RegId from logTable where UserName= '" + TextBox1.Text + "' and Password= '" + TextBox2.Text + "'";
                string regid = obj.Fn_Scalar(str1);

                Session["userid"] = regid;
                string str2 = "select [Type] from logTable where UserName= '" + TextBox1.Text + "' and Password= '" + TextBox2.Text + "'";
                string logType = obj.Fn_Scalar(str2);

                if (logType == "Admin")
                {
                    Label1.Visible = true;
                    Label1.Text = "Admin";
                    Response.Redirect("AddCatogary.Aspx");
                }
                else if (logType == "user")
                {
                    Label1.Visible = true;
                    Label1.Text = "User";
                    Response.Redirect("UserPage.aspx");
                }
            }

        }
    }
}