namespace ERPSchool.DetailViewModels
{
    public class NeighbourhoodDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int? TownFk { get; set; }

        public string TownName { get; set; } = string.Empty;

        public int? StateFk { get; set; }
    }
}
