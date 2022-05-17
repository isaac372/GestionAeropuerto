using managementAirport.Models.Data;
using managementAirport.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace managementAirport.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrigenDestinoController : ControllerBase
    {
        private string ConnectionString = "Server=tcp:gestionaeropuerto.database.windows.net,1433;Initial Catalog=GestionAeropuerto;Persist Security Info=False;User ID=loginaero;Password=Aeropuerto123*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        [HttpGet]
        [Route("ROrigen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ROrigen(string id)
        {
            IList<Aeropuerto> retornarAer = new List<Aeropuerto>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand("RDestinos", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 1);
                cmd.Parameters.AddWithValue("Param1", id);
                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Aeropuerto Aer = new Aeropuerto();
                                Aer.Id = reader.GetInt32(reader.GetOrdinal("id"));
                                //reader.GetDateTime(reader.GetOrdinal("fecha"));
                                Aer.Nombre = reader.GetString(reader.GetOrdinal("nombre"));
                                // Aer.IdDepartamento = reader.GetInt32(reader.GetOrdinal("idDepartamento"));
                                retornarAer.Add(Aer);
                            }
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
                return Ok(retornarAer);
            }
        }


        [HttpGet]
        [Route("RDestino")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RDestino(string id)
        {
            IList<Aeropuerto> retornarAer = new List<Aeropuerto>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand("RDestinos", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 2);
                cmd.Parameters.AddWithValue("Param1", id);
                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Aeropuerto Aer = new Aeropuerto();
                                Aer.Id = reader.GetInt32(reader.GetOrdinal("id"));
                                //reader.GetDateTime(reader.GetOrdinal("fecha"));
                                Aer.Nombre = reader.GetString(reader.GetOrdinal("nombre"));
                                retornarAer.Add(Aer);
                            }
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
                return Ok(retornarAer);
            }
        }

        [HttpPost]
        [Route("SearchFlight")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchFlight(SearchData value)
        {
            IList<SearchData> retornarAer = new List<SearchData>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("RDestinos", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("NumConsulta", 3);
                    cmd.Parameters.AddWithValue("Param1", value.Origen);
                    cmd.Parameters.AddWithValue("Param2", value.Destino);
                    cmd.Parameters.AddWithValue("Param3", value.fechaDespegue);
                    cmd.Parameters.AddWithValue("Param4", value.fechaAterrizaje);
                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    SearchData Aer = new SearchData();
                                    Aer.IDvuelo = reader.GetInt32(reader.GetOrdinal("IDvuelo"));
                                    Aer.Origen = reader.GetString(reader.GetOrdinal("Origen"));
                                    Aer.Destino = reader.GetString(reader.GetOrdinal("Destino"));
                                    Aer.fechaDespegue = reader.GetDateTime(reader.GetOrdinal("fechaDespegue"));
                                    Aer.fechaAterrizaje = reader.GetDateTime(reader.GetOrdinal("fechaAterrizaje"));
                                    Aer.Aerolinea = reader.GetString(reader.GetOrdinal("Aerolinea"));
                                    Aer.cantidadAsiento = reader.GetInt32(reader.GetOrdinal("CantidadAsiento"));
                                    if (value.cantidadAsiento > Aer.cantidadAsiento)
                                    {
                                        Aer.cantidadAsiento = 0;
                                        Aer.pasajeros = new List<Pasajero> { };
                                    }
                                    else
                                    {
                                        for (int i = 0; i < value.cantidadAsiento; i++)
                                        {
                                            Pasajero pasajero = new Pasajero();
                                            Aer.pasajeros.Add(pasajero);
                                        }
                                    }
                                    retornarAer.Add(Aer);
                                }
                            }
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {

                var me = e.Message;
            }
            return Ok(retornarAer);
        }

        /////reporteria Vuelos Listado basado en una fecha y hora 

        [HttpPost]
        [Route("SearchFlightByDatetime")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchFlightByDatetime(SearchData value)
        {
            IList<SearchData> retornarAer = new List<SearchData>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("RDestinos", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("NumConsulta", 4);
                    cmd.Parameters.AddWithValue("Param1", value.fechaDespegue);
                    cmd.Parameters.AddWithValue("Param2", value.fechaAterrizaje);
                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    SearchData Aer = new SearchData();
                                    Aer.IDvuelo = reader.GetInt32(reader.GetOrdinal("IDvuelo"));
                                    Aer.Origen = reader.GetString(reader.GetOrdinal("Origen"));
                                    Aer.Destino = reader.GetString(reader.GetOrdinal("Destino"));
                                    Aer.fechaDespegue = reader.GetDateTime(reader.GetOrdinal("fechaDespegue"));
                                    Aer.fechaAterrizaje = reader.GetDateTime(reader.GetOrdinal("fechaAterrizaje"));
                                    Aer.Aerolinea = reader.GetString(reader.GetOrdinal("Aerolinea"));
                                    retornarAer.Add(Aer);
                                }
                            }
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {

                var me = e.Message;
            }
            return Ok(retornarAer);
        }

        //////
        ///Listado completo de vuelos
        ///
        [HttpGet]
        [Route("GetAllSearchFlight")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSearchFlight()
        {
            IList<SearchData> retornarAer = new List<SearchData>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("RDestinos", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("NumConsulta", 5);
                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    SearchData Aer = new SearchData();
                                    Aer.IDvuelo = reader.GetInt32(reader.GetOrdinal("IDvuelo"));
                                    Aer.Origen = reader.GetString(reader.GetOrdinal("Origen"));
                                    Aer.Destino = reader.GetString(reader.GetOrdinal("Destino"));
                                    Aer.fechaDespegue = reader.GetDateTime(reader.GetOrdinal("fechaDespegue"));
                                    Aer.fechaAterrizaje = reader.GetDateTime(reader.GetOrdinal("fechaAterrizaje"));
                                    Aer.Aerolinea = reader.GetString(reader.GetOrdinal("Aerolinea"));
                                    retornarAer.Add(Aer);
                                }
                            }
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {

                var me = e.Message;
            }
            return Ok(retornarAer);
        }


        //////
        ///Aviones por Aerolinea
        ///
        [HttpGet]
        [Route("GetAllAvionByaerolinea")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAvionByaerolinea()
        {
            IList<SearchData> retornarAer = new List<SearchData>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("RDestinos", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("NumConsulta", 6);
                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    SearchData Aer = new SearchData();
                                    Aer.IDvuelo = reader.GetInt32(reader.GetOrdinal("idAerolinea"));
                                    Aer.auxAvion = reader.GetString(reader.GetOrdinal("Avion"));
                                    Aer.auxFlotilla = reader.GetString(reader.GetOrdinal("flotilla"));
                                    Aer.auxModelo = reader.GetString(reader.GetOrdinal("Modelo"));
                                    Aer.Aerolinea = reader.GetString(reader.GetOrdinal("Aerolinea"));
                                    retornarAer.Add(Aer);
                                }
                            }
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {

                var me = e.Message;
            }
            return Ok(retornarAer);
        }


    }
}
