using EntityInsoteredprocedure_allcrud.AppDB;
using EntityInsoteredprocedure_allcrud.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EntityInsoteredprocedure_allcrud.Services
{
    public class Poductservice : Iproductservice
    {
        private readonly AppdbContext _context;
        public Poductservice(AppdbContext context)
        {
            _context = context;
        }
        public async Task<List<Productclass>> GetAllProductsAsync()
        {
            return await _context.productclass
                .FromSqlRaw("EXEC Storeproc @Operation",
                    new SqlParameter("@Operation", "READ"))
                .ToListAsync();
        }

        public async Task CreateProductAsync(Productclass product)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC Storeproc @Operation, @Id, @Name, @Price",
                new SqlParameter("@Operation", "CREATE"),
                new SqlParameter("@Id", DBNull.Value),
                new SqlParameter("@Name", product.name),
                new SqlParameter("@Price", product.Price));
        }

        public async Task UpdateProductAsync(int id, Productclass product)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC Storeproc @Operation, @Id, @Name, @Price",
                new SqlParameter("@Operation", "UPDATE"),
                new SqlParameter("@Id", id),
                new SqlParameter("@Name", product.name),
                new SqlParameter("@Price", product.Price));
        }

        public async Task DeleteProductAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC Storeproc @Operation, @Id",
                new SqlParameter("@Operation", "DELETE"),
                new SqlParameter("@Id", id));

        }
    }
}
