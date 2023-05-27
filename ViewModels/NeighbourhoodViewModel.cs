namespace ERPSchool.ViewModels
{
    public class NeighbourhoodViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int? TownFk { get; set; }
    }
}
