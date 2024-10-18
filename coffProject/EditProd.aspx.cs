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
    public partial class EditProd : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_grid();
            }
        }
        public void bind_grid()
        {
            string sel = "select * from pro_tab";
            DataSet ds = obj.Fun_exeAdapter(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind_grid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind_grid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind_grid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int j = e.RowIndex;
            int getid1 = Convert.ToInt32(GridView1.DataKeys[j].Value);
            TextBox txtname = (TextBox)GridView1.Rows[j].Cells[0].Controls[0];
            TextBox txtdetails = (TextBox)GridView1.Rows[j].Cells[2].Controls[0];
            TextBox txtprice = (TextBox)GridView1.Rows[j].Cells[1].Controls[0];
            FileUpload proim = (FileUpload)GridView1.Rows[j].FindControl("FileUpload1");
            TextBox txtpstock = (TextBox)GridView1.Rows[j].Cells[5].Controls[0];

            string strup;
            string b = string.Empty;
            if(proim!=null && proim.HasFile)
            {
                string folder = Server.MapPath("~/products/");
                string filepath = System.IO.Path.Combine(folder, proim.FileName);
                proim.SaveAs(filepath);
                b = "~/products/" + proim.FileName;

                strup = "update pro_tab set pro_nme='" + txtname.Text + "',pro_discrip='" + txtdetails + "',pro_price=" + txtprice.Text + ",pro_pho='" + b + "',pro_stock=" + txtpstock.Text + " where pro_id=" + getid1;
            }
            else
            {
                strup = "update pro_tab set pro_nme='" + txtname.Text + "',pro_discrip='" + txtdetails + "',pro_price=" + txtprice.Text + ",pro_stock=" + txtpstock.Text + " where pro_id=" + getid1;
            }
            obj.fun_exenonquery(strup);
            GridView1.EditIndex = -1;
            bind_grid();
        }
    }
}