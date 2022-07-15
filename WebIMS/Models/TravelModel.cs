namespace WebIMS.Models
{
    public class TravelModel : BaseModel
    {
        public string PassportNumber { get; set; }
        public string TravellerName { get; set; }
        public string TravellerSurname { get; set; }
        public string TravellerDateOfBirth { get; set; }
    }
}
