using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebService.Models;

namespace TestWebService.Services.Interface
{
    public interface ICollegeService
    {
        IQueryable<College> GetColleges();
        IQueryable<College> GetInactiveColleges();
        College GetCollege(int ID);
        College GetCollege(string collegeName);
        int AddCollege(College college);
        int UpdateCollege(College college);
        int DeleteCollege(int ID);
        int DeactivateCollege(int ID);
        int ActivateCollege(int ID);
        bool IsCollegeExist(College college);
    }
}
