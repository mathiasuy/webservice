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
    public class PTipoTraslado
    {
        private static string mensaje = "el tipo de traslado";

        public static TipoTrasladoType BuscarTipoTraslado(int id)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarTipoTraslado";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                TipoTrasladoType ret = null;

                if (lectorDatos.Read())
                {
                    int Id = (int)lectorDatos["Id"];
                    string Nombre = Convert.ToString(lectorDatos["Nombre"]);
                    bool Habilitado = (bool)lectorDatos["Habilitado"];
                    ret = new TipoTrasladoType(Id, Nombre, Habilitado);
                }

                return ret;
            }
            catch (Exception)
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

        public static int AltaTipoTraslado(TipoTrasladoType a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaTipoTraslado";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Id);
                comando.Parameters.AddWithValue("@nombre", a.Nombre);
                comando.Parameters.AddWithValue("@Habilitado", a.Habilitado);

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
            catch (Exception)
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


        public static int BajaTipoTraslado(int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaTipoTraslado";
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
            catch (Exception)
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

        public static int ModificarTipoTraslado(TipoTrasladoType a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarTipoTraslado";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Id);
                comando.Parameters.AddWithValue("@Nombre", a.Nombre);
                comando.Parameters.AddWithValue("@Habilitado", a.Habilitado);

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
            catch (Exception)
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

        public static List<TipoTrasladoType> ListarTipoTraslado()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarTipoTraslado";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<TipoTrasladoType> cod = new List<TipoTrasladoType>();

                TipoTrasladoType ag = null;

                while (lectorDatos.Read())
                {
                    ag = new TipoTrasladoType(
                        (int)lectorDatos["Id"],
                        (string)lectorDatos["nombre"],
                        (bool)lectorDatos["Habilitado"]
                        );

                    cod.Add(ag);
                }

                return cod;
            }
            catch (Exception)
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
