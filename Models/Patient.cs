using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace HealthManagementBackend.Models
{
    [BsonIgnoreExtraElements]
    public class Patient
    {   
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PatientId { get; set; }=String.Empty;


        [BsonElement("name")]
        public string Name { get; set;}=String.Empty;


        [BsonElement("gender")]
        public string Gender {  get; set; }=String.Empty;
        [BsonElement("dob")]
        public DateTime DOB {  get; set; }=DateTime.Now;
        [BsonElement("number")]
        public int Number {  get; set; }
        [BsonElement("email")]
        public string Email {  get; set; }=String.Empty;


    }
}
