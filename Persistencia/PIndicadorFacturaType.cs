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
    public class PIndicadorFacturaType
    {
        private static string mensaje = "el indicador de facturación";

        public static IndicadorFacturaType BuscarIndicadorFacturaType(int id)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarIndicadorFacturaType";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                IndicadorFacturaType ret = null;

                if (lectorDatos.Read())
                {
                    int Id = (int)lectorDatos["Id"];
                    string Nombre = Convert.ToString(lectorDatos["Nombre"]);
                    bool Habilitado = (bool)lectorDatos["Habilitado"];
                    ret = new IndicadorFacturaType(Id, Nombre, Habilitado);
                }

                return ret;
            }
            catch (Exception )
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

        public static int AltaIndicadorFacturaType(IndicadorFacturaType a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaIndicadorFacturaType";
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


        public static int BajaIndicadorFacturaType(int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaIndicadorFacturaType";
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

        public static int ModificarIndicadorFacturaType(IndicadorFacturaType a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarIndicadorFacturaType";
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

        public static List<IndicadorFacturaType> ListarIndicadorFacturaType()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarIndicadorFacturaType";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<IndicadorFacturaType> cod = new List<IndicadorFacturaType>();

                IndicadorFacturaType ag = null;

                while (lectorDatos.Read())
                {
                    ag = new IndicadorFacturaType(
                        (int)lectorDatos["Id"],
                        (string)lectorDatos["nombre"],
                        (bool)lectorDatos["Habilitado"]
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
