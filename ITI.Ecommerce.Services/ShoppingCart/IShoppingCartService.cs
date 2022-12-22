using DTOs;

namespace ITI.Ecommerce.Services
{
    public interface IShoppingCartService
    {
        Task add(ShoppingCartDto shoppingCartDto);
        Task<IEnumerable<ShoppingCartDto>> GetAll();
        Task<ShoppingCartDto> GetById(int id);
        void Delete(ShoppingCartDto shoppingCartDto);
        void Update(ShoppingCartDto shoppingCartDto);
    }
}
