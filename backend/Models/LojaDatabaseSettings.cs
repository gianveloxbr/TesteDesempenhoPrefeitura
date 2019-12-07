namespace backend.Models
{
    public class LojaDatabaseSettings : ILojaDatabaseSettings
    {
        public string ProdutosCollectionName{get;set;}
        public string ConnectionString{get;set;}
        public string DBName{get;set;}
    }
}