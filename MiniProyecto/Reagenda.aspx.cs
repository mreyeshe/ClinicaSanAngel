using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Re_Agenda : System.Web.UI.Page
{
    DataTable consultas = new DataTable();
    Negocios business = new Negocios();
    Vista mensajes = new Vista();
    string m = "";
    DataTable medico = new DataTable();
    DataTable paciente = new DataTable();
    DataTable dias = new DataTable();
    DataTable horas = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {
        Page.LoadComplete += new EventHandler(Page_LoadComplete);
    }
    void Page_LoadComplete(object sender, EventArgs e)
    {
        DataView data = new DataView(medico);
        DataView data1 = new DataView(paciente);
        DataView data3 = new DataView(horas);

        mensajes.FillDrop(ref m, DropDownList1, "NombreMedico", "Id_Medico", data);
        mensajes.FillDrop(ref m, DropDownList3, "NombreP", "Id_Paciente", data1);
        mensajes.FillDrop(ref m, DropDownList4, "HorasLab", "Id_Horas", data3);
        business.consulta(ref m, "Select Id_Medico, NombreMedico from Medicos", ref medico);
        business.consulta(ref m, "Select Id_Paciente, NombreP from Pacientes", ref paciente);
        business.consulta(ref m, "Select Id_Horas, HorasLab from HorariosLaborales", ref horas);
        business.consulta(ref m, "Select cm.Id_Cita as Numero, HorasLab, cm.Dias, NombreMedico, NombreP, cm.Descripcion from CitasMedicas cm, Medicos m, Pacientes p , HorariosLaborales hl where m.Id_Medico=cm.Id_Medico and p.Id_Paciente=cm.Id_Paciente and hl.Id_Horas=cm.Id_Horas", ref consultas);
        mensajes.LlenaGrid(ref m, GridView2, consultas);
        DataView datos1 = new DataView(consultas);
        mensajes.FillDrop(ref m, DropDownList2, "Numero", "Numero", datos1);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
    }

    protected void DropDownList2_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
        Label2.Visible = true;
        Label3.Visible = true;
        Label4.Visible = true;
        DropDownList1.Visible = true;
        DropDownList3.Visible = true;
        DropDownList4.Visible = true;
        Button1.Visible = true;
        TextBox1.Visible= true;
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        business.insertarproc(ref m, "dbo.actualizacita", null, DropDownList2.SelectedValue, DropDownList1.SelectedValue, DropDownList3.SelectedValue, Calendar1.SelectedDate, DropDownList4.SelectedValue, TextBox1.Text);
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.DayOfWeek == DayOfWeek.Saturday || e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
        {
            e.Day.IsSelectable = false;
            e.Cell.BorderColor = System.Drawing.Color.Gray;
            e.Cell.BackColor = System.Drawing.Color.DarkGray;
        }

        if (e.Day.Date.Month < DateTime.Now.Month || e.Day.Date.Day < DateTime.Now.Day)
        {
            e.Day.IsSelectable = false;
            e.Cell.BackColor = System.Drawing.Color.DarkGray;
        }
        if (e.Day.Date.Month < DateTime.Now.Month || e.Day.Date.Year < DateTime.Now.Year)
        {
            e.Day.IsSelectable = false;
            e.Cell.BackColor = System.Drawing.Color.DarkGray;
        }
        if (e.Day.Date.Year > DateTime.Now.Year || e.Day.Date.Month > DateTime.Now.Month && e.Day.Date.DayOfWeek != DayOfWeek.Saturday && e.Day.Date.DayOfWeek != DayOfWeek.Sunday)
        {
            e.Day.IsSelectable = true;
            e.Cell.BackColor = System.Drawing.Color.White;
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        Calendar1.SelectedDate.ToString("dd/mm/yyyy");
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}