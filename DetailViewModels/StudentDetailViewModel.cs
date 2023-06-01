namespace ERPSchool.DetailViewModels
{
    public class StudentDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public int SexFk { get; set; }

        public string SexName { get; set; } = null!;

        public int GroupFk { get; set; }

        public string GroupName { get; set; } = null!;
    }
}
