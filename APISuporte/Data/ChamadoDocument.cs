using MongoDB.Bson;

namespace APISuporte.Data;

public class ChamadoDocument
{
    public ObjectId _id { get; set; }    
    public string? DataAbertura { get; set; }
    public string? Email { get; set; }
    public string? DescritivoRequisicao { get; set; }
    public bool Solucionado { get; set; }
}