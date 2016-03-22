using EFstore.Data.Infrastructure;
using EFstore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFstore.Data.Repositories
{
    public interface ICategoryRepository : IRepository<CategoryModel>
    {
        CategoryModel GetCategoryByName(string name);
    }

    public class CategoryRepository : RepositoryBase<CategoryModel>, ICategoryRepository
    {

    }
}
