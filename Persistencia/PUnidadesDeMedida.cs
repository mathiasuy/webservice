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
    public class PUnidadesDeMedida
    {
        private static string mensaje = "unidad de medida";

        public static UnidadesDeMedida BuscarUnidadDeMedida(int id)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarUnidadDeMedida";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                UnidadesDeMedida ret = null;

                if (lectorDatos.Read())
                {
                    int Id = (int)lectorDatos["Id"];
                    string Nombre = Convert.ToString(lectorDatos["Nombre"]);
                    bool Habilitado = (bool)lectorDatos["Habilitado"];
                    ret = new UnidadesDeMedida(Id, Nombre, Habilitado);
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

        public static int AltaUnidadDeMedida(UnidadesDeMedida a, out int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaUnidadDeMedida";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@nombre", a.Nombre);
                comando.Parameters.AddWithValue("@Habilitado", a.Habilitado);


                SqlParameter pid = new SqlParameter("@Id", SqlDbType.Int);
                pid.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pid);


                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add(valorRetorno);

                conexion.Open();

                comando.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -2)
                {
                    throw new Exception();
                }
                id = Convert.ToInt32(pid.Value);
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


        public static int BajaUnidadDeMedida(int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaUnidadDeMedida";
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

        public static int ModificarUnidadDeMedida(UnidadesDeMedida a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarUnidadDeMedida";
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

        public static List<UnidadesDeMedida> ListarUnidadesDeMedida()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarUnidadDeMedida";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<UnidadesDeMedida> cod = new List<UnidadesDeMedida>();

                UnidadesDeMedida ag = null;

                while (lectorDatos.Read())
                {
                    ag = new UnidadesDeMedida(
                        (int)lectorDatos["Id"],
                        (string)lectorDatos["nombre"],
                        (bool)lectorDatos["Habilitado"]
                        );

                    cod.Add(ag);
                }

                return cod;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo conseguir la listas de " + mensaje + ex.Message + ".");
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
