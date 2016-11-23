using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    Modelo m = new Modelo();
    Negocios bussines = new Negocios();
    Vista mens = new Vista();
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
        string variable="";
        string respuestamedoto = "";
        //atrapar el parametro o variable que viene del cliente
        variable = Request.QueryString[0].ToString();
        //respuestametodo=cm
        Response.ContentType = "text";
        Response.Write("El servidor dice: " + respuestamedoto);
        Response.Flush();
        Response.End();
        // todo esto es solo la parte del servidor
                                         

       

    }
}