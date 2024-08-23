namespace WebAPI_1.Models.RegistrationData
{
    public class Provinces
    {
        public int id { get; set; }
        public string Province { get; set; }
        public int CountryFKID { get; set; }

        // Navigation property
        public ICollection<Cities> Children { get; set; }

        // Navigation property
        public Countries Countries { get; set; }
    }
}
