using System.Data;
using Dapper;
using MedicalEncounters.Application.Interfaces;
using MedicalEncounters.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MedicalEncounters.Infrastructure.Repositories
{
    public class MedicalEncounterRepository : IMedicalEncounterRepository
    {
        private readonly string _connectionString;

        public MedicalEncounterRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
        }

        public async Task<IEnumerable<MedicalEncounter>> GetAll()
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            //return await db.QueryAsync<MedicalEncounter>(
            //    @"SELECT e.id, p.first_name || ' ' || p.last_name as PatientName, 
            //              f.name as FacilityName, py.name as PayerName 
            //      FROM encounters e
            //      JOIN patients p ON e.patient_id = p.id
            //      JOIN facilities f ON e.facility_id = f.id
            //      JOIN payers py ON e.payer_id = py.id");

            return await db.QueryAsync<MedicalEncounter>(
               @"SELECT id, patient_id as PatientId, facility_id as FacilityId, payer_id as PayerId
                  FROM encounters e");
        }
    }
}
