using System.Text.RegularExpressions;

namespace Softana.Models
{
    public class SalerDetail
    {
        public SalerDetail()
        {
            Salers = new HashSet<Saler>();
        }
        public int SalerDetailId { get; set; }
        public int MemberShipType { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TCKN { get; set; }
        public DateTime? DateOfBirthDay { get; set; }
        public string Adress { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public string IBAN { get; set; }

        public virtual Country Country { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<Saler> Salers { get; set; }
    }
}