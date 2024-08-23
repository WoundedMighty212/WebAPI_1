namespace WebAPI_1.Models
{
    using System.ComponentModel.DataAnnotations;
    public class UserData
    {
        [Key]
        public int id { get; set; }
        public string FirstName { get; set; }
        public string MiddelName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public string AccountName { get; set; }
        public int FKID { get; set; }

        // Navigation property
        public UserLoginInfo userLoginInfo { get; set; }
    }
}
