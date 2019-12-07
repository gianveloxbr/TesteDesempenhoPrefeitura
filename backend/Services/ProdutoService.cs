using backend.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace backend.Services{
    public class ProdutoService
    {
        private readonly IMongoCollection<Produto> _produtos;

        public ProdutoService(ILojaDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DBName);
            _produtos = db.GetCollection<Produto>(settings.ProdutosCollectionName);
        }

        //Buscando todos os produtos
        public List<Produto> Get() =>
        _produtos.Find(produto => true).ToList();

        //Buscando o produto pelo id
        public Produto Get(string id) =>
        _produtos.Find<Produto>(produto => produto.id == id).FirstOrDefault();

        //Criando um produto
        public Produto Create(Produto p)
        {
            _produtos.InsertOne(p);
            return p;
        }
        
        //Atualizando um produto
        public void Update(string id, Produto prod) =>
            _produtos.ReplaceOne(produto => produto.id == id, prod);

        //Removendo um produto
        public void Delete(Produto prod) =>
        _produtos.DeleteOne(produto => produto.id == prod.id);

        //Removendo um produto pelo ID
        public void Delete(string id) =>
        _produtos.DeleteOne(produto => produto.id == id);
   }
}