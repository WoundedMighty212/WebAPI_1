using System.ComponentModel.DataAnnotations;
namespace WebAPI_1.Models
{
    public class UserLoginInfo
    {
        [Key]
        public int id { get; set; }
        public string AccountName { get; set; }
        public string EmailAddress { get; set; }
        public byte[] Password { get; set; }
    }
}
