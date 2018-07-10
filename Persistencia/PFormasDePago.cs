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
    public class PFormasDePago
    {
        private static string mensaje = "la Forma de Pago";

        public static FormasDePagoType BuscarFormasDePago(int id)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarFormasDePago";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                FormasDePagoType ret = null;

                if (lectorDatos.Read())
                {
                    int Id = (int)lectorDatos["Id"];
                    string Nombre = Convert.ToString(lectorDatos["Nombre"]);
                    bool Habilitado = (bool)lectorDatos["Habilitado"];

                    ret = new FormasDePagoType(Id, Nombre, Habilitado);
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

        public static int AltaFormasDePago(FormasDePagoType a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaFormasDePago";
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


        public static int BajaFormasDePago(int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaFormasDePago";
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

        public static int ModificarFormasDePago(FormasDePagoType a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarFormasDePago";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Id);
                comando.Parameters.AddWithValue("@nombre", a.Nombre);

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

        public static List<FormasDePagoType> ListarFormasDePago()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarFormasDePago";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<FormasDePagoType> cod = new List<FormasDePagoType>();

                FormasDePagoType ag = null;

                while (lectorDatos.Read())
                {
                    ag = new FormasDePagoType(
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
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo conseguir las listas de " + mensaje + ".");
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
