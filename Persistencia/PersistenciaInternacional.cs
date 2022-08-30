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
  internal class PersistenciaInternacional:IPersistenciaInternacional
  {
    private static PersistenciaInternacional instancia = null;
    private PersistenciaInternacional() { }
    public static PersistenciaInternacional GetInstancia()
    {
      if (instancia == null)
        instancia = new PersistenciaInternacional();

      return instancia;
    }

    public void AgregarInternacional(Internacional I)
    {
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("AltaNoticiaInternacional", cnx);
      cmd.CommandType = CommandType.StoredProcedure;

      SqlParameter codigo = new SqlParameter("@codigo", I.Codigo);
      SqlParameter fechaPubli = new SqlParameter("@fechaPublicacion", I.FechaPublicacion);
      SqlParameter titulo = new SqlParameter("@titulo", I.Titulo);
      SqlParameter contenido = new SqlParameter("@contenido", I.Contenido);
      SqlParameter importancia = new SqlParameter("@importancia", I.Importancia);
      SqlParameter nomUsu = new SqlParameter("@nombreUsuario", I.Usuario.NombreUsuario);
      SqlParameter pais = new SqlParameter("@pais", I.Pais);
      SqlParameter ret = new SqlParameter("@Retorno", SqlDbType.Int);
      ret.Direction = ParameterDirection.ReturnValue;

      int afect = -5;

      cmd.Parameters.Add(codigo);
      cmd.Parameters.Add(fechaPubli);
      cmd.Parameters.Add(titulo);
      cmd.Parameters.Add(contenido);
      cmd.Parameters.Add(importancia);
      cmd.Parameters.Add(nomUsu);
      cmd.Parameters.Add(pais);
      cmd.Parameters.Add(ret);

      SqlTransaction trs = null;

      try
      {
        cnx.Open();

        trs = cnx.BeginTransaction();

        cmd.Transaction = trs;
        cmd.ExecuteNonQuery();

        afect = (int)cmd.Parameters["@Retorno"].Value;
        if (afect == -1)
          throw new Exception("La noticia ya existe");
        if (afect == -2)
          throw new Exception("El usuario no existe");
        if (afect == -3)
          throw new Exception("Error al generar la noticia");

        foreach (Periodista item in I.Periodistas)
        {
          PersistenciaPeriodista.GetInstancia().AgregarAutores(item, I.Codigo, trs);
        }
        trs.Commit();
      }
      catch (Exception ex)
      {
        trs.Rollback();
        throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
      }
      finally
      {
        cnx.Close();
      }
    }

    public void ModificarInternacional(Internacional I)
    {
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlTransaction miTransaccion = null;

      SqlCommand cmd = new SqlCommand("ModificarNoticiaInternacional", cnx);
      cmd.CommandType = CommandType.StoredProcedure;
      SqlParameter codigo = new SqlParameter("@codigo", I.Codigo);
      SqlParameter fechaPubli = new SqlParameter("@fechaPublicacion", I.FechaPublicacion);
      SqlParameter titulo = new SqlParameter("@titulo", I.Titulo);
      SqlParameter contenido = new SqlParameter("@contenido", I.Contenido);
      SqlParameter importancia = new SqlParameter("@importancia", I.Importancia);
      SqlParameter nomUsu = new SqlParameter("@nombreUsuario", I.Usuario.NombreUsuario);
      SqlParameter pais = new SqlParameter("@pais", I.Pais);
      SqlParameter ret = new SqlParameter("@Retorno", SqlDbType.Int);
      ret.Direction = ParameterDirection.ReturnValue;

      cmd.Parameters.Add(codigo);
      cmd.Parameters.Add(fechaPubli);
      cmd.Parameters.Add(titulo);
      cmd.Parameters.Add(contenido);
      cmd.Parameters.Add(importancia);
      cmd.Parameters.Add(nomUsu);
      cmd.Parameters.Add(pais);
      cmd.Parameters.Add(ret);

      try
      {
        cnx.Open();
        miTransaccion = cnx.BeginTransaction();

        cmd.Transaction = miTransaccion;
        cmd.ExecuteNonQuery();

        int error = (int)ret.Value;
        if (error == -1)
          throw new Exception("No existe la noticia a modificar.");
        if (error == -2)
          throw new Exception("No existe el usuario ligado a la modificacion.");
        if (error == -3)
          throw new Exception("Error al modificar la noticia.");

        PersistenciaPeriodista.GetInstancia().EliminarAutores(I.Codigo, miTransaccion);

        foreach (Periodista P in I.Periodistas)
        {
          PersistenciaPeriodista.GetInstancia().AgregarAutores(P, I.Codigo, miTransaccion);
        }
        miTransaccion.Commit();
      }
      catch (Exception ex)
      {
        miTransaccion.Commit();
        throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
      }
      finally
      {
        cnx.Close();
      }
    }

    public List<Internacional> ListarInternacional()
    {
      List<Internacional> lista = new List<Internacional>();

      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("ListarNotInter", cnx);
      cmd.CommandType = CommandType.StoredProcedure;

      try
      {

        cnx.Open();

        //ejecuto consulta
        SqlDataReader read = cmd.ExecuteReader();

        //verifico si hay telefonos
        if (read.HasRows)
        {
          while (read.Read())
          {
            string codigo = (string)read["codigo"];
            DateTime fechaPub = (DateTime)read["FechaPublicacion"];
            string titulo = (string)read["Titulo"];
            string contenido = (string)read["contenido"];
            int importancia = (int)read["importancia"];
            string nomUsu = (string)read["nombreUsuario"];
            string pais = (string)read["pais"];

            Internacional I = new Internacional(codigo, fechaPub, titulo, contenido, importancia, PersistenciaUsuario.GetInstance().Buscar(nomUsu), pais, PersistenciaPeriodista.GetInstancia().CargarAutores(codigo));
            lista.Add(I);
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

      return lista;
    }

    public List<Internacional> ListarInternacionalUlt5Dias()
    {
      List<Internacional> lista = new List<Internacional>();

      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("ListarNotInterUlt5Dias", cnx);
      cmd.CommandType = CommandType.StoredProcedure;

      try
      {

        cnx.Open();

        //ejecuto consulta
        SqlDataReader read = cmd.ExecuteReader();

        //verifico si hay telefonos
        if (read.HasRows)
        {
          while (read.Read())
          {
            string codigo = (string)read["codigo"];
            DateTime fechaPub = (DateTime)read["FechaPublicacion"];
            string titulo = (string)read["Titulo"];
            string contenido = (string)read["contenido"];
            int importancia = (int)read["importancia"];
            string nomUsu = (string)read["nombreUsuario"];
            string pais = (string)read["pais"];

            Internacional I = new Internacional(codigo, fechaPub, titulo, contenido, importancia, PersistenciaUsuario.GetInstance().Buscar(nomUsu), pais, PersistenciaPeriodista.GetInstancia().CargarAutores(codigo));
            lista.Add(I);
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
      return lista;
    }

    public Internacional BuscarInternacional(string pCode)
    {
      Internacional I = null;
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("Exec BuscarInternacional " + pCode, cnx);

      SqlDataReader read;

      try
      {
        cnx.Open();
        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
          read.Read();
          string codigo = (string)read["codigo"];
          DateTime fechaPub = (DateTime)read["FechaPublicacion"];
          string titulo = (string)read["Titulo"];
          string contenido = (string)read["contenido"];
          int importancia = (int)read["importancia"];
          string nomUsu = (string)read["nombreUsuario"];
          string pais = (string)read["pais"];

          I = new Internacional(codigo, fechaPub, titulo, contenido, importancia, PersistenciaUsuario.GetInstance().Buscar(nomUsu), pais, PersistenciaPeriodista.GetInstancia().CargarAutores(codigo));
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
      return I;
    }

  }
}
