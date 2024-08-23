namespace WebAPI_1.Models.RegistrationData
{
    public class Countries
    {
        public int id {  get; set; }
        public string Country { get; set; }

        // Navigation property
        public ICollection<Provinces> Children { get; set; }
    }
}
