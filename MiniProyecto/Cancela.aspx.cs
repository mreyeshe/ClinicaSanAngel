using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class Cancela : System.Web.UI.Page
{
    DataTable consultas = new DataTable();
    Negocios business = new Negocios();
    Vista mensajes = new Vista();
    string m = "";
    DataTable medicos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.LoadComplete += new EventHandler(Page_LoadComplete);
    }
    void Page_LoadComplete(object sender, EventArgs e)
    {


        business.consulta(ref m, "Select Id_Medico, NombreMedico from Medicos", ref medicos);
        DataView data = new DataView(medicos);
        mensajes.FillDrop(ref m, DropDownList1, "NombreMedico", "Id_Medico", data);
        mensajes.LlenaGrid(ref m, GridView2, consultas);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        business.consulta(ref m, "Select cm.Id_Cita as Numero, HorasLab, cm.Dias, NombreMedico, NombreP, cm.Descripcion from CitasMedicas cm, Medicos m, Pacientes p , HorariosLaborales hl where m.Id_Medico=cm.Id_Medico and p.Id_Paciente=cm.Id_Paciente and hl.Id_Horas=cm.Id_Horas and m.Id_Medico =" + DropDownList1.SelectedValue, ref consultas);
        mensajes.LlenaGrid(ref m, GridView2, consultas);
        DataView datos1 = new DataView(consultas);
        mensajes.FillDrop(ref m, DropDownList2, "Numero", "Numero", datos1);

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        business.insertarproc(ref m, "dbo.borracitas", null, DropDownList2.SelectedValue);
    }
}