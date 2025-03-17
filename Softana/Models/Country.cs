namespace Softana.Models
{
    public class Country
    {
        public Country()
        {
            SalerDetails = new HashSet<SalerDetail>();
            Cities = new HashSet<City>();
        }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Code2 { get; set; }

        public virtual ICollection<SalerDetail> SalerDetails { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}