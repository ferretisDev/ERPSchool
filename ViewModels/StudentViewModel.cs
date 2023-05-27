namespace ERPSchool.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public int SexFk { get; set; }

        public int GroupFk { get; set; }
    }
}
