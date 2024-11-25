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
    public partial class CartTab : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userid"] != null)
                {
                    int userid = Convert.ToInt32(Session["userid"]);
                    LoadCart(userid);
                }
                else
                {
                    Response.Write("Error: User ID not found in session.");
                }
                DataBind();
            }

        }
        private void LoadCart(int userid)
        {
            {
                string que = "SELECT C.cart_id, P.pro_nme, P.pro_price, P.pro_pho, C.quantity, C.total_price " +
                             "FROM cart_tab C " +
                             "JOIN pro_tab P ON C.pro_id = P.pro_id " +
                             "WHERE C.user_id = " + userid;

                DataSet ds = obj.Fun_exeAdapter(que);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }

            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cartid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string deletequery = "delete from cart_tab where cart_id =" + cartid;
            int result = obj.fun_exenonquery(deletequery);

            if (result > 0)
            {
                int userid = 1;
                LoadCart(userid);
               
            }
            Response.Write("<script>alert('Deletion successful');</script>");
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            if (Session["userid"] != null)
            {
                int userid = Convert.ToInt32(Session["userid"]);
                LoadCart(userid);
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            if (Session["userid"] != null)
            {
                int userid = Convert.ToInt32(Session["userid"]);
                LoadCart(userid);
            }

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            
                int ia = e.RowIndex;
                int getid = Convert.ToInt32(GridView1.DataKeys[ia].Value);
                TextBox txtqnty = (TextBox)GridView1.Rows[ia].Cells[3].Controls[0];
                string newQuantity = txtqnty.Text;

                string strup = "UPDATE cart_tab SET quantity = " + newQuantity + " WHERE cart_id = " + getid;
                int n = obj.fun_exenonquery(strup);

                if (n == 1)
                {
                    string nqnty = txtqnty.Text;
                    string op = "SELECT pro_id FROM cart_tab WHERE cart_id = " + getid;
                    string proId = obj.fun_scalar(op).ToString();
                    string pri = $"SELECT pro_price FROM pro_tab WHERE pro_id = {proId}";
                    double npri = Convert.ToDouble(obj.fun_scalar(pri));
                    int nqnty1 = Convert.ToInt32(nqnty);
                    string np = $"UPDATE cart_tab SET total_price = {nqnty1 * npri} WHERE cart_id = {getid}";
                    obj.fun_exenonquery(np);

                    GridView1.EditIndex = -1;
                    if (Session["userid"] != null)
                    {
                        int userid = Convert.ToInt32(Session["userid"]);
                        LoadCart(userid);
                    }
                    Response.Write("<script>alert('Update successful');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error: Unable to update the item.');</script>");
                }
            
     
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("singlePro.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string s = "select max(cart_id) from cart_tab";
            string z = obj.fun_scalar(s);
            int ns = Convert.ToInt32(z);

            DateTime tdate = DateTime.Now;
            string dt = tdate.ToString("yyyy-MM-dd");

            int prqnty = 0;
            float gp = 0;
            int pid = 0;

            // Step 1: Retrieve all cart records first
            List<Dictionary<string, object>> cartItems = new List<Dictionary<string, object>>();

            for (int i = 1; i <= ns; i++)
            {
                string sel = "select * from cart_tab where cart_id=" + i;
                SqlDataReader dr = obj.fun_reader(sel);

                while (dr.Read())
                {
                    var item = new Dictionary<string, object>
            {
                { "quantity", dr["quantity"] },
                { "total_price", dr["total_price"] },
                { "pro_id", dr["pro_id"] },
                { "cart_id", i }
            };
                    cartItems.Add(item);
                }
                dr.Close();
            }

            // Step 2: Process each cart item and insert into the order table
            foreach (var item in cartItems)
            {
                prqnty = Convert.ToInt32(item["quantity"]);
                gp = Convert.ToSingle(item["total_price"]);
                pid = Convert.ToInt32(item["pro_id"]);
                int cart_id = Convert.ToInt32(item["cart_id"]);

                string insnew = "insert into Ordertab values(" + Session["userid"] + "," + pid + "," + prqnty + "," + gp + ",'" + dt + "','available')";
                int a = obj.fun_exenonquery(insnew);

                // Delete from cart_table after inserting into order_tab
                if (a == 1)
                {
                    string dnsnew = "delete from cart_tab where cart_id=" + cart_id;
                    int b = obj.fun_exenonquery(dnsnew);

                    if (b == 1)
                    {
                        Label4.Text = "Inserted successfully";

                    }

                }

                DataBind();
            }
            Response.Redirect("OrderConfir.aspx");
        }
    }
    }

          
    
    