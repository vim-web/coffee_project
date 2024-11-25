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
    public partial class OrderConfir : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = "select * from Ordertab where user_id=" + Session["userid"] + "";
                SqlDataReader dr = obj.fun_reader(s);
                while (dr.Read())
                {
                    Label2.Text = dr["user_id"].ToString();
                    Label7.Text = dr["o_date"].ToString();
                }
                int tp = 0;int gp = 0;

                string s1 = "select sum(quantity) as tqnty,sum(total_pri) as tpr from Ordertab where user_id=" + Session["userid"] + "";
                SqlDataReader dr1 = obj.fun_reader(s1);
                if (dr1.Read())
                {
                    string tqnty = dr1["tqnty"].ToString();

                    Label3.Text = tqnty;

                    string tpr = dr1["tpr"].ToString();

                    Label4.Text = tpr;
                    tp = Convert.ToInt32(tpr);

                    gp = tp + 4;
                    Label5.Text = Convert.ToString(gp);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int tp = 0;int gp = 0;string date = " ";
            string s1 = "select o_date, sum(total_pri) as tpr from Ordertab where user_id=" + Session["userid"] + " GROUP BY o_date";

            SqlDataReader dr1 = obj.fun_reader(s1);
            if (dr1.Read())
            {
                date = dr1["o_date"].ToString();

                string tpr = dr1["tpr"].ToString();
                tp = Convert.ToInt32(tpr);
                gp = tp + 4;
            }


            string ins = "insert into bill_tab values (" + Session["userid"] + ",'" + date + "'," + gp + ")";
            int n = obj.fun_exenonquery(ins);
            if (n == 1)
            {
                Response.Redirect("ACC.aspx");
            }
        }
    }
}