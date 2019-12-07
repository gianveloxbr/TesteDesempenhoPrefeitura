using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id{get;set;}

        [BsonElement("Nome")]
        public string Nome{get;set;}

        public string Descricao{get;set;}
        public decimal Preco{get;set;}

        public string Categoria{get;set;}
    }
}