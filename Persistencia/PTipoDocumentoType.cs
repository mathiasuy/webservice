using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;

namespace Persistencia
{
    public class PTipoDocumentoType
    {
        private static string mensaje = "el Tipo de Documento";

        public static TipoDocumentoType BuscarTipoDocumento(int id)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarTipoDocumento";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                TipoDocumentoType ret = null;


                if (lectorDatos.Read())
                {
                    int Id = (int)lectorDatos["Id"];
                    string Nombre = Convert.ToString(lectorDatos["Nombre"]);

                    ret = new TipoDocumentoType(Id, Nombre);
                }

                return ret;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesPersonalizadas.
                    Persistencia("No se pudo buscar " + mensaje + ".");
            }
            finally
            {
                if (lectorDatos != null)
                {
                    lectorDatos.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static int AltaTipoDocumento(TipoDocumentoType a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaTipoDocumento";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Id);
                comando.Parameters.AddWithValue("@nombre", a.Nombre);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add(valorRetorno);

                conexion.Open();

                comando.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -2)
                {
                    throw new Exception();
                }

                return (int)valorRetorno.Value;
            }
            catch (Exception )
            {
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo dar de alta " + mensaje + ".");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }


        public static int BajaTipoDocumento(int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaTipoDocumento";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add(valorRetorno);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -2)
                {
                    throw new Exception();
                }

                return (int)valorRetorno.Value;
            }
            catch (Exception )
            {
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo dar de baja " + mensaje + ".");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static int ModificarTipoDocumento(TipoDocumentoType a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarTipoDocumentoType";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Id);
                comando.Parameters.AddWithValue("@Nombre", a.Nombre);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add(valorRetorno);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -2)
                {
                    throw new Exception();
                }

                return (int)valorRetorno.Value;
            }
            catch (Exception )
            {
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo modificar " + mensaje + ".");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static List<TipoDocumentoType> ListarTipoDocumentoType()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarTipoDocumento";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<TipoDocumentoType> cod = new List<TipoDocumentoType>();

                TipoDocumentoType ag = null;

                while (lectorDatos.Read())
                {
                    ag = new TipoDocumentoType(
                        (int)lectorDatos["Id"],
                        (string)lectorDatos["nombre"]
                        );

                    cod.Add(ag);
                }

                return cod;
            }
            catch (Exception )
            {
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo conseguir la listas de " + mensaje + ".");
            }
            finally
            {
                if (lectorDatos != null)
                {
                    lectorDatos.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

    }
}
