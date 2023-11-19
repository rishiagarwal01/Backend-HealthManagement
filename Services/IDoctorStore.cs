using HealthManagementBackend.Models;

namespace HealthManagementBackend.Services
{
    public interface IDoctorStore
    {

        List<Doctor> Get();
        Doctor Get(string id);
        Doctor Create(Doctor doctor);
        void Update(string id, Doctor doctor);
        void Remove(string id);
    }
}

