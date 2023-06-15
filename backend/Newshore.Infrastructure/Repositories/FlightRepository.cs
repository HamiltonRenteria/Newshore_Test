using Newshore.Core.Entities;
using Newshore.Core.Interfaces;
using Newtonsoft.Json;

namespace Newshore.Infrastructure.Repositories
{
    public class FlightRepository : IFlight
    {
        private static HttpClient httpClient = new HttpClient();

        public async Task<IEnumerable<ResponseFlight>> GetFlights()
        {
            List<ResponseFlight> responses = new List<ResponseFlight>();
            HttpResponseMessage message = await httpClient.GetAsync("https://recruiting-api.newshore.es/api/flights/0");

            if (message.IsSuccessStatusCode)
            {
                string responseQuery = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
                responses = JsonConvert.DeserializeObject<List<ResponseFlight>>(responseQuery);
            }

            return responses;
        }
    }
}
