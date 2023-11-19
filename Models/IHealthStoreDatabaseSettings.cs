namespace HealthManagementBackend.Models
{
    public interface IHealthStoreDatabaseSettings
    {
        string PatientCollectionName { get; set; }
        string DoctorCollectionName{get;set;}
        string UserCollectionName { get; set; }
        string ConnectionString {  get; set; }
        string DatabaseName { get; set; }
    }
}
