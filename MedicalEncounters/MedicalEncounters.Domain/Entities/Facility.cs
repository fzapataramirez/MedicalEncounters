namespace MedicalEncounters.Domain.Entities
{
    public class Facility : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
