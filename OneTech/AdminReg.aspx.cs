using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneTech
{
    public partial class AdminReg : System.Web.UI.Page
    {
        Class1 obj = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(RegId) from logTable";
            string regid = obj.Fn_Scalar(sel);
            int reg_id = 0;
            if (regid == "")
            {
                reg_id = 1;

            }
            else
            {
                int newregId = Convert.ToInt32(regid);
                reg_id = newregId + 1;
                //Not next time -error came so i gave +2 because Reg id 3 was deleted

            }

            string ins = "insert into Admin_Reg values (" + reg_id + ", '" + TextBox1.Text + "','" + TextBox2.Text + "' ,'" + TextBox3.Text + "' ,'" + TextBox4.Text + "')";
            int i = obj.Fn_Nonquery(ins);

            string inslog = "insert into logTable values (" + reg_id + ", '" + TextBox5.Text + "','" + TextBox6.Text + "','Admin','active')";
            int j = obj.Fn_Nonquery(inslog);


        }
    }
}