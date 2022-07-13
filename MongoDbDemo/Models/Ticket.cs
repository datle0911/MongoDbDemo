namespace MongoDbDemo.Models;

public class Ticket
{
    public Ticket(int id, int movieId, DateTime timestamp, ERoom thearterType)
    {
        Id = id;
        MovieId = movieId;
        Timestamp = timestamp;
        ThearterType = thearterType;
    }

    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int Id { get; set; }
    public int MovieId { get; set; }
    public DateTime Timestamp { get; set; }
    public ERoom ThearterType { get; set; }
}
