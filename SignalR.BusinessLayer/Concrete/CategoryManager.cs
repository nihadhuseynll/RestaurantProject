using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TAdd(Category entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
