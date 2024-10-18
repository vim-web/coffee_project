using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace coffProject
{
    public partial class ProductIns : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_dropdown();
            }

        }
        public void bind_dropdown()
        {
            string str = "select cat_id,cat_nme from category_1";
            DataSet ds = obj.Fun_exeAdapter(str);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "cat_nme";
            DropDownList1.DataValueField = "cat_id";
            DropDownList1.DataBind();
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string propho = "~/products/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(propho));
            string sel = "insert into pro_tab values(" + DropDownList1.SelectedItem.Value + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + propho + "','Available','" + TextBox4.Text + "')";
            int j = obj.fun_exenonquery(sel);
            if (j == 1)
            {
                Label1.Text = "inserted";
            }


        }
    }
}