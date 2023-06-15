namespace Newshore.Core.Entities
{
    public class ResponseFlight
    {
        public string? DepartureStation { get; set; }
        public string? ArrivalStation { get; set; }
        public string? FlightCarrier { get; set; }
        public string? FlightNumber { get; set; }
        public int Price { get; set; }
    }
}
