using BusinessObject.Models;
using DataAccess;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class ClassService : IClassService
    {
        private readonly ClassDAO _dao;
        public ClassService(ClassDAO dao)
        {
            _dao = dao;
        }

        public void AddClass(Class newClass)
        {
            try
            {
                _dao.AddClass(newClass);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Class GetClassById(int id)
        {
            try
            {
                return _dao.GetClassById(id);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public List<Class> GetClasses()
        {
			try
			{
                return _dao.GetClassList();
			}
			catch (Exception e)
			{
				throw;
			}
        }

        public void UpdateClass(Class newClass)
        {
            try
            {
                _dao.UpdateClass(newClass);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
