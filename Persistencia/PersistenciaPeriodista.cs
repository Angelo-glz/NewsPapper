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
  internal class PersistenciaPeriodista : IPersistenciaPeriodista
  {
    private static PersistenciaPeriodista instancia = null;
    private PersistenciaPeriodista() { }
    public static PersistenciaPeriodista GetInstancia()
    {
      if (instancia == null)
        instancia = new PersistenciaPeriodista();

      return instancia;
    }

    public void AgregarPeriodista(Periodista P)
    {
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("AltaPeriodista", cnx);
      cmd.CommandType = CommandType.StoredProcedure;

      SqlParameter cedula = new SqlParameter("@cedula", P.Cedula);
      SqlParameter nombre = new SqlParameter("@nombre", P.Nombre);
      SqlParameter mail = new SqlParameter("@mail", P.Mail);
      SqlParameter ret = new SqlParameter("@Retorno", SqlDbType.Int);
      ret.Direction = ParameterDirection.ReturnValue;

      int afect = -3;

      cmd.Parameters.Add(cedula);
      cmd.Parameters.Add(nombre);
      cmd.Parameters.Add(mail);
      cmd.Parameters.Add(ret);

      try
      {
        cnx.Open();
        cmd.ExecuteNonQuery();
        afect = (int)cmd.Parameters["@Retorno"].Value;
        if (afect == -1)
          throw new Exception("El Periodista ya existe");
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

    public void EliminarPeriodista(Periodista P)
    {
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("BajaPeriodista", cnx);
      cmd.CommandType = CommandType.StoredProcedure;

      SqlParameter cedula = new SqlParameter("@cedula", P.Cedula);
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
          throw new Exception("El periodista no existe");
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

    public void ModificarPeriodista(Periodista P)
    {
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("ModificarPeriodista", cnx);
      cmd.CommandType = CommandType.StoredProcedure;

      SqlParameter cedula = new SqlParameter("@cedula", P.Cedula);
      SqlParameter nombre = new SqlParameter("@nombre", P.Nombre);
      SqlParameter mail = new SqlParameter("@mail", P.Mail);


      SqlParameter ret = new SqlParameter("@Retorno", SqlDbType.Int);
      ret.Direction = ParameterDirection.ReturnValue;

      int afect = -3;

      cmd.Parameters.Add(cedula);
      cmd.Parameters.Add(nombre);
      cmd.Parameters.Add(mail);
      cmd.Parameters.Add(ret);

      try
      {
        cnx.Open();
        cmd.ExecuteNonQuery();
        afect = (int)cmd.Parameters["@Retorno"].Value;
        if (afect == -1)
          throw new Exception("El periodista no existe");
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

    public Periodista BuscarPeriodista(int pCedula)
    {
      Periodista P = null;
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("Exec BuscarPeriodistaActivo " + pCedula, cnx);

      SqlDataReader read;

      try
      {
        cnx.Open();
        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
          read.Read();
          P = new Periodista((int)read["cedula"], (string)read["Nombre"], (string)read["mail"]);
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
      return P;
    }

    internal Periodista BuscarPeriodistaTodos(int pCedula)
    {
      Periodista P = null;
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("Exec BuscoPeriodista " + pCedula, cnx);

      SqlDataReader read;

      try
      {
        cnx.Open();
        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
          read.Read();
          P = new Periodista((int)read["cedula"], (string)read["Nombre"], (string)read["mail"]);
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
      return P;
    }

    public List<Periodista> ListarPeriodistas()
    {
      Periodista P = null;
      List<Periodista> lista = new List<Periodista>();
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("Exec ListarPeriodistasActivo", cnx);
      SqlDataReader read;
      try
      {
        cnx.Open();
        read = cmd.ExecuteReader();
        while (read.Read())
        {
          P = new Periodista((int)read["cedula"], (string)read["Nombre"], (string)read["mail"]);
          lista.Add(P);
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

    internal List<Periodista> CargarAutores(string pCodigoNoticia)
    {
      List<Periodista> _lista = new List<Periodista>();

      SqlConnection cnx = new SqlConnection(Conexion.Cnx);

      SqlCommand _comando = new SqlCommand("ListarAutores", cnx);
      _comando.CommandType = CommandType.StoredProcedure;
      _comando.Parameters.AddWithValue("@codigo", pCodigoNoticia);

      try
      {
        cnx.Open();

        SqlDataReader read = _comando.ExecuteReader();

        if (read.HasRows)
        {
          while (read.Read())
          {
            _lista.Add(new Periodista((int)read["Cedula"], (string)read["Nombre"], (string)read["Mail"]));
          }
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
      return _lista;
    }

    internal void AgregarAutores(Periodista T, string CodigoNot, SqlTransaction trs)
    {
      SqlCommand cmd = new SqlCommand("AltaAutoresNoticia", trs.Connection);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@cedula", T.Cedula);
      cmd.Parameters.AddWithValue("@codigo", CodigoNot);
      SqlParameter ret = new SqlParameter("@retorno", SqlDbType.Int);
      ret.Direction = ParameterDirection.ReturnValue;
      cmd.Parameters.Add(ret);

      try
      {
        cmd.Transaction = trs;

        cmd.ExecuteNonQuery();

        if ((int)ret.Value == -1 || (int)ret.Value == -3)
          throw new Exception("No existe el periodista");
        if ((int)ret.Value == -2)
          throw new Exception("No existe la noticia.");
        if ((int)ret.Value == -4)
          throw new Exception("Error al asignar un autor a la noticia");
      }
      catch (Exception ex)
      {
        throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
      }
    }

    internal void EliminarAutores(string CodigoNot, SqlTransaction trs)
    {
      SqlCommand cmd = new SqlCommand("EliminarAutorNoticia", trs.Connection);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@codigo", CodigoNot);
      SqlParameter ret = new SqlParameter("@retorno", SqlDbType.Int);
      ret.Direction = ParameterDirection.ReturnValue;
      cmd.Parameters.Add(ret);

      try
      {
        cmd.Transaction = trs;

        cmd.ExecuteNonQuery();

      }
      catch (Exception ex)
      {
        throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
      }
    }


  }
}
