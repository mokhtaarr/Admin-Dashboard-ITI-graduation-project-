using DTOs;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ITI.Ecommerce.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationDbContext _context ;

        //Edit Constructor
        public ShoppingCartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task add(ShoppingCartDto shoppingCartDto)
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                //ProductId = shoppingCartDto.ProductId,
                //UnitPrice = shoppingCartDto.UnitPrice,
                //Quantity = shoppingCartDto.Quantity,
                //Discount = shoppingCartDto.Discount,
                //Total = shoppingCartDto.Total,
                //NameAR = shoppingCartDto.NameAR,
                //NameEN = shoppingCartDto.NameEN,
                IsDeleted = shoppingCartDto.IsDeleted
            };

            //add Product in ProductList in Shopping Cart
            foreach (var productDto in shoppingCartDto.productList)
            {
                Product product = new Product()
                {
                    NameAR = productDto.NameAR,
                    NameEN = productDto.NameEN,
                    Description = productDto.Description,
                    CategoryID = productDto.CategoryID,
                    Quantity = productDto.Quantity,
                    UnitPrice = productDto.UnitPrice,
                    Discount = productDto.Discount,
                    TotalPrice = productDto.TotalPrice,
                    IsDeleted = productDto.IsDeleted,
                };
                shoppingCart.productList.Add(product);

            }

            await _context.ShoppingCarts.AddAsync(shoppingCart);
            _context.SaveChanges();

        }

        public void Delete(ShoppingCartDto shoppingCartDto)
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                //ProductId = shoppingCartDto.ProductId,
                //UnitPrice = shoppingCartDto.UnitPrice,
                //Quantity = shoppingCartDto.Quantity,
                //Discount = shoppingCartDto.Discount,
                //Total = shoppingCartDto.Total,
                //NameAR = shoppingCartDto.NameAR,
                //NameEN = shoppingCartDto.NameEN,
                IsDeleted = true
            };
            _context.Update(shoppingCart);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<ShoppingCartDto>> GetAll()
        {
            List<ShoppingCartDto> shoppingCartes = new List<ShoppingCartDto>();
            var carts = await _context.ShoppingCarts.Where(o => o.IsDeleted == false).ToListAsync();

            foreach (var cart in carts)
            {
                ShoppingCartDto shoppingCartDto = new ShoppingCartDto();

                shoppingCartDto.ID = cart.ID;
                //shoppingCartDto.ProductId = cart.ProductId;
                //shoppingCartDto.UnitPrice = cart.UnitPrice;
                //shoppingCartDto.Quantity = cart.Quantity;
                //shoppingCartDto.Discount = cart.Discount;
                //shoppingCartDto.Total = cart.Total;
                shoppingCartDto.IsDeleted = cart.IsDeleted;
                shoppingCartes.Add(shoppingCartDto);
            }

            return shoppingCartes;
        }

        public async Task<ShoppingCartDto> GetById(int id)
        {
            var item = await _context.ShoppingCarts.SingleOrDefaultAsync(i => i.ID == id);

            if (item == null)
            {
                throw new Exception("not found");
            }
            else
            {
                ShoppingCartDto shoppingCartDto = new ShoppingCartDto()
                {
                    ID = item.ID,
                    //ProductId = item.ProductId,
                    //UnitPrice = item.UnitPrice,
                    //Quantity = item.Quantity,
                    //Discount = item.Discount,
                    //Total = item.Total,
                    IsDeleted = item.IsDeleted,

                };
                return shoppingCartDto;


            }
        }

        public void Update(ShoppingCartDto shoppingCartDto)
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                //ProductId = shoppingCartDto.ProductId,
                //UnitPrice = shoppingCartDto.UnitPrice,
                //Quantity = shoppingCartDto.Quantity,
                //Discount = shoppingCartDto.Discount,
                //Total = shoppingCartDto.Total,
                //NameAR = shoppingCartDto.NameAR,
                //NameEN = shoppingCartDto.NameEN,
                IsDeleted = shoppingCartDto.IsDeleted
            };
            _context.Update(shoppingCart);
            _context.SaveChanges();
        }
    }
}
