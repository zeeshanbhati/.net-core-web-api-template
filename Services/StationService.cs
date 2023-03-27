using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using EFTemplate.Data;
using EFTemplate.Models;
using EFTemplate.Request;
using EFTemplate.Repository;
using EFTemplate.CustomExceptions;
using System.Net;

namespace EFTemplate.Services
{
    public class StationService
    {
        private readonly StationRepository stationRepository;

        public StationService(StationRepository stationRepository)
        {
            this.stationRepository = stationRepository;
        }

        public async Task<Guid> CreateStation(CreateStationRequest request)
        {
            try
            {
                var station = new Station(request.Name, request.ImageURL, request.Pricing, request.Address);
                return await stationRepository.CreateStation(station);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError, "Error while creating new station");
            }



        }

        public async Task<List<Station>> ListStations(int limit, int offset)
        {
            try
            {
                return await stationRepository.ListStations(limit, offset);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError, "Error while fetching station list");
            }
        }


    }
}
