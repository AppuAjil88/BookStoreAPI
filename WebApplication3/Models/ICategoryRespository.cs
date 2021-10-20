using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    interface ICategoryRespository
    {
        Category AddCategory(Category category);
        List<Category> GetAllCategories();

        Category GetCategoryById(int id);

        bool DisableCategory(int catID);
        bool EnableCategory(int catID);

        List<Category> GetCategoriesBySearch(string searchString);
    }
}
