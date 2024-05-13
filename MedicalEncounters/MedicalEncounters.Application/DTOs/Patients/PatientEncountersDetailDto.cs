namespace MedicalEncounters.Application.DTOs.Patients
{
    public class PatientEncountersDetailDto
    {
        public string FullName { get; set; } = string.Empty;
        public string? VisitedCities { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
