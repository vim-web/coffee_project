using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace coffProject
{
    public partial class category : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/cate/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string ins = "insert into category_1 values('" + TextBox1.Text + "','" + p + "','" + TextBox3.Text + "')";
            int i = obj.fun_exenonquery(ins);
            if (i == 1)
            {
                Label2.Text = "inserted";
            }
           

        }

    }
}