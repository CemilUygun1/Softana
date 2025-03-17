namespace Softana.Models
{
    public class City
    {
        public City()
        {
            SalerDetails = new HashSet<SalerDetail>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<SalerDetail> SalerDetails { get; set; }
    }
}