namespace ERPSchool.ViewModels
{
    public class GroupViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int MaxStudents { get; set; }

        public int SchoolFk { get; set; }
    }
}
