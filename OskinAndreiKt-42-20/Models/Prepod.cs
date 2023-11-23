namespace OskinAndreiKt_42_20.Models
{
    public class Prepod
    {
        public int PrepodId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Telephone { get; set; }
        public string? Mail { get; set; }
        public int KafedraId { get; set; }
        public int DegreeId { get; set; }
        public Kafedra? Kafedra { get; set; }
        public Degree? Degree { get; set; }
    }
}
