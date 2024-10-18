using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;

namespace coffProject
{
    public partial class ProdView : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["cid"] != null)
                {
                    string p_sel = "select * from pro_tab where cat_id='" + Session["cid"] + "'";
                    DataSet ds = obj.Fun_exeAdapter(p_sel);
                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                }
            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton clickedButton = (ImageButton)sender;

            string proid = clickedButton.CommandArgument;

            if (!string.IsNullOrEmpty(proid) && int.TryParse(proid, out int pro_id))
            {
                Session["pid"] = proid;
                Response.Redirect("singlePro.aspx");
            }

        }
    }
}