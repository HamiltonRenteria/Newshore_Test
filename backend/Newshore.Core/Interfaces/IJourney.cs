using Newshore.Core.Entities;

namespace Newshore.Core.Interfaces
{
    public interface IJourney
    {
        Task<IEnumerable<ResponseJourney>> GetJourneys(string origin, string destination);
    }
}
