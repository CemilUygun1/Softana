using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Softana.Models
{
    public class Saler
    {
        public int SalerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime? Cdate { get; set; }
        public string Cuser { get; set; }
        public DateTime? Udate { get; set; }
        public string Uuser { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? Ddate { get; set; }
        public string Duser { get; set; }
        public bool? IsActive { get; set; }

        public virtual SalerDetail SalerDetails { get; set; }
    }
}