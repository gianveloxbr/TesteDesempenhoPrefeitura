using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace backend.Models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id{get;set;}

        [BsonElement("Nome")]
        [JsonProperty("Nome")]
        public string Nome{get;set;}

        [BsonElement("Descricao")]
        [JsonProperty("Descricao")]
        public string Descricao{get;set;}
        
        [BsonElement("Preco")]
        [JsonProperty("Preco")]
        public decimal Preco{get;set;}

        [BsonElement("Categoria")]
        [JsonProperty("Categoria")]
        public string Categoria{get;set;}
    }
}