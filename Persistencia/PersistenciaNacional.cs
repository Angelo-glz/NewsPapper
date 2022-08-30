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
  internal class PersistenciaNacional:IPersistenciaNacional
  {
    private static PersistenciaNacional instancia = null;
    private PersistenciaNacional() { }
    public static PersistenciaNacional GetInstancia()
    {
      if (instancia == null)
        instancia = new PersistenciaNacional();

      return instancia;
    }

    public void AgregarNacional(Nacional N)
    {
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("AltaNoticiaNacional", cnx);
      cmd.CommandType = CommandType.StoredProcedure;

      SqlParameter codigo = new SqlParameter("@codigo", N.Codigo);
      SqlParameter fechaPubli = new SqlParameter("@fechaPublicacion", N.FechaPublicacion);
      SqlParameter titulo = new SqlParameter("@titulo", N.Titulo);
      SqlParameter contenido = new SqlParameter("@contenido", N.Contenido);
      SqlParameter importancia = new SqlParameter("@importancia", N.Importancia);
      SqlParameter nomUsu = new SqlParameter("@nombreUsuario", N.Usuario.NombreUsuario);
      SqlParameter codigoSecc = new SqlParameter("@codigoSeccion", N.Seccion.CodigoSeccion);
      SqlParameter ret = new SqlParameter("@Retorno", SqlDbType.Int);
      ret.Direction = ParameterDirection.ReturnValue;

      int afect = -3;

      cmd.Parameters.Add(codigo);
      cmd.Parameters.Add(fechaPubli);
      cmd.Parameters.Add(titulo);
      cmd.Parameters.Add(contenido);
      cmd.Parameters.Add(importancia);
      cmd.Parameters.Add(nomUsu);
      cmd.Parameters.Add(codigoSecc);
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

        foreach (Periodista item in N.Periodistas)
        {
          PersistenciaPeriodista.GetInstancia().AgregarAutores(item, N.Codigo, trs);
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

    public void ModificarNacional(Nacional N)
    {
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlTransaction miTransaccion = null;

      SqlCommand cmd = new SqlCommand("ModificarNoticiaNacional", cnx);
      cmd.CommandType = CommandType.StoredProcedure;
      SqlParameter codigo = new SqlParameter("@codigo", N.Codigo);
      SqlParameter fechaPubli = new SqlParameter("@fechaPublicacion", N.FechaPublicacion);
      SqlParameter titulo = new SqlParameter("@titulo", N.Titulo);
      SqlParameter contenido = new SqlParameter("@contenido", N.Contenido);
      SqlParameter importancia = new SqlParameter("@importancia", N.Importancia);
      SqlParameter nomUsu = new SqlParameter("@nombreUsuario", N.Usuario.NombreUsuario);
      SqlParameter codigoSecc = new SqlParameter("@codigoSeccion", N.Seccion.CodigoSeccion);
      SqlParameter ret = new SqlParameter("@Retorno", SqlDbType.Int);
      ret.Direction = ParameterDirection.ReturnValue;

      cmd.Parameters.Add(codigo);
      cmd.Parameters.Add(fechaPubli);
      cmd.Parameters.Add(titulo);
      cmd.Parameters.Add(contenido);
      cmd.Parameters.Add(importancia);
      cmd.Parameters.Add(nomUsu);
      cmd.Parameters.Add(codigoSecc);
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

        PersistenciaPeriodista.GetInstancia().EliminarAutores(N.Codigo, miTransaccion);

        foreach (Periodista P in N.Periodistas)
        {
          PersistenciaPeriodista.GetInstancia().AgregarAutores(P, N.Codigo, miTransaccion);
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

    public List<Nacional> ListarNacionales()
    {
      List<Nacional> lista = new List<Nacional>();

      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("ListarNotNacional", cnx);
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
            string codSec = (string)read["codigoSeccion"];

            Nacional N = new Nacional(codigo, fechaPub, titulo, contenido, importancia, PersistenciaUsuario.GetInstance().Buscar(nomUsu), PersistenciaPeriodista.GetInstancia().CargarAutores(codigo), PersistenciaSeccion.GetInstance().BuscarSeccionesTodas(codSec));
            lista.Add(N);
          }
        }
        read.Close();
      }
      catch(Exception ex)
      {
        throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
      }
      finally
      {
        cnx.Close();
      }

      return lista;
    }

    public List<Nacional> ListarNacionalesUlt5Dias()
    {
      List<Nacional> lista = new List<Nacional>();

      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("ListarNotNacionalUlt5Dias", cnx);
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
            string codSec = (string)read["codigoSeccion"];


            Nacional N = new Nacional(codigo, fechaPub, titulo, contenido, importancia, PersistenciaUsuario.GetInstance().Buscar(nomUsu), PersistenciaPeriodista.GetInstancia().CargarAutores(codigo), PersistenciaSeccion.GetInstance().BuscarSeccionesTodas(codSec));
            lista.Add(N);
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

    public Nacional BuscarNacional(string pCode)
    {
      Nacional N = null;
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("Exec BuscarNacional " + pCode, cnx);

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
          string codSec = (string)read["codigoSeccion"];

          N = new Nacional(codigo, fechaPub, titulo, contenido, importancia, PersistenciaUsuario.GetInstance().Buscar(nomUsu), PersistenciaPeriodista.GetInstancia().CargarAutores(codigo), PersistenciaSeccion.GetInstance().BuscarSeccionesTodas(codSec));
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
      return N;
    }


  }
}
