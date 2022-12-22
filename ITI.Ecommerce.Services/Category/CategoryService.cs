using DTOs;
using ITI.Ecommerce.Models;
using Microsoft.EntityFrameworkCore;


namespace ITI.Ecommerce.Services
{
    public class CategoryService : ICategoryServie
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task add(CategoryDto categoryDto)
        {
            Category category = new Category()
            {
                NameAR = categoryDto.NameAR,
                NameEN = categoryDto.NameEN,
                IsDeleted = categoryDto.IsDeleted,
            };
            await _context.Categories.AddAsync(category);
            _context.SaveChanges();
        }

        public void Delete(CategoryDto categoryDto)
        {
            Category category = new Category()
            {
                ID = categoryDto.ID,
                NameAR = categoryDto.NameAR,
                NameEN = categoryDto.NameEN,
                IsDeleted = true,
            };
            _context.Update(category);
            _context.SaveChanges();
        }
        public void CDelete(int id)
        {
            var categoryDto = _context.Categories.AsNoTracking().FirstOrDefault(c => c.ID == id);
            //Category category = new Category()
            //{
            //    ID = categoryDto.ID,
            //    NameAR = categoryDto.NameAR,
            //    NameEN = categoryDto.NameEN,
            //    IsDeleted = true,
            //};
            categoryDto.IsDeleted = true;
            _context.Update(categoryDto);
            _context.SaveChanges();
        }
        //public async Task<CategoryDto> CDelete(int id)
        //{
        //    var categoryDto = await _context.Categories.SingleOrDefaultAsync(c => c.ID == id);
        //    Category category = new Category()
        //    {
        //        ID = categoryDto.ID,
        //        NameAR = categoryDto.NameAR,
        //        NameEN = categoryDto.NameEN,
        //        IsDeleted = true,
        //    };
        //    return categoryDto;
        //    _context.Update(category);
        //    _context.SaveChanges();
        //}

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            List<CategoryDto> categoryDtosList = new List<CategoryDto>();
            var categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            foreach (var category in categories)
            {
                CategoryDto categoryDto = new CategoryDto()
                {
                    ID = category.ID,
                    NameAR = category.NameAR,
                    NameEN = category.NameEN,
                    IsDeleted = category.IsDeleted,
                };
                categoryDtosList.Add(categoryDto);
            }
            return categoryDtosList;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(o => o.ID == id);
            if (category == null)
            {
                throw new Exception("this category not found");
            }
            else
            {
                CategoryDto categoryDto = new CategoryDto()
                {
                    ID = category.ID,
                    NameAR = category.NameAR,
                    NameEN = category.NameEN,
                    IsDeleted = category.IsDeleted,
                };
                return categoryDto;
            }
        }

        public void Update(CategoryDto categoryDto)
        {
            var categoryD = _context.Categories.FirstOrDefault(c => c.ID == categoryDto.ID);
            //_context.Categories.AsNoTracking().FirstOrDefault(c => c.ID == id);
            categoryD.NameAR = categoryDto.NameAR;
            categoryD.NameEN = categoryDto.NameEN;
            //categoryD.ID = id;
            //Category category = new Category()
            //{
            //    ID = categoryDto.ID,
            //    NameAR = categoryDto.NameAR,
            //    NameEN = categoryDto.NameEN,
            //    IsDeleted = false,
            //};

            //_context.Update(category);
            _context.SaveChanges();
        }

        //public async Task Update(CategoryDto categoryDto)
        //{
        //    //var categoryD = _context.Categories.AsNoTracking().FirstOrDefault(c => c.ID == id);
        //    //_context.Categories.AsNoTracking().FirstOrDefault(c => c.ID == id);
        //    //categoryD.NameAR = categoryDto.NameAR;
        //    //categoryD.NameEN = categoryDto.NameEN;
        //    //categoryD.ID =id;
        //    Category category = new Category()
        //    {
        //        ID = categoryDto.ID,
        //        NameAR = categoryDto.NameAR,
        //        NameEN = categoryDto.NameEN,
        //        IsDeleted = false,
        //    };

        //    _context.Categories.Update(category);
        //    _context.SaveChanges();
        //}

        //----------------------------------------------------------
        //public Category CUpdate(int id)
        //{
        //    var category = _context.Categories.FirstOrDefault(c => c.ID == id);
        //    return category;
        //}

        public async Task<IEnumerable<CategoryDto>> GetAllDeleted()
        {
            List<CategoryDto> categoryDtosList = new List<CategoryDto>();
            var categories = await _context.Categories.Where(c => c.IsDeleted == true).ToListAsync();
            foreach (var category in categories)
            {
                CategoryDto categoryDto = new CategoryDto()
                {
                    ID = category.ID,
                    NameAR = category.NameAR,
                    NameEN = category.NameEN,
                    IsDeleted = category.IsDeleted,
                };
                categoryDtosList.Add(categoryDto);
            }
            return categoryDtosList;
        }
        public void Restore(int id)
        {
            var categoryDto = _context.Categories.AsNoTracking().FirstOrDefault(c => c.ID == id);

            categoryDto.IsDeleted = false;
            _context.Update(categoryDto);
            _context.SaveChanges();
        }

    }
}
