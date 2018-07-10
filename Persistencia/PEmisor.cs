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
    public class PEmisor
    {
        private static string mensaje = "el Emisor";

        public static Emisor BuscarEmisor(int id)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarEmisor";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                Emisor ret = null;

                if (lectorDatos.Read())
                {
                    TipoDocumentoType Documento = PTipoDocumentoType.BuscarTipoDocumento(2);
                    NumeroDocumento RUCEmisor = new NumeroDocumento(Documento,(string)lectorDatos["RUCEmisor"]);
                    int Id = (int)lectorDatos["Id"];
                    string RznSoc = (string)lectorDatos["RznSoc"];
                    string CdgDGISuc = (string)lectorDatos["CdgDGISuc"];
                    string DomFiscal = (string)lectorDatos["DomFiscal"];
                    string Ciudad = Convert.ToString(lectorDatos["Ciudad"]);
                    string Departamento = Convert.ToString(lectorDatos["Departamento"]);
                    string NomComercial = Convert.ToString(lectorDatos["NomComercial"]);
                    string GiroEmis = Convert.ToString(lectorDatos["GiroEmis"]);
                    string Telefono = Convert.ToString(lectorDatos["Telefono"]);
                    string CorreoEmisor = Convert.ToString(lectorDatos["CorreoEmisor"]);
                    string EmiSucursal = Convert.ToString(lectorDatos["EmiSucursal"]);
                    ret = new Emisor(RUCEmisor, RznSoc, CdgDGISuc, DomFiscal, Ciudad, Departamento, NomComercial, GiroEmis, Telefono, CorreoEmisor, EmiSucursal);
                    ret.IdEmisor = Id;
                }

                return ret;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesPersonalizadas.
                    Persistencia("No se pudo buscar " + mensaje + ex.Message + ".");
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

        public static int AltaEmisor(Emisor a, out int id)
        {
            SqlConnection conexion = null;

            try
            {

                
                conexion = new SqlConnection(DatosConexion.CadenaConexion);
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaEmisor";
                comando.CommandType = CommandType.StoredProcedure;
                mensaje = a.RznSoc;
                comando.Parameters.AddWithValue("@RUCEmisor", a.RUCEmisor.Documento);
                comando.Parameters.AddWithValue("@RznSoc", a.RznSoc);
                comando.Parameters.AddWithValue("@CdgDGISucur", a.CdgDGISuc);
                comando.Parameters.AddWithValue("@DomFiscal", a.DomFiscal);
                comando.Parameters.AddWithValue("@Ciudad", a.Ciudad);
                comando.Parameters.AddWithValue("@Departamento", a.Departamento);
                comando.Parameters.AddWithValue("@NomComercial", a.NomComercial);
                comando.Parameters.AddWithValue("@GiroEmis", a.GiroEmis);
                comando.Parameters.AddWithValue("@Telefono", a.Telefono1);
                comando.Parameters.AddWithValue("@CorreoEmisor", a.CorreoEmisor);
                comando.Parameters.AddWithValue("@EmiSucursal", a.EmiSucursal);

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
                if ((int)valorRetorno.Value == -1)
                {
                    id = -1; 
                }
                else
                {
                    id = Convert.ToInt32(pid.Value);
                }
                return (int)valorRetorno.Value;
                
            }
            catch (Exception ex)
            {
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo dar de alta "  + mensaje + ".");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }


        public static int BajaEmisor(int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaEmisor";
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

        public static int ModificarEmisor(Emisor a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarEmisor";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.IdEmisor);
                comando.Parameters.AddWithValue("@RUCEmisor", a.RUCEmisor.Documento);
                comando.Parameters.AddWithValue("@CdgDGISuc", a.CdgDGISuc);
                comando.Parameters.AddWithValue("@RznSoc", a.RznSoc);
                comando.Parameters.AddWithValue("@DomFiscal", a.DomFiscal);
                comando.Parameters.AddWithValue("@Ciudad", a.Ciudad);
                comando.Parameters.AddWithValue("@Departamento", a.Departamento);
                comando.Parameters.AddWithValue("@NomComercial", a.NomComercial);
                comando.Parameters.AddWithValue("@GiroEmis", a.GiroEmis);
                comando.Parameters.AddWithValue("@Telefono", a.Telefono1);
                comando.Parameters.AddWithValue("@CorreoEmisor", a.CorreoEmisor);
                comando.Parameters.AddWithValue("@EmiSucursal", a.EmiSucursal);
                    
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
            catch (Exception ex)
            {
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo modificar " + mensaje + ex.Message + ".");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static List<Emisor> ListarEmisor()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarEmisores";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<Emisor> cod = new List<Emisor>();

                Emisor ag = null;

                while (lectorDatos.Read())
                {
                    TipoDocumentoType Documento = PTipoDocumentoType.BuscarTipoDocumento(2);
                    NumeroDocumento RUCEmisor = new NumeroDocumento(Documento,(string)lectorDatos["RUCEmisor"]);
                    
                    ag = new Emisor(RUCEmisor,
                        (string)lectorDatos["RznSoc"],
                        (string)lectorDatos["CdgDGISuc"],
                        (string)lectorDatos["DomFiscal"],
                        (string)lectorDatos["Ciudad"],
                        (string)lectorDatos["Departamento"],
                     Convert.ToString(lectorDatos["NomComercial"]),
                     Convert.ToString(lectorDatos["GiroEmis"]),
                     Convert.ToString(lectorDatos["Telefono"]),
                     Convert.ToString(lectorDatos["CorreoEmisor"]),
                     Convert.ToString(lectorDatos["EmiSucursal"])
                        );
                    ag.IdEmisor = (int)lectorDatos["Id"];
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
