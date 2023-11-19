using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HealthManagementBackend.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("firstname")]

        public string FirstName { get; set; } = String.Empty;

        [BsonElement("lastname")]

        public string LastName { get; set; } = String.Empty;

        [BsonElement("username")]
        public string UserName { get; set; } = String.Empty;
        [BsonElement("email")]
        public string Email { get; set; } = String.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = String.Empty;

        [BsonElement("role")]

        public string Role { get; set; } = String.Empty;
    }
}
