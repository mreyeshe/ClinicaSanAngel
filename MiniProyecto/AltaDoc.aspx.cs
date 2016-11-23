using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class index : System.Web.UI.Page
{
    Vista mensajes = new Vista();
    Negocios business = new Negocios();
    DataTable tabla = new DataTable();
    string m = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }

    
    protected void Button1_Click(object sender, EventArgs e)
    {
        business.insertarproc(ref m, "dbo.insertamedico", null, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text);
        mensajes.miMessaggeBox(m, this.Page);
    }
}