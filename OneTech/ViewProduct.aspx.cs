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
    public partial class ViewProduct : System.Web.UI.Page
    {
        Class1 obj = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FnDataBind();
            }
        }

        public void FnDataBind()
        {
            string query = "select * from ProductTable";
            DataSet ds = obj.Fn_DataAdapter(query);
            if (ds.Tables[0] != null)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];
           
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int id = e.RowIndex;
            //int getId = Convert.ToInt32(GridView1.DataKeys[id].Value);

            //string query = "delete from ProductTable where ProductId=" + id + "";
            //int i = obj.Fn_Nonquery(query);
            //FnDataBind();

            int id = e.RowIndex;
            int getId = Convert.ToInt32(GridView1.DataKeys[id].Value);

            string query = "delete from ProductTable where ProductId=" + getId;
            DataSet ds = obj.Fn_DataAdapter(query);
            FnDataBind();

            //int id = e.RowIndex;
            //int getId = Convert.ToInt32(GridView1.DataKeys[id].Value);
            //string query2 = "delete from Catogary where CatogaryId=" + getId;
            //DataSet ds = obj.Fn_DataAdapter(query2);
            //FnDataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            FnDataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            FnDataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //int id = e.RowIndex;
            //int getId = Convert.ToInt32(GridView1.DataKeys[id].Value);
            //TextBox txtName = (TextBox)GridView1.Rows[id].Cells[6].Controls[0];
            //string query = "update ProductTable set ProductName='" + txtName + "' where ProductId=" + id + "";
            //int i = obj.Fn_Nonquery(query);
            //GridView1.EditIndex = -1;
            //FnDataBind();

            int id = e.RowIndex;
            int getId = Convert.ToInt32(GridView1.DataKeys[id].Value);
            TextBox txtName = (TextBox)GridView1.Rows[id].Cells[6].Controls[0];
            string query = "update ProductTable set ProductName='" + txtName.Text + "' where ProductId=" + getId;
            DataSet ds = obj.Fn_DataAdapter(query);
            GridView1.EditIndex = -1;
            FnDataBind();

            //int id = e.RowIndex;
            //int getId = Convert.ToInt32(GridView1.DataKeys[id].Value);
            //TextBox txtName = (TextBox)GridView1.Rows[id].Cells[4].Controls[0];
            //string query3 = "update Catogary set CatogaryName='" + txtName.Text + "' where CatogaryId=" + getId;
            //DataSet ds = obj.Fn_DataAdapter(query3);
            //GridView1.EditIndex = -1;
            //FnDataBind();

        }
    }
}