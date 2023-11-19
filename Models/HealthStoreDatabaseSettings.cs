
namespace HealthManagementBackend.Models
{
    public class HealthStoreDatabaseSettings:IHealthStoreDatabaseSettings
    {
        public string PatientCollectionName { get; set; } = String.Empty;
        public string DoctorCollectionName {  get; set; } = String.Empty;
        public string UserCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; }=String.Empty;
    }
}
