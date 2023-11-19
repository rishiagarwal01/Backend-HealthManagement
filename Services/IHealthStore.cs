
using HealthManagementBackend.Models;

namespace HealthManagementBackend.Services
{
    public interface IHealthStore
    {
        List<Patient> Get();
        Patient Get(string id);
        Patient Create(Patient patient);
        void Update(string id,Patient patient);
        void Remove(string id);
    }
}
