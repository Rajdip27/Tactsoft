using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbTest.Models;

public class Student
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Photos { get; set; }
   
}
