using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace coffProject
{
    public partial class Log : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(reg_id) from login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
            string cid = obj.fun_scalar(str);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string str1 = "select reg_id from login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                string regid = obj.fun_scalar(str1);
                Session["userid"] = regid;
                string str2 = "select log_type from login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                string log_type = obj.fun_scalar(str2);
                if (log_type== "admin")
                {
                    Response.Redirect("AdminHme.aspx");
                    Label2.Text = "Admin";
                }
                else if (log_type == "user")
                {
                    Response.Redirect("UserHme.aspx");
                    Label2.Text = "User";

                }

            }
            else
            {
                Label2.Text = "invalid usename and password";
            }

        }
    }
}