namespace MedicalEncounters.Domain.Entities
{
    public class PatientWithEncounterData
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? VisitedCities { get; set; }
    }
}
