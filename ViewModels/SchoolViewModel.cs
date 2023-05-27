using ERPSchool.Models;

namespace ERPSchool.ViewModels
{
    public class SchoolViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? StreetName { get; set; }

        public string? Number { get; set; }

        public int? NeighborhoodFk { get; set; }
    }
}
