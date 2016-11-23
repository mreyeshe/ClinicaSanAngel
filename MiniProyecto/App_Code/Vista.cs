using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Descripción breve de Vista
/// </summary>
public class Vista
{
	public Vista()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public string convertir(string c)
    {
        string limpia = "";
        int i, longi;
        longi = c.Length - 1;
        for (i = 0; i <= longi; i++)
        {
            if (c[i] != '\'')
            {
                limpia = limpia + c[i];
            }
            else
            {
                limpia = limpia + '\\' + c[i];
            }

        }
        return limpia;
    }


    public void miMessaggeBox(string cade, System.Web.UI.Page Pagina)
    {
        //convertir(cade);
        Pagina.Response.Write("<script type='text/javascript'/> alert('" + cade + "') </script>");
    }
    
    public void FillDrop(ref string m, System.Web.UI.WebControls.DropDownList drop, string columna, string ID, DataView tabla)
    {
        drop.DataSource = tabla;
        drop.DataTextField = columna;
        drop.DataValueField = ID;
        drop.DataBind();


    }
    public void FillDrop(ref string m, System.Web.UI.WebControls.DropDownList drop,  string ID, DataView tabla)
    {
        drop.DataSource = tabla;
        drop.DataValueField = ID;
        drop.DataBind();
    }
    public void LlenaGrid(ref string m, System.Web.UI.WebControls.GridView grid, DataTable tabla)
    {
        grid.DataSource = tabla;
        
        grid.DataBind();
    }

}