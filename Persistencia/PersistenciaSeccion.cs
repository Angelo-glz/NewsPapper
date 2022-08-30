using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
  internal class PersistenciaSeccion:IPersistenciaSeccion
  {
    private static PersistenciaSeccion instancia = null;
    private PersistenciaSeccion() { }
    public static PersistenciaSeccion GetInstance()
    {
      if (instancia == null)
        instancia = new PersistenciaSeccion();

      return instancia;
    }

    public void AgregarSeccion(Seccion S)
    {
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("AltaSeccion", cnx);
      cmd.CommandType = CommandType.StoredProcedure;

      SqlParameter codigo = new SqlParameter("@codigoSeccion", S.CodigoSeccion);
      SqlParameter nombre = new SqlParameter("@nombre", S.Nombre);
      SqlParameter ret = new SqlParameter("@Retorno", SqlDbType.Int);
      ret.Direction = ParameterDirection.ReturnValue;

      int afect = -3;

      cmd.Parameters.Add(codigo);
      cmd.Parameters.Add(nombre);
      cmd.Parameters.Add(ret);

      try
      {
        cnx.Open();
        cmd.ExecuteNonQuery();
        afect = (int)cmd.Parameters["@Retorno"].Value;
        if (afect == -1)
          throw new Exception("La seccion ya existe");
      }
      catch (Exception ex)
      {
        throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
      }
      finally
      {
        cnx.Close();
      }
    }

    public void EliminarSeccion(Seccion S)
    {
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("EliminarSeccion", cnx);
      cmd.CommandType = CommandType.StoredProcedure;

      SqlParameter cedula = new SqlParameter("@codigoSeccion", S.CodigoSeccion);
      SqlParameter ret = new SqlParameter("@Retorno", SqlDbType.Int);
      ret.Direction = ParameterDirection.ReturnValue;

      int afect = -3;

      cmd.Parameters.Add(cedula);
      cmd.Parameters.Add(ret);

      try
      {
        cnx.Open();
        cmd.ExecuteNonQuery();
        afect = (int)cmd.Parameters["@Retorno"].Value;
        if (afect == -1)
          throw new Exception("La seccion no existe");
      }
      catch (Exception ex)
      {
        throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
      }
      finally
      {
        cnx.Close();
      }
    }

    public void ModificarSeccion(Seccion S)
    {
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("ModificarSeccion", cnx);
      cmd.CommandType = CommandType.StoredProcedure;

      SqlParameter codigo = new SqlParameter("@codigoSeccion", S.CodigoSeccion);
      SqlParameter nombre = new SqlParameter("@nombre", S.Nombre);
      SqlParameter ret = new SqlParameter("@Retorno", SqlDbType.Int);
      ret.Direction = ParameterDirection.ReturnValue;

      int afect = -3;

      cmd.Parameters.Add(codigo);
      cmd.Parameters.Add(nombre);
      cmd.Parameters.Add(ret);

      try
      {
        cnx.Open();
        cmd.ExecuteNonQuery();
        afect = (int)cmd.Parameters["@Retorno"].Value;
        if (afect == -1)
          throw new Exception("La seccion no existe");
        if (afect == -2)
          throw new Exception("Error al modificar seccion.");
      }
      catch (Exception ex)
      {
        throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
      }
      finally
      {
        cnx.Close();
      }
    }

    public Seccion BuscarSeccion(string pCodigo)
    {
      Seccion S = null;
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("Exec BuscarSeccionActivo " + pCodigo, cnx);

      SqlDataReader read;

      try
      {
        cnx.Open();
        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
          read.Read();
          S = new Seccion((string)read["codigoSeccion"], (string)read["nombre"]);
        }
        read.Close();
      }
      catch (Exception ex)
      {
        throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
      }
      finally
      {
        cnx.Close();
      }
      return S;
    }

    internal Seccion BuscarSeccionesTodas(string pCodigo)
    {
      Seccion S = null;
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("Exec BuscarSeccion " + pCodigo, cnx);

      SqlDataReader read;

      try
      {
        cnx.Open();
        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
          read.Read();
          S = new Seccion((string)read["codigoSeccion"], (string)read["nombre"]);
        }
        read.Close();
      }
      catch (Exception ex)
      {
        throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
      }
      finally
      {
        cnx.Close();
      }
      return S;
    }

    public List<Seccion> Listar()
    {
      Seccion S = null;
      List<Seccion> lista = new List<Seccion>();
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("Exec ListarSeccionesActivo", cnx);
      SqlDataReader read;
      try
      {
        cnx.Open();
        read = cmd.ExecuteReader();
        while (read.Read())
        {
          S = new Seccion((string)read["codigoSeccion"], (string)read["nombre"]);
          lista.Add(S);
        }
        read.Close();
      }
      catch (Exception ex)
      {
        throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
      }
      finally
      {
        cnx.Close();
      }
      return lista;
    }



  }
}
