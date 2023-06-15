using Newshore.Core.Entities;
using Newshore.Core.Interfaces;
using Newtonsoft.Json;

namespace Newshore.Infrastructure.Repositories
{
    public class JourneyRepository : IJourney
    {
        private static readonly HttpClient httpClient = new();


        public async Task<IEnumerable<ResponseJourney>> GetJourneys(string origin, string destination)
        {
            List<ResponseFlight>? responsesFlights = new();
            List<ResponseJourney> responseJourney = new();
            List<Flight> listFlights = new();

            HttpResponseMessage message = await httpClient.GetAsync("https://recruiting-api.newshore.es/api/flights/0");

            if (message.IsSuccessStatusCode)
            {
                string responseQuery = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
                responsesFlights = JsonConvert.DeserializeObject<List<ResponseFlight>>(responseQuery);
            }

            List<ResponseFlight> dataTransports = GetDataTransports(responsesFlights);
            List<Flight> dataFlights = GetDataFlights(dataTransports, responsesFlights);
            List<Flight> dataJourneys = GetDataJourneys(origin, dataTransports, responsesFlights);

            foreach (Flight item in dataJourneys)
            {
                IEnumerable<Flight> secJouney = dataFlights.Where(s => s.Origin!.Equals(item.Destination)).Select(x => new Flight
                {
                    Origin = x.Origin,
                    Destination = x.Destination,
                    Price = x.Price,
                    Transport = x.Transport
                });

                if (secJouney != null)
                {
                    foreach (Flight? secondJourney in secJouney)
                    {
                        listFlights.Add(new Flight { Origin = item.Origin, Destination = item.Destination, Price = item.Price, Transport = item.Transport });
                        if (secondJourney.Destination == destination)
                        {
                            responseJourney.Add(new ResponseJourney
                            {
                                Journey = new Journey()
                                {
                                    Origin = origin,
                                    Destination = destination,
                                    Price = item.Price + secondJourney.Price,
                                    Flights = listFlights
                                },
                            });

                            listFlights.Add(new Flight { Origin = secondJourney.Origin, Destination = secondJourney.Destination, Price = secondJourney.Price, Transport = secondJourney.Transport });
                            break;
                        }
                    }
                }
                break;
            }

            return responseJourney;
        }

        private static List<Flight> GetDataFlights(List<ResponseFlight> transports, List<ResponseFlight>? responses)
        {
            return responses!.Join(transports, flight => flight.FlightNumber, transport => transport.FlightNumber, (flights, transports) => new Flight
            {
                Origin = flights.DepartureStation,
                Destination = flights.ArrivalStation,
                Price = flights.Price,
                Transport = new Transport()
                {
                    FlightCarrier = transports.FlightCarrier!,
                    FlightNumber = transports.FlightNumber!
                }
            }).ToList();
        }

        private static List<Flight> GetDataJourneys(string origin, List<ResponseFlight> dataTransports, List<ResponseFlight>? responsesFlights)
        {
            return responsesFlights!.Join(dataTransports, flight => flight.FlightNumber, transport => transport.FlightNumber, (flights, transports) => new Flight
            {
                Origin = flights.DepartureStation,
                Destination = flights.ArrivalStation,
                Price = flights.Price,
                Transport = new Transport()
                {
                    FlightCarrier = transports.FlightCarrier!,
                    FlightNumber = transports.FlightNumber!
                }
            }).Where(f => f.Origin == origin).ToList();
        }

        private static List<ResponseFlight> GetDataTransports(List<ResponseFlight>? responses)
        {
            return responses!.ToList();
        }
    }
}
