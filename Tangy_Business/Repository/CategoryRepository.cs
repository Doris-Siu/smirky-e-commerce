using System;
using AutoMapper;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public CategoryDTO Create(CategoryDTO objDTO)
        // manually convert between Category & CategoryDTO
        {
            //Category category = new Category()
            //{
            //    Name = objDTO.Name,
            //    Id = objDTO.Id,
            //    CreatedDate = DateTime.Now
            //};

            // use mapper
            var obj = _mapper.Map<CategoryDTO, Category>(objDTO);

            _db.Categories.Add(obj);
            _db.SaveChanges();

            //return new CategoryDTO()
            //{
            //    Id = category.Id,
            //    Name = category.Name
            //};

            return _mapper.Map<Category, CategoryDTO>(obj);
        }
    }

    public int Delete(int id)
    {
        throw new NotImplementedException();
    }

    public CategoryDTO Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CategoryDTO> GetAll()
    {
        throw new NotImplementedException();
    }

    public CategoryDTO Update(CategoryDTO objDTO)
    {
        throw new NotImplementedException();
    }
}
}

