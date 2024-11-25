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
    public partial class ACC : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["userid"]);
            string sel = "select grand_total from bill_tab where user_id=" + userId + "";
            SqlDataReader dr = obj.fun_reader(sel);
            int amount = 0;
            while (dr.Read())
            {
                int price = Convert.ToInt32(dr["grand_total"]);
                amount += price;
            }
            string ins = "insert into acc_tab values(" + userId + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3 + "'," + TextBox4.Text + ")";
            int i = obj.fun_exenonquery(ins);
            if (i == 1)
            {
                balance(userId, amount);
            }
            else
            {
                Label2.Text = "Error adding details";
            }
        }
        public void balance(int userId, int amount)
        {
            Balance_service.ServiceClient cls = new Balance_service.ServiceClient();
            string ifmin = cls.balancemin(userId, amount);

            if (ifmin == "Success")
            {
                string upd = "update Ordertab set o_status='paid' where user_id=" + userId + "";
                int status = obj.fun_exenonquery(upd);

                if (status >= 1)
                {
                    string message = "Order Confirmed and Payment Processed";
                    Response.Write("<script>alert('" + message + "');</script>");
                }
                else
                {
                    string message = "Failed to Update order status";
                    Response.Write("<script>alert('" + message + "');</script>");
                }
            }
            else if (ifmin == "Insufficient Balance")
            {
                string message = "Insufficient Balance";
                Response.Write("<script>alert('" + message + "');</script>");
            }
            else if (ifmin == "User not found")
            {
                string message = "user not found";
                Response.Write("<script>alert('" + message + "');</script>");
            }
            else
            {
                string message = "An error occurred while processing the balance.";
                Response.Write("<script>alert('" + message + "');</script>");
            }
        }
    }
}
        
    
