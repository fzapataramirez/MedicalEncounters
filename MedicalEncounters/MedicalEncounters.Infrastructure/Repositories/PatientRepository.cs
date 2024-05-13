using System.Data;
using Dapper;
using MedicalEncounters.Application.Interfaces;
using MedicalEncounters.Domain.Entities;
using MedicalEncounters.Infrastructure.Queries;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MedicalEncounters.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly string _connectionString;

        public PatientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
        }

        public async Task<IEnumerable<MedicalEncounter>> GetAll()
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            return await db.QueryAsync<MedicalEncounter>(
               @"SELECT id, patient_id as PatientId, facility_id as FacilityId, payer_id as PayerId
                  FROM encounters e");
        }

        public async Task<IEnumerable<PatientWithEncounterData>> GetPatientsWithEncounters(int minCitiesRequired)
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            var data = await connection.QueryAsync<PatientWithEncounterData>(PatientQueries.GetPatientsWithEncounters, new { minCitiesRequired });
            return data;
        }
    }
}
