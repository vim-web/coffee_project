﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace coffProject
{
    public partial class Adminreg : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select max(reg_id) from login";
            string maxregid = obj.fun_scalar(s);
            int regid = 0;
            if (maxregid == "")
            {
                regid = 1;
            }
            else
            {
                int newmaxid = Convert.ToInt32(maxregid);
                regid = newmaxid + 1;
            }
            string ins = "insert into admin_tab values(" + regid + ",'" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ")";
            int i = obj.fun_exenonquery(ins);
            if (i == 1)
            {
                string inlog="insert into login values("+regid+",'"+TextBox4.Text+"','"+TextBox5.Text+"','admin')";
                int j = obj.fun_exenonquery(inlog);
            }

        }
    }
}