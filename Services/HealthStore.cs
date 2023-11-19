using HealthManagementBackend.Models;
using MongoDB.Driver;
namespace HealthManagementBackend.Services
{
    public class HealthStore : IHealthStore
    {
        private readonly IMongoCollection<Patient> _patients;

        public HealthStore(IHealthStoreDatabaseSettings settings,IMongoClient mongoClient)
        {
           var database= mongoClient.GetDatabase(settings.DatabaseName);
           _patients= database.GetCollection<Patient>(settings.PatientCollectionName);
        }
        public Patient Create(Patient patient)
        {
            _patients.InsertOne(patient);
            return patient;
        }

        public List<Patient> Get()
        {
            return _patients.Find(patient=>true).ToList();
        }

        public Patient Get(string id)
        {
            return _patients.Find(patient => patient.PatientId == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
             _patients.DeleteOne(patient => patient.PatientId == id);
        }

        public void Update(string id, Patient patient)
        {
            _patients.ReplaceOne(patient => patient.PatientId == id,patient);
        }
    }
}
