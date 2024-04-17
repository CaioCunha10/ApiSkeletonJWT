using WebApiJWT.Entities;

namespace WebApiJWT.Repository
{
    public interface InterfaceProduct
    {
        Task Add(ProductModel Objeto);

        Task Update(ProductModel Objeto);

        Task Delete(ProductModel Objeto);

        Task<ProductModel> GetEntityById(int id);

        Task<List<ProductModel>> List();
    }
}
