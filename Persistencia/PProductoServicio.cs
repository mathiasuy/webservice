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
    public class PProductoServicio
    {
        private static string mensaje = "el Producto o Servicio";

        public static ProductoServicio BuscarProductoServicio(string id)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarProductoServicio";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                ProductoServicio ret = null;
                TipoMoneda Moneda = null;
                if (lectorDatos.Read())
                {
                    string Codigo = (string)lectorDatos["Id"];
                    string Nombre = Convert.ToString(lectorDatos["Nombre"]);
                    decimal Precio = (decimal )lectorDatos["Precio"];
                    Moneda = PTipoMoneda.BuscarTipoMoneda((string)lectorDatos["IdMoneda"]);
                    string Comentario = (string)lectorDatos["Comentario"];
                    int Stock = (int)lectorDatos["Stock"];
                    UnidadesDeMedida UniMed = PUnidadesDeMedida.BuscarUnidadDeMedida((int)lectorDatos["UnidadDeMedida"]);
                    ret = new ProductoServicio(Codigo, Nombre, Precio, Moneda,Comentario, Stock, UniMed);
                }

                return ret;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesPersonalizadas.
                    Persistencia("No se pudo buscar " + mensaje + "." + ex.Message);
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

        public static int AltaProductoServicio(ProductoServicio a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaProductoServicio";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Codigo);
                comando.Parameters.AddWithValue("@nombre", a.Nombre);
                comando.Parameters.AddWithValue("@cambio", a.Precio);
                comando.Parameters.AddWithValue("@simbolo", a.Moneda.Id);
                comando.Parameters.AddWithValue("@nacional", a.Comentario);
                comando.Parameters.AddWithValue("@habilitado", a.Stock);
                comando.Parameters.AddWithValue("@UnidadDeMedida", a.UniMed.Id);

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


        public static int BajaProductoServicio(string Codigo)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaProductoServicio";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", Codigo);

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

        public static int ModificarProductoServicio(ProductoServicio a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarProductoServicio";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Codigo);
                comando.Parameters.AddWithValue("@nombre", a.Nombre);
                comando.Parameters.AddWithValue("@cambio", a.Precio);
                comando.Parameters.AddWithValue("@simbolo", a.Moneda.Id);
                comando.Parameters.AddWithValue("@nacional", a.Comentario);
                comando.Parameters.AddWithValue("@habilitado", a.Stock);
                comando.Parameters.AddWithValue("@UnidadDeMedida", a.UniMed.Id);

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

        public static List<ProductoServicio> ListarProductoServicio()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarProductoServicio";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<ProductoServicio> cod = new List<ProductoServicio>();

                ProductoServicio ag = null;

                while (lectorDatos.Read())
                {

                    string Id = (string)lectorDatos["Id"];
                        string Nombre = (string)lectorDatos["Nombre"];
                        decimal Precio = (decimal)lectorDatos["Precio"];
                        TipoMoneda Moneda = Persistencia.PTipoMoneda.BuscarTipoMoneda((string)lectorDatos["IdMoneda"]);
                        string Comentario = (string)lectorDatos["Comentario"];
                        int Stock = (int)lectorDatos["Stock"];
                        UnidadesDeMedida UniMed = PUnidadesDeMedida.BuscarUnidadDeMedida((int)lectorDatos["UnidadDeMedida"]);
                        
                    ag = new ProductoServicio(Id,Nombre,Precio,Moneda,Comentario,Stock,UniMed);
                    cod.Add(ag);
                }

                return cod;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo conseguir las listas de " + mensaje + ex.Message + ".");
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
