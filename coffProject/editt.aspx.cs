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
    public partial class editt : System.Web.UI.Page
    {

        ConnectionCls obj= new ConnectionCls();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }

        }
        public void bind()
        {
            string str = "select * from category_1";

            DataSet ds = obj.Fun_exeAdapter(str);
            GridView1.DataSource = ds;
            GridView1.DataBind();


            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtnme = (TextBox)GridView1.Rows[i].Cells[0].Controls[0];
            TextBox txtdes = (TextBox)GridView1.Rows[i].Cells[3].Controls[0];
            FileUpload catimg = GridView1.Rows[i].FindControl("Fileupload1") as FileUpload;
            string strup = "";
            if (catimg != null && catimg.HasFile)
            {
                string folder = Server.MapPath("~/cate/");
                string filepath = System.IO.Path.Combine(folder, catimg.FileName);
                catimg.SaveAs(filepath);
                string a = "~/cate/" + catimg.FileName;

                strup = "update category_1 set cat_nme='" + txtnme.Text + "',cat_img='" +a +"',cat_des='" + txtdes.Text + "'where cat_id=" + getid + "";

            }
            else
            {
                strup = "update category_1 set cat_nme='" + txtnme.Text + "',cat_des='" + txtdes.Text + "'where cat_id=" + getid + "";
            }

            
            int up = obj.fun_exenonquery(strup);

            GridView1.EditIndex = -1;
            bind();
            

        }
    }
}