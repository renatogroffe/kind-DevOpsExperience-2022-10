using MongoDB.Bson;
using MongoDB.Driver;

namespace APISuporte.Data;

public class ChamadosRepository
{
    private readonly IMongoCollection<ChamadoDocument> _chamadosCollection;

    public ChamadosRepository(IConfiguration configuration)
    {
        _chamadosCollection = new MongoClient(configuration.GetConnectionString("MongoDB"))
            .GetDatabase(configuration["MongoDB:Database"])
            .GetCollection<ChamadoDocument>(configuration["MongoDB:Collection"]);
    }

    public string Save(ChamadoDocument document)
    {
        _chamadosCollection.InsertOne(document);
        return document._id.ToString();
    }

    public ChamadoDocument? Get(string id)
    {
        if (ObjectId.TryParse(id, out var bsonId))
            return _chamadosCollection.Find(c => c._id == bsonId).FirstOrDefault();
        return null;
    }
}