namespace EFTemplate.Models
{
    public class Station
    {
        public Station()
        {
        }

        public Station(string name, string image, decimal pricing, string address)
        {
            StationId = Guid.NewGuid();
            Name = name;
            Image = image;
            Pricing = pricing;
            Address = address;
        }

        public Guid StationId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Pricing { get; set; }
        public string Address { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
