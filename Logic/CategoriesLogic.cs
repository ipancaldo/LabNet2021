using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Logic
{
    public class CategoriesLogic : BaseLogic
    {
        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public Categories GetData(int id)
        {
            Categories categories = new Categories();
            var seleccionarCategoria = context.Categories.FirstOrDefault(o => o.CategoryID == id);
            return seleccionarCategoria;
        }
    }
}