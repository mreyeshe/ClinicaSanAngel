using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Intermedia
/// </summary>
public class Intermedia
{
	
    Modelo conexion = new Modelo();
    SqlConnection camino = new SqlConnection();
    SqlDataReader lector;
    SqlDataAdapter Adaptador;
	public Intermedia()
	{
        conexion.cadenaconexion = @"Data Source='';Initial Catalog=ClinicaSanAngel;Integrated Security=SSPI;";
	}
    public void ConsultarBD(ref string mensaje, string consulta, ref DataTable tabla)
    {
        tabla = new DataTable();
        camino = conexion.AbrirConexion(ref mensaje);
        if (camino != null)
        {
            lector = conexion.ConsultaDataReader(camino, consulta, ref mensaje);
            if (lector != null)
            {
                for (int c = 0; c < lector.FieldCount; c++)//field count numero de columnas de la fila actual
                {
                    tabla.Columns.Add(lector.GetName(c).ToString(), System.Type.GetType(lector.GetFieldType(c).ToString()));
                }
                while (lector.Read())
                {
                    DataRow dr = tabla.NewRow();
                    for (int c = 0; c < lector.FieldCount; c++)
                    {
                        dr[c] = lector[c];
                    }
                    tabla.Rows.Add(dr);
                }
            }
        }
        camino.Close(); camino.Dispose();
    }
    public void obtenerparametros(ref string mensaje, string consulta, string procedure, params object[] datos)
    {
        camino = conexion.AbrirConexion(ref mensaje);
        SqlCommand comando =new SqlCommand(procedure,camino);
        comando.CommandType = CommandType.StoredProcedure;
        //comando.CommandText = procedure;
        
       
        if (camino != null)
        {
            lector = conexion.ConsultaDataReader(camino, consulta, ref mensaje);
            if (lector != null)
            {
                for (int c = 1; c < lector.FieldCount; c++)//field count numero de columnas de la fila actual
                {
                    comando.Parameters.Add(lector.GetName(c).ToString(), System.Type.GetType(lector.GetFieldType(c).ToString()));
                    comando.Parameters[lector.GetName(c).ToString()].Value = datos[c-1];
                }
            }
        }
        camino = conexion.AbrirConexion(ref mensaje);
        conexion.ModifcarBd(camino, comando, ref mensaje);
        camino.Close();
        camino.Dispose();
    }

    public void insertaproce(ref string mensaje, string procedure, params object[] datos)
    {
        int c = 0;
        camino = conexion.AbrirConexion(ref mensaje);
        SqlCommand comando = new SqlCommand(procedure,camino);
        comando.CommandType = CommandType.StoredProcedure;
        SqlCommandBuilder.DeriveParameters(comando);
        
        if (camino != null)
        {
            foreach (SqlParameter parametro in comando.Parameters)
            {
                parametro.Value = datos[c];
                c++;
            }
        }
        conexion.ModifcarBd(camino, comando, ref mensaje);
        camino.Close(); camino.Dispose();
    }
    public void Consulta(ref string mensaje, string consulta, ref DataTable Tabla)
    {
        Tabla.Clear();

        camino = conexion.AbrirConexion(ref mensaje);
        if (camino != null)
        {
            Adaptador = conexion.ConsultaDataAdapter(camino, consulta, ref mensaje);
            Adaptador.Fill(Tabla);
            camino.Close();
        }

    }



}