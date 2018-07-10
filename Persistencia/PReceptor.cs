using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Receptores;

namespace Persistencia
{
    public class PReceptor
    {
        private static string mensaje = "el Receptor";

        public static Receptor BuscarReceptor(int Id)
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BuscarReceptor";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", Id);

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                Receptor ret = null;

                if (lectorDatos.Read())
                {
                    TipoDocumentoType Documento = PTipoDocumentoType.BuscarTipoDocumento((int)lectorDatos["TipoDocRecep"]);
                    NumeroDocumento NumeroDeDocumento = new NumeroDocumento(Documento,(string)lectorDatos["DocRecep"]);
                    PaisType Pais = PPaisType.BuscarPaisType((string)lectorDatos["CodPaisRecep"]);
                    string RznSocRecep = (string)lectorDatos["RznSocRecep"];
                    string DirRecep = Convert.ToString(lectorDatos["DirRecep"]);
                    string CiudadRecep = Convert.ToString(lectorDatos["CiudadRecep"]);
                    string DeptoRecep = Convert.ToString(lectorDatos["DeptoRecep"]);
                    string CP = Convert.ToString(lectorDatos["CP"]);
                    string InfoAdicional = Convert.ToString(lectorDatos["InfoAdicional"]);
                    string LugarDestEnt = Convert.ToString(lectorDatos["LugarDestEnt"]);
                    string CompraID = Convert.ToString(lectorDatos["CompraID"]);
                    ret = new Receptor(NumeroDeDocumento, Pais, RznSocRecep, DirRecep,
                    CiudadRecep, DeptoRecep, CP, InfoAdicional, LugarDestEnt, CompraID);
                    ret.Id = Id;
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

        public static int AltaReceptor(Receptor a, out int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "AltaReceptor";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@TipoDocRecep", a.DocRecep.Id);
                comando.Parameters.AddWithValue("@CodPaisRecep", a.PaisRecep.Id);
                comando.Parameters.AddWithValue("@DocRecep", a.DocRecep.Documento);
                comando.Parameters.AddWithValue("@RznSocRecep", a.RznSocRecep);
                comando.Parameters.AddWithValue("@DirRecep", a.DirRecep);
                comando.Parameters.AddWithValue("@CiudadRecep", a.CiudadRecep);
                comando.Parameters.AddWithValue("@DeptoRecep", a.DeptoRecep);
                comando.Parameters.AddWithValue("@CP", a.CP);
                comando.Parameters.AddWithValue("@InfoAdicional", a.InfoAdicional);
                comando.Parameters.AddWithValue("@LugarDestEnt", a.LugarDestEnt);
                comando.Parameters.AddWithValue("@CompraID", a.CompraID);

                SqlParameter pid = new SqlParameter("@id", SqlDbType.Int);
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
                if (pid.Value is  DBNull)
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
                throw new ExcepcionesPersonalizadas.Persistencia("No se pudo dar de alta " + mensaje +ex.Message+  ".");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }


        public static int BajaReceptor(int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "BajaReceptor";
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

        public static int ModificarReceptor(Receptor a)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarReceptor";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", a.Id);
                comando.Parameters.AddWithValue("@TipoDocRecep", a.DocRecep.Id);
                comando.Parameters.AddWithValue("@CodPaisRecep", a.PaisRecep.Id);
                comando.Parameters.AddWithValue("@DocRecep", a.DocRecep.Documento);
                comando.Parameters.AddWithValue("@RznSocRecep", a.RznSocRecep);
                comando.Parameters.AddWithValue("@DirRecep", a.DirRecep);
                comando.Parameters.AddWithValue("@CiudadRecep", a.CiudadRecep);
                comando.Parameters.AddWithValue("@DeptoRecep", a.DeptoRecep);
                comando.Parameters.AddWithValue("@CP", a.CP);
                comando.Parameters.AddWithValue("@InfoAdicional", a.InfoAdicional);
                comando.Parameters.AddWithValue("@LugarDestEnt", a.LugarDestEnt);
                comando.Parameters.AddWithValue("@CompraID", a.CompraID);

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

        public static List<Receptor> ListarReceptores()
        {
            SqlConnection conexion = null;
            SqlDataReader lectorDatos = null;

            try
            {
                conexion = new SqlConnection(DatosConexion.CadenaConexion);

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ListarReceptores";
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                lectorDatos = comando.ExecuteReader();

                List<Receptor> cod = new List<Receptor>();

                Receptor ag = null;

                while (lectorDatos.Read())
                {
                    TipoDocumentoType Documento = PTipoDocumentoType.BuscarTipoDocumento((int)lectorDatos["TipoDocRecep"]);
                    NumeroDocumento NumeroDeDocumento = new NumeroDocumento(Documento,(string)lectorDatos["DocRecep"]);
                    PaisType Pais = PPaisType.BuscarPaisType((string)lectorDatos["CodPaisRecep"]);
                    string RznSocRecep = (string)lectorDatos["RznSocRecep"];
                    string DirRecep = (string)lectorDatos["DirRecep"];
                    string CiudadRecep = (string)lectorDatos["CiudadRecep"];
                    string DeptoRecep = (string)lectorDatos["DeptoRecep"];
                    string CP = (string)lectorDatos["CP"];
                    string InfoAdicional = (string)lectorDatos["InfoAdicional"];
                    string LugarDestEnt = (string)lectorDatos["LugarDestEnt"];
                    string CompraID = (string)lectorDatos["CompraID"];
                    ag = new Receptor(NumeroDeDocumento, Pais, RznSocRecep, DirRecep,
                    CiudadRecep, DeptoRecep, CP, InfoAdicional, LugarDestEnt, CompraID);
                    ag.Id = (int)lectorDatos["Id"];
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
