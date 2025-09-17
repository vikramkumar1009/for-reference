using Dlplone.LMS.Entities.Master;

namespace Dlplone.LMS.Domain
{
    public interface IFindCenterService
    {
        Task<IEnumerable<State>> GetStates();
        Task<IEnumerable<City>> GetCities(string stateUrl);
        Task<IEnumerable<Area>> GetAreas(string stateUrl, string cityUrl);
        Task<IEnumerable<LabLocation>> GetLabs(string labType);
        Task<LabLocation> GetAreaDeatilsById(int locaId);

    }
}
