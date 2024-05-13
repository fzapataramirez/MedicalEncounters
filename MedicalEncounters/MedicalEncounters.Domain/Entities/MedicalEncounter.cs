namespace MedicalEncounters.Domain.Entities
{
    public class MedicalEncounter : BaseEntity
    {
        public int PatientId { get; set; }
        public int FacilityId { get; set; }
        public int PayerId { get; set; }
    }
}
