
using ApiCiudad.DBConnection;
using ApiCiudad.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApiCiudad.Interfaces
{
    public class CrudCiudad : ICrudCiudad
    {
        public List<Ciudad> SpMetodos(Ciudad ciudad)
        {
            List<Ciudad> lista = new List<Ciudad>();
            using (ConexionSQL sql = new ConexionSQL())
            {
                try
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "SP_Ciudades";
                    sql.Comando.Parameters.AddWithValue("@codigo", ciudad.Codigo);
                    sql.Comando.Parameters.AddWithValue("@IDCiudad", ciudad.IDCiudad);
                    sql.Comando.Parameters.AddWithValue("@NombreCiudad", ciudad.NombreCiudad);
                    using (IDataReader reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                        {
                            Ciudad c = new Ciudad
                            {
                                IDCiudad = reader["IDCiudad"].ToString(),
                                NombreCiudad = reader["NombreCiudad"].ToString(),
                                FechaCreacion = reader["FechaCreacion"].ToString()
                            };
                            lista.Add(c);
                        }
                    }
                    sql.CerrarConexion();
                }
                catch (SqlException exSQL)
                {
                    sql.CerrarConexion();
                    throw exSQL;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sql.CerrarConexion();
                }
            }
            return lista;
        }
    }
}
