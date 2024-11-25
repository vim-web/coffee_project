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
    public partial class singlePro : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["pid"] != null)
                {

                    string s = "select * from pro_tab where pro_id=" + Session["pid"] + "";
                    SqlDataReader dr = obj.fun_reader(s);
                    while (dr.Read())
                    {
                        Image1.ImageUrl = dr["pro_pho"].ToString();
                        Label1.Text = dr["pro_nme"].ToString();
                        Label2.Text = dr["pro_discrip"].ToString();
                        Label3.Text = dr["pro_price"].ToString();
                        Label4.Text = dr["pro_stock"].ToString();

                    }
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                string sel = "select max(cart_id) from cart_tab";
                string max_cart = obj.fun_scalar(sel);
                int n_cart = 0;
                if (max_cart == "")
                {
                    n_cart = 1;
                }
                else
                {
                    int newregid = Convert.ToInt32(max_cart);
                    n_cart = newregid + 1;
                }

                int stock = 0;
                stock = stock_check();
                double tot_price = 0;
                tot_price = price_calc();
                Session["cartid"] = n_cart;
            int qty = Convert.ToInt32(DropDownList1.SelectedItem.Text);
                if (qty <= stock)
                {
                    string cart_ins = "insert into cart_tab values(" + n_cart + "," + Session["userid"] + "," + Session["pid"] + ",'"+Label1.Text+"'," + qty + "," + tot_price + ")";
                    int i = obj.fun_exenonquery(cart_ins);
                    if (i == 1)
                    {
                       
                        Label5.Text = "Added to cart.";
                    }
                }
                else
                {
                 
                    Label5.Text = "Insufficient Stock.";
                }
            }
            public int stock_check()
            {
                string get_stock = "select pro_stock from pro_tab where pro_id='" + Session["pid"] + "'";
                string stock = obj.fun_scalar(get_stock);
                int stock_val = Convert.ToInt32(stock);
                return stock_val;
            }
            public double price_calc()
            {
                string get_price = "select pro_price from pro_tab where pro_id='" + Session["pid"] + "'";
                string price = obj.fun_scalar(get_price);
                double price_val = Convert.ToDouble(price);
                int qty = Convert.ToInt32(DropDownList1.SelectedItem.Text);
                double tprice = price_val * qty;
                return tprice;
            }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHme.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartTab.aspx");
        }
    }
    }
