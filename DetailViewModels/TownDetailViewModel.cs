namespace ERPSchool.DetailViewModels
{
    public class TownDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? StatesFk { get; set; }

        public string StateName { get; set; } = string.Empty;
    }
}
