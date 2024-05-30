using System.ComponentModel.DataAnnotations;

namespace InjectionClinic.Entities
{
    public class userinfo
    {
        public string user_name { get; set; }
        [Key]public string user_password { get; set; }
        public DateTime user_birth { get; set; }
        public string user_disease { get; set; }
    }
}
