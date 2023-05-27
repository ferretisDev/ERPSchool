namespace ERPSchool.DetailViewModels
{
    public class SchoolDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? StreetName { get; set; }

        public string? Number { get; set; }

        public int? NeighborhoodFk { get; set; }

        public string? NeighborhoodName { get; set; }

        public int? StatesFk { get; set; }

        public int? TownFk { get; set; }
    }
}
