using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Services
{
    public interface IProductImageService
    {
        Task add(ProductImageDto productImageDto);
        Task<IEnumerable<ProductImageDto>> GetAll();
        Task<ProductImageDto> GetById(int id);
        Task<IEnumerable<ProductImageDto>> GetByProductId(int id);
        void Delete(int img);
        void Update(ProductImageDto productImageDto);

    }
}
