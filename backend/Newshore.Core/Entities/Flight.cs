namespace Newshore.Core.Entities
{
    public class Flight
    {
        public string? Origin { get; set; }

        public string? Destination { get; set; }

        public decimal Price { get; set; }

        public Transport? Transport { get; set; }
    }
}
