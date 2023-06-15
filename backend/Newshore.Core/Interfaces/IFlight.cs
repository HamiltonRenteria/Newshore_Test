using Newshore.Core.Entities;

namespace Newshore.Core.Interfaces
{
    public interface IFlight
    {
        Task<IEnumerable<ResponseFlight>> GetFlights();
    }
}
