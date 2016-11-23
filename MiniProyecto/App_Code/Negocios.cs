using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de Negocios
/// </summary>
public class Negocios
{
	public Negocios()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    Intermedia inter = new Intermedia();
    DataTable citas = new DataTable();
    public void insertarproc(ref string m, string procedure, params object[] datos)
    {
        inter.insertaproce(ref m, procedure, datos);
    }
    public void consulta(ref string m, string consulta, ref DataTable tabla)
    {
        inter.Consulta(ref m, consulta, ref tabla);
    }

    public void comprueba(ref string m,  params object[] datos)
    {
       
        consulta(ref m , "Select HorasLab, cm.Dias, NombreMedico from CitasMedicas cm, Medicos m, HorariosLaborales hl where m.Id_Medico=cm.Id_Medico  and hl.Id_Horas=cm.Id_Horas and hl.Id_Horas=" + datos[4]    + " and Dias = '" + datos[3] + "' and cm.Id_Medico = " + datos[1], ref citas );
        if(citas.Rows.Count>0)
        {
            m = "Cita ya reservada, elija otra fecha u hora";

        }
        else
        {
            
            insertarproc(ref m, "dbo.insertacitas", datos);
        }
    }

    
}