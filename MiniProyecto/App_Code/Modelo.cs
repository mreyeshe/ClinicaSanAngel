using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


/// <summary>
/// Descripción breve de Modelo
/// </summary>
public class Modelo
{
	public Modelo()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public string cadenaconexion { set; get; }
    public SqlConnection AbrirConexion(ref string mensaje)// metodod devuelve conexion abierta
    {
        SqlConnection conexion =//
            new SqlConnection();
        conexion.ConnectionString = cadenaconexion;
        try
        {
            conexion.Open();
            mensaje = ("La conexion esta bien ");
        }
        catch (Exception t)
        {
            conexion = null;
            mensaje = ("Error" + t.Message);
        }
        return conexion;
    }

    public void ModifcarBd(SqlConnection cna, SqlCommand carrito, ref string mensaje)
    {


        carrito.Connection = cna;




        try
        {
            carrito.ExecuteNonQuery();
            mensaje = ("Modificacion correcta");
        }
        catch (Exception g)
        {
            mensaje = ("error" + g.Message);
        }
        cna.Close();
        cna.Dispose();
    }

    public SqlDataAdapter ConsultaDataAdapter(SqlConnection cna, string consulta, ref string mensaje)
    {
        SqlDataAdapter resultados;
        SqlCommand carrito = new SqlCommand();
        carrito.Connection = cna;
        carrito.CommandText = consulta;
        try
        {
            resultados = new SqlDataAdapter(carrito);// resutlado de la consulta en resultados
            mensaje = ("Consulta correcta");
        }
        catch (Exception f)
        {
            mensaje = ("Ocurrio un error " + f.Message);
            resultados = null;
        }
        return resultados;
    }

    public SqlDataReader ConsultaDataReader(SqlConnection cna, string consulta, ref string mensaje)
    {
        SqlDataReader resultados;
        SqlCommand carrito = new SqlCommand();
        carrito.Connection = cna;
        carrito.CommandText = consulta;
        try
        {
            resultados = carrito.ExecuteReader();// resutlado de la consulta en resultados
            mensaje = ("Consulta correcta");
        }
        catch (Exception f)
        {
            mensaje = ("Ocurrio un error " + f.Message);
            resultados = null;
        }
        return resultados;
    }
}