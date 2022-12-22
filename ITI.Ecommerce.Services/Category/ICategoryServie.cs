using DTOs;

namespace ITI.Ecommerce.Services
{
    public interface ICategoryServie
    {
        Task add(CategoryDto categoryDto);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
        void Delete(CategoryDto categoryDto);
        void CDelete(int id);
        //Category CUpdate(int id);
        //Task<CategoryDto> CDelete(int id);

        void Update( CategoryDto categoryDto);
        //Task Update( CategoryDto categoryDto);
        //void Update(int id ,string NameA , string NameE);

        Task<IEnumerable<CategoryDto>> GetAllDeleted();
        void Restore(int id);
    }
}
