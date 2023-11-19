using HealthManagementBackend.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthManagementBackend.Services
{
    public class DoctorStore : IDoctorStore
    {
        private readonly IMongoCollection<Doctor> _doctor;

        public DoctorStore(IHealthStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _doctor = database.GetCollection<Doctor>(settings.DoctorCollectionName);
        }
        public Doctor Create(Doctor doctor)
        {
            _doctor.InsertOne(doctor);
            return doctor;
        }

        public List<Doctor> Get()
        {
            return _doctor.Find(doctor => true).ToList();
        }


        public Doctor Get(string id)
        {

            ObjectId objectId;
            if (string.IsNullOrEmpty(id) || !ObjectId.TryParse(id, out objectId))
            {
                return null;
            }
            else
            {
                return _doctor.Find<Doctor>(doc => doc.DoctorId == id).FirstOrDefault();
            }

        }

        public void Remove(string id)
        {
            _doctor.DeleteOne(doctor => doctor.DoctorId == id);
        }

        public void Update(string id, Doctor doctor)
        {
            _doctor.ReplaceOne(doctor => doctor.DoctorId == id, doctor);
        }
    }
}
