namespace MedicalEncounters.Domain.Entities
{
    public class Payer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
