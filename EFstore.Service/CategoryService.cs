using EFstore.Data.Infrastructure;
using EFstore.Data.Repositories;
using EFstore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFstore.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetCategories(string name = null);
        CategoryModel GetCategory(int id);
        CategoryModel GetCategory(string name);
        void CreateCategory(CategoryModel category);
        void SaveCategory();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categorysRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categorysRepository, IUnitOfWork unitOfWork)
        {
            this.categorysRepository = categorysRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<CategoryModel> GetCategories(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return categorysRepository.GetAll();
            else
                return categorysRepository.GetAll().Where(c => c.CategoryName == name);
        }

        public CategoryModel GetCategory(int id)
        {
            var category = categorysRepository.GetById(id);
            return category;
        }

        public CategoryModel GetCategory(string name)
        {
            var category = categorysRepository.GetCategoryByName(name);
            return category;
        }

        public void CreateCategory(CategoryModel category)
        {
            categorysRepository.Add(category);
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
