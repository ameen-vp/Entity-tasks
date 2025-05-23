using EntityInsoteredprocedure_allcrud.Models;

namespace EntityInsoteredprocedure_allcrud.Services
{
    public interface Iproductservice
    {
        Task<List<Productclass>> GetAllProductsAsync();
        Task CreateProductAsync(Productclass product);
        Task UpdateProductAsync(int id, Productclass product);
        Task DeleteProductAsync(int id);
    }
}
