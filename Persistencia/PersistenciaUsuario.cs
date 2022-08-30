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
  internal class PersistenciaUsuario:IPersistenciaUsuario
  {
    private static PersistenciaUsuario instancia = null;
    private PersistenciaUsuario() { }
    public static PersistenciaUsuario GetInstance()
    {
      if (instancia == null)
        instancia = new PersistenciaUsuario();

      return instancia;
    }

    public void AgregarUsuario(Usuario U)
    {
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("AltaUsu", cnx);
      cmd.CommandType = CommandType.StoredProcedure;

      SqlParameter _pass = new SqlParameter("@pass", U.Contrasena);
      SqlParameter _nomUsu = new SqlParameter("@nomUsu", U.NombreUsuario);
      SqlParameter ret = new SqlParameter("@Retorno", SqlDbType.Int);
      ret.Direction = ParameterDirection.ReturnValue;

      int afect;

      cmd.Parameters.Add(_pass);
      cmd.Parameters.Add(_nomUsu);
      cmd.Parameters.Add(ret);


      try
      {
        cnx.Open();

        cmd.ExecuteNonQuery();
        afect = (int)cmd.Parameters["@Retorno"].Value;
        if (afect == -1)
          throw new Exception("El usuario ya existe.");
        if (afect == -2)
          throw new Exception("Error al dar de alta el ususario.");

      }catch(Exception ex) { throw new ApplicationException("Error en base de datos: " + ex.Message); }
      finally { cnx.Close(); }
    }

    public bool Loguear(Usuario U)
    {
      Usuario Usu = null;
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);

      SqlCommand cmd = new SqlCommand("Logueo", cnx);
      cmd.CommandType = CommandType.StoredProcedure;

      SqlParameter _pass = new SqlParameter("@pass", U.Contrasena);
      SqlParameter _nomUsu = new SqlParameter("@nomUsu", U.NombreUsuario);

      cmd.Parameters.Add(_pass);
      cmd.Parameters.Add(_nomUsu);

      SqlDataReader read;

      try
      {
        cnx.Open();

        read = cmd.ExecuteReader();
        if(read.HasRows)
        {
          read.Read();
          Usu = new Usuario((string)read["NombreUsuario"], (string)read["Contraseña"]);
        }
        read.Close();
      }
      catch (Exception ex) { throw new ApplicationException("Error en base de datos: " + ex.Message); }
      finally { cnx.Close(); }
      if (Usu == null)
        return false;
      else
        return true;
    }

    public Usuario Buscar(string nomUsu)
    {
      Usuario Usu = null;
      SqlConnection cnx = new SqlConnection(Conexion.Cnx);
      SqlCommand cmd = new SqlCommand("Exec BuscarUsuario " + nomUsu, cnx);

      SqlDataReader read;

      try
      {
        cnx.Open();

        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
          read.Read();
          Usu = new Usuario((string)read["NombreUsuario"], (string)read["Contraseña"]);
        }
        read.Close();
      }
      catch (Exception ex) { throw new ApplicationException("Error en base de datos: " + ex.Message); }
      finally { cnx.Close(); }
      return Usu;
    }


  }
}
