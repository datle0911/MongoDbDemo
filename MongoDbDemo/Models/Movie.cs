namespace MongoDbDemo.Models;

public class Movie
{
    public Movie(int id, string name, double cost)
    {
        Id = id;
        Name = name;
        Cost = cost;
    }

    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int Id { get; set; }
    public string Name { get; set; }
    public double Cost { get; set; }
}
