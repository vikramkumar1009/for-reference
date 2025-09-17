using Microsoft.Extensions.Logging;
using Dlplone.LMS.Domain.Infrastructure.Enums;
using Dlplone.LMS.Entities.Master;

namespace Dlplone.LMS.Domain.Implementation
{
    public class FindCenterService : IFindCenterService
    {
        private readonly ILPLRepository repository;
        private readonly ILogger<FindCenterService> logger;

        public FindCenterService(ILPLRepository lPLRepository, ILogger<FindCenterService> _logger)
        {
            repository = lPLRepository;
            logger = _logger;
        }


        public async Task<IEnumerable<State>> GetStates()
        {
            try
            {
                var states = await repository.ExecuteRawSqlAsync<State, int?>(nameof(PROCS.UDSP_LPL_SELECT_STATE_CITY_AREA), null, false);
                return states;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<City>> GetCities(string stateUrl)
        {
            try
            {
                var data = await repository.ExecuteRawSqlAsync<State, City, int, object>(nameof(PROCS.UDSP_LPL_SELECT_STATE_CITY_AREA), new { State = stateUrl }, false);
                var cities = (IEnumerable<City>)data[1];
                return cities;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Area>> GetAreas(string stateUrl, string cityUrl)
        {
            try
            {
                var data = await repository.ExecuteRawSqlAsync<State, City, Area, object>(nameof(PROCS.UDSP_LPL_SELECT_STATE_CITY_AREA), new { State = stateUrl, City = cityUrl }, false);
                var areas = (IEnumerable<Area>)data[2];
                return areas;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<LabLocation>> GetLabs(string labType)
        {
            try
            {
                var data = await repository.ExecuteRawSqlAsync<LabLocation, object>(nameof(PROCS.GetLabLocation), new { Type = labType }, false);
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<LabLocation> GetAreaDeatilsById(int locaId)
        {
            try
            {
                var data = await repository.ExecuteRawSqlAsync<LabLocation, object>(nameof(PROCS.UDSP_LPL_SELECT_AREA_DEATILS_BY_ID), new { locId = locaId }, false);
                return data.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
