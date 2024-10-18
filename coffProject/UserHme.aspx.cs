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
    public partial class UserHme : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                data_bind();
            }
        }
        public void data_bind()
        {
            string s = "select * from category_1";
            DataSet ds = obj.Fun_exeAdapter(s);
            DataList1.DataSource = ds;
            DataList1.DataBind();
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton clickedButton = (ImageButton)sender;

            string catid = clickedButton.CommandArgument;

            if(!string.IsNullOrEmpty(catid) && int.TryParse(catid,out int categoryId))
            {
                Session["cid"] = categoryId;
                Response.Redirect("ProdView.aspx");
            }
        }
    }
}