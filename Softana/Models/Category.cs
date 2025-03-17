namespace Softana.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime? Cdate { get; set; }
        public string Cuser { get; set; }
        public DateTime? Udate { get; set; }
        public string Uuser { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? Ddate { get; set; }
        public string Duser { get; set; }
    }
}