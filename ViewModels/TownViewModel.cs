namespace ERPSchool.ViewModels
{
    public class TownViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? StatesFk { get; set; }

        //public string StateName { get; set; } = string.Empty;
    }
}
