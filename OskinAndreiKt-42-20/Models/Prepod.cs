using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

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
        public bool IsValidMail()
        {
            return Regex.Match(Mail, @"^((\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)\\s*[;]{0,1}\\s*)+$").Success;
        }
        public int KafedraId { get; set; }
        public int DegreeId { get; set; }
        [JsonIgnore]
        public Kafedra? Kafedra { get; set; }
        [JsonIgnore]
        public Degree? Degree { get; set; }
    }
}
