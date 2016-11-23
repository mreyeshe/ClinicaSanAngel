using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Agendas : System.Web.UI.Page
{
    Negocios business = new Negocios();
    Vista mensajes = new Vista();
    string m = "";
    DataTable medico = new DataTable();
    DataTable paciente = new DataTable();
    DataTable dias = new DataTable();
    DataTable horas = new DataTable();
     string fecha = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.LoadComplete += new EventHandler(Page_LoadComplete);
    }

    void Page_LoadComplete(object sender, EventArgs e)
    {
        // call your download function
        business.consulta(ref m, "Select Id_Medico, NombreMedico from Medicos", ref medico);
        business.consulta(ref m, "Select Id_Paciente, NombreP from Pacientes", ref paciente);
        business.consulta(ref m, "Select Id_Horas, HorasLab from HorariosLaborales", ref horas);

        DataView data = new DataView(medico);
        DataView data1 = new DataView(paciente);
        DataView data3 = new DataView(horas);
       
        mensajes.FillDrop(ref m, DropDownList1, "NombreMedico" ,"Id_Medico", data);
        mensajes.FillDrop(ref m, DropDownList2, "NombreP", "Id_Paciente", data1);
        mensajes.FillDrop(ref m, DropDownList4, "HorasLab", "Id_Horas", data3);
        

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        business.comprueba(ref m, null, DropDownList1.SelectedValue, DropDownList2.SelectedValue, TextBox2.Text, DropDownList4.SelectedValue, TextBox1.Text);

        //business.insertarproc(ref m, "dbo.insertacitas", null, DropDownList1.SelectedValue, DropDownList2.SelectedValue, TextBox2.Text, DropDownList4.SelectedValue, TextBox1.Text);
        mensajes.miMessaggeBox(m, this.Page);
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
       
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
    protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
    {
       
        TextBox2.Text= Calendar1.SelectedDate.ToString("dd/MM/yyyy");
    
    }
}