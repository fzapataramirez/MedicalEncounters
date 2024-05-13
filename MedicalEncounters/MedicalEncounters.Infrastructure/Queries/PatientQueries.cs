namespace MedicalEncounters.Infrastructure.Queries
{
    internal static class PatientQueries
    {
        public static string GetPatientsWithEncounters => @"
             SELECT p.id, 
                    p.first_name As FirstName,
                    p.last_name as LastName,
                    string_agg(DISTINCT f.city, ', ') AS VisitedCities,
                    p.age
                 FROM patients p
                 INNER JOIN encounters e ON p.id = e.patient_id
                 INNER JOIN facilities f ON e.facility_id = f.id
                 INNER JOIN payers py ON e.payer_id = py.id
             GROUP BY p.id, p.first_name, p.last_name, p.age
                HAVING COUNT(DISTINCT py.city) >= @MinCitiesRequired 
             ORDER BY COUNT(*) ASC;
            ";
    }
}
