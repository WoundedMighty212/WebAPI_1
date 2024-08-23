namespace WebAPI_1.Models.RegistrationData
{
    public class Cities
    {
        public int id { get; set; }
        public string City { get; set; }
        public int ProvinceFKID { get; set; }
        // Navigation property
        public Provinces Provinces { get; set; }
    }
}
