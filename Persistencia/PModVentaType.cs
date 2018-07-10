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
    public class PModVentaType
    {
        public static ModVentaType BuscarModVentaType(int id)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarModVentaType";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                ModVentaType ret = null;

                if (lectorDatos.Read())
                {
                    int Codigo = Convert.ToInt16(lectorDatos["Id"]);
                    string Tasa = Convert.ToString(lectorDatos["Nombre"]);
                    bool habilitado = Convert.ToBoolean(lectorDatos["habilitado"]);
                    ret = new ModVentaType(Codigo, Tasa, habilitado);
                }

                return ret;
            }
            catch (Exception )
            {
                throw new ExcepcionesPersonalizadas.
                    Persistencia("No se pudo buscar la Modalidad de venta.");
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

        public static int AltaModVentaType(ModVentaType a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaModVentaType";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Id);
                comando.Parameters.AddWithValue("@nombre", a.Nombre);
                comando.Parameters.AddWithValue("@habilitado", a.Habilitado);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add(valorRetorno);

                conexion.Open();

                comando.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -1)
                {
                    throw new Exception();
                }

                return (int)valorRetorno.Value;
            }
            catch (Exception )
            {
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo dar de alta la Modalidad de venta.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }


        public static int BajaModVentaType(int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaModVentaType";
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
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo dar de baja la Modalidad de venta.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static int ModificarModVentaType(ModVentaType a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarModVentaType";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Id);
                comando.Parameters.AddWithValue("@nombre", a.Nombre);
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
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo modificar la Modalidad de venta.");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static List<ModVentaType> ListarModVentaType()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarModVentaType";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<ModVentaType> cod = new List<ModVentaType>();

                ModVentaType ag = null;

                while (lectorDatos.Read())
                {
                    ag = new ModVentaType(
                        (int)lectorDatos["Id"],
                        (string)lectorDatos["nombre"],
                        (bool)lectorDatos["habilitado"]
                        );

                    cod.Add(ag);
                }

                return cod;
            }
            catch (Exception )
            {
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo listar las Modalidades de venta.");
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
