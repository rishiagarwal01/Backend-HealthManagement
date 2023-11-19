using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HealthManagementBackend.Models
{
    public class Doctor
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DoctorId { get; set; } = String.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("gender")]
        public string Gender { get; set; } = String.Empty;
        [BsonElement("dob")]
        public DateTime DOB { get; set; } = DateTime.Now;
        [BsonElement("number")]
        public int Number { get; set; } 
        [BsonElement("email")]
        public string Email { get; set; } = String.Empty;
        [BsonElement("department")]
        public string Department {  get; set; } = String.Empty;
    }
}
