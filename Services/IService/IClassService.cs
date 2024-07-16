using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface IClassService
    {
        List<Class> GetClasses();

        void AddClass(Class newClass);

        void UpdateClass(Class newClass);

        Class GetClassById(int id);

    }
}
