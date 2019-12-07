namespace backend.Models
{
    public interface ILojaDatabaseSettings{
        string ProdutosCollectionName{get;set;}
        string ConnectionString{get;set;}
        string DBName{get;set;}
    }
}