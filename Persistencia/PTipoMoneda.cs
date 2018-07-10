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
    public class PTipoMoneda
    {
        private static string mensaje =  "el Tipo de moneda";

        public static TipoMoneda BuscarTipoMoneda(string id)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;
            
            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarTipoMoneda";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                TipoMoneda ret = null;

                if (lectorDatos.Read())
                {
                    string Id = Convert.ToString(lectorDatos["Id"]);
                    string Nombre = Convert.ToString(lectorDatos["Nombre"]);
                    double Cambio = Convert.ToDouble(lectorDatos["Cambio"]);
                    string Simbolo = Convert.ToString(lectorDatos["Simbolo"]);
                    bool Nacional = Convert.ToBoolean(lectorDatos["Nacional"]);
                    bool Habilitado = Convert.ToBoolean(lectorDatos["habilitado"]);
                    ret = new TipoMoneda(Id, Nombre, Cambio, Simbolo, Nacional, Habilitado);
                }

                return ret;
            }
            catch (Exception )
            {
                throw new ExcepcionesPersonalizadas.
                    Persistencia("No se pudo buscar "+ mensaje +".");
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

        public static int AltaTipoMoneda(TipoMoneda a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaTipoMoneda";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Id);
                comando.Parameters.AddWithValue("@nombre", a.Nombre);
                comando.Parameters.AddWithValue("@cambio", a.Cambio);
                comando.Parameters.AddWithValue("@simbolo", a.Simbolo);
                comando.Parameters.AddWithValue("@nacional", a.Nacional);
                comando.Parameters.AddWithValue("@habilitado", a.Habilitado);

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
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo dar de alta "+ mensaje + ".");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }


        public static int BajaTipoMoneda(string id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaTipoMoneda";
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
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo dar de baja "+ mensaje +".");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static int ModificarTipoMoneda(TipoMoneda a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarTipoMoneda";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Id);
                comando.Parameters.AddWithValue("@nombre", a.Nombre);
                comando.Parameters.AddWithValue("@cambio", a.Cambio);
                comando.Parameters.AddWithValue("@simbolo", a.Simbolo);
                comando.Parameters.AddWithValue("@nacional", a.Nacional);
                comando.Parameters.AddWithValue("@habilitado", a.Habilitado);

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
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo modificar "+mensaje+".");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static List<TipoMoneda> ListarTipoMoneda()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarTipoMoneda";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<TipoMoneda> cod = new List<TipoMoneda>();

                TipoMoneda ag = null;

                while (lectorDatos.Read())
                {
                    ag = new TipoMoneda(
                        (string)lectorDatos["Id"],
                        (string)lectorDatos["nombre"],
                        (double)lectorDatos["Cambio"],
                        (string)lectorDatos["Simbolo"],
                        (bool)lectorDatos["Nacional"],
                        (bool)lectorDatos["Habilitado"]
                        );

                    cod.Add(ag);
                }

                return cod;
            }
            catch (Exception )
            {
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo conseguir las listas de "+mensaje+".");
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
