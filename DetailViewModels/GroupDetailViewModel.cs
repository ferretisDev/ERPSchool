namespace ERPSchool.DetailViewModels
{
    public class GroupDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int MaxStudents { get; set; }

        public int SchoolFk { get; set; }

        public string SchoolName { get; set; } = null!;
    }
}
