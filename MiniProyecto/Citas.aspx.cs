using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Citas : System.Web.UI.Page
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

        business.consulta(ref m, "exec informacion", ref consultas);
        business.consulta(ref m, "Select Id_Medico, NombreMedico from Medicos", ref medicos);
        DataView data = new DataView(medicos);
        mensajes.FillDrop(ref m, DropDownList1, "NombreMedico", "Id_Medico", data);
        mensajes.LlenaGrid(ref m, GridView1, consultas);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        business.consulta(ref m, "Select HorasLab, cm.Dias, NombreMedico, NombreP, cm.Descripcion from CitasMedicas cm, Medicos m, Pacientes p , HorariosLaborales hl where m.Id_Medico=cm.Id_Medico and p.Id_Paciente=cm.Id_Paciente and hl.Id_Horas=cm.Id_Horas and m.Id_Medico =" + DropDownList1.SelectedValue  , ref consultas);
        mensajes.LlenaGrid(ref m, GridView2, consultas);

    }
}